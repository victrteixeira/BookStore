using System.ComponentModel.DataAnnotations;
using Catalog.Application.Commands.Create;

namespace Catalog.Application.Commands.Update;

public class UpdateBookCommand : BookCommand
{
    [Required]
    public int BookId { get; set; }
}