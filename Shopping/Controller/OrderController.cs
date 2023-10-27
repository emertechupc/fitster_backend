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
public class OrderController: ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;
    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all orders",
        Description = "List of orders already stored",
        Tags = new[] { "Orders" })]
    public async Task<IEnumerable<OrderResource>> GetAllAsync()
    {
        var orders = await _orderService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
        return resources;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get Order By Id",
        Description = "Get an order from the database identified by its id",
        Tags = new[] { "Orders" })]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _orderService.GetById(id);
        if(!result.Success)
            return BadRequest(result.Message);
        return Ok(result.Resource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new order",
        Description = "Create a new order",
        Tags = new[] { "Orders" })]
    public async Task<IActionResult> PostAsync([FromBody] SaveOrderResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var order = _mapper.Map<SaveOrderResource, Order>(resource);
        var result = await _orderService.SaveAsync(order);
        if(!result.Success)
            return BadRequest(result.Message);
        var orderResource = _mapper.Map<Order, OrderResource>(result.Resource);
        return Ok(orderResource);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update an existing order",
        Description = "Update an existing order",
        Tags = new[] { "Orders" })]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOrderResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var order = _mapper.Map<SaveOrderResource, Order>(resource);
        var result = await _orderService.UpdateAsync(id, order);
        if(!result.Success)
            return BadRequest(result.Message);
        var orderResource = _mapper.Map<Order, OrderResource>(result.Resource);
        return Ok(orderResource);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete an existing order",
        Description = "Delete an existing order",
        Tags = new[] { "Orders" })]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _orderService.DeleteAsync(id);
        if(!result.Success)
            return BadRequest(result.Message);
        var orderResource = _mapper.Map<Order, OrderResource>(result.Resource);
        return Ok(orderResource);
    }
}