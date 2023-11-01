using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Repositories;
using Fitster.API.Shared.Persistence.Contexts;
using Fitster.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fitster.API.Shopping.Persistence.Repositories;

public class WishListRepository: BaseRepository, IWishListRepository
{
    public WishListRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<WishList>> ListAsync()
    {
        return await _context.WishLists.ToListAsync();
    }

    public async Task<WishList> FindByIdAsync(int id)
    {
        return await _context.WishLists.FindAsync(id);
    }

    public async Task<WishList> FindByUserIdAsync(int userId)
    {
        return await _context.WishLists
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task AddAsync(WishList wishList)
    {
        await _context.WishLists.AddAsync(wishList);
    }

    public void Update(WishList wishList)
    {
        _context.WishLists.Update(wishList);
    }

    public void Remove(WishList wishList)
    {
        _context.WishLists.Remove(wishList);
    }
}