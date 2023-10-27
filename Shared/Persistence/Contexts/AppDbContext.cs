using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Shared.Extensions;
using Fitster.API.Clothing.Resources;
using Microsoft.EntityFrameworkCore;
using Fitster.API.Users.Domain.Models;
using Fitster.API.Shopping.Domain.Models;

namespace Fitster.API.Shared.Persistence.Contexts;

public class AppDbContext: DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products {get; set; }
    public DbSet<Category> Categories {get; set; }  
    public DbSet<Gender> Genders {get; set; }
    public DbSet<Brand> Brands {get; set; }
    public DbSet<ShoppingCart> ShoppingCarts {get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems {get; set; }
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

        //Relationships
        builder.Entity<User>()
            .HasOne(p => p.ShoppingCart)
            .WithOne(c => c.User)
            .HasForeignKey<ShoppingCart>(p => p.UserId);

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
        builder.Entity<Product>().Property(pd => pd.Size).IsRequired().HasMaxLength(10);
        builder.Entity<Product>().Property(pd => pd.Price).IsRequired().HasColumnType("decimal(10,2)");
        builder.Entity<Product>().Property(pd => pd.Image).HasMaxLength(1024);
        builder.Entity<Product>().Property(pd => pd.Stock).IsRequired();
        builder.Entity<Product>().Property(pd => pd.Model3d).HasMaxLength(2056);

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

        //Shopping Carts
        //Constraints
        builder.Entity<ShoppingCart>().ToTable("ShoppingCarts");
        builder.Entity<ShoppingCart>().HasKey(p => p.Id);
        builder.Entity<ShoppingCart>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

        //Relationships
        builder.Entity<ShoppingCart>()
            .HasMany(p => p.ShoppingCartItems)
            .WithOne(p => p.ShoppingCart)
            .HasForeignKey(p => p.ShoppingCartId);

        //Shopping Cart Items
        //Constraints
        builder.Entity<ShoppingCartItem>().ToTable("ShoppingCartItems");
        builder.Entity<ShoppingCartItem>().HasKey(p => p.Id);
        builder.Entity<ShoppingCartItem>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ShoppingCartItem>().Property(p => p.Quantity).IsRequired();

        // Apply Snake Case Naming Conventions
        
        builder.UseSnakeCaseNamingConvention();

    }

}