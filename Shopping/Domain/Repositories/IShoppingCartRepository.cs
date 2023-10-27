using Fitster.API.Shopping.Domain.Models;

namespace Fitster.API.Shopping.Domain.Repositories;

public interface IShoppingCartRepository
{
    Task<IEnumerable<ShoppingCart>> ListAsync();
    Task AddAsync(ShoppingCart shoppingCart);
    Task<ShoppingCart> FindByIdAsync(int id);
    Task<ShoppingCart> FindByUserIdAsync(int userId);
    void Update(ShoppingCart shoppingCart);
    void Remove(ShoppingCart shoppingCart);
}