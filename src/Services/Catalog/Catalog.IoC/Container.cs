using Catalog.Core.Interfaces;
using Catalog.Infra.Database;
using Catalog.Infra.Interfaces;
using Catalog.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.IoC;

public static class Container
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CatalogConnection");

        services.AddDbContext<CatalogContext>(opt => opt.UseSqlServer(connectionString));

        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IRedisCacheRepository, RedisCacheRepository>();
        services.AddStackExchangeRedisCache(opt =>
        {
            opt.Configuration = configuration["CacheSettings:ConnectionString"];
        });
        

        return services;
    }
}