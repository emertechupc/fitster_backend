using Fitster.API.Shopping.Domain.Repositories;
using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Services;
using Fitster.API.Shopping.Domain.Services.Communication;
using Fitster.API.Shared.Domain.Repositories;

namespace Fitster.API.Shopping.Services;

public class ShoppingCartService: IShoppingCartService
{
    private readonly IShoppingCartRepository _shoppingCartRepository;
    private readonly IUnitOfWork _unitOfWork;
    public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IUnitOfWork unitOfWork)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ShoppingCart>> ListAsync()
    {
        return await _shoppingCartRepository.ListAsync();
    }

    public async Task<ShoppingCartResponse> GetById(int id)
    {
        var existingShoppingCart = await _shoppingCartRepository.FindByIdAsync(id);

        if (existingShoppingCart == null)
            return new ShoppingCartResponse("Shopping cart not found.");

        return new ShoppingCartResponse(existingShoppingCart);
    }

    public async Task<ShoppingCartResponse> GetByUserId(int userId)
    {
        var existingShoppingCart = await _shoppingCartRepository.FindByUserIdAsync(userId);

        if (existingShoppingCart == null)
            return new ShoppingCartResponse("Shopping cart not found.");

        return new ShoppingCartResponse(existingShoppingCart);
    }

    public async Task<ShoppingCartResponse> SaveAsync(ShoppingCart shoppingCart)
    {
        try
        {
            await _shoppingCartRepository.AddAsync(shoppingCart);
            await _unitOfWork.CompleteAsync();

            return new ShoppingCartResponse(shoppingCart);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new ShoppingCartResponse($"An error occurred when saving the shopping cart: {ex.Message}");
        }
    }

    public async Task<ShoppingCartResponse> DeleteAsync(int id)
    {
        var existingShoppingCart = await _shoppingCartRepository.FindByIdAsync(id);

        if (existingShoppingCart == null)
            return new ShoppingCartResponse("Shopping cart not found.");

        try
        {
            _shoppingCartRepository.Remove(existingShoppingCart);
            await _unitOfWork.CompleteAsync();

            return new ShoppingCartResponse(existingShoppingCart);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new ShoppingCartResponse($"An error occurred when deleting the shopping cart: {ex.Message}");
        }
    }

}