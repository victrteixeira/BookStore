using Catalog.API.ExceptionMiddleware;
using Catalog.Application.Commands.Create;
using Catalog.Application.Commands.Delete;
using Catalog.Application.Commands.Update;
using Catalog.Application.Queries.ByAuthor;
using Catalog.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediatr;

    public AuthorController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorCommand command)
    {
        var mediatorResponse = await _mediatr.Send(command);
        var apiResponse = ApiResponse<Author>.Success(mediatorResponse, "Author created successfully.");

        return Ok(apiResponse);
    }
    
    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateAuthor([FromBody] UpdateAuthorCommand command)
    {
        var mediatorResponse = await _mediatr.Send(command);
        var apiResponse = ApiResponse<Book>.Success(mediatorResponse, "Author updated successfully.");
        
        return Ok(apiResponse);
    }
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        await _mediatr.Send(new RemoveAuthorCommand(id));
        return NoContent();
    }
    
    [HttpGet]
    [Route("GetAuthorById/{id:int}")]
    public async Task<IActionResult> GetAuthorById(int id)
    {
        var command = new GetAuthorByIdQuery(id);
        var response = await _mediatr.Send(command);
        
        return Ok(response);
    }

    [HttpGet]
    [Route("GetAuthorByName")]
    public async Task<IActionResult> GetAuthorByName([FromQuery] GetAuthorByNameQuery command)
    {
        var response = await _mediatr.Send(command);

        return Ok(response);
    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAllAuthors()
    {
        var command = new GetAllAuthorsQuery();
        var response = await _mediatr.Send(command);
        
        return Ok(response);
    }
}