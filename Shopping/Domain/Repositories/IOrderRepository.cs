using Fitster.API.Shopping.Domain.Models;

namespace Fitster.API.Shopping.Domain.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> ListAsync();
    Task<IEnumerable<Order>> ListByUserIdAsync(int userId);
    Task AddAsync(Order order);
    Task<Order> FindByIdAsync(int id);
    void Update(Order order);
    void Remove(Order order);
}