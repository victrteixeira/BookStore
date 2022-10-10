using MediatR;

namespace Catalog.Application.Commands.Delete;

public class RemoveBookCommand : IRequest<int>
{
    public RemoveBookCommand(int bookId)
    {
        BookId = bookId;
    }

    public int BookId { get; set; }
}