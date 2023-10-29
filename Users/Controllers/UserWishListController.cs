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
[Route("/api/v1/users/{userId}/orders")]
public class UserWishListController : ControllerBase
{
    private readonly IWishListService _wishListService;
    private readonly IMapper _mapper;
    public UserWishListController(IWishListService wishListService, IMapper mapper)
    {
        _wishListService = wishListService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get wish lists by User Id",
        Description = "List of wish lists already stored by User Id",
        Tags = new[] { "Wish Lists" })]
    public async Task<IActionResult> GetWishListByUserIdAsync(int userId)
    {
        var result = await _wishListService.GetByUserId(userId);
        if(!result.Success)
            return BadRequest(result.Message);
        return Ok(result.Resource);
    }
}