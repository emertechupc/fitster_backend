using Fitster.API.Security.Domain.Services.Communication;
using Fitster.API.Users.Domain.Models;

namespace Fitster.API.Users.Domain.Services;

public interface IUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    Task<IEnumerable<User>> ListAsync();
    Task<User> GetByIdAsync(int id);
    Task RegisterAsync(RegisterRequest request);
    Task UpdateAsync(int id, UpdateRequest request);
    Task DeleteAsync(int id);
}