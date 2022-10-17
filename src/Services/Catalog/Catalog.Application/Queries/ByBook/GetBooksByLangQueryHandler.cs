using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses.ForBook;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class
    GetBooksByLangQueryHandler : IRequestHandler<GetBooksByLangQuery, IReadOnlyCollection<BookQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IBookRepository _repository;

    public GetBooksByLangQueryHandler(IBookRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<BookQueryResponse>> Handle(GetBooksByLangQuery request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Language))
            throw new RequestException("It's necessary to provide valid parameters to complete the search");

        var query = await _repository.GetBooksByLanguage(request.Language);
        if (!query.Any())
            throw new QueryException("Nothing was found with provided parameters.");

        return _mapper.Map<IReadOnlyCollection<BookQueryResponse>>(query);
    }
}