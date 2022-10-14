using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses.ForBook;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class
    GetBooksByPublisherQueryHandler : IRequestHandler<GetBooksByPublisherQuery, IReadOnlyCollection<BookQueryResponse>>
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;

    public GetBooksByPublisherQueryHandler(IBookRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<BookQueryResponse>> Handle(GetBooksByPublisherQuery request,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(request.Publisher))
            throw new RequestException("A publisher must be provided to complete the search.");

        var query = await _repository.GetBooksByPublisher(request.Publisher);

        if (!query.Any())
            throw new QueryException("Nothing was found from provided parameters");

        return _mapper.Map<IReadOnlyCollection<BookQueryResponse>>(query);
    }
}