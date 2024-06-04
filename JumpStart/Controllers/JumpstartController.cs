using JumpStart.Data.Entities;
using JumpStart.Data.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using JumpStart.Data.Rest;
using System.ComponentModel;

namespace Filamentous.Web.Controllers.Base;

public abstract class JumpstartController<TEntity> : Controller where TEntity : Entity
{
    protected DbContext _context;
    public JumpstartController(DbContext context)
    {
        _context = context;
    }

    // allow the concrete implementation to filter down the results based on the user's access rights
    protected virtual IQueryable<TEntity> ApplyAccessRestrictions(IQueryable<TEntity> query) => query;

    // allow the concrete implementation to include properties of related classes
    protected virtual IQueryable<TEntity> AddIncludes(IQueryable<TEntity> query) => query;

    // GET: api/Entity/
    [HttpGet]
    public virtual ActionResult<PagedResponse<TEntity>> List(
        [FromQuery] int limit = 0, 
        [FromQuery] int offset = 0, 
        [FromQuery] string? sortColumn = null,
        [FromQuery] ListSortDirection sortDirection = ListSortDirection.Ascending)
    {
        // return the paged list to the client
        return List(limit, offset, sortColumn, sortDirection, null);
    }

    protected ActionResult<PagedResponse<TEntity>> List(
        int limit = 0, 
        int offset = 0, 
        string? sortColumn = null , 
        ListSortDirection sortDirection = ListSortDirection.Ascending,
        System.Linq.Expressions.Expression<Func<TEntity, bool>>? filter = null)
    {
        // construct a query to get the records from the data store
        IQueryable<TEntity> results = _context.Set<TEntity>();

        if (filter != null)
            results = results.Where(filter);

        // if a sort order was provided, apply it
        if (!string.IsNullOrWhiteSpace(sortColumn))
        { 
            if (sortDirection == ListSortDirection.Ascending)
                results = results.OrderBy(sortColumn);
            else
                results = results.OrderByDescending(sortColumn);
        }

        // filter results down by user access level - to be provided by the concrete implementation
        results = ApplyAccessRestrictions(results);

        // allow concrete implementation to add in any required includes
        results = AddIncludes(results);

        int count = results.Count();

        if (offset > 0)
            results = results.Skip(offset);
        if (limit > 0)
            results = results.Take(limit);

        // convert the IQueryable into a paged list
        var paged = new PagedResponse<TEntity>() { Data = results, Limit = limit, Offset = offset };

        // return the paged list to the client
        return Ok(paged);
    }

    // GET api/Entity/5
    [HttpGet("{id}")]
    public virtual ActionResult<TEntity> Get(Guid id)
    {
        var result = _context.Set<TEntity>().FirstOrDefault(t => t.Id == id);

        if (result == null)
            return NotFound();
        return Ok(result);
    }

    // POST api/Entity
    [HttpPost]
    public virtual ActionResult<TEntity> Create([FromBody] TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        entity.ConcurrencyStamp = Guid.NewGuid();
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
    }

    // PUT api/Entity/5
    [HttpPut("{id}")]
    public virtual IActionResult Update(Guid id, [FromBody] TEntity updated)
    {
        var entity = _context.Set<TEntity>().Find(id);
        if (entity == null)
            return NotFound();
        entity.ConcurrencyStamp = Guid.NewGuid();

        var t = updated.GetType();
        var properties = t.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

        // TODO: enumerate over all properties of Entity, and copy values from updated to entity
        foreach (var property in properties)
        {
            switch (property.Name)
            {
                // do not copy over any changes for ConcurrencyStamp, CreatedOn, CreatedBy, DeletedOn, or DeletedBy.
                case nameof(IAuditableEntity.CreatedOn):
                case nameof(IAuditableEntity.CreatedBy):
                case nameof(IAuditableEntity.CreatedById):
                case nameof(Entity.ConcurrencyStamp):
                case nameof(IAuditableEntity.DeletedOn):
                case nameof(IAuditableEntity.DeletedBy):
                case nameof(IAuditableEntity.DeletedById):
                    break;
                default:
                    object? oldValue = property.GetValue(entity);
                    object? newValue = property.GetValue(updated);
                    bool valueChanged = false;
                    if (oldValue != null)
                    {
                        valueChanged = !oldValue.Equals(newValue);
                    }
                    else if (newValue != null)
                    {
                        valueChanged = true;
                    }

                    if (valueChanged
                        && property.SetMethod != null
                        && !property.SetMethod.IsPrivate)
                    {
                        property.SetValue(entity, newValue);
                    }
                    break;
            }
        }

        _context.SaveChanges();
        return NoContent();
    }

    // DELETE api/Entity/5
    [HttpDelete("{id}")]
    public virtual IActionResult Delete(Guid id)
    {
        var delete = _context.Set<TEntity>().Find(id);
        if (delete == null)
            return NotFound();
        _context.Set<TEntity>().Remove(delete);
        _context.SaveChanges();
        return NoContent();
    }
}
