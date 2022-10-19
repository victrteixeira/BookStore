﻿using Auth.Core.DTOs;
using Auth.Core.Models;

namespace Auth.Core.Interfaces;

public interface IAuthServices
{
    Task<AppUser?> CreateUserAsync(CreateUserDto user);
    Task<AppUser?> UpdateUserAsync(UpdateUserDto newUser);
}