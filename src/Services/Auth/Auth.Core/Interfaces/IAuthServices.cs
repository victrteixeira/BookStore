using Auth.Core.DTO.AuthDto;
using Auth.Core.Models;

namespace Auth.Core.Interfaces;

public interface IAuthServices
{
    Task<AppUser?> CreateUserAsync(CreateUser user);
    Task<AppUser?> UpdateUserAsync(UpdateUser newUser);
    Task<bool> DeleteUserAsync(string email);
}