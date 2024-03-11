using Microsoft.Extensions.Caching.Memory;

namespace Data.Context.Memory;

/// <summary>
///     Memory Manager
/// </summary>
public class MemoryManager : IMemoryService
{
    /// <summary>
    ///     services.AddMemoryCache(); DI
    /// </summary>
    private readonly IMemoryCache _memoryCache;

    public MemoryManager(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public void Set<TEntity>(string key, TEntity value, int slidingExpirationSecond = 10,
        CacheItemPriority priority = CacheItemPriority.Low, int absoluteExpirationMinute = 10)
    {
        if (string.IsNullOrEmpty(key))
            return;

        _memoryCache.Set(key, value, new MemoryCacheEntryOptions
        {
            AbsoluteExpiration = DateTime.Now.AddMinutes(absoluteExpirationMinute),
            SlidingExpiration = TimeSpan.FromSeconds(slidingExpirationSecond),
            Priority = priority
        });
    }

    public TEntity Get<TEntity>(string key)
    {
        if (string.IsNullOrEmpty(key))
            return default;

        return _memoryCache.Get<TEntity>(key);
    }

    public bool TryGetValue<TEntity>(string key, out TEntity value)
    {
        if (string.IsNullOrEmpty(key))
        {
            value = default;
            return false;
        }

        return _memoryCache.TryGetValue(key, out value);
    }

    public void Remove(string key)
    {
        if (string.IsNullOrEmpty(key))
            return;

        _memoryCache.Remove(key);
    }

    public TEntity GetOrCreate<TEntity>(string key, Func<ICacheEntry, TEntity> factory)
    {
        return _memoryCache.GetOrCreate(key, factory);
    }
}