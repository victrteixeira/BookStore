namespace Catalog.Application.Responses.ForBook;

public class BookQueryResponse
{
    public int BookId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Language { get; set; } = string.Empty;

    public string? Publisher { get; set; }

    public int Pages { get; set; }

    public decimal Price { get; set; }

    public AuthorResponseForBook Author { get; set; } = null!;

    public GenreQueryResponse Genre { get; set; } = null!;
}