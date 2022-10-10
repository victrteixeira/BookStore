using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByAuthor;

public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IReadOnlyCollection<Author>>
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;

    public GetAllAuthorsQueryHandler(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<Author>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _repository.GetAll();
        if (!authors.Any())
            throw new QueryException("Nothing was found.");

        return authors;
    }
}