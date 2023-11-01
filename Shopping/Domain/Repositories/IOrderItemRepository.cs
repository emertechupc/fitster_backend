using Fitster.API.Shopping.Domain.Models;

namespace Fitster.API.Shopping.Domain.Repositories;

public interface IOrderItemRepository
{
    Task<IEnumerable<OrderItem>> ListAsync();
    Task<IEnumerable<OrderItem>> ListByOrderIdAsync(int orderId);
    Task<IEnumerable<OrderItem>> ListByProductIdAsync(int productId);
    Task AddAsync(OrderItem orderItem);
    Task<OrderItem> FindByIdAsync(int id);
    void Update(OrderItem orderItem);
    void Remove(OrderItem orderItem);
}