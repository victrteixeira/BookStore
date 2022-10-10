using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries.ByAuthor;

public class GetAllAuthorsQuery : IRequest<IReadOnlyCollection<Author>>
{
}