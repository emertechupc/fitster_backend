using Fitster.API.Shared.Persistence.Contexts;
using Fitster.API.Shared.Persistence.Repositories;
using Fitster.API.Users.Domain.Models;
using Fitster.API.Users.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fitster.API.Users.Persistence.Repositories;

public class UserRepository: BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> FindByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
    }

    public bool ExistsByEmail(string email)
    {
        return _context.Users.Any(u => u.Email == email);
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public void Update(User user)
    {
        _context.Users.Update(user);
    }

    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }

}