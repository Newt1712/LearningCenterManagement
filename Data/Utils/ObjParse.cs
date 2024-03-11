using Newtonsoft.Json;

namespace Data.Utils;

public static class ObjParse
{
    public static T ToDTO<T1, T>(this T1 service)
    {
        return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(service));
    }

    public static string GetUserConnectionKey(this string UserID)
    {
        return string.Format("conn_{0}", UserID);
    }
}