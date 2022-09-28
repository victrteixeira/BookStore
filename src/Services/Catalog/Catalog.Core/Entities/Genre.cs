using Catalog.Core.Validators;

namespace Catalog.Core.Entities;

public sealed class Genre : Base
{
    public Genre(string name, string? subGenre, string? briefDescription)
    {
        Name = name;
        SubGenre = subGenre;
        BriefDescription = briefDescription;
        Validate();
    }

    public int GenreId { get; private set; }
    public string Name { get; private set; }
    public string? SubGenre { get; private set; } // Epistemology
    public string? BriefDescription { get; private set; } // Studies about knowledge.

    public List<GenreBook>? Books { get; set; }

    public bool Validate() => base.Validate(new GenreValidator(), this);
}