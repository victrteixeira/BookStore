using System.ComponentModel.DataAnnotations;

namespace Auth.Core.DTO.AuthDto;

public class ChangePasswordUser
{
    [Required] [Display(Name = "Email")] public string Email { get; set; } = null!;
    [Required] [Display(Name = "Old Password")] public string OldPassword { get; set; } = null!;
    [Required] [Display(Name = "New Password")] public string Password { get; set; } = null!;
}