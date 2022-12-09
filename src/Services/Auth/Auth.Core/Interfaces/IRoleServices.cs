using Microsoft.AspNetCore.Identity;

namespace Auth.Core.Interfaces;

public interface IRoleServices
{
    Task<IdentityResult> ManageUserInRole(string username, string role);
}