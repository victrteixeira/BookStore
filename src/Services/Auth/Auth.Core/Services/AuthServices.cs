using Auth.Core.DTO.AuthDto;
using Auth.Core.Interfaces;
using Auth.Core.Models;
using Auth.Core.Utils.Constants;
using Auth.Core.Utils.Exceptions;
using Auth.Core.Utils.Messages;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Auth.Core.Services;

public class AuthServices : IAuthServices
{
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IRoleServices _roleServices;

    public AuthServices(IMapper mapper, UserManager<AppUser> userManager, IRoleServices roleServices, SignInManager<AppUser> signInManager)
    {
        _mapper = mapper;
        _userManager = userManager;
        _roleServices = roleServices;
        _signInManager = signInManager;
    }

    public async Task<ReadUser> CreateUserAsync(CreateUser command)
    {
        var appUser = _mapper.Map<AppUser>(command);
        
        var userManager = await _userManager.CreateAsync(appUser, command.Password);

        var roleManager = await _roleServices.ManageUserInRole(appUser.UserName, Roles.Administrator);

        if (!userManager.Succeeded || !roleManager.Succeeded)
            throw new AuthException(IdentityMessage.IdentityMessageBuilder(userManager.Errors, roleManager.Errors));

        return _mapper.Map<ReadUser>(appUser);
    }

    public async Task<ReadUser> UpdateUserAsync(UpdateUser command)
    {
        var user = await _userManager.FindByIdAsync(command.Id);
        if (user is null)
            throw new RequestException("User not found or don't exist.");

        user.UserName = command.UserName;
        user.Email = command.Email;
        user.Age = command.Age;
        user.FirstName = command.FirstName;
        user.LastName = command.LastName;

        var userManager = await _userManager.UpdateAsync(user);
        if (!userManager.Succeeded)
            throw new AuthException(IdentityMessage.IdentityMessageBuilder(userManager.Errors));
        
        return _mapper.Map<ReadUser>(user);
    }

    public async Task<ReadUser> RegisterAsync(CreateUser command)
    {
        bool pwdConfirmed = command.Password.Equals(command.ConfirmPassword);
        if (!pwdConfirmed)
            throw new RequestException("Password don't match. Please review and try again.");
        
        var regularUser = _mapper.Map<AppUser>(command);

        var userManager = await _userManager.CreateAsync(regularUser, command.Password);

        if (!userManager.Succeeded)
            throw new AuthException(IdentityMessage.IdentityMessageBuilder(userManager.Errors));
        
        var roleManager = await _roleServices.ManageUserInRole(regularUser.UserName, Roles.User);
        if (!roleManager.Succeeded)
            throw new RoleException(IdentityMessage.IdentityMessageBuilder(roleManager.Errors));

        return _mapper.Map<ReadUser>(regularUser);
    }

    public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordUser command)
    {
        var user = await _userManager.FindByEmailAsync(command.Email);
        if(user is null)
            throw new RequestException("User not found or don't exist.");

        var checkPwd = await _userManager.CheckPasswordAsync(user, command.OldPassword);
        if (!checkPwd)
            throw new PasswordException("Email or password are incorrect.");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        var result = await _userManager.ResetPasswordAsync(user, token, command.Password);
        if (!result.Succeeded)
            throw new AuthException(IdentityMessage.IdentityMessageBuilder(result.Errors));

        return result;
    }

    public async Task<IdentityResult> LoginAsync(LoginUser command)
    {
        var appUser = await _userManager.FindByEmailAsync(command.Email);
        
        if (appUser is null) throw new RequestException("Provided user don't exist. Please make a register.");
        await _signInManager.SignOutAsync();
        
        var result = await _signInManager.PasswordSignInAsync(appUser, command.Password, command.Remember, false);

        if (!result.Succeeded) throw new PasswordException("Provided credentials were incorrect or user don't exist.");

        return IdentityResult.Success;
    }

    public async Task DeleteUserAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
            throw new RequestException("User not found or don't exist.");

        await _userManager.DeleteAsync(user);
    }
    
    public async Task<bool> Logout()
    {
        await _signInManager.SignOutAsync();
        return true;
    }
}