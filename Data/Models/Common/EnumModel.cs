namespace Data.Models.Common;

public class EnumModel<T> where T : Enum
{
    public static IEnumerable<T> GetAllValuesAsIEnumerable()
    {
        return Enum.GetValues(typeof(T)).Cast<T>();
    }
}