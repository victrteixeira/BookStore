using Auth.Core.DTOs;
using Auth.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthServices _authServices;

    public AuthController(IAuthServices authServices)
    {
        _authServices = authServices;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create([FromBody] UserDto user)
    {
        var newUser = await _authServices.CreateUserAsync(user);
        if (newUser == null)
            return BadRequest();
        
        return Ok(newUser);
    }
}