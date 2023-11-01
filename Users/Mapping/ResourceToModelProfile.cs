using AutoMapper;
using Fitster.API.Security.Domain.Services.Communication;
using Fitster.API.Users.Domain.Models;

namespace Fitster.API.Users.Mapping;
public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<RegisterRequest, User>();

        CreateMap<UpdateRequest, User>()
            .ForAllMembers(options => options.Condition(
                (source, target, property) =>
                {
                    if (property == null) return false;
                    if (property.GetType() == typeof(string) && string.IsNullOrEmpty((string)property)) return false;
                    return true;
                }
            ));
    }
}