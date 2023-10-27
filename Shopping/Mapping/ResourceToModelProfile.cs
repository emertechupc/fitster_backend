using AutoMapper;
using Fitster.API.Shopping.Domain.Models;
using Fitster.API.Shopping.Resources;

namespace Fitster.API.Shopping.Mapping;
public class ResourcetoModelProfile : Profile
{
    public ResourcetoModelProfile()
    {
        CreateMap<SaveShoppingCartResource, ShoppingCart>();
        CreateMap<ShoppingCartItemResource, ShoppingCartItem>();
    }
}