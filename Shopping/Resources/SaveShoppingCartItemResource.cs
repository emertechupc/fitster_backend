using System.ComponentModel.DataAnnotations;

namespace Fitster.API.Shopping.Resources;

public class SaveShoppingCartItemResource
{
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public int ShoppingCartId { get; set; }
}