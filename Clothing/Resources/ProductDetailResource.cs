namespace Fitster.API.Clothing.Resources;

public class ProductDetailResource
{
    public int Id { get; set; }
    public string Size { get; set; }  = default!;
    public decimal Price { get; set; }
    public string? Image { get; set; }
    public int Stock { get; set; }
    public string? Model3d { get; set; }
}