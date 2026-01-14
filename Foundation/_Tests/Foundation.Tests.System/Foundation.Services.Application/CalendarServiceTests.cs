//-----------------------------------------------------------------------
// <copyright file="CalendarServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.System.BaseClasses;

using NSubstitute;

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

            DateTime actual = TheService!.GetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, startDate);

            Assert.That(actual, Is.EqualTo(expected), comment);
        }

        [TestCase("2020-12-29", "2020-12-20", ScheduleInterval.Days, 5)]
        [TestCase("2020-12-29", "2019-12-25", ScheduleInterval.Years, 1)]
        public void Test_GetNextWorkingDay_LookAhead(String expectedString, String startDateString, ScheduleInterval scheduleInterval, Int32 interval)
        {
            DateTime expected = DateTime.Parse(expectedString);
            DateTime startDate = DateTime.Parse(startDateString);

            DateTime actual = TheService!.GetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, startDate, scheduleInterval, interval);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
