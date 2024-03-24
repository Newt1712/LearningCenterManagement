namespace Data.Utils;

public static class DateTimeHelper
{
    public static DateTime ConvertUtcToVnTime()
    {
        var utcNow = DateTime.UtcNow;
        var vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        var vnNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vnTimeZone);
        return vnNow;
    }
}