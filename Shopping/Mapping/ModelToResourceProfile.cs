using AutoMapper;
using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Resources;

namespace Fitster.API.Shopping.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<ShoppingCart, ShoppingCartResource>();
        CreateMap<ShoppingCartItem, ShoppingCartItemResource>();
        CreateMap<Order, OrderResource>();
        CreateMap<OrderItem, OrderItemResource>();
        CreateMap<WishList, WishListResource>();
        CreateMap<WishListItem, WishListItemResource>();
    }
}
