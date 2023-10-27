using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Services;
using Fitster.API.Shopping.Domain.Services.Communication;

namespace Fitster.API.Shopping.Domain.Services;
public interface IShoppingCartItemService
{
    Task<IEnumerable<ShoppingCartItem>> ListAsync();
    Task<IEnumerable<ShoppingCartItem>> ListByShoppingCartIdAsync(int shoppingCartId);
    Task<IEnumerable<ShoppingCartItem>> ListByProductIdAsync(int productId);
    Task<ShoppingCartItemResponse> GetById(int id);
    Task<ShoppingCartItemResponse> SaveAsync(ShoppingCartItem shoppingCartItem);
    Task<ShoppingCartItemResponse> UpdateAsync(int id, ShoppingCartItem shoppingCartItem);
    Task<ShoppingCartItemResponse> DeleteAsync(int id);
}