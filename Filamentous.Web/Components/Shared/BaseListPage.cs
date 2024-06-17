namespace Filamentous.Web.Components.Shared;

using Filamentous.Data.Entities;
using Filamentous.Web.Components.Brands;
using Filamentous.Web.Resources;
using Filamentous.Web.Services;
using JumpStart.Data.Entities.Base;
using JumpStart.Dialogs;
using JumpStart.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.FluentUI.AspNetCore.Components;

public class BaseListPage<TService, TEntity, TUpsertPanel> : ComponentBase 
    where TEntity : Entity, new()
    where TService : IDataService<TEntity>
    where TUpsertPanel : IDialogContentComponent<EntityDialogContent<TEntity>>
{
    #region Dependency Injection
    [Inject] public required TService DataService { get; set; }

    [Inject] public required IDialogService DialogService { get; set; }

    [Inject] public required IToastService ToastService { get; set; }
    [Inject] public required IStringLocalizer<SharedResources> Localizer { get; set; }
    [Inject] public required NavigationManager NavigationManager { get; set; }
	[Inject] public required IServiceProvider ServiceProvider { get; set; }
	#endregion

	protected IQueryable<TEntity>? _entities = null;
    protected IDialogReference? _dialog;

    protected enum Operation
    {
        Add,
        Update,
        Delete
    };

    protected async override Task OnInitializedAsync()
    {
        await LoadEntities();
        await base.OnInitializedAsync();
    }

    protected virtual async Task LoadEntities()
    {
        if (DataService != null)
        {
            var result = await DataService.ListAsync();
            _entities = result.Data.AsQueryable();
            StateHasChanged(); 
        }
    }

    protected async void OnEditEntityClick(TEntity context, Func<TEntity, string> DisplayName)
    {
        var entityName = typeof(TEntity).Name;
        var result = await ShowPanel(context, false);
        if (result.Cancelled)
        {
            return;
        }
        var entity = result.Data as TEntity;
        string displayName = DisplayName(context);
        ShowProgressToast(nameof(OnEditEntityClick), entityName, displayName, Operation.Update);
        bool updateResult = await DataService.UpdateAsync(entity!);
        CloseProgressToast(nameof(OnEditEntityClick));
        ShowSuccessToast(entityName, displayName, Operation.Update);

        await LoadEntities();
    }

    protected async Task OnAddEntityClick(Func<TEntity, string> DisplayName)
    {
        var entityName = typeof(TEntity).Name;
        var entity = new TEntity();
        var result = await ShowPanel(entity, true);
        if (result.Cancelled)
        {
            return;
        }
        entity = result.Data as TEntity;
        if (entity == null)
        {
            ShowFailureToast(nameof(OnAddEntityClick), entityName, Operation.Add, "Error creating new " + entityName);
        }
        else
        { 
            string displayName = DisplayName(entity);
            ShowProgressToast(nameof(OnAddEntityClick), entityName, displayName);
            await DataService.CreateAsync(entity);
            CloseProgressToast(nameof(OnAddEntityClick));
            ShowSuccessToast(entityName, displayName);
            await LoadEntities();
        }
    }

    protected async Task<DialogResult> ShowPanel(TEntity entity, bool insert = true)
    {
        var primaryActionText = insert ? "Add" : "Save";
        var title = insert ? "Create Brand" : "Update Brand";
        var dialogContent = new EntityDialogContent<TEntity>
        {
            Entity = entity,
            ServiceProvider = ServiceProvider
        };
        var dialogParameter = new DialogParameters<EntityDialogContent<TEntity>>()
        {
            Content = dialogContent,
            Alignment = HorizontalAlignment.Right,
            Title = title,
            PrimaryAction = primaryActionText,
            Width = "500px",
            PreventDismissOnOverlayClick = false,
        };
        _dialog = await DialogService.ShowPanelAsync<TUpsertPanel>(dialogContent, dialogParameter);
        return await _dialog.Result;
    }



    protected async Task<DialogResult> ShowConfirmationDialogAsync(string title, string message)
    {
        var dialog = await DialogService.ShowMessageBoxAsync(new DialogParameters<MessageBoxContent>()
        {
            Content = new()
            {
                Title = title,
                MarkupMessage = new MarkupString(message),
                Icon = new Icons.Regular.Size24.QuestionCircle(),
                IconColor = Color.Error,
            },
            PrimaryAction = "Ok",
            SecondaryAction = "Cancel"
        });
        return await dialog.Result;
    }

    protected void ShowSuccessToast(string entityType, string entityName, Operation operation = Operation.Add)
    {
        var sentenceCasedEntityTypeName = ToSentenceCase(entityType);
        var title = PrepareSuccessToastTitle(operation, sentenceCasedEntityTypeName);
        string message = PrepareSuccessToastMessage(entityName, operation, sentenceCasedEntityTypeName);
        ToastService.ShowCommunicationToast(new ToastParameters<CommunicationToastContent>
        {
            Intent = ToastIntent.Success,
            Title = title,
            Timeout = 5000,
            Content = new CommunicationToastContent
            {
                Details = message
            }
        });
    }

    protected void ShowFailureToast(string entityType, string entityName, Operation operation = Operation.Add, string failureMessage = "")
    {
        var sentenceCasedEntityTypeName = ToSentenceCase(entityType);
        var title = PrepareFailureToastTitle(operation, sentenceCasedEntityTypeName);
        var message = failureMessage == string.Empty ? PrepareFailureToastMessage(entityName, operation, sentenceCasedEntityTypeName)
                                                     : failureMessage;
        ToastService.ShowCommunicationToast(new ToastParameters<CommunicationToastContent>
        {
            Intent = ToastIntent.Error,
            Title = title,
            Timeout = 5000,
            Content = new CommunicationToastContent
            {
                Details = message
            }
        });
    }

    protected void ShowProgressToast(string id, string entityType, string entityName, Operation operation = Operation.Add)
    {
        var sentenceCasedEntityTypeName = ToSentenceCase(entityType);
        ToastService.ShowProgressToast(new ToastParameters<ProgressToastContent>
        {
            Id = id,
            Intent = ToastIntent.Progress,
            Title = PrepareProgressToastTitle(operation, sentenceCasedEntityTypeName),
            Content = new ProgressToastContent
            {
                Details = PrepareProgressToastMessage(entityName, operation),
            }
        });
    }

    protected void CloseProgressToast(string id)
    {
        ToastService.CloseToast(id);
    }

    private static string PrepareProgressToastTitle(Operation operation, string sentenceCasedEntityTypeName)
    {
        return $"{operation switch
        {
            Operation.Add => "Creating",
            Operation.Update => "Updating",
            Operation.Delete => "Deleting",
            _ => "Creating/Updating/Deleting"
        }} {sentenceCasedEntityTypeName}";
    }

    private string PrepareProgressToastMessage(string entityName, Operation operation)
    {
        return $"{operation switch
        {
            Operation.Add => "Creating",
            Operation.Update => "Updating",
            Operation.Delete => "Deleting",
            _ => "Creating/Updating/Deleting"
        }} {entityName}. Please wait...";
    }



    private string PrepareSuccessToastTitle(Operation operation, string entityType)
    {
        return $"{entityType} {operation switch
        {
            Operation.Add => "created",
            Operation.Update => "updated",
            Operation.Delete => "deleted",
            _ => "created/updated/deleted"
        }} successfully";
    }

    private string PrepareSuccessToastMessage(string entityName, Operation operation, string entityType)
    {
        return $"{entityType}: {entityName} was {operation switch
        {
            Operation.Add => "created",
            Operation.Update => "updated",
            Operation.Delete => "deleted",
            _ => throw new InvalidOperationException("Invalid operation")
        }} successfully";
    }

    private static string PrepareFailureToastTitle(Operation operation, string entityName)
    {
        return $"{operation switch
        {
            Operation.Add => "Adding",
            Operation.Update => "Updating",
            Operation.Delete => "Deleting",
            _ => "Add/Update/Delete action on "
        }} {entityName} failed";
    }

    private string PrepareFailureToastMessage(string entityName, Operation operation, string entityType)
    {
        return $"Error {entityType}: {entityName} was {operation switch
        {
            Operation.Add => "created",
            Operation.Update => "updated",
            Operation.Delete => "deleted",
            _ => "created/updated/deleted"
        }} successfully"; 
    }

    private string ToSentenceCase(string str)
    {
        if (string.IsNullOrEmpty(str))
            return str;

        string lowerCase = str.ToLower();
        return char.ToUpper(lowerCase[0]) + lowerCase.Substring(1);
    }
}
