using Catalog.Core.Exceptions;
using Catalog.Core.Validators;

namespace Catalog.Core.Entities;

public class Author : Base
{
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string BornAt { get; set; }
    public string DiedAt { get; set; }
    public string? Country { get; set; }
    public string? BriefDescription { get; set; }

    public List<Book>? Books { get; set; } = null!;

    public Author(string firstname, string lastName, string bornAt, string diedAt, string? country, string? briefDescription)
    {
        FirstName = firstname;
        LastName = lastName;
        BornAt = bornAt;
        DiedAt = diedAt;
        Country = country;
        BriefDescription = briefDescription;
        Validate();
    }

    public bool Validate() => base.Validate(new AuthorValidator(), this);
}