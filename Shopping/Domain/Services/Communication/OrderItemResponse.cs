using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shared.Domain.Services.Communication;

namespace Fitster.API.Shopping.Domain.Services.Communication;

public class OrderItemResponse : BaseResponse<OrderItem>
{
    public OrderItemResponse(OrderItem resource) : base(resource)
    {
    }

    public OrderItemResponse(string message) : base(message)
    {
    }
}