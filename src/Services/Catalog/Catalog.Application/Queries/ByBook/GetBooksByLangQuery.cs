using Catalog.Application.Responses.ForBook;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class GetBooksByLangQuery : IRequest<IReadOnlyCollection<BookQueryResponse>>
{
    public GetBooksByLangQuery(string? language)
    {
        Language = language;
    }

    public string? Language { get; set; }
}