using Fitster.API.Shopping.Domain.Models;

namespace Fitster.API.Clothing.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal? Rating { get; set; }
    public string Size { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public string? Image { get; set; }
    public int Stock { get; set; }
    public string? Model3d { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int GenderId { get; set; }
    public Gender? Gender { get; set; }
    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
    public OrderItem OrderItem { get; set; }
}