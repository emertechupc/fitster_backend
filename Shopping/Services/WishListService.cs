using Fitster.API.Shopping.Domain.Repositories;
using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Services;
using Fitster.API.Shopping.Domain.Services.Communication;
using Fitster.API.Shared.Domain.Repositories;

namespace Fitster.API.Shopping.Services;

public class WishListService: IWishListService
{
    private readonly IWishListRepository _wishListRepository;
    private readonly IUnitOfWork _unitOfWork;

    public WishListService(IWishListRepository wishListRepository, IUnitOfWork unitOfWork)
    {
        _wishListRepository = wishListRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<WishList>> ListAsync()
    {
        return await _wishListRepository.ListAsync();
    }

    public async Task<WishListResponse> GetById(int id)
    {
        var existingWishList = await _wishListRepository.FindByIdAsync(id);

        if (existingWishList == null)
            return new WishListResponse("WishList not found.");

        return new WishListResponse(existingWishList);
    }

    public async Task<WishListResponse> GetByUserId(int userId)
    {
        var existingWishList = await _wishListRepository.FindByUserIdAsync(userId);

        if (existingWishList == null)
            return new WishListResponse("WishList not found.");

        return new WishListResponse(existingWishList);
    }

    public async Task<WishListResponse> SaveAsync(WishList wishList)
    {
        try
        {
            await _wishListRepository.AddAsync(wishList);
            await _unitOfWork.CompleteAsync();

            return new WishListResponse(wishList);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new WishListResponse($"An error occurred when saving the wishList: {ex.Message}");
        }
    }

    public async Task<WishListResponse> UpdateAsync(int id, WishList wishList)
    {
        var existingWishList = await _wishListRepository.FindByIdAsync(id);

        if (existingWishList == null)
            return new WishListResponse("WishList not found.");

        existingWishList.UserId = wishList.UserId;

        try
        {
            _wishListRepository.Update(existingWishList);
            await _unitOfWork.CompleteAsync();

            return new WishListResponse(existingWishList);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new WishListResponse($"An error occurred when updating the wishList: {ex.Message}");
        }
    }

    public async Task<WishListResponse> DeleteAsync(int id)
    {
        var existingWishList = await _wishListRepository.FindByIdAsync(id);

        if (existingWishList == null)
            return new WishListResponse("WishList not found.");
        
        try
        {
            _wishListRepository.Remove(existingWishList);
            await _unitOfWork.CompleteAsync();

            return new WishListResponse(existingWishList);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new WishListResponse($"An error occurred when deleting the wishList: {ex.Message}");
        }
    }
}