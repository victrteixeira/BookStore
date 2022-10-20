using System.ComponentModel.DataAnnotations;

namespace Auth.Core.DTO.RoleDto;

public class InsertRoleInUser
{
    [Required] public string Username { get; set; } = null!;
    [Required] public string Role { get; set; } = null!;
}