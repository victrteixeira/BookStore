using Catalog.Core.Validators;

namespace Catalog.Core.Entities;

public sealed class Genre : Base
{
    public Genre(string name, string subGenre, string? briefDescription)
    {
        Name = name;
        SubGenre = subGenre;
        BriefDescription = briefDescription;
        Books = new List<Book>();
        Validate();
    }

    public int GenreId { get; private set; }
    public string Name { get; }
    public string SubGenre { get; }
    public string? BriefDescription { get; }

    public List<Book>? Books { get; set; }
    public bool Validate() => base.Validate(new GenreValidator(), this);
}