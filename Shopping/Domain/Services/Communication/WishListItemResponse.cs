using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shared.Domain.Services.Communication;

namespace Fitster.API.Shopping.Domain.Services.Communication;

public class WishListItemResponse : BaseResponse<WishListItem>
{
    public WishListItemResponse(WishListItem resource) : base(resource)
    {
    }

    public WishListItemResponse(string message) : base(message)
    {
    }
}