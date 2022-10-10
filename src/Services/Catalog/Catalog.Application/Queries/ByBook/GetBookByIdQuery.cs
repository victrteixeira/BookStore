using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class GetBookByIdQuery : IRequest<Book>
{
    public GetBookByIdQuery(int bookId)
    {
        BookId = bookId;
    }

    public int BookId { get; set; }
}