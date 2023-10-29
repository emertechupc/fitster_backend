using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Services;
using Fitster.API.Shopping.Domain.Services.Communication;

namespace Fitster.API.Shopping.Domain.Services;
public interface IWishListService
{
    Task<IEnumerable<WishList>> ListAsync();
    Task<WishListResponse> GetById(int id);
    Task<WishListResponse> GetByUserId(int userId);
    Task<WishListResponse> SaveAsync(WishList wishList);
    Task<WishListResponse> UpdateAsync(int id, WishList wishList);
    Task<WishListResponse> DeleteAsync(int id);
}