using Microsoft.Extensions.Caching.Memory;

namespace Data.Cache;

public class CacheProcessor
{
    private static MemoryCache _cache;

    public static MemoryCache GetCacheInstance()
    {
        if (_cache == null)
            _cache = new MemoryCache(new MemoryCacheOptions
            {
                SizeLimit = null // 1024
            });
        return _cache;
    }
}