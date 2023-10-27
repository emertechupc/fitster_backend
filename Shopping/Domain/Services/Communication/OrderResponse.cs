using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shared.Domain.Services.Communication;

namespace Fitster.API.Shopping.Domain.Services.Communication;

public class OrderResponse : BaseResponse<Order>
{
    public OrderResponse(Order resource) : base(resource)
    {
    }

    public OrderResponse(string message) : base(message)
    {
    }
}