using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Services;
using Fitster.API.Shopping.Domain.Services.Communication;

namespace Fitster.API.Shopping.Domain.Services;
public interface IOrderItemService
{
    Task<IEnumerable<OrderItem>> ListAsync();
    Task<IEnumerable<OrderItem>> ListByOrderIdAsync(int orderId);
    Task<OrderItemResponse> GetById(int id);
    Task<OrderItemResponse> SaveAsync(OrderItem orderItem);
    Task<OrderItemResponse> UpdateAsync(int id, OrderItem orderItem);
    Task<OrderItemResponse> DeleteAsync(int id);
}