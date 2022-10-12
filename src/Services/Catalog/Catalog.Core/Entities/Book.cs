using Catalog.Core.Validators;

namespace Catalog.Core.Entities;

public sealed class Book : Base
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
    
    public Book(string name, int pages, decimal price, string language, string? publisher, int authorId)
    {
        Name = name;
        Pages = pages;
        Price = price;
        Language = language;
        Publisher = publisher;
        AuthorId = authorId;
        Validate();
    }

    public int BookId { get; private set; }
    public string Name { get; private set; }
    public int Pages { get; private set; }
    public decimal Price { get; private set; }
    public string Language { get; private set; }
    public string? Publisher { get; private set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    
    public int GenreId { get; set; }
    public Genre Genre { get; set; } = null!;

    public bool Validate() => base.Validate(new BookValidator(), this);
}