using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Shared.Domain.Services.Communication;

namespace Fitster.API.Clothing.Domain.Services.Communication;

public class ProductDetailResponse: BaseResponse<ProductDetail>
{
    public ProductDetailResponse(ProductDetail resource) : base(resource)
    {
    }

    public ProductDetailResponse(string message) : base(message)
    {
    }
}