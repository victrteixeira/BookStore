using Catalog.Application.Responses.ForBook;

namespace Catalog.Application.Responses.ForAuthor;

public class AuthorQueryResponse
{
    public int AuthorId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? BornAt { get; set; }

    public string? DiedAt { get; set; }

    public string? Country { get; set; }

    public string? BriefDescription { get; set; }

    public List<BookResponse>? Books { get; set; }
}