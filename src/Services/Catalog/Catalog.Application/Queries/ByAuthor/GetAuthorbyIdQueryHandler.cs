using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByAuthor;

public class GetAuthorbyIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;

    public GetAuthorbyIdQueryHandler(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetById(request.AuthorId) ?? 
               throw new QueryException("Author not found.");
    }
}