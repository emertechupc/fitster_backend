using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Shared.Extensions;
using Fitster.API.Clothing.Resources;
using Microsoft.EntityFrameworkCore;
using Fitster.API.Users.Domain.Models;

namespace Fitster.API.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products {get; set; }
    public DbSet<ProductDetail> ProductDetails {get; set; }
    public DbSet<Category> Categories {get; set; }  
    public DbSet<Gender> Genders {get; set; }
    public DbSet<Brand> Brands {get; set; }
    protected readonly IConfiguration _configuration;
    public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //Users
        //Constraints
        builder.Entity<User>().ToTable("Users");
        builder.Entity<User>().HasKey(p => p.Id);
        builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(p => p.FirstName).IsRequired().HasMaxLength(64);
        builder.Entity<User>().Property(p => p.LastName).IsRequired().HasMaxLength(64);
        builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(256);

        //Category
        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(p => p.Id);
        builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(p => p.Name).IsRequired();
        builder.Entity<Category>().Property(p => p.Description).IsRequired();

        //Gender
        builder.Entity<Gender>().ToTable("Genders");
        builder.Entity<Gender>().HasKey(p => p.Id);
        builder.Entity<Gender>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Gender>().Property(p => p.Name).IsRequired();

        //Brand
        builder.Entity<Brand>().ToTable("Brands");
        builder.Entity<Brand>().HasKey(p => p.Id);
        builder.Entity<Brand>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Brand>().Property(p => p.Name).IsRequired();


        //Products
        //Constraints
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>()
            .HasIndex(p => p.Id)
            .IsUnique();
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(256);
        builder.Entity<Product>().Property(p => p.Description).IsRequired().HasMaxLength(512);
        builder.Entity<Product>().Property(p => p.Rating).IsRequired();

        //Relationships
        builder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        builder.Entity<Product>()
            .HasOne(p => p.Gender)
            .WithMany(t => t.Products)
            .HasForeignKey(p => p.GenderId);
        
        builder.Entity<Product>()
            .HasOne(p => p.Brand)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.BrandId);

        //Product Details
        builder.Entity<ProductDetail>().ToTable("ProductDetails");
        builder.Entity<ProductDetail>()
            .HasIndex(pd => pd.Id)
            .IsUnique();
        builder.Entity<ProductDetail>().Property(pd => pd.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ProductDetail>().Property(pd => pd.Size).IsRequired().HasMaxLength(10);
        builder.Entity<ProductDetail>().Property(pd => pd.Price).IsRequired().HasColumnType("decimal(10,2)");
        builder.Entity<ProductDetail>().Property(pd => pd.Image).HasMaxLength(1024);
        builder.Entity<ProductDetail>().Property(pd => pd.Stock).IsRequired();
        builder.Entity<ProductDetail>().Property(pd => pd.Model3d).HasMaxLength(2056);

        builder.Entity<ProductDetail>()
            .HasOne(p => p.Product)
            .WithMany(pd => pd.ProductDetails)
            .HasForeignKey(pd => pd.ProductId);

    }

}