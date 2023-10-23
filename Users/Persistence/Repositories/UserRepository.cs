using Fitster.API.Shared.Persistence.Contexts;
using Fitster.API.Shared.Persistence.Repositories;
using Fitster.API.Users.Domain.Models;
using Fitster.API.Users.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fitster.API.Users.Persistence.Repositories;

public class UserRepository: BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
        
    }

}