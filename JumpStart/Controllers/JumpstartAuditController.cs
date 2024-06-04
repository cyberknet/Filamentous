using Filamentous.Web.Controllers.Base;
using JumpStart.Data.Entities;
using JumpStart.Data.Entities.Base;
using JumpStart.Data.Rest;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq.Expressions;

namespace JumpStart.Controllers;

public class JumpstartAuditController<TEntity> : JumpstartController<TEntity> where TEntity : Entity, IAuditableEntity
{
    public JumpstartAuditController(DbContext context) : base(context) { }

    [NonAction]
    public override ActionResult<PagedResponse<TEntity>> List(
        int limit = 0, 
        int offset = 0,
        string? sortColumn = null,
        ListSortDirection sortDirection = ListSortDirection.Ascending)
    { throw new NotImplementedException(); }

    [HttpGet]
    public ActionResult<PagedResponse<TEntity>> List(
        [FromQuery]bool includeDeleted = false, 
        [FromQuery] int limit = 0, 
        [FromQuery] int offset = 0,
        [FromQuery] string? sortColumn = null,
        [FromQuery] ListSortDirection sortDirection = ListSortDirection.Ascending)
    {
        Expression<Func<TEntity, bool>>? filter = null;
        
        if (includeDeleted)
            filter = (e) => !e.DeletedOn.HasValue;
        
        return base.List(limit, offset, sortColumn, sortDirection, filter);
    }

    [HttpPost]
    public override ActionResult<TEntity> Create([FromBody] TEntity entity)
    {
        // TODO: set CreatedById
        IdentityUser createdBy = _context.Set<IdentityUser>().Find(entity.CreatedById);
        entity.CreatedBy = createdBy;
        return base.Create(entity);
    }
    [HttpPut("{id}")]
    public override IActionResult Update(Guid id, [FromBody] TEntity updated)
    {
        if (updated is IAuditableEntity updatedAudit)
        { 
            updatedAudit.UpdatedOn = DateTime.UtcNow;
            return base.Update(id, updated);
        }
        else
            return NotFound();
    }
    [HttpDelete("{id}")]
    public override IActionResult Delete(Guid id)
    {
        var entity = _context.Set<TEntity>().Find(id);
        if (entity == null)
            return NotFound();
        entity.DeletedOn = DateTime.UtcNow;
        // TODO: set DeletedById

        _context.SaveChanges();
        return NoContent();
    }

    protected override IQueryable<TEntity> AddIncludes(IQueryable<TEntity> query)
    {
        return AddIncludes(query, true);
    }
    protected virtual IQueryable<TEntity> AddIncludes(IQueryable<TEntity> query, bool includeAuditEntities)
    {
        if (includeAuditEntities)
            return query.Include(e => e.CreatedBy)
                .Include(e => e.UpdatedBy)
                .Include(e => e.DeletedBy);
        else
            return query;
    }
}
