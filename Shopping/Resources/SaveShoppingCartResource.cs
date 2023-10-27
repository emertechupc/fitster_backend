using System.ComponentModel.DataAnnotations;

namespace Fitster.API.Shopping.Resources;

public class SaveShoppingCartResource
{
    [Required]
    public int UserId { get; set; }
}