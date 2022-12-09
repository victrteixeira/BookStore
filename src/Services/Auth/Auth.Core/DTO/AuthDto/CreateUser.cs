using System.ComponentModel.DataAnnotations;

namespace Auth.Core.DTO.AuthDto;

public class CreateUser
{
    [Required(ErrorMessage = $"{nameof(UserName)} is required.")] 
    public string UserName { get; set; } = null!;

    [Required(ErrorMessage = $"{nameof(Email)} is required.")] 
    [EmailAddress] 
    public string Email { get; set; } = null!;
    
    [Required(ErrorMessage = $"{nameof(Password)} is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = $"{nameof(ConfirmPassword)} is required.")]
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; } = null!;

    [Required(ErrorMessage = $"{nameof(FirstName)} is required.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = $"{nameof(LastName)} is required.")] 
    public string LastName { get; set; } = null!;
    
    [Required(ErrorMessage = $"{nameof(Age)} is required.")]
    public int Age { get; set; }
}