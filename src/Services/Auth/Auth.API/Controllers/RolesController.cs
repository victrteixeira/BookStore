using Auth.Core.DTO.RoleDto;
using Auth.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleServices _roleServices;

    public RoleController(IRoleServices roleServices)
    {
        _roleServices = roleServices;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateRole(CreateRole role)
    {
        var res = await _roleServices.CreateRoleAsync(role);
        if (!res)
            return BadRequest();

        return Ok();
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteRole(string roleId)
    {
        var res = await _roleServices.DeleteRoleAsync(roleId);
        if (!res)
            return BadRequest();

        return Ok();
    }

    [HttpPost]
    [Route("UserInRole")]
    public async Task<IActionResult> EnrollUserInRole(InsertRoleInUser model)
    {
        var res = await _roleServices.ManageUserInRole(model.Username, model.Role);
        if (!res)
            return BadRequest();

        return Ok();
    }
}