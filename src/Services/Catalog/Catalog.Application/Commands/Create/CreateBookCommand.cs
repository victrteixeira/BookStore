using System.ComponentModel.DataAnnotations;

namespace Catalog.Application.Commands.Create;

public class CreateBookCommand : BookCommand
{
    [Required]
    public GenreCommand Genre { get; set; } = null!;
}