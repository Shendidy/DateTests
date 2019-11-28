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
           // Main variables/ values to be used
             var sourceDateTimeString = "08/12/2018 17:37:32.525+02:00";
            var sourceDateTimeFormat = "MM/dd/yyyy HH:mm:ss.fffzzz";
            var sourceTimeZonePattern = "Africa/Cairo";




            //var offset = DateTimeOffset.ParseExact(sourceDateTimeString, sourceDateTimeFormat, Culturei)

            //TimeZoneInfo testInfo = TimeZoneInfo.Utc;

            //var offsetFromUtc = testInfo.GetUtcOffset(Convert.ToDateTime(sourceDateTimeString));

            var convertedStringDateTime = DateTimeOffset.Parse(sourceDateTimeString, CultureInfo.GetCultureInfo("en-US")).UtcDateTime.ToString("yyyy-MM-ddTHH:mm:ss");
            //var offsetFromString = convertedDateTime.ToUniversalTime();

            var sourceDateTimeAsIsString = DateTimeOffset.Parse(sourceDateTimeString).DateTime.ToString("yyyy-MM-ddTHH:mm:ss");

            var targetTimeZone = "UTC";
            var targetDateTimeFormat = "yyyy-MM-ddTHH:mm:ss";

            //Check if time zone provided separately and that in the DateTimeString match

            var SourceDateTimePattern = LocalDateTimePattern.CreateWithInvariantCulture(sourceDateTimeFormat);
            var SourceDateTime = SourceDateTimePattern.Parse(sourceDateTimeAsIsString).Value;

            var TargetTimeZone = string.IsNullOrEmpty(targetTimeZone) ? sourceTimeZonePattern : targetTimeZone;
            var sourceTz = DateTimeZoneProviders.Tzdb[sourceTimeZonePattern];
            var targetTz = DateTimeZoneProviders.Tzdb[TargetTimeZone];

            var SourceZonedDateTime = SourceDateTime.InZoneLeniently(sourceTz);
            var TargetZonedDateTime = SourceZonedDateTime.WithZone(targetTz);


            var outPattern = ZonedDateTimePattern.CreateWithInvariantCulture(targetDateTimeFormat, DateTimeZoneProviders.Tzdb);


            var outputString = outPattern.Format(TargetZonedDateTime);
            Console.WriteLine(outPattern.Format(TargetZonedDateTime));

        }





        public DateTime GetDateTimeObject(string dateTimeString, string timeZoneSpecifier)
        {
            DateTime convertedDateTime = new DateTime();



            return convertedDateTime;
        }

        //public static bool TryParseExact(string sourceDateTimeString, string sourceDateTimeFormat)
        //{
        //    var canParse = System.DateTime.TryParseExact(sourceDateTimeString, sourceDateTimeFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDateTime);

        //    return canParse;
        //}

        //public static string GetTimeZoneOffset(string sourceDateTimeString)
        //{
        //    string timeZoneOffset = "test";
        //    //Offset x = DateTimeZoneProviders

        //    return timeZoneOffset;
        //}

    }
}
