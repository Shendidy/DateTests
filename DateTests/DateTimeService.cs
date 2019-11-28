using NodaTime;
using NodaTime.Text;

namespace DateTests
{
    public class DateTimeService
    {
        public bool ValidateSourceDateCriteria(string sourceDateTime, string sourceFormat, string sourceTimeZonePattern)
        {
            //Convert to offsetDateTime
            var isOffset = TryGetOffsetPattern(sourceFormat, out var offsetPattern);
            var isLocal = TryGetLocalPattern(sourceFormat, out var localPattern);

            //If format parsing failed for both local and offset, then the sourceFormat is invalid
            if (!(isOffset || isLocal))
                return false;


            //If this is an offset pattern, but we can't parse the actual date, then fail
            if (isOffset && !offsetPattern.Parse(sourceDateTime).Success)
                return false;

            //If this is a local pattern, but we can't parse the actual date, then fail
            if (isLocal && !localPattern.Parse(sourceDateTime).Success)
                return false;


            var timeZoneExists = !string.IsNullOrWhiteSpace(sourceTimeZonePattern);

            //Ensure exclusivity between timezone and offset
            if (!(timeZoneExists ^ isOffset))
                return false;

            var timeZoneValid =  DateTimeZoneProviders.Tzdb.GetZoneOrNull(sourceTimeZonePattern) != null;

            //Return true if isOffset or there is a valid timezone
            return timeZoneValid || isOffset;
        }

        private bool TryGetOffsetPattern(string format, out IPattern<OffsetDateTime> pattern)
        {
            pattern = default;

            if (!(format.Contains("+o<HH:mm>") || format.EndsWith("Z")))
                return false;

            try
            {
                pattern = OffsetDateTimePattern.CreateWithInvariantCulture(format);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private bool TryGetLocalPattern(string format, out IPattern<LocalDateTime> pattern)
        {
            pattern = default;
            try
            {
                pattern = LocalDateTimePattern.CreateWithInvariantCulture(format);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
