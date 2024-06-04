using JumpStart.Data.Entities.Base;
using JumpStart.Data.Rest;

namespace JumpStart.Services;

public interface IAuditDataService<TEntity> : IDataService<TEntity> where TEntity : AuditEntity
{
    Task<PagedResponse<TEntity>> ListAsync(bool includeDeleted);
}
