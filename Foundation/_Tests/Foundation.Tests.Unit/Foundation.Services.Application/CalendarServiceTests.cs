//-----------------------------------------------------------------------
// <copyright file="CalendarServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Common;
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

            ICore core = Substitute.For<ICore>();

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

            CalendarRepository!.CheckIsWorkingDayOrGetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, Arg.Any<DateTime>()).Returns(expected);

            DateTime actual = TheService!.CheckIsWorkingDayOrGetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, startDate);

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

            CalendarRepository!.GetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, Arg.Any<DateTime>(), Arg.Any<ScheduleInterval>(), Arg.Any<Int32>()).Returns(expected);

            DateTime actual = TheService!.GetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, startDate);

            Assert.That(actual, Is.EqualTo(expected));
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

        [TestCase]
        public void Test_StartOfMonth()
        {
            Int32 year = DateTimeService.SystemUtcDateTimeNow.Year;
            Int32 month = DateTimeService.SystemUtcDateTimeNow.Month;

            DateTime value = new DateTime(year, month, 1);
            DateTime actualValue = TheService!.StartOfMonth();

            Assert.That(actualValue, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_EndOfMonth()
        {
            Int32 year = DateTimeService.SystemUtcDateTimeNow.Year;
            Int32 month = DateTimeService.SystemUtcDateTimeNow.Month;

            DateTime value = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            DateTime actualValue = TheService!.EndOfMonth();

            Assert.That(actualValue, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_StartOfLastMonth()
        {
            Int32 year = DateTimeService.SystemUtcDateTimeNow.Year;
            Int32 month = DateTimeService.SystemUtcDateTimeNow.Month;

            DateTime value = new DateTime(year, month, 1).AddMonths(-1);
            DateTime actualValue = TheService!.StartOfLastMonth();

            Assert.That(actualValue, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_EndOfLastMonth()
        {
            Int32 year = DateTimeService.SystemUtcDateTimeNow.Year;
            Int32 month = DateTimeService.SystemUtcDateTimeNow.Month - 1;

            if (month == 0)
            {
                year--;
                month = 12;
            }

            DateTime value = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            DateTime actualValue = TheService!.EndOfLastMonth();

            Assert.That(actualValue, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_GetStartOfMonth_DateTime()
        {
            DateTime targetDate = new DateTime(2020, 6, 27);
            DateTime actualValue = TheService!.GetStartOfMonth(targetDate);

            DateTime value = new DateTime(2020, 6, 1);
            Assert.That(actualValue, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_GetStartOfMonth_YearMonth()
        {
            DateTime actualValue = TheService!.GetStartOfMonth(2020, 6);

            DateTime value = new DateTime(2020, 6, 1);
            Assert.That(actualValue, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_GetEndOfMonth_DateTime()
        {
            DateTime targetDate = new DateTime(2020, 6, 27);
            DateTime actualValue = TheService!.GetEndOfMonth(targetDate);

            DateTime value = new DateTime(2020, 6, 30);
            Assert.That(actualValue, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_GetEndOfMonth_YearMonth()
        {
            DateTime actualValue = TheService!.GetEndOfMonth(2020, 6);

            DateTime value = new DateTime(2020, 6, 30);
            Assert.That(actualValue, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_GetPreviousPeriod()
        {
            DateTime startDate = new DateTime(2023, 01, 01);
            DateTime endDate = new DateTime(2025, 12, 31);

            for (DateTime dateLoop = startDate; dateLoop <= endDate; dateLoop = dateLoop.AddDays(1))
            {
                DateTime workingDateTime = new DateTime(dateLoop.Year, dateLoop.Month, dateLoop.Day);
                IDateTimeService dateTimeService = new DateTimeService(workingDateTime, workingDateTime);
                ICalendarService calendarService = new CalendarService(dateTimeService, CalendarRepository!);

                DateTime actualStartOfPeriod = calendarService.GetStartOfPreviousPeriod();
                DateTime actualEndOfPeriod = calendarService.GetEndOfPreviousPeriod();
            }
        }

        [TestCase]
        public void Test_GetPreviousQuarter()
        {
            DateTime workingDateTime = new DateTime(2024, 05, 10);
            IDateTimeService dateTimeService = new DateTimeService(workingDateTime, workingDateTime);
            ICalendarService calendarService = new CalendarService(dateTimeService, CalendarRepository!);

            DateTime startOfQuarter = new DateTime(2024, 01, 01);
            DateTime endOfQuarter = new DateTime(2024, 03, 31);

            DateTime actualStartOfQuarter = calendarService.GetStartOfPreviousQuarter();
            DateTime actualEndOfQuarter = calendarService.GetEndOfPreviousQuarter();

            Assert.That(actualStartOfQuarter, Is.EqualTo(startOfQuarter));
            Assert.That(actualEndOfQuarter, Is.EqualTo(endOfQuarter));
        }

        [TestCase]
        public void Test_GetPreviousQuarter_Loop()
        {
            DateTime startDate = new DateTime(2023, 01, 01);
            DateTime endDate = new DateTime(2025, 12, 31);

            for (DateTime dateLoop = startDate; dateLoop <= endDate; dateLoop = dateLoop.AddDays(1))
            {
                DateTime workingDateTime = new DateTime(dateLoop.Year, dateLoop.Month, dateLoop.Day);
                IDateTimeService dateTimeService = new DateTimeService(workingDateTime, workingDateTime);
                ICalendarService calendarService = new CalendarService(dateTimeService, CalendarRepository!);

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

                DateTime actualStartOfQuarter = calendarService.GetStartOfPreviousQuarter();
                DateTime actualEndOfQuarter = calendarService.GetEndOfPreviousQuarter();

                Assert.That(actualStartOfQuarter, Is.EqualTo(startOfQuarter), dateLoop.ToString("yyyy-MMM-dd"));
                Assert.That(actualEndOfQuarter, Is.EqualTo(endOfQuarter), dateLoop.ToString("yyyy-MMM-dd"));
            }
        }

        [TestCase]
        public void Test_GetCurrentQuarter_SingleValue()
        {
            IDateTimeService dateTimeService = new DateTimeService(new DateTime(2024, 05, 10), new DateTime(2024, 05, 10));
            ICalendarService calendarService = new CalendarService(dateTimeService, CalendarRepository!);

            DateTime startOfQuarter = new DateTime(2024, 04, 01);
            DateTime endOfQuarter = new DateTime(2024, 06, 30);

            DateTime actualStartOfQuarter = calendarService.GetStartOfCurrentQuarter();
            DateTime actualEndOfQuarter = calendarService.GetEndOfCurrentQuarter();

            Assert.That(actualStartOfQuarter, Is.EqualTo(startOfQuarter));
            Assert.That(actualEndOfQuarter, Is.EqualTo(endOfQuarter));
        }

        [TestCase]
        public void Test_GetCurrentQuarter_Loop()
        {
            DateTime startDate = new DateTime(2023, 01, 01);
            DateTime endDate = new DateTime(2025, 12, 31);

            for (DateTime dateLoop = startDate; dateLoop <= endDate; dateLoop = dateLoop.AddDays(1))
            {
                DateTime workingDateTime = new DateTime(dateLoop.Year, dateLoop.Month, dateLoop.Day);
                IDateTimeService dateTimeService = new DateTimeService(workingDateTime, workingDateTime);
                ICalendarService calendarService = new CalendarService(dateTimeService, CalendarRepository!);

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

                DateTime actualStartOfQuarter = calendarService.GetStartOfCurrentQuarter();
                DateTime actualEndOfQuarter = calendarService.GetEndOfCurrentQuarter();

                Assert.That(actualStartOfQuarter, Is.EqualTo(startOfQuarter), dateLoop.ToString("yyyy-MMM-dd"));
                Assert.That(actualEndOfQuarter, Is.EqualTo(endOfQuarter), dateLoop.ToString("yyyy-MMM-dd"));
            }
        }

        [TestCase]
        public void Test_GetNextQuarter()
        {
            DateTime workingDateTime = new DateTime(2024, 05, 10);
            IDateTimeService dateTimeService = new DateTimeService(workingDateTime, workingDateTime);
            ICalendarService calendarService = new CalendarService(dateTimeService, CalendarRepository!);

            DateTime startOfQuarter = new DateTime(2024, 07, 01);
            DateTime endOfQuarter = new DateTime(2024, 09, 30);

            DateTime actualStartOfQuarter = calendarService.GetStartOfNextQuarter();
            DateTime actualEndOfQuarter = calendarService.GetEndOfNextQuarter();

            Assert.That(actualStartOfQuarter, Is.EqualTo(startOfQuarter));
            Assert.That(actualEndOfQuarter, Is.EqualTo(endOfQuarter));
        }

        [TestCase]
        public void Test_GetNextQuarter_Loop()
        {
            DateTime startDate = new DateTime(2023, 01, 01);
            DateTime endDate = new DateTime(2025, 12, 31);

            for (DateTime dateLoop = startDate; dateLoop <= endDate; dateLoop = dateLoop.AddDays(1))
            {
                DateTime workingDateTime = new DateTime(dateLoop.Year, dateLoop.Month, dateLoop.Day);
                IDateTimeService dateTimeService = new DateTimeService(workingDateTime, workingDateTime);
                ICalendarService calendarService = new CalendarService(dateTimeService, CalendarRepository!);

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

                DateTime actualStartOfQuarter = calendarService.GetStartOfNextQuarter();
                DateTime actualEndOfQuarter = calendarService.GetEndOfNextQuarter();

                Assert.That(actualStartOfQuarter, Is.EqualTo(startOfQuarter), dateLoop.ToString("yyyy-MMM-dd"));
                Assert.That(actualEndOfQuarter, Is.EqualTo(endOfQuarter), dateLoop.ToString("yyyy-MMM-dd"));
            }
        }
    }
}
