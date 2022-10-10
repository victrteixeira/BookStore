using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class GetBooksByPublisherQuery : IRequest<IReadOnlyCollection<Book>>
{
    public GetBooksByPublisherQuery(string? publisher)
    {
        Publisher = publisher;
    }

    public string? Publisher { get; set; }
}