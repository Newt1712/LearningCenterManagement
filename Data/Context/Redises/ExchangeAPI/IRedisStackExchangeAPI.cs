using StackExchange.Redis;

namespace Data.Redises.ExchangeAPI;

public interface IRedisStackExchangeAPI
{
    void ConnectServer();

    IDatabase GetSelectedDatabase(int databaseIndex = 0);
}