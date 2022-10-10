using Catalog.Application.Exceptions;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class
    GetBooksByPriceAndLangQueryHandler : IRequestHandler<GetBooksByPriceAndLangQuery, IReadOnlyCollection<Book>>
{
    private readonly IBookRepository _repository;

    public GetBooksByPriceAndLangQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<Book>> Handle(GetBooksByPriceAndLangQuery request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Language) || request.Price < 1)
            throw new RequestException("It's necessary to provide valid parameters to complete the search");

        var query = await _repository.GetBooksByPriceAndLanguage(request.Language, request.Price);
        if (!query.Any())
            throw new QueryException("Nothing was found with provided parameters.");

        return query;
    }
}