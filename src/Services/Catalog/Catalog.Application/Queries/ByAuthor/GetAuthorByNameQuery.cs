using Catalog.Core.Entities;
using MediatR;

namespace Catalog.Application.Queries.ByAuthor;

public class GetAuthorByNameQuery : IRequest<Author>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}