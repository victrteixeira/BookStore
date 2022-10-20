using Auth.Core.DTO.AccountDto;
using Auth.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountServices _accountServices;

    public AccountController(IAccountServices accountServices)
    {
        _accountServices = accountServices;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("login")]
    public async Task<IActionResult> Login(LoginUser login)
    {
        var result = await _accountServices.LoginAsync(login);
        if (!result)
            return BadRequest();

        return Ok();
    }

    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> Logout()
    {
        var result = await _accountServices.Logout();
        if (!result) return BadRequest();

        return Ok();
    }
}