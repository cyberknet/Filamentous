using Filamentous.Data;
using Filamentous.Data.Entities;
using Filamentous.Web.Controllers.Base;
using JumpStart.Controllers;
using JumpStart.Data.Entities;
using JumpStart.Data.Entities.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Filamentous.Web.Controllers;
[Route("api/[controller]")]
//[Authorize]
public class PolymerController : JumpstartAuditController<Polymer>
{ 
	public PolymerController(FilamentousDbContext context) : base(context) { }

    protected override IQueryable<Polymer> ApplyAccessRestrictions(IQueryable<Polymer> query)
    {
        return query;
    }

    protected override IQueryable<Polymer> AddIncludes(IQueryable<Polymer> query)
    {
        return base.AddIncludes(query, true);
    }

}
