using System.ComponentModel.DataAnnotations;

namespace Auth.Core.DTO.AuthDto;

public class LoginUser
{
    [Required] [Display(Name = "Email")] public string? Email { get; set; }
    [Required] [Display(Name = "Password")]public string? Password { get; set; }

    public bool Remember { get; set; }
}