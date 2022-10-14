using Catalog.Application.Responses.ForBook;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class GetBookByIdQuery : IRequest<BookQueryResponse>
{
    public GetBookByIdQuery(int bookId)
    {
        BookId = bookId;
    }

    public int BookId { get; set; }
}