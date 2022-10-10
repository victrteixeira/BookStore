using Catalog.Application.Exceptions;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class GetBookByNameQueryHandler : IRequestHandler<GetBookByNameQuery, Book>
{
    private readonly IBookRepository _repository;

    public GetBookByNameQueryHandler(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<Book> Handle(GetBookByNameQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.BookName))
            throw new RequestException("It's necessary to provide book's name to complete the search");

        return await _repository.GetBookByName(request.BookName) ??
               throw new QueryException("Book not found.");
    }
}