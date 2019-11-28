using DateTests;
using NUnit.Framework;

namespace Date.Tests
{
    public class Tests
    {
        private DateTimeService _service;

        [SetUp]
        public void Setup()
        {
            _service = new DateTimeService();
        }

        
        //Source date has offset. Source pattern considers offset. No timezone specified. Should pass
        [TestCase("08/12/2018 17:37:32.525+02:00", "MM/dd/yyyy HH:mm:ss.fff+o<HH:mm>", "", true)]

        //Source date has no offset. Source pattern has no offset. Timezone specified. Should pass
        [TestCase("08/12/2018 17:37:32.525", "MM/dd/yyyy HH:mm:ss.fff", "Africa/Cairo", true)]

        //Source date has offset. Source pattern considers offset. Timezone specified. Should fail as both specified
        [TestCase("08/12/2018 17:37:32.525+02:00", "MM/dd/yyyy HH:mm:ss.fff+o<HH:mm>", "Africa/Cairo", false)]


        [TestCase("08/12/2018 17:37:32.525+00:00", "MM/dd/yyyy HH:mm:ss.fff+o<HH:mm>", "Africa/Cairo", false)]

        [TestCase("08/12/2018 17:37:32.525Z", "MM/dd/yyyy HH:mm:ss.fffo<g>", "Africa/Cairo", false)]


        //Source date has no offset. Source pattern has no offset. No timezone specified. Should fail as neither specified
        [TestCase("08/12/2018 17:37:32.525", "MM/dd/yyyy HH:mm:ss.fff", "", false)]


        //Fail with invalid invalid pattern/date combinations
        [TestCase("08/12/2018 17:37:32.525+02:00", "MM/dd/yyyy HH:mm:ss.fff", "", false)]
        [TestCase("08/12/2018 17:37:32.525", "MM/dd/yyyy HH:mm:ss.fff+o<HH:mm>",  "Africa/Cairo", false)]
        [TestCase("08/13/2018 17:37:32.525", "dd/MM/yyyy HH:mm:ss.fff", "Africa/Cairo", false)]


        //Ensure failure when valid offset date but gibberish zone
        [TestCase("08/12/2018 17:37:32.525+02:00", "MM/dd/yyyy HH:mm:ss.fff+o<HH:mm>", "asdf", false)]

        public void Test1(string sourceDateTime, string sourceFormat, string sourceTimeZonePattern, bool expected)
        {
            var result = _service.ValidateSourceDateCriteria(sourceDateTime, sourceFormat, sourceTimeZonePattern);

            Assert.AreEqual(expected, result);
        }
    }
}