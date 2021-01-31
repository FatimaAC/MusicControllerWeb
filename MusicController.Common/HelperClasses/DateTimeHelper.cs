using System;
using System.Globalization;

namespace MusicController.Common.HelperClasses
{
    public static class DateTimeHelper
    {
        public static TimeSpan ShortTimeTo24HourFormat(string timeSpan)
        {
            DateTime dateTime = DateTime.ParseExact(timeSpan,
                                    "hh:mm tt", CultureInfo.InvariantCulture);
            return dateTime.TimeOfDay; ;
        }

        public static string ShortTimeTo12HourFormat(TimeSpan timeSpan)
        {
            return new DateTime().Add(timeSpan).ToString("hh:mm tt");
        }

        public static int TotalNoofDays(DateTime dateTime)
        {
            var firstDateofYear = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 00, 00, 00);
            return firstDateofYear.DayOfYear;
        }
    }
}
