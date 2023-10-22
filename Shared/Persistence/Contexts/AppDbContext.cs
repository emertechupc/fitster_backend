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
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Products
        //Constraints
        // builder.Entity<Product>()
        //     .HasIndex(p => p.Name)
        //     .IsUnique();








    }

}