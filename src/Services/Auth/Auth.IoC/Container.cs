using Auth.Core.Database;
using Auth.Core.Interfaces;
using Auth.Core.Models;
using Auth.Core.Policies;
using Auth.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.IoC;

public static class Container
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MySqlConnection");
        services.AddDbContext<AuthDbContext>(opt =>
            opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddIdentity<AppUser, IdentityRole>()
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

        services.Configure<IdentityOptions>(opt =>
        {
            opt.Password.RequiredLength = 8;
            opt.Password.RequireLowercase = true;
            opt.Password.RequireUppercase = true;
            opt.Password.RequireNonAlphanumeric = true;

            opt.User.RequireUniqueEmail = true;
            opt.User.AllowedUserNameCharacters = default;
        });

        services.AddTransient<IPasswordValidator<AppUser>, CustomPasswordPolicies>();
        services.AddTransient<IUserValidator<AppUser>, CustomUserPolicies>();

        services.AddScoped<IAuthServices, AuthServices>();
        
        return services;
    }
}