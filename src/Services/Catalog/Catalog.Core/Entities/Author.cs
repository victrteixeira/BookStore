using Catalog.Core.Validators;

namespace Catalog.Core.Entities;

public sealed class Author : Base
{
    public Author(string firstName, string lastName, string bornAt, string diedAt, string? country,
        string? briefDescription)
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

    public int AuthorId { get; private set; }
    public string FirstName { get; }
    public string LastName { get; }
    public string BornAt { get; }
    public string DiedAt { get; }
    public string? Country { get; }
    public string? BriefDescription { get; }

    public List<Book>? Books { get; set; }

    public bool Validate() => base.Validate(new AuthorValidator(), this);
}