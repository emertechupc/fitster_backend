using AutoMapper;
using Fitster.API.Clothing.Resources;
using Fitster.API.Security.Authorization.Attributes;
using Fitster.API.Security.Domain.Services.Communication;
using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Domain.Services;
using Fitster.API.Shopping.Resources;
using Fitster.API.Users.Domain.Models;
using Fitster.API.Users.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Fitster.API.Users.Controllers;

[Produces("application/json")]
[ApiController]
[Route("/api/v1/users/{userId}/shoppingcart")]
public class UserShoppingCartController : ControllerBase
{
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IMapper _mapper;
    public UserShoppingCartController(IShoppingCartService shoppingCartService, IMapper mapper)
    {
        _shoppingCartService = shoppingCartService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get shopping carts by User Id",
        Description = "List of shopping carts already stored by User Id",
        Tags = new[] { "Shopping Carts" })]
    public async Task<IActionResult> GetShoppingCartByUserIdAsync(int userId)
    {
        var result = await _shoppingCartService.GetByUserId(userId);
        if(!result.Success)
            return BadRequest(result.Message);
        return Ok(result.Resource);
    }
}