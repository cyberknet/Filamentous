using Filamentous.Data.Entities;
using JumpStart.Services;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Filamentous.Web.Services;

public class BrandService : DataService<Brand>, IBrandService
{
    public BrandService(ILogger<DataService<Brand>> logger, ProtectedSessionStorage storage) : base(logger, storage)
    {
    }
}
