using AutoMapper;
using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Services;
using Fitster.API.Shopping.Resources;
using Fitster.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Fitster.API.Shopping.Controllers;

[Produces("application/json")]
[ApiController]
[Route("/api/v1/wishlists/{wishListId}/wishlistitems")]
public class WishListWishListItemsController: ControllerBase
{
    private readonly IWishListItemService _wishListItemService;
    private readonly IMapper _mapper;
    public WishListWishListItemsController(IWishListItemService wishListItemService, IMapper mapper)
    {
        _wishListItemService = wishListItemService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all wish list items",
        Description = "List of wish list items already stored",
        Tags = new[] { "Wish List Items" })]
    public async Task<IEnumerable<WishListItemResource>> GetAllByWishListIdAsync(int wishListId)
    {
        var wishListItems = await _wishListItemService.GetByWishListId(wishListId);
        var resources = _mapper.Map<IEnumerable<WishListItem>, IEnumerable<WishListItemResource>>(wishListItems);
        return resources;
    }
}