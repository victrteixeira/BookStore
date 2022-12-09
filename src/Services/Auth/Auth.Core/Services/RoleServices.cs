using Auth.Core.Interfaces;
using Auth.Core.Models;
using Auth.Core.Utils.Exceptions;
using Auth.Core.Utils.Messages;
using Microsoft.AspNetCore.Identity;

namespace Auth.Core.Services;

public class RoleServices : IRoleServices
{
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<AppUser> _userManager;

    public RoleServices(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task<IdentityResult> ManageUserInRole(string username, string role)
    {
        var currentUser = await _userManager.FindByNameAsync(username);
        if (currentUser is null)
            throw new RequestException("User to associated to a role was not found or don't exist.");
        
        var fetched = await _userManager.IsInRoleAsync(currentUser, role);
        if (fetched)
            return IdentityResult.Failed(new IdentityErrorDescriber().UserAlreadyInRole(nameof(role)));

        var roleExist = await _roleManager.FindByNameAsync(role);
        if (roleExist is null)
        {
            await CreateRoleAsync(role);
        }

        var res = await _userManager.AddToRoleAsync(currentUser, role);
        if (!res.Succeeded)
            throw new RoleException(IdentityMessage.IdentityMessageBuilder(res.Errors));

        return res;
    }
    
    private async Task<IdentityResult> CreateRoleAsync(string roleName)
    {
        var role = new IdentityRole(roleName);
        var result = await _roleManager.CreateAsync(role);

        if (!result.Succeeded)
            throw new RoleException(IdentityMessage.IdentityMessageBuilder(result.Errors));

        return result;
    }
}