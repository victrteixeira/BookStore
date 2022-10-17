using Catalog.API.ExceptionMiddleware;
using Catalog.Application.Commands.Create;
using Catalog.Application.Commands.Delete;
using Catalog.Application.Commands.Update;
using Catalog.Application.Queries.ByBook;
using Catalog.Application.Responses.ForBook;
using Catalog.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("Api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IMediator _mediatr;

    public BookController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookCommand command)
    {
        var mediatorResponse = await _mediatr.Send(command);
        var apiResponse = ApiResponse<BookResponse>.Success(mediatorResponse, "Book created successfully.");
        
        return Ok(apiResponse);
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> UpdateBook([FromBody] UpdateBookCommand command)
    {
        var mediatorResponse = await _mediatr.Send(command);
        var apiResponse = ApiResponse<Book>.Success(mediatorResponse, "Book updated successfully.");
        
        return Ok(apiResponse);
    }
    
    [HttpDelete]
    [Route("delete/{id:int}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        await _mediatr.Send(new RemoveBookCommand(id));
        return NoContent();
    }
    
    [HttpGet]
    [Route("GetBookById/{id:int}")]
    public async Task<IActionResult> GetBookById(int id)
    {
        var command = new GetBookByIdQuery(id);
        var response = await _mediatr.Send(command);
        
        return Ok(response);
    }
    
    [HttpGet]
    [Route("GetBookByName")]
    public async Task<IActionResult> GetBookByName([FromQuery] string bookName)
    {
        var command = new GetBookByNameQuery(bookName);
        var response = await _mediatr.Send(command);

        return Ok(response);
    }
    
    [HttpGet]
    [Route("GetBooksByAuthor/{authorId:int}")]
    public async Task<IActionResult> GetBooksByAuthor([FromRoute] int authorId)
    {
        var command = new GetBooksByAuthorQuery(authorId);
        var response = await _mediatr.Send(command);

        return Ok(response);
    }
    
    [HttpGet]
    [Route("GetBooksByLanguage")]
    public async Task<IActionResult> GetBooksByLanguage([FromQuery] string language)
    {
        var command = new GetBooksByLangQuery(language);
        var response = await _mediatr.Send(command);

        return Ok(response);
    }
    
    [HttpGet]
    [Route("GetBooksByPrice/{price:decimal}")]
    public async Task<IActionResult> GetBooksByPrice(decimal price)
    {
        var command = new GetBooksByPriceQuery(price);
        var response = await _mediatr.Send(command);

        return Ok(response);
    }
    
    [HttpGet]
    [Route("GetBooksByPublisher")]
    public async Task<IActionResult> GetBooksByPublisher([FromQuery] string publisher)
    {
        var command = new GetBooksByPublisherQuery(publisher);
        var response = await _mediatr.Send(command);

        return Ok(response);
    }
}