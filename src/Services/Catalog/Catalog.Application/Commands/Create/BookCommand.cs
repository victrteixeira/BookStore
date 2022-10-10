using System.ComponentModel.DataAnnotations;
using Catalog.Application.Responses;
using Catalog.Application.Responses.ForBook;
using MediatR;

namespace Catalog.Application.Commands.Create;

public class BookCommand : IRequest<BookResponse>
{
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Language { get; set; } = string.Empty;
    
    public string? Publisher { get; set; }
    
    [Required]
    public int Pages { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    public int AuthorId { get; set; }
}