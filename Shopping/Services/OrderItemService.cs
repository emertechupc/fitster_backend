using Fitster.API.Shopping.Domain.Repositories;
using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Services;
using Fitster.API.Shopping.Domain.Services.Communication;
using Fitster.API.Shared.Domain.Repositories;

namespace Fitster.API.Shopping.Services;

public class OrderItemService: IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IUnitOfWork _unitOfWork;
    public OrderItemService(IOrderItemRepository orderItemRepository, IUnitOfWork unitOfWork)
    {
        _orderItemRepository = orderItemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<OrderItem>> ListAsync()
    {
        return await _orderItemRepository.ListAsync();
    }

    public async Task<IEnumerable<OrderItem>> ListByOrderIdAsync(int orderId)
    {
        return await _orderItemRepository.ListByOrderIdAsync(orderId);
    }

    public async Task<IEnumerable<OrderItem>> ListByProductIdAsync(int productId)
    {
        return await _orderItemRepository.ListByProductIdAsync(productId);
    }

    public async Task<OrderItemResponse> GetById(int id)
    {
        var existingOrderItem = await _orderItemRepository.FindByIdAsync(id);

        if (existingOrderItem == null)
            return new OrderItemResponse("Order item not found.");

        return new OrderItemResponse(existingOrderItem);
    }

    public async Task<OrderItemResponse> SaveAsync(OrderItem orderItem)
    {
        try
        {
            await _orderItemRepository.AddAsync(orderItem);
            await _unitOfWork.CompleteAsync();
            return new OrderItemResponse(orderItem);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new OrderItemResponse($"An error occurred when saving the order item: {ex.Message}");
        }
    }

    public async Task<OrderItemResponse> UpdateAsync(int id, OrderItem orderItem)
    {
        var existingOrderItem = await _orderItemRepository.FindByIdAsync(id);

        if (existingOrderItem == null)
            return new OrderItemResponse("Order item not found.");

        existingOrderItem.Quantity = orderItem.Quantity;
        existingOrderItem.Subtotal = orderItem.Subtotal;

        try
        {
            _orderItemRepository.Update(existingOrderItem);
            await _unitOfWork.CompleteAsync();

            return new OrderItemResponse(existingOrderItem);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new OrderItemResponse($"An error occurred when updating the order item: {ex.Message}");
        }
    }

    public async Task<OrderItemResponse> DeleteAsync(int id)
    {
        var existingOrderItem = await _orderItemRepository.FindByIdAsync(id);

        if (existingOrderItem == null)
            return new OrderItemResponse("Order item not found.");

        try
        {
            _orderItemRepository.Remove(existingOrderItem);
            await _unitOfWork.CompleteAsync();

            return new OrderItemResponse(existingOrderItem);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new OrderItemResponse($"An error occurred when deleting the order item: {ex.Message}");
        }
    }

}