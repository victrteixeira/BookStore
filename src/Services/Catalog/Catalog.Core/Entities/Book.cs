namespace Catalog.Core.Entities;

public class Book
{
    public int BookId { get; set; }
    public string Name { get; set; } = null!;
    public int Pages { get; set; }
    public decimal Price { get; set; }
    public string Language { get; set; } = null!;
    public string? Publisher { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;

    public List<Genre>? Genres { get; set; }
    
}