namespace Data.Redises;

public class RedisSettings
{
    public string Host { get; set; }
    public string Port { get; set; }
    public bool AbortOnConnectFail { get; set; }
    public int AsyncTimeOutMilliSecond { get; set; }
    public int ConnectTimeOutMilliSecond { get; set; }
    public string Password { get; set; }
}