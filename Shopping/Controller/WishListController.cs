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
public class WishListController: ControllerBase
{
    private readonly IWishListService _wishListService;
    private readonly IMapper _mapper;
    public WishListController(IWishListService wishListService, IMapper mapper)
    {
        _wishListService = wishListService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all wishLists",
        Description = "List of wishLists already stored",
        Tags = new[] { "WishLists" })]
    public async Task<IEnumerable<WishListResource>> GetAllAsync()
    {
        var wishLists = await _wishListService.ListAsync();
        var resources = _mapper.Map<IEnumerable<WishList>, IEnumerable<WishListResource>>(wishLists);
        return resources;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get WishList By Id",
        Description = "Get a wishList from the database identified by its id",
        Tags = new[] { "WishLists" })]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _wishListService.GetById(id);
        if(!result.Success)
            return BadRequest(result.Message);
        return Ok(result.Resource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new wishList",
        Description = "Create a new wishList",
        Tags = new[] { "WishLists" })]
    public async Task<IActionResult> PostAsync([FromBody] SaveWishListResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var wishList = _mapper.Map<SaveWishListResource, WishList>(resource);
        var result = await _wishListService.SaveAsync(wishList);
        if(!result.Success)
            return BadRequest(result.Message);
        var wishListResource = _mapper.Map<WishList, WishListResource>(result.Resource);
        return Ok(wishListResource);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a wishList",
        Description = "Delete a wishList",
        Tags = new[] { "WishLists" })]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _wishListService.DeleteAsync(id);
        if(!result.Success)
            return BadRequest(result.Message);
        var wishListResource = _mapper.Map<WishList, WishListResource>(result.Resource);
        return Ok(wishListResource);
    }
}