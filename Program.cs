using Fitster.API.Clothing.Domain.Repositories;
using Fitster.API.Clothing.Domain.Services;
using Fitster.API.Clothing.Persistence.Repositories;
using Fitster.API.Clothing.Services;
using Fitster.API.Security.Authorization.Handlers.Implementations;
using Fitster.API.Security.Authorization.Handlers.Interfaces;
using Fitster.API.Security.Authorization.Middleware;
using Fitster.API.Security.Authorization.Settings;
using Fitster.API.Shared.Domain.Repositories;
using Fitster.API.Shared.Persistence.Contexts;
using Fitster.API.Shared.Persistence.Repositories;
using Fitster.API.Shopping.Domain.Repositories;
using Fitster.API.Shopping.Persistence.Repositories;
using Fitster.API.Users.Domain.Repositories;
using Fitster.API.Users.Domain.Services;
using Fitster.API.Users.Persistence.Repositories;
using Fitster.API.Users.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add CORS service
builder.Services.AddCors();

// AppSettings Configuration
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddSwaggerGen(options =>
{
    // Add API Documentation Information

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Fitster Project API",
        Description = "Fitster Project RESTful API",
        TermsOfService = new Uri("https://fitster.com"),
        Contact = new OpenApiContact
        {
            Name = "Fitster Project",
            Url = new Uri("https://fitster.com")
        },
        License = new OpenApiLicense
        {
            Name = "Fitster Project Resources License",
            Url = new Uri("https://fitster.com/license")
        }
    });
    options.EnableAnnotations();
});

// Add Database Connection

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Database Connection with Standard Level for Information and Errors
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));

// Add lowercase routes

builder.Services.AddRouting(options => 
    options.LowercaseUrls = true);

// Dependency Injection Configuration

// Shared Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// User Injection Configuration
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();
builder.Services.AddScoped<IUserService, UserService>();

// Security Injection Configuration
builder.Services.AddScoped<IJwtHandler, JwtHandler>();

// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(Fitster.API.Clothing.Mapping.ModelToResourceProfile),
    typeof(Fitster.API.Clothing.Mapping.ResourceToModelProfile),
    typeof(Fitster.API.Shopping.Mapping.ModelToResourceProfile),
    typeof(Fitster.API.Shopping.Mapping.ResourceToModelProfile),
    typeof(Fitster.API.Users.Mapping.ModelToResourceProfile),
    typeof(Fitster.API.Users.Mapping.ResourceToModelProfile)
);

var app = builder.Build();

// Configure CORS
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure Error Handler Middleware

app.UseMiddleware<ErrorHandlerMiddleware>();

// Configure JWT Handling Middleware

app.UseMiddleware<JwtMiddleware>();

// Validation for ensuring Database Objects are created

using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment
())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json", "v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
