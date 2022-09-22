using Catalog.Core.Validators;

namespace Catalog.Core.Entities;

public class Author : Base
{
    public int AuthorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Born { get; set; }
    public string Died { get; set; }
    public string? Country { get; set; }
    public string? BriefDescription { get; set; }

    public List<Book>? Books { get; set; }

    public Author(string firstname, string lastName, string born, string died, string? country, string? briefDescription)
    {
        FirstName = firstname;
        LastName = lastName;
        Born = born;
        Died = died;
        Country = country;
        BriefDescription = briefDescription;
        Validate();
    }
    
    public bool Validate() => base.Validate(new AuthorValidator(), this);
}