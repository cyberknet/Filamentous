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
    private SequentialGuid _brandGuid = new("D9A3F45C-81AE-4B86-B477-030000000000");
    private Dictionary<Guid, Brand> _brands = new();

    private Guid _brandIdPrusament;
    private Guid _brandIdPolymaker;

    private void InitializeBrands()
    {
        // DO NOT REORDER or insert new values in the middle of the list!
        _brandIdPrusament = _brandGuid.Next();
        _brandIdPolymaker = _brandGuid.Next();
    }

    private void Brands(ModelBuilder modelBuilder)
    {
        MakeBrand(_brandIdPolymaker, "Polymaker", new Uri("https://us.polymaker.com/"));
        MakeBrand(_brandIdPrusament, "Prusament", new Uri("https://prusa3d.com/"));

        Console.WriteLine($" * Entity Brand has {_brands.Keys.Count} rows in seed data.");
        modelBuilder.Entity<Brand>().HasData(_brands.Values);
    }

    private void MakeBrand(Guid id, string name, Uri url)
    {
        var brand = new Brand
        {
            Id = id,
            Name = name,
            Url = url,
            ConcurrencyStamp = id,
            CreatedById = _userAdminId.ToString()
        };
        try
        {
            if (!_brands.ContainsKey(brand.Id))
                _brands.Add(id, brand);
            //else
            //    Console.WriteLine($"Using existing Brand {name} with id {id}");
        }
        catch (Exception ex)
        {
            //Console.WriteLine($"Unable to create Brand {name} with id {id}: ${ex.Message}");
        }
    }
}
