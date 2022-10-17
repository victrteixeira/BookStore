using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses.ForBook;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class GetBookByNameQueryHandler : IRequestHandler<GetBookByNameQuery, BookQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _repository;

    public GetBookByNameQueryHandler(IBookRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BookQueryResponse> Handle(GetBookByNameQuery request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.BookName))
            throw new RequestException("It's necessary to provide book's name to complete the search");

        var query = await _repository.GetBookByName(request.BookName) ??
                    throw new QueryException("Book not found.");

        return _mapper.Map<BookQueryResponse>(query);
    }
}