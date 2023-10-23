using Fitster.API.Shared.Domain.Services.Communication;
using Fitster.API.Users.Domain.Models;

namespace Fitster.API.Users.Domain.Services.Communication;

public class UserResponse : BaseResponse<User>
{
    public UserResponse(User user): base(user) {}
    
    public UserResponse(string message): base(message) {}
    
}