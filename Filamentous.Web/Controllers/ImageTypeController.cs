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
public class ImageTypeController : JumpstartAuditController<ImageType>
{ 
	public ImageTypeController(FilamentousDbContext context) : base(context) { }

    protected override IQueryable<ImageType> ApplyAccessRestrictions(IQueryable<ImageType> query)
    {
        return query;
    }

    protected override IQueryable<ImageType> AddIncludes(IQueryable<ImageType> query)
    {
        return base.AddIncludes(query, true);
    }

}
