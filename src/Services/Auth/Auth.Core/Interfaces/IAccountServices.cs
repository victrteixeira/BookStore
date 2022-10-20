using Auth.Core.DTOs;

namespace Auth.Core.Interfaces;

public interface IAccountServices
{
    Task<bool> LoginAsync(LoginUserDto loginUserDto);
    Task<bool> Logout();
}