using Auth.Core.DTO.AuthDto;
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
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] CreateUser user)
    {
        var newUser = await _authServices.CreateUserAsync(user);
        if (newUser is null)
            return BadRequest();
        
        return Ok(newUser);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateUser updateUser)
    {
        var updatedUser = await _authServices.UpdateUserAsync(updateUser);
        if (updatedUser is null)
            return BadRequest();

        return Ok(updatedUser);
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> Delete(string email)
    {
        var res = await _authServices.DeleteUserAsync(email);
        if (res is false)
            return BadRequest();

        return NoContent();
    }
}