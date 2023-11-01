using Fitster.API.Shopping.Domain.Repositories;
using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Services;
using Fitster.API.Shopping.Domain.Services.Communication;
using Fitster.API.Shared.Domain.Repositories;

namespace Fitster.API.Shopping.Services;

public class ShoppingCartItemService: IShoppingCartItemService
{
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
    private readonly IUnitOfWork _unitOfWork;
    public ShoppingCartItemService(IShoppingCartItemRepository shoppingCartItemRepository, IUnitOfWork unitOfWork)
    {
        _shoppingCartItemRepository = shoppingCartItemRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<ShoppingCartItem>> ListAsync()
    {
        return await _shoppingCartItemRepository.ListAsync();
    }

    public async Task<IEnumerable<ShoppingCartItem>> ListByShoppingCartIdAsync(int shoppingCartId)
    {
        return await _shoppingCartItemRepository.ListByShoppingCartIdAsync(shoppingCartId);
    }

    public async Task<IEnumerable<ShoppingCartItem>> ListByProductIdAsync(int productId)
    {
        return await _shoppingCartItemRepository.ListByProductIdAsync(productId);
    }

    public async Task<ShoppingCartItemResponse> GetById(int id)
    {
        var existingShoppingCartItem = await _shoppingCartItemRepository.FindByIdAsync(id);

        if (existingShoppingCartItem == null)
            return new ShoppingCartItemResponse("Shopping cart item not found.");

        return new ShoppingCartItemResponse(existingShoppingCartItem);
    }

    public async Task<ShoppingCartItemResponse> SaveAsync(ShoppingCartItem shoppingCartItem)
    {
        try
        {
            await _shoppingCartItemRepository.AddAsync(shoppingCartItem);
            await _unitOfWork.CompleteAsync();
            return new ShoppingCartItemResponse(shoppingCartItem);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new ShoppingCartItemResponse($"An error occurred when saving the shopping cart item: {ex.Message}");
        }
    }

    public async Task<ShoppingCartItemResponse> UpdateAsync(int id, ShoppingCartItem shoppingCartItem)
    {
        var existingShoppingCartItem = await _shoppingCartItemRepository.FindByIdAsync(id);

        if (existingShoppingCartItem == null)
            return new ShoppingCartItemResponse("Shopping cart item not found.");

        existingShoppingCartItem.Quantity = shoppingCartItem.Quantity;

        try
        {
            _shoppingCartItemRepository.Update(existingShoppingCartItem);
            await _unitOfWork.CompleteAsync();

            return new ShoppingCartItemResponse(existingShoppingCartItem);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new ShoppingCartItemResponse($"An error occurred when updating the shopping cart item: {ex.Message}");
        }
    }

    public async Task<ShoppingCartItemResponse> DeleteAsync(int id)
    {
        var existingShoppingCartItem = await _shoppingCartItemRepository.FindByIdAsync(id);

        if (existingShoppingCartItem == null)
            return new ShoppingCartItemResponse("Shopping cart item not found.");

        try
        {
            _shoppingCartItemRepository.Remove(existingShoppingCartItem);
            await _unitOfWork.CompleteAsync();

            return new ShoppingCartItemResponse(existingShoppingCartItem);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new ShoppingCartItemResponse($"An error occurred when deleting the shopping cart item: {ex.Message}");
        }
    }
}