using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;

namespace Takealittle.Api;

public static class SwaggerConfig
{
    /// <summary>
    /// Add Swagger configuration to the services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
    {
        var securityScheme = new OpenApiSecurityScheme
        {
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.OAuth2,
            Description = "Bearer {access_token}",
            Scheme = "Bearer",
            BearerFormat = "JWT",
            Flows = new OpenApiOAuthFlows()
            {
                AuthorizationCode = new OpenApiOAuthFlow()
                {
                    AuthorizationUrl = new Uri("https://accounts.google.com/o/oauth2/v2/auth"),
                    TokenUrl = new Uri("https://oauth2.googleapis.com/token"),
                    Scopes = new Dictionary<string, string> {{"email", "email"}, {"profile", "profile"}}
                }
            },
            Extensions = new Dictionary<string, IOpenApiExtension>
            {
                {"x-tokenName", new OpenApiString("id_token")}
            },
        };
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "TakealittleAPI",
                Version = "v1",
                Description = "A simple shopping cart API",
            });
            opt.AddSecurityDefinition("BearerAuth", securityScheme);

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="BearerAuth"
                        }
                    },
                    new List<string> {"email", "profile"}
                }
            });
            
            opt.EnableAnnotations();
            
            
            var xmlFile = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name +".xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            opt.IncludeXmlComments(xmlPath);
        });

        return services;
    }
}
