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
[Route("/api/v1/products/{productId}/productdetails")]
public class ProductProductDetailsController: ControllerBase
{
    private readonly IProductDetailService _productDetailService;
    private readonly IMapper _mapper;
    public ProductProductDetailsController(IProductDetailService productDetailService, IMapper mapper)
    {
        _productDetailService = productDetailService;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all product details from a product",
        Description = "List of product details already stored from a product",
        Tags = new[] { "ProductDetails" })]
    public async Task<IEnumerable<ProductDetailResource>> GetAllByProductIdAsync(int productId)
    {
        var productDetails = await _productDetailService.ListByProductIdAsync(productId);
        var resources = _mapper.Map<IEnumerable<ProductDetail>, IEnumerable<ProductDetailResource>>(productDetails);
        return resources;
    }
}