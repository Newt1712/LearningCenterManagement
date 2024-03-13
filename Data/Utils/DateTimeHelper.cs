using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utils
{
    public static class DateTimeHelper
    {
        public static DateTime ConvertUtcToVnTime()
        {
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime vnNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vnTimeZone);
            return vnNow;
        }
    }
}
