using Filamentous.Data.Entities;
using JumpStart.Data.Primitives;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filamentous.Data.Seed;
internal partial class FilamentousSeed
{
    public FilamentousSeed()
    {
        InitializeIdentityRoles();
        InitializeIdentityUsers();

        InitializeImageTypes();
        InitializeBrands();
        InitializePolymers();
        InitializeProductLines();
    }
    private object _seedLock = new object();
    public void Seed(ModelBuilder modelBuilder)
    {
        lock(_seedLock)
        { 
            IdentityUsers(modelBuilder);
            IdentityRoles(modelBuilder);
            
            ImageTypes(modelBuilder);
            Brands(modelBuilder);
            Polymers(modelBuilder);
            ProductLines(modelBuilder);
        }
    }

    
}
