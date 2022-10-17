using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using Catalog.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infra.Repositories;

public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
{
    private readonly CatalogContext _context;

    public AuthorRepository(CatalogContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Author?> GetAuthorById(int authorId)
    {
        return await _context.Authors
            .AsNoTracking()
            .Include(a => a.Books)!
            .ThenInclude(b => b.Genre)
            .Where(i => i.AuthorId == authorId)
            .FirstOrDefaultAsync();
    }

    public async Task<Author?> GetAuthorByName(string firstname, string lastname)
    {
        return await _context.Authors
            .AsNoTracking()
            .Include(a => a.Books)!
            .ThenInclude(b => b.Genre)
            .Where(n =>
                n.FirstName.ToLower() == firstname.Trim().ToLower() &&
                n.LastName.ToLower() == lastname.Trim().ToLower())
            .FirstOrDefaultAsync();
    }
}