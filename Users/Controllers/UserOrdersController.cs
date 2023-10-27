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
public class UserOrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;
    public UserOrdersController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all orders by User Id",
        Description = "List of orders already stored by User Id",
        Tags = new[] { "Orders" })]
    public async Task<IEnumerable<OrderResource>> GetAllOrdersByUserIdAsync(int userId)
    {
        var orders = await _orderService.GetAllByUserId(userId);
        var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
        return resources;
    }
}