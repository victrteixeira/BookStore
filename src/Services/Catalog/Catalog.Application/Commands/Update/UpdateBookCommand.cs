using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Catalog.Application.Commands.Update;

public class UpdateBookCommand : IRequest<UpdateBookCommand>
{
    [Required] public string Name { get; set; } = string.Empty;

    [Required] public string Language { get; set; } = string.Empty;

    public string? Publisher { get; set; }

    [Required] public int Pages { get; set; }

    [Required] public decimal Price { get; set; }

    [Required] public int AuthorId { get; set; }

    [Required] public int BookId { get; set; }

    [Required] public int GenreId { get; set; }
}