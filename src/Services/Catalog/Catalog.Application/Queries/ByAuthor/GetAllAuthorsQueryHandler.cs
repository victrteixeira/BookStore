using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses.ForAuthor;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByAuthor;

public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, IReadOnlyCollection<AuthorResponse>>
{
    private readonly IMapper _mapper;
    private readonly IAuthorRepository _repository;

    public GetAllAuthorsQueryHandler(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<AuthorResponse>> Handle(GetAllAuthorsQuery request,
        CancellationToken cancellationToken)
    {
        var query = await _repository.GetAll();
        if (!query.Any())
            throw new QueryException("Nothing was found.");

        return _mapper.Map<IReadOnlyCollection<AuthorResponse>>(query);
    }
}