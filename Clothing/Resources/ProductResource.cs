namespace Fitster.API.Clothing.Resources;

public class ProductResource
{
    public int Id { get; set; }
    public string Name { get; set; }  = default!;
    public string Description { get; set; } = default!;
    public decimal Rating { get; set; }
}