using Catalog.Application.Responses.ForBook;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class GetBookByNameQuery : IRequest<BookQueryResponse>
{
    public GetBookByNameQuery(string? bookName)
    {
        BookName = bookName;
    }

    public string? BookName { get; set; }
}