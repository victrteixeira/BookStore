using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using Catalog.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infra.Repositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    private readonly CatalogContext _context;
    public BookRepository(CatalogContext context) : base(context) => _context = context;


    public async Task<Book?> GetBookById(int id)
    {
        var res = await _context.Books
            .AsNoTracking()
            .Where(i => i.BookId == id)
            .FirstOrDefaultAsync();

        if (res is null)
            return null;

        return res;
    }

    public async Task<Book?> GetBookByName(string bookName)
    {
        var res = await _context.Books
            .AsNoTracking()
            .Where(b => b.Name.ToLower() == bookName.Trim().ToLower())
            .FirstOrDefaultAsync();

        if (res is null)
            return null;

        return res;
    }

    public async Task<IEnumerable<Book>> GetBooksByPrice(decimal price)
    {
        return await _context.Books
            .AsNoTracking()
            .Where(n => n.Price == price)
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksByPriceAndLanguage(string language, decimal price)
    {
        return await _context.Books
            .AsNoTracking()
            .Where(n =>
                n.Language.ToLower() == language.Trim().ToLower() &&
                n.Price == price)
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksByPublisher(string publisher)
    {
        return await _context.Books
            .AsNoTracking()
            .Where(p => p.Publisher != null && p.Publisher.ToLower() == publisher.Trim().ToLower())
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthor(int authorId)
    {
        return await _context.Books
            .AsNoTracking()
            .Where(i => i.AuthorId == authorId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Book>?> GetBooksByGenre(string genreName)
    {
        return await _context.Books
            .AsNoTracking()
            .Where(x => x.Genres.Any(c => c.Genre != null && c.Genre.Name != null &&
                                          c.Genre.Name.ToLower() == genreName.Trim().ToLower()))
            .ToListAsync();
    }
}