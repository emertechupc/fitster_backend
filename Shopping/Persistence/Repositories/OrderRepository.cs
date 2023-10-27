using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Repositories;
using Fitster.API.Shared.Persistence.Contexts;
using Fitster.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fitster.API.Shopping.Persistence.Repositories;

public class OrderRepository: BaseRepository, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> ListAsync()
    {
        return await _context.Orders.ToListAsync();
    }

    public async Task<IEnumerable<Order>> ListByUserIdAsync(int userId)
    {
        return await _context.Orders
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
    }

    public async Task<Order> FindByIdAsync(int id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public void Update(Order order)
    {
        _context.Orders.Update(order);
    }

    public void Remove(Order order)
    {
        _context.Orders.Remove(order);
    }
}