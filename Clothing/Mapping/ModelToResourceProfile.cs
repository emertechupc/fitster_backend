using AutoMapper;
using Fitster.API.Clothing.Domain.Models;
using Fitster.API.Clothing.Resources;

namespace Fitster.API.Clothing.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Product, ProductResource>();
    }
}
