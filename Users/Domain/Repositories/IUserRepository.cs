using Fitster.API.Users.Domain.Models;

namespace Fitster.API.Clothing.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task<User> FindByIdAsync(int id);
    Task<User> FindByEmailAsync(string email);
    bool ExistsByEmail(string email);
    Task AddAsync(User user);
    void Update(User user);
    void Remove(User user);
}