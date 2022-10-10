using Catalog.Application.Exceptions;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class
    GetBooksByPublisherQueryHandler : IRequestHandler<GetBooksByPublisherQuery, IReadOnlyCollection<Book>>
{
    private readonly IBookRepository _repository;

    public GetBooksByPublisherQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<Book>> Handle(GetBooksByPublisherQuery request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Publisher))
            throw new RequestException("A publisher must be provided to complete the search.");

        var query = await _repository.GetBooksByPublisher(request.Publisher);

        if (!query.Any())
            throw new QueryException("Nothing was found from provided parameters");

        return query;
    }
}