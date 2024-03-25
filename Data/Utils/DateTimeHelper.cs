using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utils
{
    public record DateRange
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
    public static class DateTimeHelper
    {
        public static DateTime ConvertUtcToVnTime()
        {
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo vnTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime vnNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, vnTimeZone);
            return vnNow;
        }
        

        public static DateRange GetStartAndEndTimeOfSlot(Slot slot)
        {
            switch (slot)
            {
                case Slot.Morning:
                    return new DateRange { StartTime = new TimeSpan(7, 30, 0), EndTime = new TimeSpan(12, 0, 0) };
                case Slot.Afternoon:
                    return new DateRange { StartTime = new TimeSpan(1, 30, 0), EndTime = new TimeSpan(5, 0, 0) };
                case Slot.Night:
                    return new DateRange { StartTime = new TimeSpan(6, 0, 0), EndTime = new TimeSpan(9, 0, 0) };
            }
            return new DateRange { StartTime = new TimeSpan(7, 30, 0), EndTime = new TimeSpan(12, 0, 0) };
        }
    }
}
