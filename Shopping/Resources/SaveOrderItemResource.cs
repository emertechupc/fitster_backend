using System.ComponentModel.DataAnnotations;

namespace Fitster.API.Shopping.Resources;

public class SaveOrderItemResource
{
    [Required]
    public int ProductId { get; set; }

    [Required]
    public int Quantity { get; set; }

    [Required]
    public decimal Subtotal { get; set; }

    [Required]
    public int OrderId { get; set; }
}