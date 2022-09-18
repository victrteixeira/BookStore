using System.ComponentModel.DataAnnotations;

namespace Registration.Core.DTOs;

public class RegisterDto
{
    [Required]
    [MinLength(3, ErrorMessage = "First Name is too short.")]
    [MaxLength(50, ErrorMessage = "First Name is too long.")]
    public string FirstName { get; set; } = null!;

    [Required]
    [MinLength(3, ErrorMessage = "First Name is too short.")]
    [MaxLength(50, ErrorMessage = "First Name is too long.")]
    public string LastName { get; set; } = null!;
    
    [MinLength(4, ErrorMessage = "Username is too short.")]
    [MaxLength(50, ErrorMessage = "Username is too long.")]
    public string? Username { get; set; }

    [MinLength(10, ErrorMessage = "Email is too short.")]
    [MaxLength(100, ErrorMessage = "Email is too long.")]
    public string? Email { get; set; }
    
    [Range(18, 100, ErrorMessage = "Age must be more than eighteen and less than one hundred.")]
    public int? Age { get; set; }

    [Required(ErrorMessage = "The Gender is a required field.")]
    public string Gender { get; set; } = null!;
}