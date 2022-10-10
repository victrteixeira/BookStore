using MediatR;

namespace Catalog.Application.Commands.Delete;

public class RemoveAuthorCommand : IRequest<int>
{
    public RemoveAuthorCommand(int authorId)
    {
        AuthorId = authorId;
    }

    public int AuthorId { get; set; }
}