using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Sentry;

namespace Data.Utils;

public static class TextHelper
{
    public static int RandomNumber(int min, int max)
    {
        var _random = new Random();
        return _random.Next(min, max);
    }

    public static string GetRandomString(int length)
    {
        var allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
        var chars = new char[length];
        var rd = new Random();
        for (var i = 0; i < length; i++) chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
        return new string(chars);
    }

    public static string GenerateUserCode(int no)
    {
        return $"{DateTime.Now.ToString("YYMM")}{no.ToString("###0")}";
    }

    public static string GetThoundsandNumber(decimal number)
    {
        try
        {
            return number.ToString("#,##0").Replace(",", ".").Replace("-", "");
        }
        catch (Exception ex)
        {
            SentrySdk.CaptureException(ex);
            return number.ToString();
        }
    }

    public static string SHA1(string input)
    {
        return string.Join("", System.Security.Cryptography.SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(input)));
    }

    public static string ToNotDiacriticalMarks(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;
        input = RemoveDiacritics(input.Normalize(NormalizationForm.FormD));
        const string FindText =
            "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴÐ";
        const string ReplText =
            "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYYD";
        var index = -1;
        var arrChar = FindText.ToCharArray();
        while ((index = input.IndexOfAny(arrChar)) != -1)
        {
            var index2 = FindText.IndexOf(input[index]);
            input = input.Replace(input[index], ReplText[index2]);
        }

        return input.Trim();
    }

    private static string RemoveDiacritics(string stIn)
    {
        var stFormD = stIn.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();

        for (var ich = 0; ich < stFormD.Length; ich++)
        {
            var uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
            if (uc != UnicodeCategory.NonSpacingMark) sb.Append(stFormD[ich]);
        }

        return sb.ToString().Normalize(NormalizationForm.FormC);
    }

    public static long ToTimeStamp(this DateTime value)
    {
        var unixTime = ((DateTimeOffset)value.ToLocalTime()).ToUnixTimeMilliseconds();
        return unixTime;
    }

    public static DateTime ToDateTime(this long unixDate)
    {
        return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Unspecified).AddMilliseconds(unixDate).ToLocalTime();
    }

    public static string Base64Encode(string plainText)
    {
        var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }

    public static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }

    public static string StripHTML(string input)
    {
        return Regex.Replace(input, "<.*?>", string.Empty);
    }
}