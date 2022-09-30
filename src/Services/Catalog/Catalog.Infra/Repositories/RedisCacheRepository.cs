using System.Text.Json;
using Catalog.Core.Entities;
using Catalog.Infra.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace Catalog.Infra.Repositories;

public class RedisCacheRepository : IRedisCacheRepository
{
    private readonly IDistributedCache _cache;

    public RedisCacheRepository(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await _cache.GetStringAsync(key);
        if (value != null)
            return JsonSerializer.Deserialize<T>(value);

        return default;
    }

    public async Task<T> SetAsync<T>(string key, T value)
    {
        var timeOut = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1),
            SlidingExpiration = TimeSpan.FromMinutes(30)
        };

        await _cache.SetStringAsync(key, JsonSerializer.Serialize(value), timeOut);
        return value;
    }
}