using Catalog.Application.Exceptions;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class
    GetBooksByPriceQueryHandler : IRequestHandler<GetBooksByPriceQuery, IReadOnlyCollection<Book>>
{
    private readonly IBookRepository _repository;

    public GetBooksByPriceQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<Book>> Handle(GetBooksByPriceQuery request,
        CancellationToken cancellationToken)
    {
        var query = await _repository.GetBooksByPrice(request.Price);
        if (!query.Any())
            throw new QueryException("Nothing was found.");

        return query;
    }
}