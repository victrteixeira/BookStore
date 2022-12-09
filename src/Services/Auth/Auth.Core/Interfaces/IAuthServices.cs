using Auth.Core.DTO.AuthDto;
using Microsoft.AspNetCore.Identity;

namespace Auth.Core.Interfaces;

public interface IAuthServices
{
    Task<ReadUser> CreateUserAsync(CreateUser command);
    Task<ReadUser> UpdateUserAsync(UpdateUser command);
    Task<ReadUser> RegisterAsync(CreateUser command);
    Task<IdentityResult> ChangePasswordAsync(ChangePasswordUser command);
    Task<IdentityResult> LoginAsync(LoginUser command);
    Task DeleteUserAsync(string email);
    Task<bool> Logout();
}