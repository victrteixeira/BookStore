using System.ComponentModel.DataAnnotations;

namespace Auth.Core.DTOs;

public class UpdateUserDto
{
    [Required] public string OlderEmail { get; set; } = null!;
    
    [Required] public string Name { get; set; } = null!;

    [Required] [EmailAddress] public string Email { get; set; } = null!;

    [Required] public string Password { get; set; } = null!;
}