using Fitster.API.Shopping.Domain.Models;

namespace Fitster.API.Shopping.Domain.Repositories;

public interface IWishListRepository
{
    Task<IEnumerable<WishList>> ListAsync();
    Task<WishList> FindByIdAsync(int id);
    Task<WishList> FindByUserIdAsync(int userId);
    Task AddAsync(WishList wishList);
    void Update(WishList wishList);
    void Remove(WishList wishList);
}