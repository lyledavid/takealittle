using System.Reflection;
using FluentValidation;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Takealittle.Application.Common.Behaviours;

namespace Takealittle.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<IMapper, ServiceMapper>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}