using Auth.Core.DTO.RoleDto;
using Auth.Core.Interfaces;
using Auth.Core.Models;
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

    public async Task<bool> CreateRoleAsync(CreateRole model)
    {
        var role = new IdentityRole(model.RoleName);
        var result = await _roleManager.CreateAsync(role);
        
        if (!result.Succeeded)
            return false;

        return true;
    }
    
    public async Task<bool> DeleteRoleAsync(string roleId)
    {
        var role = await _roleManager.FindByIdAsync(roleId);
        if (role is null)
            return false;

        var result = await _roleManager.DeleteAsync(role);
        if (!result.Succeeded)
            return false;

        return true;
    }

    public async Task<bool> ManageUserInRole(string username, string role)
    {
        var currentUser = await _userManager.FindByNameAsync(username);
        if (currentUser is null)
            return false;
        
        var fetched = await _userManager.IsInRoleAsync(currentUser, role);
        if (fetched)
            return true;

        var roleExist = await _roleManager.FindByNameAsync(role);
        if (roleExist is null)
        {
            await CreateRoleAsync(new CreateRole { RoleName = role });
        }

        var res = await _userManager.AddToRoleAsync(currentUser, role);
        if (!res.Succeeded)
            return false;

        return true;
    }
}