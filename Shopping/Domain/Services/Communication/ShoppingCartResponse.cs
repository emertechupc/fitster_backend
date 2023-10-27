using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shared.Domain.Services.Communication;

namespace Fitster.API.Shopping.Domain.Services.Communication;

public class ShoppingCartResponse : BaseResponse<ShoppingCart>
{
    public ShoppingCartResponse(ShoppingCart resource) : base(resource)
    {
    }

    public ShoppingCartResponse(string message) : base(message)
    {
    }
}