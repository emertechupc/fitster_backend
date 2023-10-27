using AutoMapper;
using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Resources;

namespace Fitster.API.Shopping.Mapping;
public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveShoppingCartResource, ShoppingCart>();
        CreateMap<SaveShoppingCartItemResource, ShoppingCartItem>();
        CreateMap<SaveOrderResource, Order>();
        CreateMap<SaveOrderItemResource, OrderItem>();
    }
}