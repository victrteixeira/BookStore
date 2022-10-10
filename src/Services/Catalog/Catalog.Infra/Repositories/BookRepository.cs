using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using Catalog.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infra.Repositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    private readonly CatalogContext _context;
    public BookRepository(CatalogContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Book?> GetBookById(int id)
    {
        return await _context.Books
            .AsNoTracking()
            .Where(i => i.BookId == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Book?> GetBookByName(string bookName)
    {
        return await _context.Books
            .AsNoTracking()
            .Where(b => b.Name.ToLower() == bookName.Trim().ToLower())
            .FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyCollection<Book>> GetBooksByPrice(decimal price)
    {
        return await _context.Books
            .AsNoTracking()
            .Where(n => n.Price == price)
            .ToListAsync();
    }

    public async Task<IReadOnlyCollection<Book>> GetBooksByPriceAndLanguage(string language, decimal price)
    {
        return await _context.Books
            .AsNoTracking()
            .Where(n =>
                n.Language.ToLower() == language.Trim().ToLower() &&
                n.Price == price)
            .ToListAsync();
    }

    public async Task<IReadOnlyCollection<Book>> GetBooksByPublisher(string publisher)
    {
        return await _context.Books
            .AsNoTracking()
            .Where(p => p.Publisher != null && p.Publisher.ToLower() == publisher.Trim().ToLower())
            .ToListAsync();
    }

    public async Task<IReadOnlyCollection<Book>> GetBooksByAuthor(int authorId)
    {
        return await _context.Books
            .AsNoTracking()
            .Where(i => i.AuthorId == authorId)
            .ToListAsync();
    }

    public async Task<IReadOnlyCollection<Book>?> GetBooksByGenre(string genreName)
    {
        // TODO > To verify this query with Genre Class integration after.
        return await _context.Books
            .AsNoTracking()
            .Where(x => x.Genres.Any(c => c.Genre != null &&
                                          c.Genre.Name.ToLower() == genreName.Trim().ToLower()))
            .ToListAsync();
    } 
}