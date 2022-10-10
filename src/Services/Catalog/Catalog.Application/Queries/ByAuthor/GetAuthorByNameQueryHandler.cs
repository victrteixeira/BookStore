using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByAuthor;

public class GetAuthorByNameQueryHandler : IRequestHandler<GetAuthorByNameQuery, Author>
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;

    public GetAuthorByNameQueryHandler(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Author> Handle(GetAuthorByNameQuery request, CancellationToken cancellationToken)
    {
        if (request.FirstName is null || request.LastName is null)
            throw new RequestException("It is necessary to provide author's fullname.");

        return await _repository.GetAuthorByName(request.FirstName, request.LastName) ?? 
               throw new QueryException("No author was found."); 
    }
}