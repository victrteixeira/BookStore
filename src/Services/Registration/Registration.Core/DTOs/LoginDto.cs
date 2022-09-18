using System.ComponentModel.DataAnnotations;

namespace Registration.Core.DTOs;

public class LoginDto
{
    [Required]
    public string Email { get; set; } = null!;
    
    [Required]
    public string Password { get; set; } = null!;
}