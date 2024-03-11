using Microsoft.Extensions.Configuration;

namespace Data.Models.Common;

public static class Connection
{
    private static IConfiguration _keyConfig;
    private static IConfiguration Configuration { get; set; }

    public static IConfiguration AppSettings
    {
        get
        {
            if (_keyConfig == null)
            {
                InitSetting();
                _keyConfig = Configuration.GetSection("AppSettings");
            }

            return _keyConfig;
        }
    }

    public static IConfiguration JWT
    {
        get
        {
            if (_keyConfig == null)
            {
                InitSetting();
                _keyConfig = Configuration.GetSection("JWT");
            }

            return _keyConfig;
        }
    }

    public static void InitSetting()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        Configuration = builder.Build();
    }
}