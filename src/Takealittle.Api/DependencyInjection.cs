using Takealittle.Api.Common.Mapping;
using Takealittle.Api.Services;
using Takealittle.Application.Common.Interfaces.Authentication;

namespace Takealittle.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        services.AddHttpContextAccessor();
        services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
        return services;
    }
}