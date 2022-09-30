using Catalog.Core.Entities;

namespace Catalog.Infra.Interfaces;

public interface IRedisCacheRepository
{
    Task<T?> GetAsync<T>(string key);
    Task<T> SetAsync<T>(string key, T value);
}