namespace Catalog.Application.Responses.ForBook;

public class GenreQueryResponse
{
    public int GenreId { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public string SubGenre { get; set; } = string.Empty;
    
    public string? BriefDescription { get; set; }
}