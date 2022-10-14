using AutoMapper;
using Catalog.Application.Exceptions;
using Catalog.Application.Responses.ForBook;
using Catalog.Core.Interfaces;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class
    GetBooksByPriceQueryHandler : IRequestHandler<GetBooksByPriceQuery, IReadOnlyCollection<BookQueryResponse>>
{
    private readonly IBookRepository _repository;
    private readonly IMapper _mapper;

    public GetBooksByPriceQueryHandler(IBookRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<BookQueryResponse>> Handle(GetBooksByPriceQuery request,
        CancellationToken cancellationToken)
    {
        var query = await _repository.GetBooksByPrice(request.Price);
        if (!query.Any())
            throw new QueryException("Nothing was found.");

        return _mapper.Map<IReadOnlyCollection<BookQueryResponse>>(query);
    }
}