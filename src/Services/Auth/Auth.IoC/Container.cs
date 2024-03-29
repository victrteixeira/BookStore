﻿using Auth.Core.Database;
using Auth.Core.Interfaces;
using Auth.Core.Models;
using Auth.Core.Policies;
using Auth.Core.Services;
using Auth.Core.Utils.AutoMapper;
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
            .AddErrorDescriber<CustomIdentityErrorDescriber>()
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();
        
        services.ConfigureApplicationCookie(opt =>
        {
            opt.Cookie.Name = "BookStore.Authentication";
            opt.ExpireTimeSpan = TimeSpan.FromMinutes(10);
            opt.SlidingExpiration = true;
            
            opt.LoginPath = "/api/Account/Login";
        });


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
        services.AddScoped<IRoleServices, RoleServices>();

        services.AddAutoMapper(typeof(AuthMapper));
        
        return services;
    }
}