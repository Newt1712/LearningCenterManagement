using Data.Context.MSSQLContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data;

public static class AppSettings
{
    public static MSSQLSettings MSSQLSettings { get; set; }
    public static IConfiguration Keys { get; set; }

    public static void Init(IServiceCollection services, IConfiguration configuration)
    {
        MSSQLSettings = configuration.GetSection("ConnectionStrings").Get<MSSQLSettings>();
        Keys = configuration.GetSection("AppSettings");
    }
}