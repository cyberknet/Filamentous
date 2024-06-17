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
public abstract class AuditDataService<TEntity> : DataService<TEntity>, IAuditDataService<TEntity> where TEntity : AuditEntity
{
    public AuditDataService(ILogger<DataService<TEntity>> logger, ProtectedSessionStorage storage) : base(logger, storage)
    {
    }

    #region Asynchronous Methods
    public async Task<PagedResponse<TEntity>> ListAsync(bool includeDeleted, string sortColumn = "", bool sortAscending = true, int limit = 20, int offset = 0)
    {
        try
        {
            var request = new RestRequest(_entityName, Method.Get);
            // Add additional query parameters for includeDeleted if needed
            if (includeDeleted)
            {
                request.AddParameter("includeDeleted", true);
            }
            if (limit > 0)
                request.AddParameter("limit", limit);
            if (offset > 0)
                request.AddParameter("offset", offset);

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

    public override async Task<PagedResponse<TEntity>> ListAsync(string orderByColumn = "", bool orderAscending = true, int limit = 20, int offset = 0)
    {
        return await ListAsync(includeDeleted: false, limit: limit, offset: offset);
    }
    #endregion


}
