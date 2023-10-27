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
public class ShoppingCartController: ControllerBase
{
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IMapper _mapper;
    public ShoppingCartController(IShoppingCartService shoppingCartService, IMapper mapper)
    {
        _shoppingCartService = shoppingCartService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all shopping carts",
        Description = "List of shopping carts already stored",
        Tags = new[] { "Shopping Carts" })]
    public async Task<IEnumerable<ShoppingCartResource>> GetAllAsync()
    {
        var shoppingCarts = await _shoppingCartService.ListAsync();
        var resources = _mapper.Map<IEnumerable<ShoppingCart>, IEnumerable<ShoppingCartResource>>(shoppingCarts);
        return resources;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get Shopping Cart By Id",
        Description = "Get a shopping cart from the database identified by its id",
        Tags = new[] { "Shopping Carts" })]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _shoppingCartService.GetById(id);
        if(!result.Success)
            return BadRequest(result.Message);
        return Ok(result.Resource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new shopping cart",
        Description = "Create a new shopping cart",
        Tags = new[] { "Shopping Carts" })]
    public async Task<IActionResult> PostAsync([FromBody] SaveShoppingCartResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var shoppingCart = _mapper.Map<SaveShoppingCartResource, ShoppingCart>(resource);
        var result = await _shoppingCartService.SaveAsync(shoppingCart);
        if(!result.Success)
            return BadRequest(result.Message);
        var shoppingCartResource = _mapper.Map<ShoppingCart, ShoppingCartResource>(result.Resource);
        return Ok(shoppingCartResource);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a shopping cart",
        Description = "Delete a shopping cart",
        Tags = new[] { "Shopping Carts" })]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _shoppingCartService.DeleteAsync(id);
        if(!result.Success)
            return BadRequest(result.Message);
        var shoppingCartResource = _mapper.Map<ShoppingCart, ShoppingCartResource>(result.Resource);
        return Ok(shoppingCartResource);
    }
}