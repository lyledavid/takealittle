using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Takealittle.Api;

/// <summary>
/// OAuth configuration
/// </summary>
public static class OAuthConfig
{
    /// <summary>
    /// Add OAuth configuration to the services
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddOAuthConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        
        }).AddJwtBearer(options =>
        {
            options.Authority = "https://accounts.google.com";
            options.Audience = configuration.GetValue<string>("GoogleAuth:ClientId");
        
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                NameClaimType = ClaimTypes.NameIdentifier
            };
        });

        return services;
    }
}