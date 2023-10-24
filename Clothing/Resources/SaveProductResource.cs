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
}