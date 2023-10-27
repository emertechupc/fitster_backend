using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shared.Domain.Services.Communication;

namespace Fitster.API.Shopping.Domain.Services.Communication;

public class ShoppingCartItemResponse : BaseResponse<ShoppingCartItem>
{
    public ShoppingCartItemResponse(ShoppingCartItem resource) : base(resource)
    {
    }

    public ShoppingCartItemResponse(string message) : base(message)
    {
    }
}