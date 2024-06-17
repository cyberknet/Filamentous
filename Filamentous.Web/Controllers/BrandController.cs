using Filamentous.Data;
using Filamentous.Data.Entities;
using Filamentous.Web.Controllers.Base;
using JumpStart.Controllers;
using JumpStart.Data.Entities;
using JumpStart.Data.Entities.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Filamentous.Web.Controllers;
[Route("api/[controller]")]
//[Authorize]
public class BrandController : JumpstartAuditController<Brand>
{ 
	public BrandController(FilamentousDbContext context) : base(context) { }

    protected override IQueryable<Brand> ApplyAccessRestrictions(IQueryable<Brand> query)
    {
        return query;
    }

    protected override IQueryable<Brand> AddIncludes(IQueryable<Brand> query)
    {
        query = query.Include(b => b.ProductLines)
            .ThenInclude(pl => pl.Polymer);
            
        return base.AddIncludes(query, true);
    }

}
