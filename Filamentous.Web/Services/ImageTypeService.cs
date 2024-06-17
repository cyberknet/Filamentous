using Filamentous.Data.Entities;
using JumpStart.Services;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Filamentous.Web.Services;

public class ImageTypeService : DataService<ImageType>, IImageTypeService
{
    public ImageTypeService(ILogger<DataService<ImageType>> logger, ProtectedSessionStorage storage) : base(logger, storage)
    {
    }
}
