using AutoMapper;
using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Clothing.Domain.Services;
using Fitster.API.Clothing.Resources;
using Fitster.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Fitster.API.Reports.Controllers;

[Produces("application/json")]
[ApiController]
[Route("/api/v1/[controller]")]
public class ProductsController: ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all products",
        Description = "List of products already stored",
        Tags = new[] { "Products" })]
    public async Task<IEnumerable<ProductResource>> GetAllAsync()
    {
        var products = await _productService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        return resources;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get Product By Id",
        Description = "Get a product from the database identified by its id",
        Tags = new[] { "Products" })]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _productService.GetById(id);
        if(!result.Success)
            return BadRequest(result.Message);
        return Ok(result.Resource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new product",
        Description = "Create a new product",
        Tags = new[] { "Products" })]
    public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var product = _mapper.Map<SaveProductResource, Product>(resource);
        var result = await _productService.SaveAsync(product);

        if(!result.Success)
            return BadRequest(result.Message);

        var productResource =_mapper.Map<Product, ProductResource>(result.Resource);
        return Ok(productResource);
    }
    
    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a product",
        Description = "Update a product",
        Tags = new[] { "Products" })]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var product = _mapper.Map<SaveProductResource, Product>(resource);
        var result = await _productService.UpdateAsync(id, product);

        if(!result.Success)
            return BadRequest(result.Message);

        var productResource =_mapper.Map<Product, ProductResource>(result.Resource);
        return Ok(productResource);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a product",
        Description = "Delete a product",
        Tags = new[] { "Products" })]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _productService.DeleteAsync(id);

        if(!result.Success)
            return BadRequest(result.Message);

        var productResource =_mapper.Map<Product, ProductResource>(result.Resource);
        return Ok(productResource);
    }

}