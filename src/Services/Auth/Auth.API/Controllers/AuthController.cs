using Auth.API.Utils;
using Auth.Core.DTO.AuthDto;
using Auth.Core.Interfaces;
using Auth.Core.Utils.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthServices _authServices;
    public AuthController(IAuthServices authServices) => _authServices = authServices;

    [HttpPost]
    [AuthorizeRoles(Roles.Administrator, Roles.Developer)]
    [Route("Create")]
    public async Task<IActionResult> Create([FromBody] CreateUser command)
    {
        var serviceResponse = await _authServices.CreateUserAsync(command);
        var apiResponse = ApiResponse<ReadUser>.Success(serviceResponse, "User registered successfully.");
        
        return Ok(apiResponse);
    }

    [HttpPut]
    [AuthorizeRoles(Roles.Administrator, Roles.Developer)]
    [Route("Update")]
    public async Task<IActionResult> Update([FromBody] UpdateUser command)
    {
        var serviceResponse = await _authServices.UpdateUserAsync(command);
        var apiResponse = ApiResponse<ReadUser>.Success(serviceResponse, "User updated successfully.");

        return Ok(apiResponse);
    }

    [HttpDelete]
    [AuthorizeRoles(Roles.Administrator, Roles.Developer)]
    [Route("Delete")]
    public async Task<IActionResult> Delete(string email)
    {
        await _authServices.DeleteUserAsync(email);
        return NoContent();
    }
}