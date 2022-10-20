using Auth.Core.DTOs;
using Auth.Core.Interfaces;
using Auth.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Auth.Core.Services;

public class AccountServices : IAccountServices
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountServices(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> LoginAsync(LoginUserDto loginUserDto)
    {
        var appUser = await _userManager.FindByEmailAsync(loginUserDto.Email);
        
        if (appUser is null) return false;

        await _signInManager.SignOutAsync();
        var result = await _signInManager.PasswordSignInAsync(appUser, loginUserDto.Password, loginUserDto.Remember, false);

        if (!result.Succeeded) return false;

        return true;
    }

    public async Task<bool> Logout()
    {
        await _signInManager.SignOutAsync();
        return true;
    }
}