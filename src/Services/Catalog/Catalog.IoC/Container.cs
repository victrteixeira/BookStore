using System.Reflection;
using Catalog.Application.AutoMapper;
using Catalog.Application.Commands.Create;
using Catalog.Core.Interfaces;
using Catalog.Infra.Database;
using Catalog.Infra.Repositories;
using MediatR;
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
        services.AddScoped<IGenreRepository, GenreRepository>();
        
        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateBookCommandHandler).Assembly);
        services.AddAutoMapper(typeof(AuthorMappers));

        return services;
    }
}