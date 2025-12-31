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
        [TestCase("2020-12-27 00:00:00", 3, DatePeriod.Days)]
        [TestCase("2021-01-14 00:00:00", 3, DatePeriod.Weeks)]
        [TestCase("2021-03-24 00:00:00", 3, DatePeriod.Months)]
        [TestCase("2023-12-24 00:00:00", 3, DatePeriod.Years)]
        public void Test_DatePeriod_Add(String expectedDateTimeString, Int32 interval, DatePeriod datePeriod)
        {
            DateTime earlyDateTime = new DateTime(2020, 12, 24, 15, 48, 55);
            DateTime expectedDateTime = DateTime.ParseExact(expectedDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime actualRunDateTime = earlyDateTime.Add(datePeriod, interval);

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
                DateTime earlyDateTime = new DateTime(2020, 12, 24, 15, 48, 55);
                earlyDateTime.Add(datePeriod, 100);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
        }

        [TestCase("2020-12-24 15:48:55", 0, ScheduleInterval.Other)]
        [TestCase("2020-12-24 15:49:05", 10 * 1000, ScheduleInterval.Milliseconds)]
        [TestCase("2020-12-24 15:49:25", 30, ScheduleInterval.Seconds)]
        [TestCase("2020-12-24 15:51:55", 3, ScheduleInterval.Minutes)]
        [TestCase("2020-12-24 18:48:55", 3, ScheduleInterval.Hours)]
        [TestCase("2020-12-27 01:02:03", 3, ScheduleInterval.Days)]
        [TestCase("2021-01-14 01:02:03", 3, ScheduleInterval.Weeks)]
        [TestCase("2021-03-24 01:02:03", 3, ScheduleInterval.Months)]
        [TestCase("2023-12-24 01:02:03", 3, ScheduleInterval.Years)]
        public void Test_ScheduleInterval_Add(String expectedDateTimeString, Int32 interval, ScheduleInterval scheduleInterval)
        {
            TimeSpan timeSpan = new TimeSpan(01, 02, 03);
            DateTime earlyDateTime = new DateTime(2020, 12, 24, 15, 48, 55);
            DateTime expectedDateTime = DateTime.ParseExact(expectedDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime actualRunDateTime = earlyDateTime.Add(scheduleInterval, interval, timeSpan);

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
                DateTime earlyDateTime = new DateTime(2020, 12, 24, 15, 48, 55);
                _ = earlyDateTime.Add(scheduleInterval, 100, earlyDateTime.TimeOfDay);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
        }

        [TestCase("2021-08-13 15:13:25", "05:13:25", "2021-08-13 10:00:00", "Within window")]
        [TestCase("2021-08-13 14:13:25", "05:13:25", "2021-08-13 06:00:00", "Before start time")]
        [TestCase("2021-08-13 15:13:25", "05:13:25", "2021-08-13 10:00:00", "After end time 1")]
        [TestCase("2021-08-14 11:13:25", "02:13:25", "2021-08-13 20:00:00", "After end time 2")]
        [TestCase("2021-08-14 11:13:25", "10:13:25", "2021-08-13 08:00:00", "Duration Greater Than One Day 1")]
        [TestCase("2021-08-14 09:13:25", "08:13:25", "2021-08-13 09:00:00", "Duration Greater Than One Day 2")]
        [TestCase("2021-08-15 09:13:25", "16:13:25", "2021-08-13 09:00:00", "Duration Greater Than Two Days 1")]
        public void Test_TimeWindow_Add(String expectedDateTimeString, String timeSpanString, String operationDateTimeString, String comment)
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            TimeWindow standardHoursDateTimeWindow = new TimeWindow(startTime, endTime);
            
            TimeSpan durationTimeSpan = TimeSpan.ParseExact(timeSpanString, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            DateTime aDateTime = DateTime.ParseExact(operationDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            DateTime expectedResult = DateTime.ParseExact(expectedDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            DateTime result = aDateTime.Add(standardHoursDateTimeWindow, durationTimeSpan);

            Assert.That(result, Is.EqualTo(expectedResult), comment);
        }

        [TestCase("2018-09-08 20:10:00", 1)]
        [TestCase("2018-09-15 20:10:00", 2)]
        [TestCase("2018-09-29 20:10:00", 4)]
        [TestCase("2018-10-13 20:10:00", 6)]
        public void Test_Weeks_Add(String expectedDateTimeString, Int32 interval)
        {
            DateTime startDate = new DateTime(2018, 9, 1, 20, 10, 0);

            DateTime expectedValue = DateTime.ParseExact(expectedDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            DateTime actualValue = startDate.AddWeeks(interval);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true, "2018-10-01 20:10:00", "2018-09-01 20:10:00", "2018-11-01 20:10:00", "True")]
        [TestCase(false, "2018-10-01 20:10:00", "2019-09-01 20:10:00", "2019-11-01 20:10:00", "False")]
        [TestCase(true, "2018-10-01 20:10:00", "2018-10-01 20:10:00", "2018-10-01 20:10:00", "SameValue")]
        [TestCase(true, "2018-10-01 20:10:00", "2018-10-01 20:10:00", "2018-11-01 20:10:00", "StartSameValue")]
        [TestCase(true, "2018-10-01 20:10:00",  "2018-09-01 20:10:00", "2018-10-01 20:10:00", "EndSameValue")]
        public void Test_IsBetween(Boolean expected, String workingDateString, String earlyDateTimeString, String laterDateTimeString, String comment)
        {
            DateTime workingDate = DateTime.ParseExact(workingDateString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime earlyDateTime = DateTime.ParseExact(earlyDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime laterDateTime = DateTime.ParseExact(laterDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            Boolean actualResult = workingDate.IsBetween(earlyDateTime, laterDateTime);

            Assert.That(actualResult, Is.EqualTo(expected), comment);
        }

        [TestCase(false, null, "2018-09-01 20:10:00", "2018-11-01 20:10:00", "Null")]
        [TestCase(true, "2018-10-01 20:10:00", "2018-09-01 20:10:00", "2018-11-01 20:10:00", "True")]
        [TestCase(false, "2018-10-01 20:10:00", "2019-09-01 20:10:00", "2019-11-01 20:10:00", "False")]
        [TestCase(true, "2018-10-01 20:10:00", "2018-10-01 20:10:00", "2018-10-01 20:10:00", "SameValue")]
        [TestCase(true, "2018-10-01 20:10:00", "2018-10-01 20:10:00", "2018-11-01 20:10:00", "StartSameValue")]
        [TestCase(true, "2018-10-01 20:10:00", "2018-09-01 20:10:00", "2018-10-01 20:10:00", "EndSameValue")]
        public void Test_Nullable_IsBetween(Boolean expected, String? workingDateString, String startValueString, String endValueString, String comment)
        {
            DateTime? workingDate = (String.IsNullOrEmpty(workingDateString)) ? null : DateTime.ParseExact(workingDateString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime earlyDateTime = DateTime.ParseExact(startValueString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime laterDateTime = DateTime.ParseExact(endValueString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            Boolean actualResult = workingDate.IsBetween(earlyDateTime, laterDateTime);

            Assert.That(actualResult, Is.EqualTo(expected), comment);
        }

        [TestCase(false, "2019-12-27 00:00:00")]
        [TestCase(true, "2019-12-28 00:00:00")]
        public void Test_IsWeekend(Boolean expected, String startValueString)
        {
            DateTime startValue = DateTime.ParseExact(startValueString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            Boolean actualResult = startValue.IsWeekend();

            Assert.That(actualResult, Is.EqualTo(expected));
        }

        [TestCase("2020-12-20", DayOfWeek.Sunday, 20)]
        [TestCase("2020-12-21", DayOfWeek.Monday, 21)]
        [TestCase("2020-12-22", DayOfWeek.Tuesday, 22)]
        [TestCase("2020-12-23", DayOfWeek.Wednesday, 23)]
        [TestCase("2020-12-24", DayOfWeek.Thursday, 24)]
        [TestCase("2020-12-25", DayOfWeek.Friday, 25)]
        [TestCase("2020-12-26", DayOfWeek.Saturday, 26)]
        public void Test_StartOfWeek(String expectedDateTimeString, DayOfWeek startOfWeek, Int32 startDate)
        {
            DateTime expectedDateTime = DateTime.ParseExact(expectedDateTimeString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            for (Int32 counter = 0; counter < 7; counter++)
            {
                DateTime earlyDateTime = new DateTime(2020, 12, startDate).AddDays(counter);

                DateTime actualDateTime = earlyDateTime.StartOfWeek(startOfWeek);

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
        [TestCase("2023-02-28 19:00:00", "Eastern Standard Time", "2023-03-01 00:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-02-28 20:00:00", "Eastern Standard Time", "2023-03-01 01:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-02-28 21:00:00", "Eastern Standard Time", "2023-03-01 02:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-02-28 22:00:00", "Eastern Standard Time", "2023-03-01 03:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-02-28 23:00:00", "Eastern Standard Time", "2023-03-01 04:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-03-01 00:00:00", "Eastern Standard Time", "2023-03-01 05:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-03-01 01:00:00", "Eastern Standard Time", "2023-03-01 06:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-03-01 02:00:00", "Eastern Standard Time", "2023-03-01 07:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-03-01 03:00:00", "Eastern Standard Time", "2023-03-01 08:00:00")] // Input - US is in EST // Output UK is in GMT

        [TestCase("2023-03-21 20:00:00", "Eastern Standard Time", "2023-03-22 00:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-21 21:00:00", "Eastern Standard Time", "2023-03-22 01:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-21 22:00:00", "Eastern Standard Time", "2023-03-22 02:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-21 23:00:00", "Eastern Standard Time", "2023-03-22 03:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-22 00:00:00", "Eastern Standard Time", "2023-03-22 04:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-22 01:00:00", "Eastern Standard Time", "2023-03-22 05:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-22 02:00:00", "Eastern Standard Time", "2023-03-22 06:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-22 03:00:00", "Eastern Standard Time", "2023-03-22 07:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-22 04:00:00", "Eastern Standard Time", "2023-03-22 08:00:00")] // Input - US is in DST // Output UK is in GMT

        [TestCase("2023-03-26 19:00:00", "Eastern Standard Time", "2023-03-27 00:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-26 20:00:00", "Eastern Standard Time", "2023-03-27 01:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-26 21:00:00", "Eastern Standard Time", "2023-03-27 02:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-26 22:00:00", "Eastern Standard Time", "2023-03-27 03:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-26 23:00:00", "Eastern Standard Time", "2023-03-27 04:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-27 00:00:00", "Eastern Standard Time", "2023-03-27 05:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-27 01:00:00", "Eastern Standard Time", "2023-03-27 06:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-27 02:00:00", "Eastern Standard Time", "2023-03-27 07:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-27 03:00:00", "Eastern Standard Time", "2023-03-27 08:00:00")] // Input - US is in DST // Output UK is in BST

        [TestCase("2023-10-29 20:00:00", "Eastern Standard Time", "2023-10-30 00:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-29 21:00:00", "Eastern Standard Time", "2023-10-30 01:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-29 22:00:00", "Eastern Standard Time", "2023-10-30 02:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-29 23:00:00", "Eastern Standard Time", "2023-10-30 03:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-30 00:00:00", "Eastern Standard Time", "2023-10-30 04:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-30 01:00:00", "Eastern Standard Time", "2023-10-30 05:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-30 02:00:00", "Eastern Standard Time", "2023-10-30 06:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-30 03:00:00", "Eastern Standard Time", "2023-10-30 07:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-30 04:00:00", "Eastern Standard Time", "2023-10-30 08:00:00")] // Input - US is in EST // Output UK is in BST

        [TestCase("2023-10-30 05:00:00", "Central Europe Standard Time", "2023-10-30 04:00:00")] // Input - EU is in CET // Output UK is in BST
        public void Test_FromUkTime(String expectedDateTimeString, String targetTimeZone, String inputDateTime)
        {
            DateTime localTime = DateTime.ParseExact(inputDateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime expected = DateTime.ParseExact(expectedDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

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
        [TestCase("2023-02-28 19:00:00", "Eastern Standard Time", "2023-03-01 00:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-02-28 20:00:00", "Eastern Standard Time", "2023-03-01 01:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-02-28 21:00:00", "Eastern Standard Time", "2023-03-01 02:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-02-28 22:00:00", "Eastern Standard Time", "2023-03-01 03:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-02-28 23:00:00", "Eastern Standard Time", "2023-03-01 04:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-03-01 00:00:00", "Eastern Standard Time", "2023-03-01 05:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-03-01 01:00:00", "Eastern Standard Time", "2023-03-01 06:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-03-01 02:00:00", "Eastern Standard Time", "2023-03-01 07:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("2023-03-01 03:00:00", "Eastern Standard Time", "2023-03-01 08:00:00")] // Input - US is in EST // Output UK is in GMT

        [TestCase("2023-03-21 20:00:00", "Eastern Standard Time", "2023-03-22 00:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-21 21:00:00", "Eastern Standard Time", "2023-03-22 01:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-21 22:00:00", "Eastern Standard Time", "2023-03-22 02:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-21 23:00:00", "Eastern Standard Time", "2023-03-22 03:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-22 00:00:00", "Eastern Standard Time", "2023-03-22 04:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-22 01:00:00", "Eastern Standard Time", "2023-03-22 05:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-22 02:00:00", "Eastern Standard Time", "2023-03-22 06:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-22 03:00:00", "Eastern Standard Time", "2023-03-22 07:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("2023-03-22 04:00:00", "Eastern Standard Time", "2023-03-22 08:00:00")] // Input - US is in DST // Output UK is in GMT

        [TestCase("2023-03-26 20:00:00", "Eastern Standard Time", "2023-03-27 00:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-26 21:00:00", "Eastern Standard Time", "2023-03-27 01:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-26 22:00:00", "Eastern Standard Time", "2023-03-27 02:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-26 23:00:00", "Eastern Standard Time", "2023-03-27 03:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-27 00:00:00", "Eastern Standard Time", "2023-03-27 04:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-27 01:00:00", "Eastern Standard Time", "2023-03-27 05:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-27 02:00:00", "Eastern Standard Time", "2023-03-27 06:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-27 03:00:00", "Eastern Standard Time", "2023-03-27 07:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("2023-03-27 04:00:00", "Eastern Standard Time", "2023-03-27 08:00:00")] // Input - US is in DST // Output UK is in BST

        [TestCase("2023-10-29 20:00:00", "Eastern Standard Time", "2023-10-30 00:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-29 21:00:00", "Eastern Standard Time", "2023-10-30 01:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-29 22:00:00", "Eastern Standard Time", "2023-10-30 02:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-29 23:00:00", "Eastern Standard Time", "2023-10-30 03:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-30 00:00:00", "Eastern Standard Time", "2023-10-30 04:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-30 01:00:00", "Eastern Standard Time", "2023-10-30 05:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-30 02:00:00", "Eastern Standard Time", "2023-10-30 06:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-30 03:00:00", "Eastern Standard Time", "2023-10-30 07:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("2023-10-30 04:00:00", "Eastern Standard Time", "2023-10-30 08:00:00")] // Input - US is in EST // Output UK is in BST

        [TestCase("2023-10-30 05:00:00", "Central Europe Standard Time", "2023-10-30 04:00:00")] // Input - EU is in CET // Output UK is in BST
        public void Test_FromUkTime_Utc(String expectedDateTimeString, String targetTimeZone, String inputDateTime)
        {
            DateTime localTime = DateTime.ParseExact(inputDateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            localTime = DateTime.SpecifyKind(localTime, DateTimeKind.Utc);
            DateTime expected = DateTime.ParseExact(expectedDateTimeString, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            DateTime actualResult = localTime.ToTimeZone(targetTimeZone);

            Assert.That(actualResult, Is.EqualTo(expected));
        }
    }
}
