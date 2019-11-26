using NodaTime;
using NodaTime.Text;
using System;
using System.Globalization;

namespace DateTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //Main variables/values to be used
            var sourceDateTimeString = "11/12/2018 17:37:32.125+00:00";
            var sourceTimeZone = "UTC";
            //var sourceDateTimeFormat = "dd/MM/yyyy HH:mm:ss.fffZ";
            //var targetTimeZone = "UTC";
            //var targetDateTimeFormat = "yyyy-MM-ddTHH-mm-ss.fffZ";

            //Check if time zone provided separately and that in the DateTimeString match
            var timeZoneOffset = GetTimeZoneOffset(sourceDateTimeString, sourceTimeZone);
            Console.WriteLine(timeZoneOffset);


            //var SourceDateTimePattern = LocalDateTimePattern.CreateWithInvariantCulture(sourceDateTimeFormat);
            //var SourceDateTime = SourceDateTimePattern.Parse(sourceDateTimeString).Value;

            //var TargetTimeZone = string.IsNullOrEmpty(targetTimeZone) ?  sourceTimeZone : targetTimeZone;
            //var SourceTzPattern = DateTimeZoneProviders.Tzdb[sourceTimeZone];
            //var TargetTzPattern = DateTimeZoneProviders.Tzdb[TargetTimeZone];

            //var SourceZonedDateTime = SourceDateTime.InZoneLeniently(SourceTzPattern);
            //var TargetZonedDateTime = SourceZonedDateTime.WithZone(TargetTzPattern);

            //var TargetDateTimeFormat = targetDateTimeFormat;


            //var outPattern = ZonedDateTimePattern.CreateWithInvariantCulture(TargetDateTimeFormat, DateTimeZoneProviders.Tzdb);
            //Console.WriteLine(outPattern.Format(TargetZonedDateTime));

        }


        public static bool TryParseExact(string sourceDateTimeString, string sourceDateTimeFormat)
        {
            var canParse = System.DateTime.TryParseExact(sourceDateTimeString, sourceDateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDateTime);

            return canParse;
        }

        public static string GetTimeZoneOffset(string sourceDateTimeString, string sourceTimeZone)
        {
            string timeZoneOffset = "test";
            //Offset x = DateTimeZoneProviders

            return timeZoneOffset;
        }

    }
}
