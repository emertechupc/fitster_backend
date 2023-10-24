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

public class ProductDetailsController: ControllerBase
{
    private readonly IProductDetailService _productDetailService;
    private readonly IMapper _mapper;
    public ProductDetailsController(IProductDetailService productDetailService, IMapper mapper)
    {
        _productDetailService = productDetailService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all product details",
        Description = "List of product details already stored",
        Tags = new[] { "ProductDetails" })]
    public async Task<IEnumerable<ProductDetailResource>> GetAllAsync()
    {
        var productDetails = await _productDetailService.ListAsync();
        var resources = _mapper.Map<IEnumerable<ProductDetail>, IEnumerable<ProductDetailResource>>(productDetails);
        return resources;
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Get Product Detail By Id",
        Description = "Get a product detail from the database identified by its id",
        Tags = new[] { "ProductDetails" })]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _productDetailService.GetByIdAsync(id);
        if(!result.Success)
            return BadRequest(result.Message);
        return Ok(result.Resource);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new product detail",
        Description = "Create a new product detail",
        Tags = new[] { "ProductDetails" })]
    public async Task<IActionResult> PostAsync([FromBody] SaveProductDetailResource resource)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var productDetail = _mapper.Map<SaveProductDetailResource, ProductDetail>(resource);
        var result = await _productDetailService.SaveAsync(productDetail);
        if(!result.Success)
            return BadRequest(result.Message);
        var productDetailResource = _mapper.Map<ProductDetail, ProductDetailResource>(result.Resource);
        return Ok(productDetailResource);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Update a product detail",
        Description = "Update a product detail",
        Tags = new[] { "ProductDetails" })]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductDetailResource resource)
    {
        var productDetail = _mapper.Map<SaveProductDetailResource, ProductDetail>(resource);
        var result = await _productDetailService.UpdateAsync(id, productDetail);
        if(!result.Success)
            return BadRequest(result.Message);
        var productDetailResource = _mapper.Map<ProductDetail, ProductDetailResource>(result.Resource);
        return Ok(productDetailResource);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete a product detail",
        Description = "Delete a product detail",
        Tags = new[] { "ProductDetails" })]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _productDetailService.DeleteAsync(id);
        if(!result.Success)
            return BadRequest(result.Message);
        var productDetailResource = _mapper.Map<ProductDetail, ProductDetailResource>(result.Resource);
        return Ok(productDetailResource);
    }
}