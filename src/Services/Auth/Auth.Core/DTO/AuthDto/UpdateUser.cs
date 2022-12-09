using System.ComponentModel.DataAnnotations;

namespace Auth.Core.DTO.AuthDto;

public class UpdateUser
{
    [Required] public string Id { get; set; } = null!;
    
    [Required] public string UserName { get; set; } = null!;

    [Required] [EmailAddress] public string Email { get; set; } = null!;
    
    [Required] public string FirstName { get; set; } = null!;

    [Required] public string LastName { get; set; } = null!;
    
    [Required] public int Age { get; set; }
}