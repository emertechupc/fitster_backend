using Fitster.API.Users.Domain.Models;

namespace Fitster.API.Shopping.Domain.Models;

public class ShoppingCart
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new();
}