using Fitster.API.Shopping.Domain.Models;

namespace Fitster.API.Shopping.Domain.Repositories;

public interface IShoppingCartItemRepository
{
    Task<IEnumerable<ShoppingCartItem>> ListAsync();
    Task<IEnumerable<ShoppingCartItem>> ListByShoppingCartIdAsync(int shoppingCartId);
    Task<IEnumerable<ShoppingCartItem>> ListByProductIdAsync(int productId);
    Task AddAsync(ShoppingCartItem shoppingCartItem);
    Task<ShoppingCartItem> FindByIdAsync(int id);
    void Update(ShoppingCartItem shoppingCartItem);
    void Remove(ShoppingCartItem shoppingCartItem);
}