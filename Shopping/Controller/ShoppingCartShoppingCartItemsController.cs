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

public class ShoppingCartShoppingCartItemsController: ControllerBase
{
    private readonly IShoppingCartItemService _shoppingCartItemService;
    private readonly IMapper _mapper;
    public ShoppingCartShoppingCartItemsController(IShoppingCartItemService shoppingCartItemService, IMapper mapper)
    {
        _shoppingCartItemService = shoppingCartItemService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all shopping cart items",
        Description = "List of shopping cart items already stored",
        Tags = new[] { "Shopping Cart Items" })]
    public async Task<IEnumerable<ShoppingCartItemResource>> GetAllByShoppingCartIdAsync(int shoppingCartId)
    {
        var shoppingCartItems = await _shoppingCartItemService.ListByShoppingCartIdAsync(shoppingCartId);
        var resources = _mapper.Map<IEnumerable<ShoppingCartItem>, IEnumerable<ShoppingCartItemResource>>(shoppingCartItems);
        return resources;
    }
}