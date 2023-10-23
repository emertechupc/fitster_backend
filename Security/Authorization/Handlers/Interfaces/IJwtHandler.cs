using Fitster.API.Users.Domain.Models;

namespace Fitster.API.Security.Authorization.Handlers.Interfaces;
public interface IJwtHandler
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}