using Fitster.API.Clothing.Domain.Models;
using Leasy.API.Shared.Extensions;
using Fitster.API.Clothing.Resources;

using Microsoft.EntityFrameworkCore;

namespace Fitster.API.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public DbSet<Product> Products {get; set; }
    public DbSet<ProductDetail> ProductDetails {get; set; }
    protected readonly IConfiguration _configuration;
    public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //Products
        //Constraints
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>()
            .HasIndex(p => p.Id)
            .IsUnique();
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(256);
        builder.Entity<Product>().Property(p => p.Description).IsRequired().HasMaxLength(512);
        builder.Entity<Product>().Property(p => p.Rating);

        //Relationships
        builder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);








    }

}