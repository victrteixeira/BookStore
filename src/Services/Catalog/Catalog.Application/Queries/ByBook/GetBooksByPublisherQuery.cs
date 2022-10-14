using Catalog.Application.Responses.ForBook;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class GetBooksByPublisherQuery : IRequest<IReadOnlyCollection<BookQueryResponse>>
{
    public GetBooksByPublisherQuery(string? publisher)
    {
        Publisher = publisher;
    }

    public string? Publisher { get; set; }
}