//-----------------------------------------------------------------------
// <copyright file="CalendarServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;

using Foundation.Interfaces;

using Foundation.Tests.System.BaseClasses;

namespace Foundation.Tests.System.Foundation.Services.Application
{
    /// <summary>
    /// System Tests for CalendarService
    /// </summary>
    [TestFixture]
    public class CalendarServiceTests : SystemTestBase
    {
        private ICalendarService? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheService = CoreInstance.IoC.Get<ICalendarService>();
        }

        [TestCase(false, "GB", "2026-12-24", "GB-Christmas Eve")]
        [TestCase(true, "GB", "2026-12-25", "GB-Christmas Day")]
        [TestCase(false, "GB", "2026-03-09", "GB-Monday")]
        [TestCase(false, "GB", "2026-03-10", "GB-Tuesday")]
        [TestCase(false, "GB", "2026-03-11", "GB-Wednesday")]
        [TestCase(false, "GB", "2026-03-12", "GB-Thursday")]
        [TestCase(false, "GB", "2026-03-13", "GB-Friday")]
        [TestCase(true, "GB", "2026-03-14", "GB-Saturday")]
        [TestCase(true, "GB", "2026-03-15", "GB-Sunday")]
        public void Test_IsNonWorkingDay(Boolean expected, String countryCode, String startDateString, String comment)
        {
            DateTime startDate = DateTime.ParseExact(startDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            Boolean actual = TheService!.IsNonWorkingDay(countryCode, startDate);

            Assert.That(actual, Is.EqualTo(expected), comment);
        }

        [TestCase("2026-12-29", "GB", "2026-12-24", "GB-Christmas Eve")]
        [TestCase("2026-12-29", "GB", "2026-12-25", "GB-Christmas Day")]
        [TestCase("2019-12-17", "GB", "2019-12-16", "GB-Start Mon 16")]
        [TestCase("2019-12-18", "GB", "2019-12-17", "GB-Start Tue 17")]
        [TestCase("2019-12-19", "GB", "2019-12-18", "GB-Start Wed 18")]
        [TestCase("2019-12-20", "GB", "2019-12-19", "GB-Start Thu 19")]
        [TestCase("2019-12-23", "GB", "2019-12-20", "GB-Start Fri 20")]
        [TestCase("2019-12-23", "GB", "2019-12-21", "GB-Start Sat 21")]
        [TestCase("2019-12-23", "GB", "2019-12-22", "GB-Start Sun 22")]
        [TestCase("2019-12-24", "GB", "2019-12-23", "GB-Start Mon 23")]
        [TestCase("2019-12-27", "GB", "2019-12-24", "GB-Start Tue 24")]
        [TestCase("2019-12-27", "GB", "2019-12-25", "GB-Start Wed 25")]
        [TestCase("2019-12-27", "GB", "2019-12-26", "GB-Start Thu 26")]
        [TestCase("2019-12-30", "GB", "2019-12-27", "GB-Start Fri 27")]
        [TestCase("2019-12-30", "GB", "2019-12-28", "GB-Start Sat 28")]
        [TestCase("2019-12-30", "GB", "2019-12-29", "GB-Start Sun 29")]
        [TestCase("2019-12-31", "GB", "2019-12-30", "GB-Start Mon 30")]
        public void Test_GetNextWorkingDay_DateOnly(String expectedString, String countryCode, String startDateString, String comment)
        {
            DateTime expected = DateTime.ParseExact(expectedString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime startDate = DateTime.ParseExact(startDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            DateTime actual = TheService!.GetNextWorkingDay(countryCode, startDate);

            Assert.That(actual, Is.EqualTo(expected), comment);
        }

        [TestCase("2019-12-24 10:30:30", "GB", "00:01:30:30", "2019-12-24 09:00:00", "GB-Christmas Eve")]
        [TestCase("2026-12-24 10:30:30", "GB", "00:01:30:30", "2026-12-24 09:00:00", "GB-Christmas Eve")]
        [TestCase("2019-12-27 10:30:30", "GB", "00:01:30:30", "2019-12-25 09:00:00", "GB-Christmas day")]
        [TestCase("2026-12-29 10:30:30", "GB", "00:01:30:30", "2026-12-25 09:00:00", "GB-Christmas Day")]
        [TestCase("2019-12-16 14:13:25", "GB", "00:05:13:25", "2019-12-16 09:00:00", "GB-Start Mon 16")]
        [TestCase("2019-12-17 14:13:25", "GB", "00:05:13:25", "2019-12-17 09:00:00", "GB-Start Tue 17")]
        [TestCase("2019-12-18 14:13:25", "GB", "00:05:13:25", "2019-12-18 09:00:00", "GB-Start Wed 18")]
        [TestCase("2019-12-19 11:13:25", "GB", "00:02:13:25", "2019-12-19 09:00:00", "GB-Start Thu 19")]
        [TestCase("2019-12-23 11:13:25", "GB", "00:10:13:25", "2019-12-20 09:00:00", "GB-Start Fri 20")]
        [TestCase("2019-12-23 09:13:25", "GB", "00:08:13:25", "2019-12-21 09:00:00", "GB-Start Sat 21")]
        [TestCase("2019-12-24 09:13:25", "GB", "00:16:13:25", "2019-12-22 09:00:00", "GB-Start Sun 22")]
        [TestCase("2019-12-23 10:30:30", "GB", "00:01:30:30", "2019-12-23 09:00:00", "GB-Start Mon 23")]
        [TestCase("2019-12-24 10:30:30", "GB", "00:01:30:30", "2019-12-24 09:00:00", "GB-Start Tue 24")]
        [TestCase("2019-12-27 14:13:25", "GB", "00:05:13:25", "2019-12-25 09:00:00", "GB-Start Wed 25")]
        [TestCase("2019-12-27 14:13:25", "GB", "00:05:13:25", "2019-12-26 09:00:00", "GB-Start Thu 26")]
        [TestCase("2019-12-27 15:13:25", "GB", "00:05:13:25", "2019-12-27 10:00:00", "GB-Start Fri 27")]
        [TestCase("2019-12-30 11:13:25", "GB", "00:02:13:25", "2019-12-28 09:00:00", "GB-Start Sat 28")]
        [TestCase("2019-12-30 11:13:25", "GB", "00:10:13:25", "2019-12-29 09:00:00", "GB-Start Sun 29")]
        [TestCase("2019-12-31 09:13:25", "GB", "00:08:13:25", "2019-12-30 09:00:00", "GB-Start Mon 30")]
        [TestCase("2020-12-29 10:30:30", "GB", "00:01:30:30", "2020-12-29 09:00:00", "GB-Within window 1")]
        [TestCase("2021-08-13 15:13:25", "GB", "00:05:13:25", "2021-08-13 10:00:00", "GB-Within window 2")]
        [TestCase("2021-08-13 14:13:25", "GB", "00:05:13:25", "2021-08-13 06:00:00", "GB-Before start time")]
        [TestCase("2021-08-13 15:13:25", "GB", "00:05:13:25", "2021-08-13 10:00:00", "GB-After end time 1")]
        [TestCase("2021-08-16 11:13:25", "GB", "00:02:13:25", "2021-08-13 20:00:00", "GB-After end time 2")]
        [TestCase("2021-08-16 11:13:25", "GB", "00:10:13:25", "2021-08-13 08:00:00", "GB-Duration Greater Than One Day 1")]
        [TestCase("2021-08-16 09:13:25", "GB", "00:08:13:25", "2021-08-13 09:00:00", "GB-Duration Greater Than One Day 2")]
        [TestCase("2021-08-16 09:13:25", "GB", "00:16:13:25", "2021-08-13 09:00:00", "GB-Duration Greater Than Two Days 1")]
        public void Test_GetNextWorkingDay_TimeWindow(String expectedString, String countryCode, String durationString, String startDateTimeString, String comment)
        {
            TimeWindow workingTimeWindow = new TimeWindow(new TimeSpan(09, 00, 00), new TimeSpan(17, 00, 00));

            DateTime expected = DateTime.ParseExact(expectedString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime startDateTime = DateTime.ParseExact(startDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.ParseExact(durationString, "dd\\:hh\\:mm\\:ss", CultureInfo.InvariantCulture);

            DateTime actual = TheService!.GetNextWorkingDay(countryCode, startDateTime, workingTimeWindow, duration);

            Assert.That(actual, Is.EqualTo(expected), comment);
        }

        [TestCase("2020-12-29", "GB", "2020-12-20", ScheduleInterval.Days, 5, "GB-2020-12-20")]
        [TestCase("2021-01-25", "GB", "2020-12-20", ScheduleInterval.Weeks, 5, "GB-2020-12-20")]
        [TestCase("2021-05-10", "GB", "2020-12-20", ScheduleInterval.Months, 5, "GB-2020-12-20")]
        [TestCase("2021-12-29", "GB", "2020-12-25", ScheduleInterval.Years, 1, "GB-2020-12-25")]
        [TestCase("2021-12-29", "GB", "2020-12-26", ScheduleInterval.Years, 1, "GB-2020-12-26")]
        [TestCase("2021-12-29", "GB", "2020-12-27", ScheduleInterval.Years, 1, "GB-2020-12-27")]
        [TestCase("2021-12-29", "GB", "2020-12-28", ScheduleInterval.Years, 1, "GB-2020-12-28")]
        [TestCase("2021-12-29", "GB", "2020-12-29", ScheduleInterval.Years, 1, "GB-2020-12-29")]
        [TestCase("2021-12-30", "GB", "2020-12-30", ScheduleInterval.Years, 1, "GB-2020-12-30")]
        public void Test_GetNextWorkingDay_Interval(String expectedString, String countryCode, String startDateString, ScheduleInterval scheduleInterval, Int32 interval, String comment)
        {
            DateTime expected = DateTime.ParseExact(expectedString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime startDate = DateTime.ParseExact(startDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            DateTime actual = TheService!.GetNextWorkingDay(countryCode, startDate, scheduleInterval, interval);

            Assert.That(actual, Is.EqualTo(expected), comment);
        }

        [TestCase("2019-12-16", "GB", "2019-12-16", "Start Monday")]
        [TestCase("2019-12-17", "GB", "2019-12-17", "Start Tuesday")]
        [TestCase("2019-12-18", "GB", "2019-12-18", "Start Wednesday")]
        [TestCase("2019-12-19", "GB", "2019-12-19", "Start Thursday")]
        [TestCase("2019-12-20", "GB", "2019-12-20", "Start Friday")]
        [TestCase("2019-12-23", "GB", "2019-12-21", "Start Saturday")]
        [TestCase("2019-12-23", "GB", "2019-12-22", "Start Sunday")]
        public void Test_CheckIsWorkingDayOrGetNextWorkingDay(String expectedString, String countryCode, String startDateString, String comment)
        {
            DateTime expected = DateTime.ParseExact(expectedString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime startDate = DateTime.ParseExact(startDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            DateTime actual = TheService!.CheckIsWorkingDayOrGetNextWorkingDay(countryCode, startDate);

            Assert.That(actual, Is.EqualTo(expected), comment);
        }

        [TestCase("2026-01-02", "2026-01-30", "GB", "2026-01-15", "January")]
        [TestCase("2026-02-02", "2026-02-27", "GB", "2026-02-15", "February")]
        [TestCase("2026-03-02", "2026-03-31", "GB", "2026-03-15", "March")]
        [TestCase("2026-04-01", "2026-04-30", "GB", "2026-04-15", "April")]
        [TestCase("2026-05-01", "2026-05-29", "GB", "2026-05-15", "May")]
        [TestCase("2026-06-01", "2026-06-30", "GB", "2026-06-15", "June")]
        [TestCase("2026-07-01", "2026-07-31", "GB", "2026-07-15", "July")]
        [TestCase("2026-08-03", "2026-08-28", "GB", "2026-08-15", "August")]
        [TestCase("2026-09-01", "2026-09-30", "GB", "2026-09-15", "September")]
        [TestCase("2026-10-01", "2026-10-30", "GB", "2026-10-15", "October")]
        [TestCase("2026-11-02", "2026-11-30", "GB", "2026-11-15", "November")]
        [TestCase("2026-12-01", "2026-12-31", "GB", "2026-12-15", "December")]
        public void Test_GetFirstAndLastWorkingDayOfMonth(String expectedFirstString, String expectedLastString, String countryCode, String startDateString, String comment)
        {
            DateTime expectedFirst = DateTime.ParseExact(expectedFirstString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime expectedLast = DateTime.ParseExact(expectedLastString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime startDate = DateTime.ParseExact(startDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            DateTime actualFirst1 = TheService!.GetFirstWorkingDayOfMonth(countryCode, startDate);
            DateTime actualFirst2 = TheService!.GetFirstWorkingDayOfMonth(countryCode, startDate.Year, startDate.Month);
            DateTime actualLast1 = TheService!.GetLastWorkingDayOfMonth(countryCode, startDate);
            DateTime actualLast2 = TheService!.GetLastWorkingDayOfMonth(countryCode, startDate.Year, startDate.Month);

            Assert.That(actualFirst1, Is.EqualTo(expectedFirst), comment);
            Assert.That(actualFirst2, Is.EqualTo(expectedFirst), comment);
            Assert.That(actualLast1, Is.EqualTo(expectedLast), comment);
            Assert.That(actualLast2, Is.EqualTo(expectedLast), comment);
        }
    }
}
