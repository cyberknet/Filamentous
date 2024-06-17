using Filamentous.Data.Entities;
using JumpStart.Data.Primitives;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filamentous.Data.Seed;
internal partial class FilamentousSeed
{
    private SequentialGuid _roleGuid = new("D9A3F45C-81AE-4B86-B477-010000000000");
    private Dictionary<Guid, IdentityRole> _identityRoles = new();

    private Guid _roleAdminId;
    private void InitializeIdentityRoles()
    {
        // DO NOT REORDER or insert new values in the middle of the list!
        _roleAdminId = _roleGuid.Next();
    }

    private void IdentityRoles(ModelBuilder modelBuilder)
    {
        MakeIdentityRole(_roleAdminId, "Administrator");

        Console.WriteLine($" * Entity IdentityRole has {_identityRoles.Keys.Count} rows in seed data.");
        modelBuilder
            .Entity<IdentityRole>()
            .HasData(_identityRoles.Values.ToArray());
    }
    private void MakeIdentityRole(Guid id, string name)
    {
        IdentityRole identityRole = new()
        {
            Id = id.ToString().ToUpper(),
            Name = name,
            NormalizedName = name.ToUpper(),
            ConcurrencyStamp = _userAdminId.ToString().ToUpper()
        };
        try
        {
            if (!_identityRoles.ContainsKey(id))
                _identityRoles.Add(id, identityRole);
            //else
            //    Console.WriteLine($"Using existing IdentityUser {name} with id {id}");
        }
        catch (Exception ex)
        {
            //Console.WriteLine($"Unable to create IdentityUser {name} with id {id}: ${ex.Message}");
        }
    }
}
