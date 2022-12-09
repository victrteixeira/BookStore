﻿using Microsoft.AspNetCore.Identity;

namespace Auth.Core.Models;

public class AppUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public int Age { get; set; }
}