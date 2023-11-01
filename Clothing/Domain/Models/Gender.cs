namespace Fitster.API.Clothing.Domain.Models;

public class Gender 
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public List<Product> Products { get; set; } = new();
}