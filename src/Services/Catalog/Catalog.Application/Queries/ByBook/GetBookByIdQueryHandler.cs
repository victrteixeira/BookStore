using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses.ForBook;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookQueryResponse>
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;

    public GetBookByIdQueryHandler(IBookRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<BookQueryResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var query = await _repository.GetBookById(request.BookId) ?? 
               throw new QueryException("Book not found.");

        return _mapper.Map<BookQueryResponse>(query);
    }
}