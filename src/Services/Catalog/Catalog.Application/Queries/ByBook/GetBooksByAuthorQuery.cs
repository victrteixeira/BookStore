using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries.ByBook;

public class GetBooksByAuthorQuery : IRequest<IReadOnlyCollection<Book>>
{
    public GetBooksByAuthorQuery(int authorId)
    {
        AuthorId = authorId;
    }

    public int AuthorId { get; set; }
}