using System.Globalization;
using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using Catalog.Infra.Database;
using Catalog.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Constants = Catalog.Infra.Utils.Constants;

namespace Catalog.Infra.Repositories;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    private readonly CatalogContext _context;
    private readonly IRedisCacheRepository _redisCache;
    public BookRepository(CatalogContext context, IRedisCacheRepository redisCache) : base(context)
    {
        _context = context;
        _redisCache = redisCache;
    }

    public async Task<Book?> GetBookById(int id)
    {
        var cachedValue = await _redisCache.GetAsync<Book>(Constants.BookRepoKeys[0]);
        if (cachedValue != null)
            return cachedValue;
        
        var res = await _context.Books
            .AsNoTracking()
            .Where(i => i.BookId == id)
            .FirstOrDefaultAsync();

        if (res is null)
            return null;

        await _redisCache.SetAsync(Constants.BookRepoKeys[0], res);
        return res;
    }

    public async Task<Book?> GetBookByName(string bookName)
    {
        var cachedValue = await _redisCache.GetAsync<Book>(Constants.BookRepoKeys[1]);
        if (cachedValue != null)
            return cachedValue;
        
        var res = await _context.Books
            .AsNoTracking()
            .Where(b => b.Name.ToLower() == bookName.Trim().ToLower())
            .FirstOrDefaultAsync();

        if (res is null)
            return null;

        await _redisCache.SetAsync(Constants.BookRepoKeys[1], res);
        return res;
    }

    public async Task<IEnumerable<Book>> GetBooksByPrice(decimal price)
    {
        var cachedValue = await _redisCache.GetAsync<IEnumerable<Book>>(Constants.BookRepoKeys[2]);
        if (cachedValue != null)
            return cachedValue;
        
        var res = await _context.Books
            .AsNoTracking()
            .Where(n => n.Price == price)
            .ToListAsync();

        await _redisCache.SetAsync(Constants.BookRepoKeys[2], res);
        return res;
    }

    public async Task<IEnumerable<Book>> GetBooksByPriceAndLanguage(string language, decimal price)
    {
        var cachedValue = await _redisCache.GetAsync<IEnumerable<Book>>(Constants.BookRepoKeys[3]);
        if (cachedValue != null)
            return cachedValue;

        var res = await _context.Books
            .AsNoTracking()
            .Where(n =>
                n.Language.ToLower() == language.Trim().ToLower() &&
                n.Price == price)
            .ToListAsync();

        await _redisCache.SetAsync(Constants.BookRepoKeys[3], res);
        return res;
    }

    public async Task<IEnumerable<Book>> GetBooksByPublisher(string publisher)
    {
        var cachedValue = await _redisCache.GetAsync<IEnumerable<Book>>(Constants.BookRepoKeys[4]);
        if (cachedValue != null)
            return cachedValue;
        
        var res = await _context.Books
            .AsNoTracking()
            .Where(p => p.Publisher != null && p.Publisher.ToLower() == publisher.Trim().ToLower())
            .ToListAsync();

        await _redisCache.SetAsync(Constants.BookRepoKeys[4], res);
        return res;
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthor(int authorId)
    {
        var cachedValue = await _redisCache.GetAsync<IEnumerable<Book>>(Constants.BookRepoKeys[5]);
        
        var res =  await _context.Books
            .AsNoTracking()
            .Where(i => i.AuthorId == authorId)
            .ToListAsync();

        await _redisCache.SetAsync(Constants.BookRepoKeys[5], res);
        return res;
    }

    public async Task<IEnumerable<Book>?> GetBooksByGenre(string genreName)
    {
        var cachedValue = await _redisCache.GetAsync<IEnumerable<Book>>(Constants.BookRepoKeys[6]);
        if (cachedValue != null)
            return cachedValue;
        
        var res =  await _context.Books
            .AsNoTracking()
            .Where(x => x.Genres.Any(c => c.Genre != null &&
                                          c.Genre.Name.ToLower() == genreName.Trim().ToLower()))
            .ToListAsync();

        await _redisCache.SetAsync(Constants.BookRepoKeys[6], res);
        return res;
    } // TODO > To verify this query with Genre Class integration after.
}