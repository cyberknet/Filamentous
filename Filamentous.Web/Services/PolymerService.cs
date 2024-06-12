using Filamentous.Data.Entities;
using JumpStart.Services;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Filamentous.Web.Services;

public class PolymerService : DataService<Polymer>, IPolymerService
{
    public PolymerService(ILogger<DataService<Polymer>> logger, ProtectedSessionStorage storage) : base(logger, storage)
    {
    }
}
