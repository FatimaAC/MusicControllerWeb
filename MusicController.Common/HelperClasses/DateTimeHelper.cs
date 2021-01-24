using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MusicController.Common.HelperClasses
{
   public static class DateTimeHelper
    {
        public static TimeSpan ShortTimeTo24HourFormat(string timeSpan)
        {
            DateTime dateTime = DateTime.ParseExact(timeSpan,
                                    "hh:mm tt", CultureInfo.InvariantCulture);
            TimeSpan span = dateTime.TimeOfDay;
            //var output = new DateTime().Add(timespan).ToString("hh:mm tt");
            return span;
        }

        public static string ShortTimeTo12HourFormat(TimeSpan timeSpan)
        {
            return new DateTime().Add(timeSpan).ToString("hh:mm tt");
        }

        public static int TotalNoofDays(DateTime currentDate)
        {
            var firstDateofYear = new DateTime(DateTime.Now.Year, 1, 1, 00, 00, 00);
            currentDate = new DateTime(currentDate.Year, currentDate.Month,currentDate.Day, 00, 00, 00);
            return (int)Math.Abs((currentDate - firstDateofYear).TotalDays) + 1;
        }
    }
}
