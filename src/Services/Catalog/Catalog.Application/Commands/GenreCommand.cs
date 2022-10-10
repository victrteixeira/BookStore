namespace Catalog.Application.Commands;

public class GenreCommand
{
    public string Genre { get; set; } = string.Empty;
    public string? SubGenre { get; set; }
    public string? BriefDescription { get; set; }
}