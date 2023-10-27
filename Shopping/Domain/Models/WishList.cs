using Fitster.API.Users.Domain.Models;

namespace Fitster.API.Shopping.Domain.Models;

public class WishList
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public int Quantity { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public List<WishListItem> Items { get; set; } = new();
}