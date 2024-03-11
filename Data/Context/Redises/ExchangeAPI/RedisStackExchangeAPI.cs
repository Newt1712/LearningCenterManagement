using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace Data.Redises.ExchangeAPI;

public class RedisStackExchangeAPI : IRedisStackExchangeAPI
{
    private readonly RedisSettings _redisSettings;
    private ConnectionMultiplexer _connectionMultiplexer;

    public RedisStackExchangeAPI(IOptions<RedisSettings> redisSettings)
    {
        _redisSettings = redisSettings.Value;
    }

    public async void ConnectServer()
    {
        var configurationOptions = new ConfigurationOptions
        {
            EndPoints = { string.Concat(_redisSettings.Host, ":", _redisSettings.Port) },
            AbortOnConnectFail = _redisSettings.AbortOnConnectFail,
            AsyncTimeout = _redisSettings.AsyncTimeOutMilliSecond,
            ConnectTimeout = _redisSettings.ConnectTimeOutMilliSecond
        };

        _connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(configurationOptions);
    }

    public IDatabase GetSelectedDatabase(int databaseIndex = 0)
    {
        return _connectionMultiplexer.GetDatabase(databaseIndex);
    }
}