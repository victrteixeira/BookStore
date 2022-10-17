using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses.ForAuthor;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByAuthor;

public class GetAuthorByNameQueryHandler : IRequestHandler<GetAuthorByNameQuery, AuthorQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IAuthorRepository _repository;

    public GetAuthorByNameQueryHandler(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AuthorQueryResponse> Handle(GetAuthorByNameQuery request, CancellationToken cancellationToken)
    {
        if (request.FirstName is null || request.LastName is null)
            throw new RequestException("It is necessary to provide author's fullname.");

        var query = await _repository.GetAuthorByName(request.FirstName, request.LastName) ??
                    throw new QueryException("No author was found.");

        return _mapper.Map<AuthorQueryResponse>(query);
    }
}