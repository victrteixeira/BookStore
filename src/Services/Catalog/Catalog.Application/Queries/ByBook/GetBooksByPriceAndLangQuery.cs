using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class GetBooksByPriceAndLangQuery : IRequest<IReadOnlyCollection<Book>>
{
    public GetBooksByPriceAndLangQuery(string? language, decimal price)
    {
        Language = language;
        Price = price;
    }

    public string? Language { get; set; }
    public decimal Price { get; set; }
}