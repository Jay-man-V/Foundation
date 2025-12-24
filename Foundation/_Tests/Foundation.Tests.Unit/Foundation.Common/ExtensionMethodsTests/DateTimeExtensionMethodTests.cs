//-----------------------------------------------------------------------
// <copyright file="DateTimeExtensionMethodTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests
{
    /// <summary>
    /// Summary description for DateTimeExtensionMethodTests
    /// </summary>
    [TestFixture]
    public class DateTimeExtensionMethodTests : UnitTestBase
    {
        private static DateTime WorkingDate => new DateTime(2018, 10, 1, 20, 10, 0);
        private static DateTime StartDate => new DateTime(2018, 9, 1, 20, 10, 0);
        private static TimeSpan StartTime => new TimeSpan(9, 0, 0);
        private static TimeSpan EndTime => new TimeSpan(17, 0, 0);
        private static TimeWindow StandardHoursDateTimeWindow => new TimeWindow(StartTime, EndTime);

        [TestCase(3, DatePeriod.Days, "2020-12-27 00:00:00")]
        [TestCase(3, DatePeriod.Weeks, "2021-01-14 00:00:00")]
        [TestCase(3, DatePeriod.Months, "2021-03-24 00:00:00")]
        [TestCase(3, DatePeriod.Years, "2023-12-24 00:00:00")]
        public void Test_DatePeriod_Add(Int32 interval, DatePeriod datePeriod, String expectedDateTimeString)
        {
            DateTime startDateTime = new DateTime(2020, 12, 24, 15, 48, 55);
            DateTime expectedDateTime = DateTime.ParseExact(expectedDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime actualRunDateTime = startDateTime.Add(datePeriod, interval);

            Assert.That(actualRunDateTime, Is.EqualTo(expectedDateTime));
        }

        [TestCase]
        public void Test_DatePeriod_Add_Exception()
        {
            DatePeriod datePeriod = DatePeriod.NotSet;
            String parameterName = nameof(datePeriod);
            String errorMessage = $"The Date Period of '{datePeriod}' is unknown or invalid for the chosen Add method (Parameter '{parameterName}')";

            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                DateTime startDateTime = new DateTime(2020, 12, 24, 15, 48, 55);
                startDateTime.Add(datePeriod, 100);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
        }

        [TestCase(0, ScheduleInterval.Other, "2020-12-24 15:48:55")]
        [TestCase(10 * 1000, ScheduleInterval.Milliseconds, "2020-12-24 15:49:05")]
        [TestCase(30, ScheduleInterval.Seconds, "2020-12-24 15:49:25")]
        [TestCase(3, ScheduleInterval.Minutes, "2020-12-24 15:51:55")]
        [TestCase(3, ScheduleInterval.Hours, "2020-12-24 18:48:55")]
        [TestCase(3, ScheduleInterval.Days, "2020-12-27 01:02:03")]
        [TestCase(3, ScheduleInterval.Weeks, "2021-01-14 01:02:03")]
        [TestCase(3, ScheduleInterval.Months, "2021-03-24 01:02:03")]
        [TestCase(3, ScheduleInterval.Years, "2023-12-24 01:02:03")]
        public void Test_ScheduleInterval_Add(Int32 interval, ScheduleInterval scheduleInterval, String expectedDateTimeString)
        {
            TimeSpan timeSpan = new TimeSpan(01, 02, 03);
            DateTime startDateTime = new DateTime(2020, 12, 24, 15, 48, 55);
            DateTime expectedDateTime = DateTime.ParseExact(expectedDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime actualRunDateTime = startDateTime.Add(scheduleInterval, interval, timeSpan);

            Assert.That(actualRunDateTime, Is.EqualTo(expectedDateTime));
        }

        [TestCase]
        public void Test_ScheduleInterval_Add_Exception()
        {
            const ScheduleInterval scheduleInterval = ScheduleInterval.NotSet;
            String parameterName = nameof(scheduleInterval);

            String errorMessage = $"The Schedule Interval of '{scheduleInterval}' is unknown or invalid for the chosen Add method (Parameter '{parameterName}')";

            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                DateTime startDateTime = new DateTime(2020, 12, 24, 15, 48, 55);
                _ = startDateTime.Add(scheduleInterval, 100, startDateTime.TimeOfDay);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
        }

        [TestCase("05:13:25", "2021-08-13 10:00:00", "2021-08-13 15:13:25", "Within window")]
        [TestCase("05:13:25", "2021-08-13 06:00:00", "2021-08-13 14:13:25", "Before start time")]
        [TestCase("05:13:25", "2021-08-13 10:00:00", "2021-08-13 15:13:25", "After end time")]
        [TestCase("10:13:25", "2021-08-13 08:00:00", "2021-08-14 11:13:25", "Duration Greater Than One Day 1")]
        [TestCase("08:13:25", "2021-08-13 09:00:00", "2021-08-14 09:13:25", "Duration Greater Than One Day 2")]
        [TestCase("16:13:25", "2021-08-13 09:00:00", "2021-08-15 09:13:25", "Duration Greater Than Two Days 1")]
        public void Test_TimeWindow_Add(String timeSpanString, String operationDateTimeString, String expectedDateTimeString, String comment)
        {
            TimeSpan durationTimeSpan = TimeSpan.ParseExact(timeSpanString, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            DateTime aDateTime = DateTime.ParseExact(operationDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            DateTime expectedResult = DateTime.ParseExact(expectedDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            DateTime result = aDateTime.Add(StandardHoursDateTimeWindow, durationTimeSpan);

            Assert.That(result, Is.EqualTo(expectedResult), comment);
        }

        [TestCase(1, "2018-09-08 20:10:00")]
        [TestCase(2, "2018-09-15 20:10:00")]
        [TestCase(4, "2018-09-29 20:10:00")]
        [TestCase(6, "2018-10-13 20:10:00")]
        public void Test_Weeks_Add(Int32 interval, String expectedDateTimeString)
        {
            DateTime expectedValue = DateTime.ParseExact(expectedDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            DateTime actualValue = StartDate.AddWeeks(interval);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true, "2018-09-01 20:10:00", "2018-11-01 20:10:00")]
        [TestCase(false, "2019-09-01 20:10:00", "2019-11-01 20:10:00")]
        [TestCase(true, "2018-10-01 20:10:00", "2018-10-01 20:10:00")]
        [TestCase(true, "2018-10-01 20:10:00", "2018-11-01 20:10:00")]
        [TestCase(true, "2018-09-01 20:10:00", "2018-10-01 20:10:00")]
        public void Test_IsBetween_True(Boolean expected, String startDateTimeString, String endDateTimeString)
        {
            DateTime startDateTime = DateTime.ParseExact(startDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime endDateTime = DateTime.ParseExact(endDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            Boolean actualResult = WorkingDate.IsBetween(startDateTime, endDateTime);

            Assert.That(actualResult, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_IsBetween_NullTarget()
        {
            DateTime? targetValue = null;
            DateTime startValue = new DateTime(2018, 9, 1, 20, 10, 0);
            DateTime endValue = new DateTime(2018, 11, 1, 20, 10, 0);

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(false));
        }

        [TestCase(true, "2018-09-01 20:10:00", "2018-11-01 20:10:00")]
        [TestCase(false, "2019-09-01 20:10:00", "2019-11-01 20:10:00")]
        [TestCase(true, "2018-10-01 20:10:00", "2018-10-01 20:10:00")]
        [TestCase(true, "2018-10-01 20:10:00", "2018-11-01 20:10:00")]
        [TestCase(true, "2018-09-01 20:10:00", "2018-10-01 20:10:00")]
        public void TestIsBetween(Boolean expected, String startValueString, String endValueString)
        {
            DateTime startDateTime = DateTime.ParseExact(startValueString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime endDateTime = DateTime.ParseExact(endValueString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            Boolean actualResult = WorkingDate.IsBetween(startDateTime, endDateTime);

            Assert.That(actualResult, Is.EqualTo(expected));
        }

        [TestCase(false, "2019-12-27 00:00:00")]
        [TestCase(true, "2019-12-28 00:00:00")]
        public void Test_IsWeekend(Boolean expected, String startDateString)
        {
            DateTime startValue = DateTime.ParseExact(startDateString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            Boolean actualResult = startValue.IsWeekend();

            Assert.That(actualResult, Is.EqualTo(expected));
        }

        [TestCase(DayOfWeek.Sunday, "2020-12-20", 20)]
        [TestCase(DayOfWeek.Monday, "2020-12-21", 21)]
        [TestCase(DayOfWeek.Tuesday, "2020-12-22", 22)]
        [TestCase(DayOfWeek.Wednesday, "2020-12-23", 23)]
        [TestCase(DayOfWeek.Thursday, "2020-12-24", 24)]
        [TestCase(DayOfWeek.Friday, "2020-12-25", 25)]
        [TestCase(DayOfWeek.Saturday, "2020-12-26", 26)]
        public void Test_StartOfWeek(DayOfWeek startOfWeek, String expectedDateTimeString, Int32 startDate)
        {
            DateTime expectedDateTime = DateTime.ParseExact(expectedDateTimeString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            for (Int32 counter = 0; counter < 7; counter++)
            {
                DateTime startDateTime = new DateTime(2020, 12, startDate).AddDays(counter);

                DateTime actualDateTime = startDateTime.StartOfWeek(startOfWeek);

                Assert.That(actualDateTime, Is.EqualTo(expectedDateTime));
            }
        }

        /// <summary>
        /// The DateTime Extension tests
        ///
        /// Primary reasons for these tests is to determine when it is Midnight in Eastern Standard Time (New York)
        /// Time changes for 2023 are:
        /// US: Sun, Mar 12, 2023 2:00 AM - Sun, Nov 5, 2023 2:00 AM
        /// UK: Sun, Mar 26, 2023 1:00 AM - Sun, Oct 29, 2023 2:00 AM
        /// </summary>
        [TestCase("Eastern Standard Time", "2023-03-01 00:00:00", "2023-02-28 19:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 01:00:00", "2023-02-28 20:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 02:00:00", "2023-02-28 21:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 03:00:00", "2023-02-28 22:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 04:00:00", "2023-02-28 23:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 05:00:00", "2023-03-01 00:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 06:00:00", "2023-03-01 01:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 07:00:00", "2023-03-01 02:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 08:00:00", "2023-03-01 03:00:00")] // Input - US is in EST // Output UK is in GMT

        [TestCase("Eastern Standard Time", "2023-03-22 00:00:00", "2023-03-21 20:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 01:00:00", "2023-03-21 21:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 02:00:00", "2023-03-21 22:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 03:00:00", "2023-03-21 23:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 04:00:00", "2023-03-22 00:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 05:00:00", "2023-03-22 01:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 06:00:00", "2023-03-22 02:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 07:00:00", "2023-03-22 03:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 08:00:00", "2023-03-22 04:00:00")] // Input - US is in DST // Output UK is in GMT

        [TestCase("Eastern Standard Time", "2023-03-27 00:00:00", "2023-03-26 19:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 01:00:00", "2023-03-26 20:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 02:00:00", "2023-03-26 21:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 03:00:00", "2023-03-26 22:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 04:00:00", "2023-03-26 23:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 05:00:00", "2023-03-27 00:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 06:00:00", "2023-03-27 01:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 07:00:00", "2023-03-27 02:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 08:00:00", "2023-03-27 03:00:00")] // Input - US is in DST // Output UK is in BST

        [TestCase("Eastern Standard Time", "2023-10-30 00:00:00", "2023-10-29 20:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 01:00:00", "2023-10-29 21:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 02:00:00", "2023-10-29 22:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 03:00:00", "2023-10-29 23:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 04:00:00", "2023-10-30 00:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 05:00:00", "2023-10-30 01:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 06:00:00", "2023-10-30 02:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 07:00:00", "2023-10-30 03:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 08:00:00", "2023-10-30 04:00:00")] // Input - US is in EST // Output UK is in BST

        [TestCase("Central Europe Standard Time", "2023-10-30 04:00:00", "2023-10-30 05:00:00")] // Input - EU is in CET // Output UK is in BST
        public void Test_FromUkTime(String targetTimeZone, String inputDateTime, String outputDateTime)
        {
            DateTime localTime = DateTime.ParseExact(inputDateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime expected = DateTime.ParseExact(outputDateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            DateTime actualResult = localTime.ToTimeZone(targetTimeZone);

            Assert.That(actualResult, Is.EqualTo(expected));
        }

        /// <summary>
        /// The DateTime Extension tests
        ///
        /// Primary reasons for these tests is to determine when it is Midnight in Eastern Standard Time (New York)
        /// Time changes for 2023 are:
        /// US: Sun, Mar 12, 2023 2:00 AM - Sun, Nov 5, 2023 2:00 AM
        /// UK: Sun, Mar 26, 2023 1:00 AM - Sun, Oct 29, 2023 2:00 AM
        /// </summary>
        [TestCase("Eastern Standard Time", "2023-03-01 00:00:00", "2023-02-28 19:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 01:00:00", "2023-02-28 20:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 02:00:00", "2023-02-28 21:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 03:00:00", "2023-02-28 22:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 04:00:00", "2023-02-28 23:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 05:00:00", "2023-03-01 00:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 06:00:00", "2023-03-01 01:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 07:00:00", "2023-03-01 02:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 08:00:00", "2023-03-01 03:00:00")] // Input - US is in EST // Output UK is in GMT

        [TestCase("Eastern Standard Time", "2023-03-22 00:00:00", "2023-03-21 20:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 01:00:00", "2023-03-21 21:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 02:00:00", "2023-03-21 22:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 03:00:00", "2023-03-21 23:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 04:00:00", "2023-03-22 00:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 05:00:00", "2023-03-22 01:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 06:00:00", "2023-03-22 02:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 07:00:00", "2023-03-22 03:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 08:00:00", "2023-03-22 04:00:00")] // Input - US is in DST // Output UK is in GMT

        [TestCase("Eastern Standard Time", "2023-03-27 00:00:00", "2023-03-26 20:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 01:00:00", "2023-03-26 21:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 02:00:00", "2023-03-26 22:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 03:00:00", "2023-03-26 23:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 04:00:00", "2023-03-27 00:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 05:00:00", "2023-03-27 01:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 06:00:00", "2023-03-27 02:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 07:00:00", "2023-03-27 03:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 08:00:00", "2023-03-27 04:00:00")] // Input - US is in DST // Output UK is in BST

        [TestCase("Eastern Standard Time", "2023-10-30 00:00:00", "2023-10-29 20:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 01:00:00", "2023-10-29 21:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 02:00:00", "2023-10-29 22:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 03:00:00", "2023-10-29 23:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 04:00:00", "2023-10-30 00:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 05:00:00", "2023-10-30 01:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 06:00:00", "2023-10-30 02:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 07:00:00", "2023-10-30 03:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 08:00:00", "2023-10-30 04:00:00")] // Input - US is in EST // Output UK is in BST

        [TestCase("Central Europe Standard Time", "2023-10-30 04:00:00", "2023-10-30 05:00:00")] // Input - EU is in CET // Output UK is in BST
        public void Test_FromUkTime_Utc(String targetTimeZone, String inputDateTime, String outputDateTime)
        {
            DateTime localTime = DateTime.ParseExact(inputDateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            localTime = DateTime.SpecifyKind(localTime, DateTimeKind.Utc);
            DateTime expected = DateTime.ParseExact(outputDateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            DateTime actualResult = localTime.ToTimeZone(targetTimeZone);

            Assert.That(actualResult, Is.EqualTo(expected));
        }
    }
}
