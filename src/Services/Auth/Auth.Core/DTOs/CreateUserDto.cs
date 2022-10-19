﻿using System.ComponentModel.DataAnnotations;

namespace Auth.Core.DTOs;

public class CreateUserDto
{
    [Required] public string UserName { get; set; } = null!;

    [Required] [EmailAddress] public string Email { get; set; } = null!;

    [Required] public string Password { get; set; } = null!;
}