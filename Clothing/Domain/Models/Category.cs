namespace Fitster.API.Clothing.Domain.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public List<Product> Products { get; set; } = new();
}