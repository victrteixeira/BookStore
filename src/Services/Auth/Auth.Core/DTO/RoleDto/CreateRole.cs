using System.ComponentModel.DataAnnotations;

namespace Auth.Core.DTO.RoleDto;

public class CreateRole
{
    [Required]
    public string RoleName { get; set; } = "User";
}