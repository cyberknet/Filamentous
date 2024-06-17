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
    private SequentialGuid _identityGuid = new("D9A3F45C-81AE-4B86-B477-020000000000");
    private Dictionary<Guid, IdentityUser> _identityUsers = new();

    private Guid _userAdminId;
    
    private void InitializeIdentityUsers()
    {
        // DO NOT REORDER or insert new values in the middle of the list!
        _userAdminId = _identityGuid.Next();
    }
    
    private void IdentityUsers(ModelBuilder modelBuilder)
    {
        string hash = "AQAAAAIAAYagAAAAEBm+qE3vZ4hlMjyrKVdyjEtTZqnU/1XXi/Sh2ycOqU8PkBxc8e5VLe//Lw/iO9dslw=="; // hashed version of "password"
        MakeIdentityUser(_userAdminId, "scott@blomfield.us", "scott@blomfield.us", true, hash);

        Console.WriteLine($" * Entity IdentityUser has {_identityUsers.Keys.Count} rows in seed data.");
        modelBuilder.Entity<IdentityUser>().HasData(_identityUsers.Values.ToArray());
    }
    private void MakeIdentityUser(Guid id, string username, string email, bool emailConfirmed, string passwordHash)
    {
        IdentityUser _identityUser = new()
        {
            Id = id.ToString().ToUpper(),
            UserName = username,
            NormalizedUserName = username.ToUpper(),
            Email = email,
            NormalizedEmail = email.ToUpper(),
            EmailConfirmed = emailConfirmed,
            ConcurrencyStamp = _userAdminId.ToString().ToUpper(),
            PasswordHash = passwordHash
        };
        try
        {
            if (string.IsNullOrEmpty(_identityUser.Id))
                Console.WriteLine($"Not adding IdentityUser {username} because id is null (provided {id})");
            else if (!_identityUsers.ContainsKey(id))
                _identityUsers.Add(id, _identityUser);
            //else
            //    Console.WriteLine($"Using existing IdentityUser {username} with id {id}");
        }
        catch (Exception ex)
        {
            //Console.WriteLine($"Unable to create IdentityUser {username} with id {id}: ${ex.Message}");
        }
    }
}
