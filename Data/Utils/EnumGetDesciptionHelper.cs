using System.ComponentModel;

namespace Data.Utils;

public static class EnumGetDesciptionHelper
{
    public static string ToDescription(this Enum value)
    {
        var da = (DescriptionAttribute[])value.GetType().GetField(value.ToString())
            .GetCustomAttributes(typeof(DescriptionAttribute), false);
        return da.Length > 0 ? da[0].Description : value.ToString();
    }
}