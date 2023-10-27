using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Repositories;
using Fitster.API.Shared.Persistence.Contexts;
using Fitster.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fitster.API.Shopping.Persistence.Repositories;

public class ShoppingCartItemRepository: BaseRepository, IShoppingCartItemRepository
{
    public ShoppingCartItemRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ShoppingCartItem>> ListAsync()
    {
        return await _context.ShoppingCartItems.ToListAsync();
    }

    public async Task<IEnumerable<ShoppingCartItem>> ListByShoppingCartIdAsync(int shoppingCartId)
    {
        return await _context.ShoppingCartItems
            .Where(p => p.ShoppingCartId == shoppingCartId)
            .Include(p => p.Product)
            .ToListAsync();
    }

    public async Task<IEnumerable<ShoppingCartItem>> ListByProductIdAsync(int productId)
    {
        return await _context.ShoppingCartItems
            .Where(p => p.ProductId == productId)
            .Include(p => p.Product)
            .ToListAsync();
    }

    public async Task AddAsync(ShoppingCartItem shoppingCartItem)
    {
        await _context.ShoppingCartItems.AddAsync(shoppingCartItem);
    }

    public async Task<ShoppingCartItem> FindByIdAsync(int id)
    {
        return await _context.ShoppingCartItems.FindAsync(id);
    }

    public void Update(ShoppingCartItem shoppingCartItem)
    {
        _context.ShoppingCartItems.Update(shoppingCartItem);
    }

    public void Remove(ShoppingCartItem shoppingCartItem)
    {
        _context.ShoppingCartItems.Remove(shoppingCartItem);
    }
}