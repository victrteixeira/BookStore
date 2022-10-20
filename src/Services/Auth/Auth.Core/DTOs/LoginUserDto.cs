using System.ComponentModel.DataAnnotations;

namespace Auth.Core.DTOs;

public class LoginUserDto
{
    [Required] public string? Email { get; set; }
    [Required] public string? Password { get; set; }

    public bool Remember { get; set; }
}