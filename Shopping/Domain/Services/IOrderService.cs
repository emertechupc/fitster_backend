using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Services;
using Fitster.API.Shopping.Domain.Services.Communication;

namespace Fitster.API.Shopping.Domain.Services;
public interface IOrderService
{
    Task<IEnumerable<Order>> ListAsync();
    Task<OrderResponse> GetById(int id);
    Task<IEnumerable<Order>> GetAllByUserId(int userId);
    Task<OrderResponse> SaveAsync(Order order);
    Task<OrderResponse> UpdateAsync(int id, Order order);
    Task<OrderResponse> DeleteAsync(int id);
}