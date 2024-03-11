using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace Data.Redises.Distributed;

public class RedisDistributedManager : IRedisDistributedService
{
    //using Microsoft.Extensions.Caching.Distributed;
    private readonly IDistributedCache _distributedCache;

    public RedisDistributedManager(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public TEntity GetObject<TEntity>(string key)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException(nameof(key));

        var cachedValue = _distributedCache.GetString(key);
        if (string.IsNullOrEmpty(cachedValue))
            return default;

        return JsonSerializer.Deserialize<TEntity>(cachedValue);
    }

    public async Task<TEntity> GetObjectAsync<TEntity>(string key)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException(nameof(key));

        var cachedValue = await _distributedCache.GetStringAsync(key);
        if (string.IsNullOrEmpty(cachedValue))
            return default;

        return JsonSerializer.Deserialize<TEntity>(cachedValue);
    }

    public void SetObject<TEntity>(string key, TEntity value, int absoluteExpirationMinute = 1,
        int slidingExpirationSecond = 10)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException(nameof(key));

        var distributedCacheEntryOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTime.Now.AddMinutes(absoluteExpirationMinute),
            SlidingExpiration = TimeSpan.FromSeconds(slidingExpirationSecond)
        };

        var serilazedValue = JsonSerializer.Serialize(value);

        _distributedCache.SetString(key, serilazedValue, distributedCacheEntryOptions);
    }

    public async Task SetObjectAsync<TEntity>(string key, TEntity value, int absoluteExpirationMinute = 1,
        int slidingExpirationSecond = 10)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException(nameof(key));

        var distributedCacheEntryOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTime.Now.AddMinutes(absoluteExpirationMinute),
            SlidingExpiration = TimeSpan.FromSeconds(slidingExpirationSecond)
        };

        var serilazedValue = JsonSerializer.Serialize(value);

        await _distributedCache.SetStringAsync(key, serilazedValue, distributedCacheEntryOptions);
    }

    public void Remove(string key)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException(nameof(key));

        _distributedCache.Remove(key);
    }

    public async Task RemoveAsync(string key)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentNullException(nameof(key));

        await _distributedCache.RemoveAsync(key);
    }

    public void FileCache(string key, byte[] value, int absoluteExpirationMinute = 10, int slidingExpirationSecond = 0)
    {
        if (string.IsNullOrEmpty(key))
            return;

        var distributedCacheEntryOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTime.Now.AddMinutes(absoluteExpirationMinute)
        };

        if (slidingExpirationSecond > 0)
            distributedCacheEntryOptions.SlidingExpiration = TimeSpan.FromSeconds(slidingExpirationSecond);

        //_distributedCache.Set(string key, byte[] value);
        _distributedCache.Set(key, value, distributedCacheEntryOptions);
    }

    public async Task FileCacheAsync(string key, byte[] value, int absoluteExpirationMinute = 10,
        int slidingExpirationSecond = 0)
    {
        if (string.IsNullOrEmpty(key))
            return;

        var distributedCacheEntryOptions = new DistributedCacheEntryOptions
        {
            AbsoluteExpiration = DateTime.Now.AddMinutes(absoluteExpirationMinute)
        };

        if (slidingExpirationSecond > 0)
            distributedCacheEntryOptions.SlidingExpiration = TimeSpan.FromSeconds(slidingExpirationSecond);

        //_distributedCache.Set(string key, byte[] value);
        await _distributedCache.SetAsync(key, value, distributedCacheEntryOptions);
    }
}