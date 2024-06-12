using Filamentous.Data.Entities;
using JumpStart.Services;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Filamentous.Web.Services;

public class ProductLineService : DataService<ProductLine>, IProductLineService
{
    public ProductLineService(ILogger<DataService<ProductLine>> logger, ProtectedSessionStorage storage) : base(logger, storage)
    {
    }
}
