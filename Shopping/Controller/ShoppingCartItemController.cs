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

public class ShoppingCartItemController: ControllerBase
{
    private readonly IShoppingCartItemService _shoppingCartItemService;
    private readonly IMapper _mapper;
    public ShoppingCartItemController(IShoppingCartItemService shoppingCartItemService, IMapper mapper)
    {
        _shoppingCartItemService = shoppingCartItemService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all shopping cart items",
        Description = "List of shopping cart items already stored",
        Tags = new[] { "Shopping Cart Items" })]
    public async Task<IEnumerable<ShoppingCartItemResource>> GetAllAsync()
    {
        var shoppingCartItems = await _shoppingCartItemService.ListAsync();
        var resources = _mapper.Map<IEnumerable<ShoppingCartItem>, IEnumerable<ShoppingCartItemResource>>(shoppingCartItems);
        return resources;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get Shopping Cart Item By Id",
        Description = "Get a shopping cart item from the database identified by its id",
        Tags = new[] { "Shopping Cart Items" })]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _shoppingCartItemService.GetById(id);
        if(!result.Success)
            return BadRequest(result.Message);
        return Ok(result.Resource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new shopping cart item",
        Description = "Create a new shopping cart item",
        Tags = new[] { "Shopping Cart Items" })]
    public async Task<IActionResult> PostAsync([FromBody] SaveShoppingCartItemResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var shoppingCartItem = _mapper.Map<SaveShoppingCartItemResource, ShoppingCartItem>(resource);
        var result = await _shoppingCartItemService.SaveAsync(shoppingCartItem);
        if(!result.Success)
            return BadRequest(result.Message);
        var shoppingCartItemResource = _mapper.Map<ShoppingCartItem, ShoppingCartItemResource>(result.Resource);
        return Ok(shoppingCartItemResource);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a shopping cart item",
        Description = "Update a shopping cart item",
        Tags = new[] { "Shopping Cart Items" })]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveShoppingCartItemResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var shoppingCartItem = _mapper.Map<SaveShoppingCartItemResource, ShoppingCartItem>(resource);
        var result = await _shoppingCartItemService.UpdateAsync(id, shoppingCartItem);
        if(!result.Success)
            return BadRequest(result.Message);
        var shoppingCartItemResource = _mapper.Map<ShoppingCartItem, ShoppingCartItemResource>(result.Resource);
        return Ok(shoppingCartItemResource);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a shopping cart item",
        Description = "Delete a shopping cart item",
        Tags = new[] { "Shopping Cart Items" })]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _shoppingCartItemService.DeleteAsync(id);
        if(!result.Success)
            return BadRequest(result.Message);
        var shoppingCartItemResource = _mapper.Map<ShoppingCartItem, ShoppingCartItemResource>(result.Resource);
        return Ok(shoppingCartItemResource);
    }
}