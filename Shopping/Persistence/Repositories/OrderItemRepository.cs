using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Repositories;
using Fitster.API.Shared.Persistence.Contexts;
using Fitster.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fitster.API.Shopping.Persistence.Repositories;

public class OrderItemRepository: BaseRepository, IOrderItemRepository
{
    public OrderItemRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<OrderItem>> ListAsync()
    {
        return await _context.OrderItems.ToListAsync();
    }

    public async Task<IEnumerable<OrderItem>> ListByOrderIdAsync(int orderId)
    {
        return await _context.OrderItems
            .Where(p => p.OrderId == orderId)
            .Include(p => p.Product)
            .ToListAsync();
    }

    public async Task<IEnumerable<OrderItem>> ListByProductIdAsync(int productId)
    {
        return await _context.OrderItems
            .Where(p => p.ProductId == productId)
            .Include(p => p.Product)
            .ToListAsync();
    }

    public async Task AddAsync(OrderItem orderItem)
    {
        await _context.OrderItems.AddAsync(orderItem);
    }

    public async Task<OrderItem> FindByIdAsync(int id)
    {
        return await _context.OrderItems.FindAsync(id);
    }

    public void Update(OrderItem orderItem)
    {
        _context.OrderItems.Update(orderItem);
    }

    public void Remove(OrderItem orderItem)
    {
        _context.OrderItems.Remove(orderItem);
    }
}