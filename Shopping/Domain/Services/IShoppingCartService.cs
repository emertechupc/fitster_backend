using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Services;
using Fitster.API.Shopping.Domain.Services.Communication;

namespace Fitster.API.Shopping.Domain.Services;
public interface IShoppingCartService
{
    Task<IEnumerable<ShoppingCart>> ListAsync();
    Task<ShoppingCartResponse> GetById(int id);
    Task<ShoppingCartResponse> GetByUserId(int userId);
    Task<ShoppingCartResponse> SaveAsync(ShoppingCart shoppingCart);
    Task<ShoppingCartResponse> UpdateAsync(int id, ShoppingCart shoppingCart);
    Task<ShoppingCartResponse> DeleteAsync(int id);
}