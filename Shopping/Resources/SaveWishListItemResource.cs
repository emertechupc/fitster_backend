using System.ComponentModel.DataAnnotations;

namespace Fitster.API.Shopping.Resources;

public class SaveWishListItemResource
{
    [Required]
    public int WishListId { get; set; }
    [Required]
    public int ProductId { get; set; }
}