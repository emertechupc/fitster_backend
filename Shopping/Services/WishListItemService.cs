using Fitster.API.Shopping.Domain.Repositories;
using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Services;
using Fitster.API.Shopping.Domain.Services.Communication;
using Fitster.API.Shared.Domain.Repositories;

namespace Fitster.API.Shopping.Services;

public class WishListItemService: IWishListItemService
{
    private readonly IWishListItemRepository _wishListItemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public WishListItemService(IWishListItemRepository wishListItemRepository, IUnitOfWork unitOfWork)
    {
        _wishListItemRepository = wishListItemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<WishListItem>> ListAsync()
    {
        return await _wishListItemRepository.ListAsync();
    }

    public async Task<WishListItemResponse> GetById(int id)
    {
        var existingWishListItem = await _wishListItemRepository.FindByIdAsync(id);

        if (existingWishListItem == null)
            return new WishListItemResponse("WishListItem not found.");

        return new WishListItemResponse(existingWishListItem);
    }

    public async Task<IEnumerable<WishListItem>> GetByWishListId(int wishListId)
    {
        return await _wishListItemRepository.ListByWishListIdAsync(wishListId);
    }

    public async Task<WishListItemResponse> SaveAsync(WishListItem wishListItem)
    {
        try
        {
            await _wishListItemRepository.AddAsync(wishListItem);
            await _unitOfWork.CompleteAsync();

            return new WishListItemResponse(wishListItem);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new WishListItemResponse($"An error occurred when saving the wishListItem: {ex.Message}");
        }
    }

    public async Task<WishListItemResponse> DeleteAsync(int id)
    {
        var existingWishListItem = await _wishListItemRepository.FindByIdAsync(id);

        if (existingWishListItem == null)
            return new WishListItemResponse("WishListItem not found.");
        
        try
        {
            _wishListItemRepository.Remove(existingWishListItem);
            await _unitOfWork.CompleteAsync();

            return new WishListItemResponse(existingWishListItem);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new WishListItemResponse($"An error occurred when deleting the wishListItem: {ex.Message}");
        }

    }
}