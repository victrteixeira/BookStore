using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using Catalog.Infra.Database;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infra.Repositories;

public class GenreRepository : BaseRepository<Genre>, IGenreRepository
{
    private readonly CatalogContext _context;

    public GenreRepository(CatalogContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Genre?> GetGenre(string genreName, string subgenre)
    {
        return await _context.Genres
            .AsNoTracking()
            .Where(x => x.Name.ToLower() == genreName.Trim().ToLower() &&
                        x.SubGenre.ToLower() == subgenre.Trim().ToLower())
            .FirstOrDefaultAsync();
    }
}