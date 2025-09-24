//-----------------------------------------------------------------------
// <copyright file="CalendarProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Core;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests
{
    /// <summary>
    /// Summary description for CalendarProcessTests
    /// </summary>
    [TestFixture]
    public class CalendarProcessTests : UnitTestBase
    {
        private ICalendarRepository? TheRepository { get; set; }
        private ICalendarProcess? TheProcess { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheRepository = Substitute.For<ICalendarRepository>();

            TheProcess = new CalendarProcess(CoreInstance, RunTimeEnvironmentSettings, DateTimeService, LoggingService, TheRepository);

            List<DateTime> holidayDates =
            [
                new(2019, 01, 01),
                new(2019, 12, 25),
                new(2020, 12, 25),
                new(2020, 12, 28),
            ];
            holidayDates.ForEach(hd => TheRepository.IsNonWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, hd).Returns(true));

            TheRepository.GetFirstWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, new DateTime(2025, 03, 26)).Returns(new DateTime(2025, 03, 03));
            TheRepository.GetFirstWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, new DateTime(2025, 03, 01)).Returns(new DateTime(2025, 03, 03));
            TheRepository.GetFirstWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, 2025, 03).Returns(new DateTime(2025, 03, 03));
            TheRepository.GetFirstWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, 2025, 03).Returns(new DateTime(2025, 03, 03));

            TheRepository.GetLastWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, new DateTime(2025, 05, 26)).Returns(new DateTime(2025, 05, 30));
            TheRepository.GetLastWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, new DateTime(2025, 05, 01)).Returns(new DateTime(2025, 05, 30));
            TheRepository.GetLastWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, 2025, 05).Returns(new DateTime(2025, 05, 30));
            TheRepository.GetLastWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, 2025, 05).Returns(new DateTime(2025, 05, 30));
        }


        [TestCase("2019-12-16", "2019-12-16")] // Start Monday
        [TestCase("2019-12-17", "2019-12-17")] // Start Tuesday
        [TestCase("2019-12-18", "2019-12-18")] // Start Wednesday
        [TestCase("2019-12-19", "2019-12-19")] // Start Thursday
        [TestCase("2019-12-20", "2019-12-20")] // Start Friday
        [TestCase("2019-12-23", "2019-12-21")] // Start Saturday
        [TestCase("2019-12-23", "2019-12-22")] // Start Sunday
        public void Test_CheckIsWorkingDayOrGetNextWorkingDay(String expectedString, String startDateString)
        {
            DateTime expected = DateTime.Parse(expectedString);
            DateTime startDate = DateTime.Parse(startDateString);

            TheRepository!.CheckIsWorkingDayOrGetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, Arg.Any<DateTime>()).Returns(expected);

            DateTime actual = TheProcess!.CheckIsWorkingDayOrGetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, startDate);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("2019-12-17", "2019-12-16")] // Start Monday
        [TestCase("2019-12-18", "2019-12-17")] // Start Tuesday
        [TestCase("2019-12-19", "2019-12-18")] // Start Wednesday
        [TestCase("2019-12-20", "2019-12-19")] // Start Thursday
        [TestCase("2019-12-23", "2019-12-20")] // Start Friday
        [TestCase("2019-12-23", "2019-12-21")] // Start Saturday
        [TestCase("2019-12-23", "2019-12-22")] // Start Sunday
        public void Test_GetNextWorkingDay(String expectedString, String startDateString)
        {
            DateTime expected = DateTime.Parse(expectedString);
            DateTime startDate = DateTime.Parse(startDateString);

            TheRepository!.GetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, Arg.Any<DateTime>(), Arg.Any<ScheduleInterval>(), Arg.Any<Int32>()).Returns(expected);

            DateTime actual = TheProcess!.GetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, startDate);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("2020-12-29", "2019-12-20", ScheduleInterval.Days, 5)]
        [TestCase("2020-12-29", "2019-12-25", ScheduleInterval.Years, 1)]
        public void Test_GetNextWorkingDay_LookAhead(String expectedString, String startDateString, ScheduleInterval scheduleInterval, Int32 interval)
        {
            DateTime expected = DateTime.Parse(expectedString);
            DateTime startDate = DateTime.Parse(startDateString);

            TheRepository!.GetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, Arg.Any<DateTime>(), Arg.Any<ScheduleInterval>(), Arg.Any<Int32>()).Returns(expected);

            DateTime actual = TheProcess!.GetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, startDate, scheduleInterval, interval);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(true, "2019-01-01")]
        [TestCase(true, "2019-12-25")]
        public void Test_IsHoliday(Boolean expected, String startDateString)
        {
            DateTime startDate = DateTime.Parse(startDateString);

            Boolean actual = TheProcess!.IsHoliday(RunTimeEnvironmentSettings.StandardCountryCode, startDate);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("2025-03-03", "2025-03-26")]
        public void Test_GetFirstWorkingDayOfMonth_Date(String expectedString, String startDateString)
        {
            DateTime expected = DateTime.Parse(expectedString);
            DateTime startDate = DateTime.Parse(startDateString);

            DateTime actual = TheProcess!.GetFirstWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, startDate);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("2025-03-03", 2025, 03)]
        public void Test_GetFirstWorkingDayOfMonth_Year_Month(String expectedString, Int32 year, Int32 month)
        {
            DateTime expected = DateTime.Parse(expectedString);

            DateTime actual = TheProcess!.GetFirstWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, year, month);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("2025-05-30", "2025-05-26")]
        public void Test_GetLastWorkingDayOfMonth_Date(String expectedString, String startDateString)
        {
            DateTime expected = DateTime.Parse(expectedString);
            DateTime startDate = DateTime.Parse(startDateString);

            DateTime actual = TheProcess!.GetLastWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, startDate);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("2025-05-30", 2025, 05)]
        public void Test_GetLastWorkingDayOfMonth_Year_Month(String expectedString, Int32 year, Int32 month)
        {
            DateTime expected = DateTime.Parse(expectedString);

            DateTime actual = TheProcess!.GetLastWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, year, month);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
