using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class GetBookByNameQuery : IRequest<Book>
{
    public GetBookByNameQuery(string? bookName)
    {
        BookName = bookName;
    }

    public string? BookName { get; set; }
}