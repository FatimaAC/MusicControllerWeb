using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MusicController.Common.HelperClasses
{
   public static class TimeSpanHelper
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
            return new DateTime().Add(timeSpan).ToShortTimeString();
        }
    }
}
