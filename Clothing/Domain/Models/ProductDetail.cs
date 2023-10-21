namespace Fitster.API.Clothing.Domain.Models;

public class ProductDetail
{
    public int Id { get; set; }
    public string Size { get; set; } = default!;
    public decimal Price { get; set; } = default!;
    public string? Image { get; set; }
    public int Stock { get; set; }
    public string? Model3d { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}
