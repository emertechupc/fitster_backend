using Fitster.API.Clothing.Domain.Models;

namespace Fitster.API.Shopping.Domain.Models;

public class ShoppingCartItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = default!;
    public int ShoppingCartId { get; set; }
    public ShoppingCart ShoppingCart { get; set; } = default!;
}