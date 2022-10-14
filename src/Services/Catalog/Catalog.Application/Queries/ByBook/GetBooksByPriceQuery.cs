using Catalog.Application.Responses.ForBook;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class GetBooksByPriceQuery : IRequest<IReadOnlyCollection<BookQueryResponse>>
{
    public GetBooksByPriceQuery(decimal price)
    {
        Price = price;
    }

    public decimal Price { get; set; }
}