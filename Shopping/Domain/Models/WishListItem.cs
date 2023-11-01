using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Users.Domain.Models;

namespace Fitster.API.Shopping.Domain.Models;

public class WishListItem
{
    public int Id { get; set; }
    public int WishListId { get; set; }
    public WishList WishList { get; set; } = default!;
    public int ProductId { get; set; }
    public Product Product { get; set; } = default!;
}