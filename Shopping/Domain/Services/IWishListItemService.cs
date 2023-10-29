using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Services;
using Fitster.API.Shopping.Domain.Services.Communication;

namespace Fitster.API.Shopping.Domain.Services;
public interface IWishListItemService
{
    Task<IEnumerable<WishListItem>> ListAsync();
    Task<WishListItemResponse> GetById(int id);
    Task<IEnumerable<WishListItem>> GetByWishListId(int wishListId);
    Task<WishListItemResponse> SaveAsync(WishListItem wishListItem);
    Task<WishListItemResponse> DeleteAsync(int id);
}