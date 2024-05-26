using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Takealittle.Application.Common.Interfaces.Persistence;
using Takealittle.Infrastructure.Authentication;
using Takealittle.Infrastructure.Persistence;
using Takealittle.Infrastructure.Persistence.Repositories;

namespace Takealittle.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<GoogleAuth>(configuration.GetSection(GoogleAuth.SectionName));
        services.AddDbContext<TakealittleDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductImageRepository, ProductImageRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();
        return services;
    }
}