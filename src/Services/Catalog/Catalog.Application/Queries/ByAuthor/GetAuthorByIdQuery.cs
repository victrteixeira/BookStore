using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries.ByAuthor;

public class GetAuthorByIdQuery : IRequest<Author>
{
    public GetAuthorByIdQuery(int authorId)
    {
        AuthorId = authorId;
    }

    public int AuthorId { get; set; }
}