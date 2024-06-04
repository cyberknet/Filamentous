using JumpStart.Data.Entities.Base;
using JumpStart.Data.Rest;

namespace JumpStart.Services;

public interface IDataService<TEntity> where TEntity : Entity
{
    Task<TEntity?> CreateAsync(TEntity entity);
    Task<TEntity?> GetAsync(Guid id);
    Task<PagedResponse<TEntity>> ListAsync();
    Task<bool> UpdateAsync(TEntity entity);
    Task<bool> DeleteAsync(Guid id);
}
