using DefaultNamespace;

namespace Catalog.Core.Entities;

public class Genre : Base
{
    public Genre(string? name, string? subGenre, Type? type, string? briefDescription)
    {
        Name = name;
        SubGenre = subGenre;
        Type = type;
        BriefDescription = briefDescription;
        Validate();
    }

    public int GenreId { get; set; }
    public string? Name { get; set; } // Philosophy
    public string? SubGenre { get; set; } // Epistemology
    public Type? Type { get; set; } // NonFiction
    public string? BriefDescription { get; set; } // Studies about knowledge.

    public List<GenreBook>? Books { get; set; }

    public bool Validate() => base.Validate(new GenreValidator(), this);
}

public enum Type
{
    Fiction = 1,
    NonFiction = 2
}