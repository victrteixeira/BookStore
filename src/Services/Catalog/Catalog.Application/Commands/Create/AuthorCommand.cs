using System.ComponentModel.DataAnnotations;
using Catalog.Application.Responses.ForAuthor;
using MediatR;

namespace Catalog.Application.Commands.Create;

public class AuthorCommand : IRequest<AuthorResponse>
{
    [Required] public string FirstName { get; set; } = string.Empty;

    [Required] public string LastName { get; set; } = string.Empty;

    [Required] public string BornAt { get; set; } = string.Empty;

    [Required] public string DiedAt { get; set; } = string.Empty;

    public string? Country { get; set; }

    public string? BriefDescription { get; set; }
}