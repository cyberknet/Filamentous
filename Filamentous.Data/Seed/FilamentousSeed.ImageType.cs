using Filamentous.Data.Entities;
using JumpStart.Data.Primitives;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filamentous.Data.Seed;
internal partial class FilamentousSeed
{
    private SequentialGuid _imageTypeGuid = new("D9A3F45C-81AE-4B86-B477-030000000000");
    private Dictionary<Guid, ImageType> _imageTypes = new();

    private Guid _imageTypeIdSwatch;
    private Guid _imageTypeIdSwatchAlternate;
    private Guid _imageTypeIdSpool;
    private Guid _imageTypeIdSamplePrint;

    private void InitializeImageTypes()
    {
        // DO NOT REORDER or insert new values in the middle of the list!
        _imageTypeIdSwatch = _imageTypeGuid.Next();
        _imageTypeIdSwatchAlternate = _imageTypeGuid.Next();
        _imageTypeIdSpool = _imageTypeGuid.Next();
        _imageTypeIdSamplePrint = _imageTypeGuid.Next();
    }

    private void ImageTypes(ModelBuilder modelBuilder)
    {
        MakeImageType(_imageTypeIdSwatch, "Swatch", 1);
        MakeImageType(_imageTypeIdSwatchAlternate, "Swatch (Alternate)", 2);
        MakeImageType(_imageTypeIdSpool, "Spool", 3);
        MakeImageType(_imageTypeIdSamplePrint, "Sample Print", 4);

        Console.WriteLine($" * Entity ImageType has {_imageTypes.Keys.Count} rows in seed data.");
        modelBuilder.Entity<ImageType>().HasData(_imageTypes.Values);
    }

    private void MakeImageType(Guid id, string name, int sortOrder)
    {
        var imageType = new ImageType
        {
            Id = id,
            Name = name,
            SortOrder = sortOrder,
            ConcurrencyStamp = id,
            CreatedById = _userAdminId.ToString()
        };
        try
        {
            if (!_imageTypes.ContainsKey(imageType.Id))
                _imageTypes.Add(id, imageType);
            //else
            //    Console.WriteLine($"Using existing ImageType {name} with id {id}");
        }
        catch (Exception ex)
        {
            //Console.WriteLine($"Unable to create ImageType {name} with id {id}: ${ex.Message}");
        }
    }
}
