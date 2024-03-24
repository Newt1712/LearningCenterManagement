using System.ComponentModel;

namespace Data.Models.Common;

public enum EnumMessage
{
    [Description("Oops! Somethings wrong. Please check it again")]
    ERROR = -1,

    [Description("Not found data")] NOT_FOUND = -5,

    [Description("Sign-in information is invalid")]
    LOGIN_ERROR = -6,

    [Description("Not found data")] NOT_EXISTED = -8
}

public enum ResponseStatusCode
{
    Error = -1,
    Success = 1,
    Warning = 0,
    Special = 2
}

public enum EnumCategoryType
{
    [Description("Bài viết")] POSTS = 1,
    [Description("Dịch vụ")] SERVICE = 2
}

public enum EnumInformationType
{
    [Description("Trang chủ")] HOME = 1,
    [Description("About us")] ABOUTUS = 2
}

public static class EnumExtensionMethod
{
    /// <summary>
    ///     Get Enum description
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string GetDescription(this Enum value, bool resource = false)
    {
        var type = value.GetType();
        var name = Enum.GetName(type, value);
        if (name != null)
        {
            var field = type.GetField(name);
            if (field != null)
            {
                var attr =
                    Attribute.GetCustomAttribute(field,
                        typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attr != null)
                {
                    if (resource) return "";
                    return attr.Description;
                }
            }
        }

        return null;
    }

    /// <summary>
    ///     Get Enum value
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int GetValue(this Enum value)
    {
        var type = value.GetType();

        return type.GetEnumValues().Rank;
    }
}