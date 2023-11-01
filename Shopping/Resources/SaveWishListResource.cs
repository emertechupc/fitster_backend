using System.ComponentModel.DataAnnotations;

namespace Fitster.API.Shopping.Resources;

public class SaveWishListResource
{
    [Required]
    public int Quantity { get; set; }
    [Required]
    public string Title { get; set; } = default!;  
    [Required]
    public int UserId { get; set;} 
}