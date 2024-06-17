using JumpStart.Data.Entities.Base;
using JumpStart.Data.Rest;

namespace JumpStart.Services;

public interface IDataService<TEntity> where TEntity : Entity
{
    Task<TEntity?> CreateAsync(TEntity entity);
    Task<TEntity?> GetAsync(Guid id);
    Task<PagedResponse<TEntity>> ListAsync(string sortColumn = "", bool sortAscending = true, int limit = 20, int offset = 0);
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(Guid id);
}
