using AutoMapper;
using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Clothing.Resources;

namespace Fitster.API.Clothing.Mapping;
public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveProductResource, Product>();
    }
}