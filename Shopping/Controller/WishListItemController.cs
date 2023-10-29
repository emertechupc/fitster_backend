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
[Route("/api/v1/[controller]")]
public class WishListItemController: ControllerBase
{
    private readonly IWishListItemService _wishListItemService;
    private readonly IMapper _mapper;
    public WishListItemController(IWishListItemService wishListItemService, IMapper mapper)
    {
        _wishListItemService = wishListItemService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all wishListItems",
        Description = "List of wishListItems already stored",
        Tags = new[] { "WishListItems" })]
    public async Task<IEnumerable<WishListItemResource>> GetAllAsync()
    {
        var wishListItems = await _wishListItemService.ListAsync();
        var resources = _mapper.Map<IEnumerable<WishListItem>, IEnumerable<WishListItemResource>>(wishListItems);
        return resources;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get WishListItem By Id",
        Description = "Get a wishListItem from the database identified by its id",
        Tags = new[] { "WishListItems" })]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _wishListItemService.GetById(id);
        if(!result.Success)
            return BadRequest(result.Message);
        return Ok(result.Resource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new wishListItem",
        Description = "Create a new wishListItem",
        Tags = new[] { "WishListItems" })]
    public async Task<IActionResult> PostAsync([FromBody] SaveWishListItemResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var wishListItem = _mapper.Map<SaveWishListItemResource, WishListItem>(resource);
        var result = await _wishListItemService.SaveAsync(wishListItem);
        if(!result.Success)
            return BadRequest(result.Message);
        var wishListItemResource = _mapper.Map<WishListItem, WishListItemResource>(result.Resource);
        return Ok(wishListItemResource);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a wishListItem",
        Description = "Delete a wishListItem identified by its id",
        Tags = new[] { "WishListItems" })]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _wishListItemService.DeleteAsync(id);
        if(!result.Success)
            return BadRequest(result.Message);
        var wishListItemResource = _mapper.Map<WishListItem, WishListItemResource>(result.Resource);
        return Ok(wishListItemResource);
    }
}