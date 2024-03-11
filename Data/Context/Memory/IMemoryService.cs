using Microsoft.Extensions.Caching.Memory;

namespace Data.Context.Memory;

/// <summary>
///     Memory Service
/// </summary>
public interface IMemoryService
{
    void Set<TEntity>(string key, TEntity value, int slidingExpirationSecond = 10,
        CacheItemPriority priority = CacheItemPriority.Low, int absoluteExpirationMinute = 10);

    TEntity Get<TEntity>(string key);

    bool TryGetValue<TEntity>(string key, out TEntity value);

    void Remove(string key);

    TEntity GetOrCreate<TEntity>(string key, Func<ICacheEntry, TEntity> factory);
}