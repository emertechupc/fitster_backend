using Fitster.API.Shopping.Domain.Models;

namespace Fitster.API.Shopping.Domain.Repositories;

public interface IWishListItemRepository
{
    Task<IEnumerable<WishListItem>> ListAsync();
    Task<IEnumerable<WishListItem>> ListByWishListIdAsync(int wishListId);
    Task<IEnumerable<WishListItem>> ListByProductIdAsync(int productId);
    Task AddAsync(WishListItem wishListItem);
    Task<WishListItem> FindByIdAsync(int id);
    void Remove(WishListItem wishListItem);
}