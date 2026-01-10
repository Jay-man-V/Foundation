//-----------------------------------------------------------------------
// <copyright file="CalendarServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;

using NSubstitute;
using NSubstitute.ClearExtensions;

using Foundation.Interfaces;
using Foundation.Services.Application;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    /// <summary>
    /// Summary description for CalendarServiceTests
    /// </summary>
    [TestFixture]
    public class CalendarServiceTests : UnitTestBase
    {
        private ICalendarRepository? CalendarRepository { get; set; }
        private ICalendarService? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            CalendarRepository = Substitute.For<ICalendarRepository>();

            TheService = new CalendarService(DateTimeService, CalendarRepository);

            List<DateTime> holidayDates =
            [
                new DateTime(2019, 01, 01),
                new DateTime(2019, 12, 25),
                new DateTime(2020, 12, 25),
                new DateTime(2020, 12, 28),
            ];
            holidayDates.ForEach(hd => CalendarRepository.IsNonWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, hd).Returns(true));

            CalendarRepository.GetFirstWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, new DateTime(2025, 03, 26)).Returns(new DateTime(2025, 03, 03));
            CalendarRepository.GetFirstWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, new DateTime(2025, 03, 01)).Returns(new DateTime(2025, 03, 03));
            CalendarRepository.GetFirstWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, 2025, 03).Returns(new DateTime(2025, 03, 03));
            CalendarRepository.GetFirstWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, 2025, 03).Returns(new DateTime(2025, 03, 03));

            CalendarRepository.GetLastWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, new DateTime(2025, 05, 26)).Returns(new DateTime(2025, 05, 30));
            CalendarRepository.GetLastWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, new DateTime(2025, 05, 01)).Returns(new DateTime(2025, 05, 30));
            CalendarRepository.GetLastWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, 2025, 05).Returns(new DateTime(2025, 05, 30));
            CalendarRepository.GetLastWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, 2025, 05).Returns(new DateTime(2025, 05, 30));
        }


        [TestCase("2019-12-16", "2019-12-16", "Start Monday")]
        [TestCase("2019-12-17", "2019-12-17", "Start Tuesday")]
        [TestCase("2019-12-18", "2019-12-18", "Start Wednesday")]
        [TestCase("2019-12-19", "2019-12-19", "Start Thursday")]
        [TestCase("2019-12-20", "2019-12-20", "Start Friday")]
        [TestCase("2019-12-23", "2019-12-21", "Start Saturday")]
        [TestCase("2019-12-23", "2019-12-22", "Start Sunday")]
        public void Test_CheckIsWorkingDayOrGetNextWorkingDay(String expectedString, String startDateString, String comment)
        {
            DateTime expected = DateTime.Parse(expectedString);
            DateTime startDate = DateTime.Parse(startDateString);

            CalendarRepository!.CheckIsWorkingDayOrGetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, Arg.Any<DateTime>()).Returns(expected);

            DateTime actual = TheService!.CheckIsWorkingDayOrGetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, startDate);

            Assert.That(actual, Is.EqualTo(expected), comment);
        }

        [TestCase("2019-12-17", "2019-12-16", "Start Monday")]
        [TestCase("2019-12-18", "2019-12-17", "Start Tuesday")]
        [TestCase("2019-12-19", "2019-12-18", "Start Wednesday")]
        [TestCase("2019-12-20", "2019-12-19", "Start Thursday")]
        [TestCase("2019-12-23", "2019-12-20", "Start Friday")]
        [TestCase("2019-12-23", "2019-12-21", "Start Saturday")]
        [TestCase("2019-12-23", "2019-12-22", "Start Sunday")]
        public void Test_GetNextWorkingDay(String expectedString, String startDateString, String comment)
        {
            DateTime expected = DateTime.Parse(expectedString);
            DateTime startDate = DateTime.Parse(startDateString);

            CalendarRepository!.GetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, Arg.Any<DateTime>(), Arg.Any<ScheduleInterval>(), Arg.Any<Int32>()).Returns(expected);

            DateTime actual = TheService!.GetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, startDate);

            Assert.That(actual, Is.EqualTo(expected), comment);
        }

        [TestCase("2020-12-29", "2019-12-20", ScheduleInterval.Days, 5)]
        [TestCase("2020-12-29", "2019-12-25", ScheduleInterval.Years, 1)]
        public void Test_GetNextWorkingDay_LookAhead(String expectedString, String startDateString, ScheduleInterval scheduleInterval, Int32 interval)
        {
            DateTime expected = DateTime.Parse(expectedString);
            DateTime startDate = DateTime.Parse(startDateString);

            CalendarRepository!.GetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, Arg.Any<DateTime>(), Arg.Any<ScheduleInterval>(), Arg.Any<Int32>()).Returns(expected);

            DateTime actual = TheService!.GetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, startDate, scheduleInterval, interval);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("2020-12-29 10:30:30", "00:01:30:30", "2020-12-29 09:00:00", "2020-12-29 09:00:00", "2020-12-29 09:00:00", "Within window 1")]
        [TestCase("2019-12-29 10:30:30", "00:01:30:30", "2019-12-25 09:00:00", "2019-12-25 09:00:00", "2019-12-29 09:00:00", "Christmas day")]
        [TestCase("2021-08-13 15:13:25", "00:05:13:25", "2021-08-13 10:00:00", "2021-08-13 10:00:00", "2021-08-13 10:00:00", "Within window 2")]
        [TestCase("2021-08-13 14:13:25", "00:05:13:25", "2021-08-13 06:00:00", "2021-08-13 09:00:00", "2021-08-13 09:00:00", "Before start time")]
        [TestCase("2021-08-13 15:13:25", "00:05:13:25", "2021-08-13 10:00:00", "2021-08-13 10:00:00", "2021-08-13 10:00:00", "After end time 1")]
        [TestCase("2021-08-14 11:13:25", "00:02:13:25", "2021-08-13 20:00:00", "2021-08-14 09:00:00", "2021-08-14 09:00:00", "After end time 2")]
        [TestCase("2021-08-14 11:13:25", "00:10:13:25", "2021-08-13 08:00:00", "2021-08-13 09:00:00", "2021-08-13 09:00:00", "Duration Greater Than One Day 1")]
        [TestCase("2021-08-14 09:13:25", "00:08:13:25", "2021-08-13 09:00:00", "2021-08-13 09:00:00", "2021-08-13 09:00:00", "Duration Greater Than One Day 2")]
        [TestCase("2021-08-15 09:13:25", "00:16:13:25", "2021-08-13 09:00:00", "2021-08-13 09:00:00", "2021-08-13 09:00:00", "Duration Greater Than Two Days 1")]
        public void Test_GetNextWorkingDay_TimeWindow_TimeSpan(String expectedString, String durationString, String startDateString, String calendarCheckDateTimeString, String calendarReturnString, String comment)
        {
            TimeWindow timeWindow = new TimeWindow(new TimeSpan(09, 00, 00), new TimeSpan(17, 00, 00));
            DateTime expected = DateTime.ParseExact(expectedString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.ParseExact(durationString, "dd\\:hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            DateTime startDate = DateTime.ParseExact(startDateString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime calendarCheckDateTime = DateTime.ParseExact(calendarCheckDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime calendarReturnDate = DateTime.ParseExact(calendarReturnString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            CalendarRepository!.ClearSubstitute();
            CalendarRepository!.CheckIsWorkingDayOrGetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, startDate).Returns(startDate);
            CalendarRepository!.CheckIsWorkingDayOrGetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, calendarCheckDateTime).Returns(calendarReturnDate);
            CalendarRepository!.CheckIsWorkingDayOrGetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, calendarCheckDateTime.AddDays(1)).Returns(calendarReturnDate.AddDays(1));
            CalendarRepository!.CheckIsWorkingDayOrGetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, calendarCheckDateTime.AddDays(2)).Returns(calendarReturnDate.AddDays(2));

            DateTime actual = TheService!.GetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, startDate, timeWindow, duration);

            Assert.That(actual, Is.EqualTo(expected), comment);
        }

        [TestCase(true, "2019-01-01")]
        [TestCase(true, "2019-12-25")]
        public void Test_IsHoliday(Boolean expected, String startDateString)
        {
            DateTime startDate = DateTime.Parse(startDateString);

            Boolean actual = TheService!.IsHoliday(RunTimeEnvironmentSettings.StandardCountryCode, startDate);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("2025-03-03", "2025-03-26")]
        public void Test_GetFirstWorkingDayOfMonth_Date(String expectedString, String startDateString)
        {
            DateTime expected = DateTime.Parse(expectedString);
            DateTime startDate = DateTime.Parse(startDateString);

            DateTime actual = TheService!.GetFirstWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, startDate);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("2025-03-03", 2025, 03)]
        public void Test_GetFirstWorkingDayOfMonth_Year_Month(String expectedString, Int32 year, Int32 month)
        {
            DateTime expected = DateTime.Parse(expectedString);

            DateTime actual = TheService!.GetFirstWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, year, month);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("2025-05-30", "2025-05-26")]
        public void Test_GetLastWorkingDayOfMonth_Date(String expectedString, String startDateString)
        {
            DateTime expected = DateTime.Parse(expectedString);
            DateTime startDate = DateTime.Parse(startDateString);

            DateTime actual = TheService!.GetLastWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, startDate);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("2025-05-30", 2025, 05)]
        public void Test_GetLastWorkingDayOfMonth_Year_Month(String expectedString, Int32 year, Int32 month)
        {
            DateTime expected = DateTime.Parse(expectedString);

            DateTime actual = TheService!.GetLastWorkingDayOfMonth(RunTimeEnvironmentSettings.StandardCountryCode, year, month);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
