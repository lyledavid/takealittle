using Takealittle.Application.Common.Interfaces.Authentication;

namespace Takealittle.Api.Services;

public class AuthenticatedUserService : IAuthenticatedUserService
{
    public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
    {
        User = httpContextAccessor.HttpContext?.User.Claims
            .Where(x => x.Type.EndsWith("emailaddress", StringComparison.Ordinal))
            .Select(x => x.Value)
            .FirstOrDefault();
    }

    public string? User { get; }
}