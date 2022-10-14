using Catalog.Application.Responses.ForAuthor;
using MediatR;

namespace Catalog.Application.Queries.ByAuthor;

public class GetAllAuthorsQuery : IRequest<IReadOnlyCollection<AuthorResponse>>
{
}