using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Shared.Domain.Services.Communication;

namespace Fitster.API.Clothing.Domain.Services.Communication;

public class ProductResponse : BaseResponse<Product>
{
    public ProductResponse(Product resource) : base(resource)
    {
    }

    public ProductResponse(string message) : base(message)
    {
    }
}