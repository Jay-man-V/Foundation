//-----------------------------------------------------------------------
// <copyright file="DateTimeServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Services.Application;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    /// <summary>
    /// The DateTime Service Tests
    /// </summary>
    [TestFixture]
    public class DateTimeServiceTests : UnitTestBase
    {
        DateTime StartDate => new DateTime(2023, 01, 01);
        DateTime EndDate => new DateTime(2025, 12, 31);

        private IDateTimeService? TheService { get; set; }
        private DateTime InjectedUtcDateTime { get; set; }
        private DateTime InjectedLocalDateTime { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            InjectedUtcDateTime = SystemDateTime;
            InjectedLocalDateTime = SystemDateTime;

            TheService = new DateTimeService(DayOfWeek.Monday, InjectedUtcDateTime, InjectedLocalDateTime);
        }

        public override void TestCleanup()
        {
            TheService = null;

            base.TestCleanup();
        }

        [TestCase]
        public void Test_Scenario_NewValidityPeriod()
        {
            DateTime currentDate = InjectedUtcDateTime;
            DateTime t = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 23, 59, 59);
            DateTime expected = DateTime.SpecifyKind(t.AddMonths(6), DateTimeKind.Utc);

            TimeSpan endTime = new TimeSpan(23, 59, 59);
            DateTime actual = TheService!.MakeUtcDateTime(TheService!.SystemUtcDateTimeNow.AddMonths(6), endTime);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_MakeUtc()
        {
            DateTime expected = new DateTime(2019, 1, 1, 20, 0, 0, DateTimeKind.Utc);

            DateTime aDate = new DateTime(2019, 1, 1, 20, 0, 0);

            DateTime actual = TheService!.MakeUtcDateTime(aDate);

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(actual.Kind, Is.EqualTo(DateTimeKind.Utc));
        }

        [TestCase]
        public void Test_MakeUtc_TimeSpan()
        {
            DateTime expected = new DateTime(2019, 1, 1, 20, 0, 0, DateTimeKind.Utc);

            DateTime aDate = new DateTime(2019, 1, 1);
            TimeSpan endTime = new TimeSpan(20, 0, 0);

            DateTime actual = TheService!.MakeUtcDateTime(aDate, endTime);

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(actual.Kind, Is.EqualTo(DateTimeKind.Utc));
        }

        [TestCase]
        public void Test_MakeUtc_Time()
        {
            DateTime expected = new DateTime(2019, 1, 1, 20, 0, 0, DateTimeKind.Utc);

            DateTime aDate = new DateTime(2019, 1, 1);

            DateTime actual = TheService!.MakeUtcDateTime(aDate, 20, 0, 0);

            Assert.That(actual, Is.EqualTo(expected));
            Assert.That(actual.Kind, Is.EqualTo(DateTimeKind.Utc));
        }

        [TestCase]
        public void Test_StartOfWeek()
        {
            DayOfWeek value = DayOfWeek.Monday;
            DayOfWeek actualValue = TheService!.StartOfWeek;

            Assert.That(actualValue, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_LocalDateTimeNow()
        {
            DateTime value = InjectedLocalDateTime;
            DateTime actualValue = TheService!.LocalDateTimeNow;

            Assert.That(actualValue.Date, Is.EqualTo(value.Date));
            Assert.That(actualValue.TimeOfDay.Hours, Is.EqualTo(value.TimeOfDay.Hours));
            Assert.That(actualValue.TimeOfDay.Minutes, Is.EqualTo(value.TimeOfDay.Minutes));
            Assert.That(actualValue.TimeOfDay.Seconds, Is.EqualTo(value.TimeOfDay.Seconds));
            Assert.That(actualValue.TimeOfDay.Milliseconds, Is.EqualTo(value.TimeOfDay.Milliseconds));
        }

        [TestCase]
        public void Test_SystemDateTimeNow()
        {
            DateTime value = InjectedUtcDateTime;
            DateTime actualValue = TheService!.SystemUtcDateTimeNow;

            Assert.That(actualValue.Date, Is.EqualTo(value.Date));
            Assert.That(actualValue.TimeOfDay.Hours, Is.EqualTo(value.TimeOfDay.Hours));
            Assert.That(actualValue.TimeOfDay.Minutes, Is.EqualTo(value.TimeOfDay.Minutes));
            Assert.That(actualValue.TimeOfDay.Seconds, Is.EqualTo(value.TimeOfDay.Seconds));
            Assert.That(actualValue.TimeOfDay.Milliseconds, Is.EqualTo(value.TimeOfDay.Milliseconds));
        }

        [TestCase]
        public void Test_SystemDateTimeNowWithoutMilliseconds()
        {
            DateTime value = InjectedUtcDateTime;
            DateTime actualValue = TheService!.SystemUtcDateTimeNowWithoutMilliseconds;

            Assert.That(actualValue.Date, Is.EqualTo(value.Date));
            Assert.That(actualValue.TimeOfDay.Hours, Is.EqualTo(value.TimeOfDay.Hours));
            Assert.That(actualValue.TimeOfDay.Minutes, Is.EqualTo(value.TimeOfDay.Minutes));
            Assert.That(actualValue.TimeOfDay.Seconds, Is.EqualTo(value.TimeOfDay.Seconds));
        }

        [TestCase("2025-12-14", "2025-12-20", "2025-12-26", DayOfWeek.Sunday)]
        [TestCase("2025-12-15", "2025-12-21", "2025-12-26", DayOfWeek.Monday)]
        [TestCase("2025-12-16", "2025-12-22", "2025-12-26", DayOfWeek.Tuesday)]
        [TestCase("2025-12-17", "2025-12-23", "2025-12-26", DayOfWeek.Wednesday)]
        [TestCase("2025-12-18", "2025-12-24", "2025-12-26", DayOfWeek.Thursday)]
        [TestCase("2025-12-19", "2025-12-25", "2025-12-26", DayOfWeek.Friday)]
        [TestCase("2025-12-13", "2025-12-19", "2025-12-26", DayOfWeek.Saturday)]
        public void Test_GetStartOfLastWeek_GetEndOfLastWeek(String expectedStartOfWeekString, String expectedEndOfWeekString, String workingDateString, DayOfWeek newStartOfWeek)
        {
            DateTime expectedStartOfWeek = DateTime.ParseExact(expectedStartOfWeekString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime expectedEndOfWeek = DateTime.ParseExact(expectedEndOfWeekString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime workingDate = DateTime.ParseExact(workingDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            IDateTimeService dateTimeService = new DateTimeService(newStartOfWeek, workingDate, workingDate);

            DateTime actualStartOfWeek1 = dateTimeService.GetStartOfLastWeek();
            Assert.That(actualStartOfWeek1, Is.EqualTo(expectedStartOfWeek));

            DateTime actualEndOfWeek1 = dateTimeService.GetEndOfLastWeek();
            Assert.That(actualEndOfWeek1, Is.EqualTo(expectedEndOfWeek));
        }

        [TestCase("2025-12-21", "2025-12-27", "2025-12-26", DayOfWeek.Sunday)]
        [TestCase("2025-12-22", "2025-12-28", "2025-12-26", DayOfWeek.Monday)]
        [TestCase("2025-12-23", "2025-12-29", "2025-12-26", DayOfWeek.Tuesday)]
        [TestCase("2025-12-24", "2025-12-30", "2025-12-26", DayOfWeek.Wednesday)]
        [TestCase("2025-12-25", "2025-12-31", "2025-12-26", DayOfWeek.Thursday)]
        [TestCase("2025-12-26", "2026-01-01", "2025-12-26", DayOfWeek.Friday)]
        [TestCase("2025-12-20", "2025-12-26", "2025-12-26", DayOfWeek.Saturday)]
        public void Test_GetStartOfCurrentWeek_GetEndOfCurrentWeek(String expectedStartOfWeekString, String expectedEndOfWeekString, String workingDateString, DayOfWeek newStartOfWeek)
        {
            DateTime expectedStartOfWeek = DateTime.ParseExact(expectedStartOfWeekString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime expectedEndOfWeek = DateTime.ParseExact(expectedEndOfWeekString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime workingDate = DateTime.ParseExact(workingDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            IDateTimeService dateTimeService = new DateTimeService(newStartOfWeek, workingDate, workingDate);

            DateTime actualStartOfWeek1 = dateTimeService.GetStartOfCurrentWeek();
            Assert.That(actualStartOfWeek1, Is.EqualTo(expectedStartOfWeek));

            DateTime actualEndOfWeek1 = dateTimeService.GetEndOfCurrentWeek();
            Assert.That(actualEndOfWeek1, Is.EqualTo(expectedEndOfWeek));
        }

        [TestCase("2025-12-21", "2025-12-27", "2025-12-26", DayOfWeek.Sunday)]
        [TestCase("2025-12-22", "2025-12-28", "2025-12-26", DayOfWeek.Monday)]
        [TestCase("2025-12-23", "2025-12-29", "2025-12-26", DayOfWeek.Tuesday)]
        [TestCase("2025-12-24", "2025-12-30", "2025-12-26", DayOfWeek.Wednesday)]
        [TestCase("2025-12-25", "2025-12-31", "2025-12-26", DayOfWeek.Thursday)]
        [TestCase("2025-12-26", "2026-01-01", "2025-12-26", DayOfWeek.Friday)]
        [TestCase("2025-12-20", "2025-12-26", "2025-12-26", DayOfWeek.Saturday)]
        public void Test_GetStartOfWeek_GetEndOfWeek(String expectedStartOfWeekString, String expectedEndOfWeekString, String workingDateString, DayOfWeek newStartOfWeek)
        {
            DateTime expectedStartOfWeek = DateTime.ParseExact(expectedStartOfWeekString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime expectedEndOfWeek = DateTime.ParseExact(expectedEndOfWeekString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime workingDate = DateTime.ParseExact(workingDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            IDateTimeService dateTimeService = new DateTimeService(newStartOfWeek, workingDate, workingDate);

            DateTime actualStartOfWeek1 = dateTimeService.GetStartOfWeek(workingDate);
            Assert.That(actualStartOfWeek1, Is.EqualTo(expectedStartOfWeek));

            DateTime actualValue2 = dateTimeService.GetStartOfWeek(workingDate.Year, workingDate.Month, workingDate.Day);
            Assert.That(actualValue2, Is.EqualTo(expectedStartOfWeek));

            DateTime actualEndOfWeek1 = dateTimeService.GetEndOfWeek(workingDate);
            Assert.That(actualEndOfWeek1, Is.EqualTo(expectedEndOfWeek));

            DateTime actualEndOfWeek2 = dateTimeService.GetEndOfWeek(workingDate.Year, workingDate.Month, workingDate.Day);
            Assert.That(actualEndOfWeek2, Is.EqualTo(expectedEndOfWeek));
        }

        [TestCase("2025-12-28", "2026-01-03", "2025-12-26", DayOfWeek.Sunday)]
        [TestCase("2025-12-29", "2026-01-04", "2025-12-26", DayOfWeek.Monday)]
        [TestCase("2025-12-30", "2026-01-05", "2025-12-26", DayOfWeek.Tuesday)]
        [TestCase("2025-12-31", "2026-01-06", "2025-12-26", DayOfWeek.Wednesday)]
        [TestCase("2026-01-01", "2026-01-07", "2025-12-26", DayOfWeek.Thursday)]
        [TestCase("2026-01-02", "2026-01-08", "2025-12-26", DayOfWeek.Friday)]
        [TestCase("2025-12-27", "2026-01-02", "2025-12-26", DayOfWeek.Saturday)]
        public void Test_GetStartONextWeek_GetEndOfNextWeek(String expectedStartOfWeekString, String expectedEndOfWeekString, String workingDateString, DayOfWeek newStartOfWeek)
        {
            DateTime expectedStartOfWeek = DateTime.ParseExact(expectedStartOfWeekString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime expectedEndOfWeek = DateTime.ParseExact(expectedEndOfWeekString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime workingDate = DateTime.ParseExact(workingDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            IDateTimeService dateTimeService = new DateTimeService(newStartOfWeek, workingDate, workingDate);

            DateTime actualStartOfNextWeek1 = dateTimeService.GetStartOfNextWeek();
            Assert.That(actualStartOfNextWeek1, Is.EqualTo(expectedStartOfWeek));

            DateTime actualEndOfNextWeek1 = dateTimeService.GetEndOfNextWeek();
            Assert.That(actualEndOfNextWeek1, Is.EqualTo(expectedEndOfWeek));
        }

        [TestCase]
        public void Test_GetStartOfLastMonth_GetEndOfLastMonth()
        {
            for (DateTime dateLoop = StartDate; dateLoop <= EndDate; dateLoop = dateLoop.AddDays(1))
            {
                DateTime workingDate = new DateTime(dateLoop.Year, dateLoop.Month, dateLoop.Day);
                IDateTimeService dateTimeService = new DateTimeService(DayOfWeek.Monday, workingDate, workingDate);

                Int32 year = workingDate.AddMonths(-1).Year;
                Int32 month = workingDate.AddMonths(-1).Month;
                DateTime expectedStartOfMonth1 = new DateTime(year, month, 1);
                DateTime expectedEndOfMonth1 = new DateTime(year, month, DateTime.DaysInMonth(year, month));

                DateTime actualStartOfMonth1 = dateTimeService.GetStartOfLastMonth();
                Assert.That(actualStartOfMonth1, Is.EqualTo(expectedStartOfMonth1));

                DateTime actualEndOfMonth1 = dateTimeService.GetEndOfLastMonth();
                Assert.That(actualEndOfMonth1, Is.EqualTo(expectedEndOfMonth1));
            }
        }

        [TestCase]
        public void Test_GetStartOfCurrentMonth_GetEndOfCurrentMonth()
        {
            for (DateTime dateLoop = StartDate; dateLoop <= EndDate; dateLoop = dateLoop.AddDays(1))
            {
                DateTime workingDate = new DateTime(dateLoop.Year, dateLoop.Month, dateLoop.Day);
                IDateTimeService dateTimeService = new DateTimeService(DayOfWeek.Monday, workingDate, workingDate);

                Int32 year = workingDate.AddMonths(0).Year;
                Int32 month = workingDate.AddMonths(0).Month;
                DateTime expectedStartOfMonth1 = new DateTime(year, month, 1);
                DateTime expectedEndOfMonth1 = new DateTime(year, month, DateTime.DaysInMonth(year, month));

                DateTime actualStartOfMonth1 = dateTimeService.GetStartOfCurrentMonth();
                Assert.That(actualStartOfMonth1, Is.EqualTo(expectedStartOfMonth1));

                DateTime actualEndOfMonth1 = dateTimeService.GetEndOfCurrentMonth();
                Assert.That(actualEndOfMonth1, Is.EqualTo(expectedEndOfMonth1));
            }
        }

        [TestCase]
        public void Test_GetStartOfNextMonth_GetEndOfNextMonth()
        {
            for (DateTime dateLoop = StartDate; dateLoop <= EndDate; dateLoop = dateLoop.AddDays(1))
            {
                DateTime workingDate = new DateTime(dateLoop.Year, dateLoop.Month, dateLoop.Day);
                IDateTimeService dateTimeService = new DateTimeService(DayOfWeek.Monday, workingDate, workingDate);

                Int32 year = workingDate.AddMonths(1).Year;
                Int32 month = workingDate.AddMonths(1).Month;
                DateTime expectedStartOfMonth1 = new DateTime(year, month, 1);
                DateTime expectedEndOfMonth1 = new DateTime(year, month, DateTime.DaysInMonth(year, month));

                DateTime actualStartOfMonth1 = dateTimeService.GetStartOfNextMonth();
                Assert.That(actualStartOfMonth1, Is.EqualTo(expectedStartOfMonth1));

                DateTime actualEndOfMonth1 = dateTimeService.GetEndOfNextMonth();
                Assert.That(actualEndOfMonth1, Is.EqualTo(expectedEndOfMonth1));
            }
        }

        [TestCase]
        public void Test_GetStartOfMonth_GetEndOfMonth()
        {
            for (DateTime dateLoop = StartDate; dateLoop <= EndDate; dateLoop = dateLoop.AddDays(1))
            {
                DateTime workingDate = new DateTime(dateLoop.Year, dateLoop.Month, dateLoop.Day);
                IDateTimeService dateTimeService = new DateTimeService(DayOfWeek.Monday, workingDate, workingDate);

                Int32 year = workingDate.AddMonths(0).Year;
                Int32 month = workingDate.AddMonths(0).Month;
                DateTime expectedStartOfMonth = new DateTime(year, month, 1);
                DateTime expectedEndOfMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month));

                DateTime actualStartOfMonth1 = dateTimeService.GetStartOfMonth(workingDate);
                DateTime actualStartOfMonth2 = dateTimeService.GetStartOfMonth(workingDate.Year, workingDate.Month);
                Assert.That(actualStartOfMonth1, Is.EqualTo(expectedStartOfMonth));
                Assert.That(actualStartOfMonth2, Is.EqualTo(expectedStartOfMonth));

                DateTime actualEndOfMonth1 = dateTimeService.GetEndOfMonth(workingDate);
                DateTime actualEndOfMonth2 = dateTimeService.GetEndOfMonth(workingDate.Year, workingDate.Month);
                Assert.That(actualEndOfMonth1, Is.EqualTo(expectedEndOfMonth));
                Assert.That(actualEndOfMonth2, Is.EqualTo(expectedEndOfMonth));
            }
        }

        [TestCase("2022-11-22", "2022-11-27", "2022-11-28", DatePeriod.Days, 5)]
        [TestCase("2022-11-17", "2022-11-27", "2022-11-28", DatePeriod.Days, 10)]
        [TestCase("2022-11-12", "2022-11-27", "2022-11-28", DatePeriod.Days, 15)]
        [TestCase("2022-11-07", "2022-11-27", "2022-11-28", DatePeriod.Days, 20)]
        [TestCase("2022-10-19", "2022-11-23", "2022-11-30", DatePeriod.Weeks, 5)]
        [TestCase("2022-09-14", "2022-11-23", "2022-11-30", DatePeriod.Weeks, 10)]
        [TestCase("2022-08-10", "2022-11-23", "2022-11-30", DatePeriod.Weeks, 15)]
        [TestCase("2022-07-06", "2022-11-23", "2022-11-30", DatePeriod.Weeks, 20)]
        [TestCase("2022-05-01", "2022-10-31", "2022-11-28", DatePeriod.Months, 5)]
        [TestCase("2021-12-01", "2022-10-31", "2022-11-28", DatePeriod.Months, 10)]
        [TestCase("2021-07-01", "2022-10-31", "2022-11-28", DatePeriod.Months, 15)]
        [TestCase("2021-02-01", "2022-10-31", "2022-11-28", DatePeriod.Months, 20)]
        [TestCase("2016-11-01", "2021-11-30", "2022-11-28", DatePeriod.Years, 5)]
        [TestCase("2011-11-01", "2021-11-30", "2022-11-28", DatePeriod.Years, 10)]
        [TestCase("2006-11-01", "2021-11-30", "2022-11-28", DatePeriod.Years, 15)]
        [TestCase("2001-11-01", "2021-11-30", "2022-11-28", DatePeriod.Years, 20)]
        public void Test_GetRollingPeriod(String expectedStartDateString, String expectedEndDateString, String workingDateString, DatePeriod datePeriod, Int32 interval)
        {
            DateTime expectedStartDate = DateTime.ParseExact(expectedStartDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime expectedEndDate = DateTime.ParseExact(expectedEndDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime workingDate = DateTime.ParseExact(workingDateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            IDateTimeService dateTimeService = new DateTimeService(DayOfWeek.Monday, workingDate, workingDate);

            DateTime actualStartOfPeriod = dateTimeService.GetStartOfRollingPeriod(datePeriod, interval);
            DateTime actualEndOfPeriod = dateTimeService.GetEndOfRollingPeriod(datePeriod, interval);

            Assert.That(actualStartOfPeriod, Is.EqualTo(expectedStartDate));
            Assert.That(actualEndOfPeriod, Is.EqualTo(expectedEndDate));
        }

        [TestCase]
        public void Test_GetStartOfPreviousQuarter_GetEndOfPreviousQuarter()
        {
            for (DateTime dateLoop = StartDate; dateLoop <= EndDate; dateLoop = dateLoop.AddDays(1))
            {
                DateTime workingDate = new DateTime(dateLoop.Year, dateLoop.Month, dateLoop.Day);
                IDateTimeService dateTimeService = new DateTimeService(DayOfWeek.Monday, workingDate, workingDate);

                DateTime startOfQuarter = DateTime.MinValue;
                DateTime endOfQuarter = DateTime.MaxValue;

                if (dateLoop.Month.IsBetween(1, 3))
                {
                    startOfQuarter = new DateTime(dateLoop.Year - 1, 10, 01);
                    endOfQuarter = new DateTime(dateLoop.Year - 1, 12, 31);
                }
                if (dateLoop.Month.IsBetween(4, 6))
                {
                    startOfQuarter = new DateTime(dateLoop.Year, 01, 01);
                    endOfQuarter = new DateTime(dateLoop.Year, 03, 31);
                }
                if (dateLoop.Month.IsBetween(7, 9))
                {
                    startOfQuarter = new DateTime(dateLoop.Year, 04, 01);
                    endOfQuarter = new DateTime(dateLoop.Year, 06, 30);
                }
                if (dateLoop.Month.IsBetween(10, 12))
                {
                    startOfQuarter = new DateTime(dateLoop.Year, 07, 01);
                    endOfQuarter = new DateTime(dateLoop.Year, 09, 30);
                }

                DateTime actualStartOfQuarter = dateTimeService.GetStartOfPreviousQuarter();
                DateTime actualEndOfQuarter = dateTimeService.GetEndOfPreviousQuarter();

                Assert.That(actualStartOfQuarter, Is.EqualTo(startOfQuarter), dateLoop.ToString("yyyy-MMM-dd"));
                Assert.That(actualEndOfQuarter, Is.EqualTo(endOfQuarter), dateLoop.ToString("yyyy-MMM-dd"));
            }
        }

        [TestCase]
        public void Test_GetStartOfCurrentQuarter_GetEndOfCurrentQuarter()
        {
            for (DateTime dateLoop = StartDate; dateLoop <= EndDate; dateLoop = dateLoop.AddDays(1))
            {
                DateTime workingDate = new DateTime(dateLoop.Year, dateLoop.Month, dateLoop.Day);
                IDateTimeService dateTimeService = new DateTimeService(DayOfWeek.Monday, workingDate, workingDate);

                DateTime startOfQuarter = DateTime.MinValue;
                DateTime endOfQuarter = DateTime.MaxValue;

                if (dateLoop.Month.IsBetween(1, 3))
                {
                    startOfQuarter = new DateTime(dateLoop.Year, 01, 01);
                    endOfQuarter = new DateTime(dateLoop.Year, 03, 31);
                }
                if (dateLoop.Month.IsBetween(4, 6))
                {
                    startOfQuarter = new DateTime(dateLoop.Year, 04, 01);
                    endOfQuarter = new DateTime(dateLoop.Year, 06, 30);
                }
                if (dateLoop.Month.IsBetween(7, 9))
                {
                    startOfQuarter = new DateTime(dateLoop.Year, 07, 01);
                    endOfQuarter = new DateTime(dateLoop.Year, 09, 30);
                }
                if (dateLoop.Month.IsBetween(10, 12))
                {
                    startOfQuarter = new DateTime(dateLoop.Year, 10, 01);
                    endOfQuarter = new DateTime(dateLoop.Year, 12, 31);
                }

                DateTime actualStartOfQuarter = dateTimeService.GetStartOfCurrentQuarter();
                DateTime actualEndOfQuarter = dateTimeService.GetEndOfCurrentQuarter();

                Assert.That(actualStartOfQuarter, Is.EqualTo(startOfQuarter), dateLoop.ToString("yyyy-MMM-dd"));
                Assert.That(actualEndOfQuarter, Is.EqualTo(endOfQuarter), dateLoop.ToString("yyyy-MMM-dd"));
            }
        }

        [TestCase]
        public void Test_GetStartOfNextQuarter_GetEndOfNextQuarter()
        {
            for (DateTime dateLoop = StartDate; dateLoop <= EndDate; dateLoop = dateLoop.AddDays(1))
            {
                DateTime workingDate = new DateTime(dateLoop.Year, dateLoop.Month, dateLoop.Day);
                IDateTimeService dateTimeService = new DateTimeService(DayOfWeek.Monday, workingDate, workingDate);

                DateTime startOfQuarter = DateTime.MinValue;
                DateTime endOfQuarter = DateTime.MaxValue;

                if (dateLoop.Month.IsBetween(1, 3))
                {
                    startOfQuarter = new DateTime(dateLoop.Year, 04, 01);
                    endOfQuarter = new DateTime(dateLoop.Year, 06, 30);
                }
                if (dateLoop.Month.IsBetween(4, 6))
                {
                    startOfQuarter = new DateTime(dateLoop.Year, 07, 01);
                    endOfQuarter = new DateTime(dateLoop.Year, 09, 30);
                }
                if (dateLoop.Month.IsBetween(7, 9))
                {
                    startOfQuarter = new DateTime(dateLoop.Year, 10, 01);
                    endOfQuarter = new DateTime(dateLoop.Year, 12, 31);
                }
                if (dateLoop.Month.IsBetween(10, 12))
                {
                    startOfQuarter = new DateTime(dateLoop.Year + 1, 01, 01);
                    endOfQuarter = new DateTime(dateLoop.Year + 1, 03, 31);
                }

                DateTime actualStartOfQuarter = dateTimeService.GetStartOfNextQuarter();
                DateTime actualEndOfQuarter = dateTimeService.GetEndOfNextQuarter();

                Assert.That(actualStartOfQuarter, Is.EqualTo(startOfQuarter), dateLoop.ToString("yyyy-MMM-dd"));
                Assert.That(actualEndOfQuarter, Is.EqualTo(endOfQuarter), dateLoop.ToString("yyyy-MMM-dd"));
            }
        }
    }
}
