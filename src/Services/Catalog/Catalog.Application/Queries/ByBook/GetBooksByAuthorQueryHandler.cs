using Catalog.Application.Exceptions;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class
    GetBooksByAuthorQueryHandler : IRequestHandler<GetBooksByAuthorQuery, IReadOnlyCollection<Book>>
{
    private readonly IBookRepository _repository;

    public GetBooksByAuthorQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IReadOnlyCollection<Book>> Handle(GetBooksByAuthorQuery request,
        CancellationToken cancellationToken)
    {
        var query = await _repository.GetBooksByAuthor(request.AuthorId);
        if (!query.Any())
            throw new QueryException("Nothing was found.");

        return query;
    }
}