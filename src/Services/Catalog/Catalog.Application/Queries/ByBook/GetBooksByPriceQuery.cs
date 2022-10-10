using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class GetBooksByPriceQuery : IRequest<IReadOnlyCollection<Book>>
{
    public GetBooksByPriceQuery(decimal price)
    {
        Price = price;
    }

    public decimal Price { get; set; }
}