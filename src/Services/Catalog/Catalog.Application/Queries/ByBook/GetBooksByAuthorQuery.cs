using Catalog.Application.Responses.ForBook;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class GetBooksByAuthorQuery : IRequest<IReadOnlyCollection<BookResponse>>
{
    public GetBooksByAuthorQuery(int authorId)
    {
        AuthorId = authorId;
    }

    public int AuthorId { get; set; }
}