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
public class OrderItemController: ControllerBase
{
    private readonly IOrderItemService _orderItemService;
    private readonly IMapper _mapper;
    public OrderItemController(IOrderItemService orderItemService, IMapper mapper)
    {
        _orderItemService = orderItemService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all order items",
        Description = "List of order items already stored",
        Tags = new[] { "Order Items" })]
    public async Task<IEnumerable<OrderItemResource>> GetAllAsync()
    {
        var orderItems = await _orderItemService.ListAsync();
        var resources = _mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemResource>>(orderItems);
        return resources;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get Order Item By Id",
        Description = "Get an order item from the database identified by its id",
        Tags = new[] { "Order Items" })]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _orderItemService.GetById(id);
        if(!result.Success)
            return BadRequest(result.Message);
        return Ok(result.Resource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new order item",
        Description = "Create a new order item",
        Tags = new[] { "Order Items" })]
    public async Task<IActionResult> PostAsync([FromBody] SaveOrderItemResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var orderItem = _mapper.Map<SaveOrderItemResource, OrderItem>(resource);
        var result = await _orderItemService.SaveAsync(orderItem);
        if(!result.Success)
            return BadRequest(result.Message);
        var orderItemResource = _mapper.Map<OrderItem, OrderItemResource>(result.Resource);
        return Ok(orderItemResource);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update an existing order item",
        Description = "Update an existing order item",
        Tags = new[] { "Order Items" })]    
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOrderItemResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var orderItem = _mapper.Map<SaveOrderItemResource, OrderItem>(resource);
        var result = await _orderItemService.UpdateAsync(id, orderItem);
        if(!result.Success)
            return BadRequest(result.Message);
        var orderItemResource = _mapper.Map<OrderItem, OrderItemResource>(result.Resource);
        return Ok(orderItemResource);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete an existing order item",
        Description = "Delete an existing order item",
        Tags = new[] { "Order Items" })]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _orderItemService.DeleteAsync(id);
        if(!result.Success)
            return BadRequest(result.Message);
        var orderItemResource = _mapper.Map<OrderItem, OrderItemResource>(result.Resource);
        return Ok(orderItemResource);
    }
}