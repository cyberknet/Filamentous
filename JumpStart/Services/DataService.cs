using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using JumpStart.Data.Entities.Base;
using System.Text.Json;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using JumpStart.Data.Rest;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace JumpStart.Services;
public abstract class DataService<TEntity> : IDataService<TEntity> where TEntity : Entity
{
    protected readonly string _entityName;
    protected readonly ILogger<DataService<TEntity>> _logger;

    protected readonly ProtectedSessionStorage _storage;

    protected RestClient Client { get; }

    public DataService(ILogger<DataService<TEntity>> logger, ProtectedSessionStorage storage)
    {
        _entityName = typeof(TEntity).Name.ToLower();
        Client = new RestClient($"https://localhost:7076/api/");
        _logger = logger;
        _storage = storage;
    }

    protected async Task<string?> GetJwtToken()
    {
        var request = await _storage.GetAsync<string>("JwtToken");
        if (request.Success)
        {
            return request.Value;
        }
        else
        {
            return null;
        }
    }

    #region Asynchronous Methods
    public virtual async Task<TEntity?> CreateAsync(TEntity entity)
    {
        try
        {
            var request = new RestRequest(_entityName, Method.Post);

            request.AddJsonBody<TEntity>(entity);
            var response = await Client.ExecuteAsync<TEntity?>(request);

            if (response != null && response.StatusCode == HttpStatusCode.OK)
                return response.Data;
            else
                _logger.LogError($"Error occurred while creating entity {_entityName}");

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while creating entity {_entityName}");
            return null;
        }
    }

    public virtual async Task<PagedResponse<TEntity>> ListAsync()
    {
        try
        {
            var request = new RestRequest(_entityName, Method.Get);
            string? token = await GetJwtToken();
            if (token != null)
                request.AddHeader("Bearer", token);
            var response = await Client.ExecuteAsync<PagedResponse<TEntity>>(request);

            if (response != null && response.StatusCode == HttpStatusCode.OK && response.Data != null)
                return response.Data;
            else
                _logger.LogError($"Error occurred while listing entities {_entityName}");

            return new PagedResponse<TEntity>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while listing entities {_entityName}");
            return new PagedResponse<TEntity>();
        }
    }

    public virtual async Task<TEntity?> GetAsync(Guid id)
    {
        try
        {
            var request = new RestRequest($"{_entityName}/{id}", Method.Get);
            var response = await Client.ExecuteAsync<TEntity>(request);

            if (response != null && response.StatusCode == HttpStatusCode.OK)
                return response.Data;
            else
                _logger.LogError($"Error occurred while getting entity {_entityName} with ID {id}");

            return null;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while getting entity {_entityName} with ID {id}");
            return null;
        }
    }

    public virtual async Task<bool> UpdateAsync(TEntity entity)
    {
        try
        {
            var request = new RestRequest($"{_entityName}/{entity.Id}", Method.Put);
            request.AddJsonBody(entity);
            var response = await Client.ExecuteAsync<TEntity>(request);

            if (response != null && response.StatusCode == HttpStatusCode.OK && response.Data != null)
                return true;
            else
                _logger.LogError($"Error occurred while updating entity {_entityName} with ID {entity.Id}");

            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while updating entity {_entityName} with ID {entity.Id}");
            return false;
        }
    }

    public virtual async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            var request = new RestRequest($"{_entityName}/{id}", Method.Delete);
            var response = await Client.ExecuteAsync<TEntity?>(request);

            if (response != null && response.StatusCode == HttpStatusCode.OK && response.Data != null)
                return true;
            else
                _logger.LogError($"Error occurred while deleting entity {_entityName} with ID {id}");

            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error occurred while deleting entity {_entityName} with ID {id}");
            return false;
        }
    }
    #endregion
}
