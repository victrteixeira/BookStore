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
            .Include(a => a.Author)
            .Include(b => b.Genre)
            .Where(i => i.BookId == id)
            .FirstOrDefaultAsync();
    }

    public async Task<Book?> GetBookByName(string bookName)
    {
        return await _context.Books
            .AsNoTracking()
            .Include(a => a.Author)
            .Include(b => b.Genre)
            .Where(b => b.Name.ToLower() == bookName.Trim().ToLower())
            .FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyCollection<Book>> GetBooksByPrice(decimal price)
    {
        return await _context.Books
            .AsNoTracking()
            .Include(a => a.Author)
            .Include(b => b.Genre)
            .Where(n => n.Price == price)
            .ToListAsync();
    }

    public async Task<IReadOnlyCollection<Book>> GetBooksByLanguage(string language)
    {
        return await _context.Books
            .AsNoTracking()
            .Include(a => a.Author)
            .Include(b => b.Genre)
            .Where(n => n.Language.ToLower() == language.Trim().ToLower())
            .ToListAsync();
    }

    public async Task<IReadOnlyCollection<Book>> GetBooksByPublisher(string publisher)
    {
        return await _context.Books
            .AsNoTracking()
            .Include(a => a.Author)
            .Include(b => b.Genre)
            .Where(p => p.Publisher != null && p.Publisher.ToLower() == publisher.Trim().ToLower())
            .ToListAsync();

        // TODO > Change this query to "Contains" rather than equal comparison
    }

    public async Task<IReadOnlyCollection<Book>> GetBooksByAuthor(int authorId)
    {
        return await _context.Books
            .AsNoTracking()
            .Include(a => a.Author)
            .Include(b => b.Genre)
            .Where(i => i.AuthorId == authorId)
            .ToListAsync();
    }
}