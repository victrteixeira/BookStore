using System.ComponentModel.DataAnnotations;

namespace Auth.Core.DTO.AccountDto;

public class LoginUser
{
    [Required] public string? Email { get; set; }
    [Required] public string? Password { get; set; }

    public bool Remember { get; set; }
}