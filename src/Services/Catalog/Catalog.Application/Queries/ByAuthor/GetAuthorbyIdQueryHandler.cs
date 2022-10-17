using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses.ForAuthor;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByAuthor;

public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IAuthorRepository _repository;

    public GetAuthorByIdQueryHandler(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AuthorQueryResponse> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var query = await _repository.GetAuthorById(request.AuthorId) ??
                    throw new QueryException("Author not found.");

        return _mapper.Map<AuthorQueryResponse>(query);
    }
}