using Auth.Core.DTO.AuthDto;
using Auth.Core.Interfaces;
using Auth.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Auth.Core.Services;

public class AuthServices : IAuthServices
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IPasswordHasher<AppUser> _passwordHasher;
    private readonly IPasswordValidator<AppUser> _passwordValidator;
    private readonly IUserValidator<AppUser> _userValidator;

    public AuthServices(UserManager<AppUser> userManager, IPasswordHasher<AppUser> passwordHasher, IPasswordValidator<AppUser> passwordValidator, IUserValidator<AppUser> userValidator)
    {
        _userManager = userManager;
        _passwordHasher = passwordHasher;
        _passwordValidator = passwordValidator;
        _userValidator = userValidator;
    }

    // TODO > AppUser validations
    public async Task<AppUser?> CreateUserAsync(CreateUser user)
    {
        var appUser = new AppUser { UserName = user.UserName, Email = user.Email };
        var result = await _userManager.CreateAsync(appUser, user.Password);
        
        if (!result.Succeeded)
            return null; // TODO > Should return the identity error list

        return appUser;
    }

    public async Task<AppUser?> UpdateUserAsync(UpdateUser newUser)
    {
        var user = await _userManager.FindByEmailAsync(newUser.OlderEmail);
        if (user is null)
            return null;

        user.UserName = newUser.UserName;
        user.Email = newUser.Email;
        user.PasswordHash = _passwordHasher.HashPassword(user, newUser.Password);

        var passwordIsValid = await _passwordValidator.ValidateAsync(_userManager, user, newUser.Password);
        var emailIsValid = await _userValidator.ValidateAsync(_userManager, user);

        if (passwordIsValid == null || emailIsValid == null || !passwordIsValid.Succeeded || !emailIsValid.Succeeded)
            return null;

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