using Filamentous.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filamentous.Data.Seed;
internal class FilamentousSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        IdentityUsers(modelBuilder);
        ApplicationRoles(modelBuilder);
        Brands(modelBuilder);
    }

    #region User
    private static Guid _userAdminId = Guid.Parse("D9A3F45C-81AE-4B86-B477-020000000001");
    private static IdentityUser _userAdmin = new()
    {
        Id = _userAdminId.ToString().ToUpper(),
        UserName = "scott@blomfield.us",
        NormalizedUserName = "SCOTT@BLOMFIELD.US",
        Email = "scott@blomfield.us",
        NormalizedEmail = "SCOTT@BLOMFIELD.US",
        EmailConfirmed = true,
        ConcurrencyStamp = _userAdminId.ToString().ToUpper(),
        PasswordHash = "AQAAAAIAAYagAAAAEBm+qE3vZ4hlMjyrKVdyjEtTZqnU/1XXi/Sh2ycOqU8PkBxc8e5VLe//Lw/iO9dslw==" // hashed version of "password"
    };
    private static void IdentityUsers(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<IdentityUser>()
            .HasData(_userAdmin);
    }
    #endregion

    #region Role
    private static Guid _roleAdminId = Guid.Parse("D9A3F45C-81AE-4B86-B477-010000000001");
    private static IdentityRole _roleAdmin = new()
    {
        Id = _roleAdminId.ToString().ToUpper(),
        Name = "Administrator",
        NormalizedName = "ADMINISTRATOR",
        ConcurrencyStamp = _roleAdminId.ToString().ToUpper()
    };

    private static void ApplicationRoles(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<IdentityRole>()
            .HasData(_roleAdmin);
    }
    #endregion

    #region Brand
    private static Guid _brandIdPrusament = Guid.Parse("D9A3F45C-81AE-4B86-B477-030000000001");
    private static Guid _brandIdPolymaker = Guid.Parse("D9A3F45C-81AE-4B86-B477-030000000002");
    private static Brand _brandPrusament = new ()
    {
        Id = _brandIdPrusament,
        Name = "Prusament",
        //Url = new Uri("https://prusa3d.com/"),
        ConcurrencyStamp = _brandIdPrusament,
        CreatedById = _userAdminId.ToString()
    };
    private static Brand _brandPolymaker = new()
    {
        Id = _brandIdPolymaker,
        Name = "Prusament",
        //Url = new Uri("https://us.polymaker.com/"),
        ConcurrencyStamp = _brandIdPolymaker,
        CreatedById = _userAdminId.ToString()
    };
    private static void Brands(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>()
            .HasData(_brandPrusament, _brandPolymaker);
    }
    #endregion
}
