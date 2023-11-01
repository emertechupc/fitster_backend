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
[Route("/api/v1/orders/{orderId}/orderitems")]
public class OrderOrderitemsController: ControllerBase
{
    private readonly IOrderItemService _orderItemService;
    private readonly IMapper _mapper;
    public OrderOrderitemsController(IOrderItemService orderItemService, IMapper mapper)
    {
        _orderItemService = orderItemService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all order items",
        Description = "List of order items already stored",
        Tags = new[] { "Order Items" })]
    public async Task<IEnumerable<OrderItemResource>> GetAllByOrderIdAsync(int orderId)
    {
        var orderItems = await _orderItemService.ListByOrderIdAsync(orderId);
        var resources = _mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemResource>>(orderItems);
        return resources;
    }
}