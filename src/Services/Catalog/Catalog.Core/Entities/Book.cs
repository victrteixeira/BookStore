using DefaultNamespace;

namespace Catalog.Core.Entities;

public class Book : Base
{
    public Book(string name, int pages, decimal price, string language, string? publisher)
    {
        Name = name;
        Pages = pages;
        Price = price;
        Language = language;
        Publisher = publisher;
        Validate();
    }

    public int BookId { get; set; }
    public string Name { get; set; }
    public int Pages { get; set; }
    public decimal Price { get; set; }
    public string Language { get; set; }
    public string? Publisher { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    public List<GenreBook> Genres { get; set; } = null!;

    public bool Validate() => base.Validate(new BookValidator(), this);
}