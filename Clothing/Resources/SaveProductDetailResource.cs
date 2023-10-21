using System.ComponentModel.DataAnnotations;

namespace Fitster.API.Clothing.Resources;

public class SaveProductDetailResource
{
    [Required]
    [MaxLength(10)]
    public string Size { get; set; } = default!;
    [Required]
    public decimal Price { get; set; }
    [Required]
    [MaxLength(1024)]
    public string Image { get; set; } = default!;
    [Required]
    public int Stock { get; set; }
    [Required]
    [MaxLength(2056)]
    public string Model3d { get; set;} = default!;
}