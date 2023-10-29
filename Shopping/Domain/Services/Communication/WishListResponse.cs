using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shared.Domain.Services.Communication;

namespace Fitster.API.Shopping.Domain.Services.Communication;

public class WishListResponse : BaseResponse<WishList>
{
    public WishListResponse(WishList resource) : base(resource)
    {
    }

    public WishListResponse(string message) : base(message)
    {
    }
}