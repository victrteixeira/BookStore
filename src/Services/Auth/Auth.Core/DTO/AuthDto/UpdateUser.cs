using System.ComponentModel.DataAnnotations;

namespace Auth.Core.DTO.AuthDto;

public class UpdateUser
{
    [Required] public string OlderEmail { get; set; } = null!;
    
    [Required] public string UserName { get; set; } = null!;

    [Required] [EmailAddress] public string Email { get; set; } = null!;

    [Required] public string Password { get; set; } = null!;
}