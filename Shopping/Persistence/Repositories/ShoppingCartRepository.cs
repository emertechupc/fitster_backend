using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Repositories;
using Fitster.API.Shared.Persistence.Contexts;
using Fitster.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fitster.API.Shopping.Persistence.Repositories;

public class ShoppingCartRepository: BaseRepository, IShoppingCartRepository
{
    public ShoppingCartRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ShoppingCart>> ListAsync()
    {
        return await _context.ShoppingCarts.ToListAsync();
    }

    public async Task AddAsync(ShoppingCart shoppingCart)
    {
        await _context.ShoppingCarts.AddAsync(shoppingCart);
    }

    public async Task<ShoppingCart> FindByIdAsync(int id)
    {
        return await _context.ShoppingCarts.FindAsync(id);
    }

    public async Task<ShoppingCart> FindByUserIdAsync(int userId)
    {
        return await _context.ShoppingCarts.FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public void Update(ShoppingCart shoppingCart)
    {
        _context.ShoppingCarts.Update(shoppingCart);
    }

    public void Remove(ShoppingCart shoppingCart)
    {
        _context.ShoppingCarts.Remove(shoppingCart);
    }
    `
}
