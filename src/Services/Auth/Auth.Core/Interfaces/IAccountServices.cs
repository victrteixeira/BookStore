using Auth.Core.DTO.AccountDto;

namespace Auth.Core.Interfaces;

public interface IAccountServices
{
    Task<bool> LoginAsync(LoginUser loginUserDto);
    Task<bool> Logout();
}