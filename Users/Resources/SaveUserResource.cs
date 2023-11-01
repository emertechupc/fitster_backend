using System.ComponentModel.DataAnnotations;

namespace Fitster.API.Users.Resources;

public class SaveUserResource
{
    [Required]
    [MaxLength(64)]
    public string FirstName { get; set; } = default!;

    [Required]
    [MaxLength(64)]
    public string LastName { get; set; } = default!;

    [Required]
    [MaxLength(256)]
    public string Email { get; set; } = default!;

    [Required]
    [MaxLength(256)]
    public string Password { get; set; } = default!;
}