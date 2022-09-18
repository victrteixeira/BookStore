namespace Catalog.Core.Entities;

public class Genre
{
    public int GenreId { get; set; }
    public string? Name { get; set; } // Philosophy
    public string? SubGenre { get; set; } // Epistemology
    public Type? Type { get; set; } // NonFiction
    public string? BriefDescription { get; set; } // Studies about knowledge.

    public List<Book>? Books { get; set; }
}

public enum Type
{
    Fiction = 1,
    NonFiction = 2
}