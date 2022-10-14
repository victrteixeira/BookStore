using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses.ForBook;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class
    GetBooksByAuthorQueryHandler : IRequestHandler<GetBooksByAuthorQuery, IReadOnlyCollection<BookResponse>>
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;

    public GetBooksByAuthorQueryHandler(IBookRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<BookResponse>> Handle(GetBooksByAuthorQuery request,
        CancellationToken cancellationToken)
    {
        var query = await _repository.GetBooksByAuthor(request.AuthorId);
        if (!query.Any())
            throw new QueryException("Nothing was found.");

        return _mapper.Map<IReadOnlyCollection<BookResponse>>(query);
    }
}