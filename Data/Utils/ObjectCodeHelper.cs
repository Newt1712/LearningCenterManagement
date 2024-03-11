namespace Data.Utils;

public static class ObjectCodeHelper
{
    public static string GeneralDrivingCode(int UserID)
    {
        return string.Format("{0}_0_{1}", UserID, DateTime.Now.ToTimeStamp());
    }

    public static string GeneralDrivingCodeByPlanOrder(int UserID, int PlanOrderID)
    {
        return string.Format("{0}_1_{1}_{2}", UserID, PlanOrderID, DateTime.Now.ToTimeStamp());
    }

    public static string GeneralDrivingName(string DriverName)
    {
        return string.Format("Phát sinh {0} {1}", DriverName, DateTime.Now.ToString("dd.MM.yyyy"));
    }

    public static DateTime ConvertUtcToVnTime()
    {
        var utcNow = DateTime.UtcNow;
        var vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
        var vnNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vnTimeZone);
        return vnNow;
    }
}