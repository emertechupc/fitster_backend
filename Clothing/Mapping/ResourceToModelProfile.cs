using AutoMapper;
using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Clothing.Resources;

namespace Fitster.API.Clothing.Mapping;
public class ResourcetoModelProfile : Profile
{
    public ResourcetoModelProfile()
    {
        CreateMap<SaveProductResource, Product>();
        CreateMap<SaveProductDetailResource, ProductDetail>();
    }
}