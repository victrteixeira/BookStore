using Catalog.Core.Validators;

namespace Catalog.Core.Entities;

public sealed class Book : Base
{
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

    public Book(string name, int pages, decimal price, string language, string? publisher, int authorId, int genreId)
    {
        Name = name;
        Pages = pages;
        Price = price;
        Language = language;
        Publisher = publisher;
        AuthorId = authorId;
        GenreId = genreId;
        Validate();
    }

    public int BookId { get; private set; }
    public string Name { get; }
    public int Pages { get; }
    public decimal Price { get; }
    public string Language { get; }
    public string? Publisher { get; }

    public int AuthorId { get; private set; }
    public Author Author { get; set; } = null!;

    public int GenreId { get; private set; }
    public Genre Genre { get; set; } = null!;

    public bool Validate() => base.Validate(new BookValidator(), this);

    public void UpdateAuthorId(int authorId)
    {
        if (authorId < 0)
            return;

        AuthorId = authorId;
    }

    public void UpdateGenreId(int genreId)
    {
        if (genreId < 0)
            return;

        GenreId = genreId;
    }
}