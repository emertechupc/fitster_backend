using AutoMapper;
using Fitster.API.Clothing.Resources;
using Fitster.API.Security.Domain.Services.Communication;
using Fitster.API.Users.Domain.Models;

namespace Fitster.API.Users.Mapping;
public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }
}