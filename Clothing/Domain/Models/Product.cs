namespace Fitster.API.Clothing.Domain.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public decimal? Rating { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public int TypeId { get; set; }
    public Type? Type { get; set; }
    public int BrandId { get; set; }
    //public Brand Brand { get; set; }
}