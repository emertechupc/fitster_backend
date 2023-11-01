using System.ComponentModel.DataAnnotations;

namespace Fitster.API.Shopping.Resources;

public class SaveOrderResource
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public decimal Total { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }
}