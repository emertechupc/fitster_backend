using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Repositories;
using Fitster.API.Shared.Persistence.Contexts;
using Fitster.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fitster.API.Shopping.Persistence.Repositories;

public class WishListItemRepository: BaseRepository, IWishListItemRepository
{
    public WishListItemRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<WishListItem>> ListAsync()
    {
        return await _context.WishListItems.ToListAsync();
    }

    public async Task<IEnumerable<WishListItem>> ListByWishListIdAsync(int wishListId)
    {
        return await _context.WishListItems
            .Where(p => p.WishListId == wishListId)
            .Include(p => p.Product)
            .ToListAsync();
    }

    public async Task<IEnumerable<WishListItem>> ListByProductIdAsync(int productId)
    {
        return await _context.WishListItems
            .Where(p => p.ProductId == productId)
            .Include(p => p.Product)
            .ToListAsync();
    }

    public async Task AddAsync(WishListItem wishListItem)
    {
        await _context.WishListItems.AddAsync(wishListItem);
    }

    public async Task<WishListItem> FindByIdAsync(int id)
    {
        return await _context.WishListItems.FindAsync(id);
    }

    public void Remove(WishListItem wishListItem)
    {
        _context.WishListItems.Remove(wishListItem);
    }
}