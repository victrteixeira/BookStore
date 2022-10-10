using Catalog.Application.Commands.Create;

namespace Catalog.Application.Commands.Update;

public class UpdateAuthorCommand : AuthorCommand
{
    public int AuthorId { get; set; }
}