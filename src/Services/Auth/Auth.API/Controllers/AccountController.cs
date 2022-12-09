using Auth.API.Utils;
using Auth.Core.DTO.AuthDto;
using Auth.Core.Interfaces;
using Auth.Core.Utils.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAuthServices _authServices;

    public AccountController(IAuthServices authServices) => _authServices = authServices;

    [HttpPost]
    [AllowAnonymous]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginUser command)
    {
        await _authServices.LoginAsync(command);
        var apiResponse = ApiResponse<string>.Success(command.Email, "The Login was successful.");
        return Ok(apiResponse);
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("Register")]
    public async Task<IActionResult> Register(CreateUser command)
    {
        var response = await _authServices.RegisterAsync(command);
        var apiResponse = ApiResponse<ReadUser>.Success(response, $"{command.FirstName}, your new user was registered successfully.");
        return Ok(apiResponse);
    }

    [HttpPut]
    [AuthorizeRoles(Roles.User, Roles.Administrator, Roles.Developer)]
    [Route("ChangePassword")]
    public async Task<IActionResult> ChangePassword(ChangePasswordUser command)
    {
        await _authServices.ChangePasswordAsync(command);
        return NoContent();
    }

    [HttpPost]
    [Authorize]
    [Route("LogOut")]
    public async Task<IActionResult> Logout()
    {
        var result = await _authServices.Logout();
        if (!result) return BadRequest();

        return Ok();
    }
}