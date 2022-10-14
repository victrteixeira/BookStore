using Catalog.Application.Responses.ForAuthor;
using MediatR;

namespace Catalog.Application.Queries.ByAuthor;

public class GetAuthorByNameQuery : IRequest<AuthorQueryResponse>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}