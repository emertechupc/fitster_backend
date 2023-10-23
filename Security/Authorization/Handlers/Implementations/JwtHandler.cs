using Fitster.API.Security.Authorization.Handlers.Interfaces;
using Fitster.API.Security.Authorization.Settings;
using Fitster.API.Shared.Persistence.Contexts;
using Fitster.API.Users.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Fitster.API.Security.Authorization.Handlers.Interfaces;

namespace Fitster.API.Security.Authorization.Handlers.Implementations;

public class JwtHandler : IJwtHandler
{
    private readonly AppSettings _appSettings;

    public JwtHandler(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public string GenerateToken(User user)
    {

    }
}