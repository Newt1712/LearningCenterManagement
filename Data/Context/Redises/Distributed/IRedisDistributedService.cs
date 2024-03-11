namespace Data.Redises.Distributed;

public interface IRedisDistributedService
{
    TEntity GetObject<TEntity>(string key);
    Task<TEntity> GetObjectAsync<TEntity>(string key);

    void SetObject<TEntity>(string key, TEntity value, int absoluteExpirationMinute = 1,
        int slidingExpirationSecond = 10);

    Task SetObjectAsync<TEntity>(string key, TEntity value, int absoluteExpirationMinute = 1,
        int slidingExpirationSecond = 10);

    void Remove(string key);
    Task RemoveAsync(string key);
    void FileCache(string key, byte[] value, int absoluteExpirationMinute = 10, int slidingExpirationSecond = 0);
    Task FileCacheAsync(string key, byte[] value, int absoluteExpirationMinute = 10, int slidingExpirationSecond = 0);
}