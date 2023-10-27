using System.ComponentModel.DataAnnotations;

namespace Fitster.API.Clothing.Resources;

public class SaveProductResource
{
    [Required]
    [MaxLength(256)]
    public string Name { get; set; } = default!;
    [Required]
    [MaxLength(512)]
    public string Description { get; set; } = default!;
    public decimal Rating { get; set; }
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public int GenderId { get; set; }
    [Required]
    public int BrandId { get; set;}
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