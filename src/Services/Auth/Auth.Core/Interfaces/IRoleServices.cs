using Auth.Core.DTO.RoleDto;

namespace Auth.Core.Interfaces;

public interface IRoleServices
{
    Task<bool> CreateRoleAsync(CreateRole model);
    Task<bool> DeleteRoleAsync(string roleId);
    Task<bool> ManageUserInRole(string username, string role);
}