using Auth.Core.DTOs;
using Auth.Core.Interfaces;
using Auth.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Auth.Core.Services;

public class AuthServices : IAuthServices
{
    private readonly UserManager<AppUser> _userManager;

    public AuthServices(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<AppUser?> CreateUserAsync(UserDto user)
    {
        var appUser = new AppUser { UserName = user.Name, Email = user.Email };
        var result = await _userManager.CreateAsync(appUser, user.Password);
        
        if (!result.Succeeded)
            return null; // TODO > Should return the identity error list

        return appUser;
    }
    
    // TODO > AppUser validations
}