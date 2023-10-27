using Fitster.API.Shopping.Domain.Repositories;
using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Services;
using Fitster.API.Shopping.Domain.Services.Communication;
using Fitster.API.Shared.Domain.Repositories;

namespace Fitster.API.Shopping.Services;

public class OrderService: IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;
    public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Order>> ListAsync()
    {
        return await _orderRepository.ListAsync();
    }

    public async Task<OrderResponse> GetById(int id)
    {
        var existingOrder = await _orderRepository.FindByIdAsync(id);

        if (existingOrder == null)
            return new OrderResponse("Order not found.");

        return new OrderResponse(existingOrder);
    }

    public async Task<IEnumerable<Order>> GetAllByUserId(int userId)
    {
        return await _orderRepository.ListByUserIdAsync(userId);
    }

    public async Task<OrderResponse> SaveAsync(Order order)
    {
        try
        {
            await _orderRepository.AddAsync(order);
            await _unitOfWork.CompleteAsync();
            return new OrderResponse(order);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new OrderResponse($"An error occurred when saving the order: {ex.Message}");
        }
    }

    public async Task<OrderResponse> UpdateAsync(int id, Order order)
    {
        var existingOrder = await _orderRepository.FindByIdAsync(id);

        if (existingOrder == null)
            return new OrderResponse("Order not found.");

        existingOrder.OrderDate = order.OrderDate;
        existingOrder.Total = order.Total;

        try
        {
            _orderRepository.Update(existingOrder);
            await _unitOfWork.CompleteAsync();

            return new OrderResponse(existingOrder);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new OrderResponse($"An error occurred when updating the order: {ex.Message}");
        }
    }

    public async Task<OrderResponse> DeleteAsync(int id)
    {
        var existingOrder = await _orderRepository.FindByIdAsync(id);

        if (existingOrder == null)
            return new OrderResponse("Order not found.");

        try
        {
            _orderRepository.Remove(existingOrder);
            await _unitOfWork.CompleteAsync();

            return new OrderResponse(existingOrder);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new OrderResponse($"An error occurred when deleting the order: {ex.Message}");
        }
    }
}