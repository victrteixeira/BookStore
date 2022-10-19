using Auth.Core.DTOs;
using Auth.Core.Interfaces;
using Auth.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Auth.Core.Services;

public class AuthServices : IAuthServices
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IPasswordHasher<AppUser> _passwordHasher;

    public AuthServices(UserManager<AppUser> userManager, IPasswordHasher<AppUser> passwordHasher)
    {
        _userManager = userManager;
        _passwordHasher = passwordHasher;
    }

    // TODO > AppUser validations
    public async Task<AppUser?> CreateUserAsync(CreateUserDto user)
    {
        var appUser = new AppUser { UserName = user.Name, Email = user.Email };
        var result = await _userManager.CreateAsync(appUser, user.Password);
        
        if (!result.Succeeded)
            return null; // TODO > Should return the identity error list

        return appUser;
    }

    public async Task<AppUser?> UpdateUserAsync(UpdateUserDto newUser)
    {
        var user = await _userManager.FindByEmailAsync(newUser.OlderEmail);
        if (user is null)
            return null;

        user.UserName = newUser.Name;
        user.Email = newUser.Email;
        user.PasswordHash = _passwordHasher.HashPassword(user, newUser.Password);

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
            return null;

        return user;
    }

    public async Task<bool> DeleteUserAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
            return false;

        await _userManager.DeleteAsync(user);
        return true;
    }
}