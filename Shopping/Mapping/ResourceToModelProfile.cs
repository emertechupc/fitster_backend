using AutoMapper;
using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Resources;

namespace Fitster.API.Shopping.Mapping;
public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveShoppingCartResource, ShoppingCart>();
        CreateMap<ShoppingCartItemResource, ShoppingCartItem>();
    }
}