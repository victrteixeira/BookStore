using Catalog.Core.Entities;
using Catalog.Core.Interfaces;
using Catalog.Infra.Database;
using Catalog.Infra.Interfaces;
using Catalog.Infra.Utils;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace Catalog.Infra.Repositories;

public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
{
    private readonly CatalogContext _context;
    private readonly IRedisCacheRepository _redisCache;
    public AuthorRepository(CatalogContext context, IRedisCacheRepository redisCache) : base(context)
    {
        _context = context;
        _redisCache = redisCache;
    }

    public async Task<Author?> GetAuthorByName(string firstname, string lastname)
    {
        var cachedValue = await _redisCache.GetAsync<Author>(Constants.AuthorRepoKey[0]);
        if (cachedValue != null)
            return cachedValue;
        
        var res =  await _context.Authors
            .AsNoTracking()
            .Where(n => 
                n.FirstName.ToLower() == firstname.Trim().ToLower() &&
                n.LastName.ToLower() == lastname.Trim().ToLower())
            .FirstOrDefaultAsync();

        await _redisCache.SetAsync(Constants.AuthorRepoKey[0], res);
        return res;
    }
}
