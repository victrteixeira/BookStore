using Catalog.Core.Validators;

namespace Catalog.Core.Entities;

public sealed class Author : Base
{
    public int AuthorId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string BornAt { get; private set; }
    public string DiedAt { get; private set; }
    public string? Country { get; private set; }
    public string? BriefDescription { get; private set; }

    public List<Book>? Books { get; set; }

    public Author(string firstName, string lastName, string bornAt, string diedAt, string? country, string? briefDescription)
    {
        FirstName = firstName;
        LastName = lastName;
        BornAt = bornAt;
        DiedAt = diedAt;
        Country = country;
        BriefDescription = briefDescription;
        Books = new List<Book>();
        Validate();
    }

    public bool Validate() => base.Validate(new AuthorValidator(), this);
}