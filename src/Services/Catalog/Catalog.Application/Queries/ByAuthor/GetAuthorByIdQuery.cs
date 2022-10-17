using Catalog.Application.Responses.ForAuthor;
using MediatR;

namespace Catalog.Application.Queries.ByAuthor;

public class GetAuthorByIdQuery : IRequest<AuthorQueryResponse>
{
    public GetAuthorByIdQuery(int authorId)
    {
        AuthorId = authorId;
    }

    public int AuthorId { get; set; }
}