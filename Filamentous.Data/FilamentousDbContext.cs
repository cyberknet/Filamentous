using Filamentous.Data.Entities;
using Filamentous.Data.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Filamentous.Data;
public class FilamentousDbContext : IdentityDbContext<IdentityUser>
{
    private FilamentousSeed _seed = new FilamentousSeed();
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Polymer> Polymers { get; set; }
    public DbSet<ProductLine> ProductLines { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Spool> Spools { get; set; }
    public DbSet<ImageType> ImageTypes { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }

    public FilamentousDbContext(DbContextOptions<FilamentousDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer($"Server=localhost;initial catalog=filamentous;user id=filamentous;password=filamentous;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<IdentityUser>()
            .HasKey(x => x.Id);

        base.OnModelCreating(builder);

        // register all CreatedBy, UpdatedBy, and DeletedBy fields
        builder.RegisterAuditEntityRelationships();
        builder.SetTableNamesToEntityNames();

        _seed.Seed(builder);
    }

}
