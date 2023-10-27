using System.Text.Json.Serialization;
using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Shopping.Domain.Models;

namespace Fitster.API.Users.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;    
    public string Email { get; set; } = default!;
    [JsonIgnore]
    public string PasswordToken { get; set; }
    //Relationships
    public ShoppingCart ShoppingCart { get; set; }
}