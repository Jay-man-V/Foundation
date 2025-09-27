//-----------------------------------------------------------------------
// <copyright file="AddTimeWindowTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.DateTimeExtensionMethodsTests
{
    /// <summary>
    /// Summary description for AddTimeWindowTests
    /// </summary>
    [TestFixture]
    public class AddTimeWindowTests : UnitTestBase
    {
        private static TimeSpan StartTime => new TimeSpan(9, 0, 0);
        private static TimeSpan EndTime => new TimeSpan(17, 0, 0);
        private static TimeWindow StandardHoursDateTimeWindow => new TimeWindow(StartTime, EndTime);

        [TestCase]
        public void TestAdjustTimeOfDate_WithinWindow()
        {
            TimeSpan durationTimeSpan = new TimeSpan(5, 13, 25);
            DateTime aDateTime = new DateTime(2021, 8, 13, 10, 0, 0);

            DateTime expectedResult = new DateTime(2021, 8, 13, 15, 13, 25);

            DateTime result = aDateTime.Add(StandardHoursDateTimeWindow, durationTimeSpan);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase]
        public void TestAdjustTimeOfDate_BeforeStartTime()
        {
            TimeSpan durationTimeSpan = new TimeSpan(5, 13, 25);
            DateTime aDateTime = new DateTime(2021, 8, 13, 6, 0, 0);

            DateTime expectedResult = new DateTime(2021, 8, 13, 14, 13, 25);

            DateTime result = aDateTime.Add(StandardHoursDateTimeWindow, durationTimeSpan);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase]
        public void TestAdjustTimeOfDate_AfterEndTime()
        {
            TimeSpan durationTimeSpan = new TimeSpan(5, 13, 25);
            DateTime aDateTime = new DateTime(2021, 8, 13, 18, 0, 0);

            DateTime expectedResult = new DateTime(2021, 8, 14, 14, 13, 25);

            DateTime result = aDateTime.Add(StandardHoursDateTimeWindow, durationTimeSpan);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase]
        public void TestAdjustTimeOfDate_DurationGreaterThanOneDay_1()
        {
            TimeSpan durationTimeSpan = new TimeSpan(10, 13, 25);
            DateTime aDateTime = new DateTime(2021, 8, 13, 8, 0, 0);

            DateTime expectedResult = new DateTime(2021, 8, 14, 11, 13, 25);

            DateTime result = aDateTime.Add(StandardHoursDateTimeWindow, durationTimeSpan);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase]
        public void TestAdjustTimeOfDate_DurationGreaterThanOneDay_2()
        {
            TimeSpan durationTimeSpan = new TimeSpan(8, 13, 25);
            DateTime aDateTime = new DateTime(2021, 8, 13, 9, 0, 0);

            DateTime expectedResult = new DateTime(2021, 8, 14, 9, 13, 25);

            DateTime result = aDateTime.Add(StandardHoursDateTimeWindow, durationTimeSpan);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase]
        public void TestAdjustTimeOfDate_DurationGreaterThanTwoDays_1()
        {
            TimeSpan durationTimeSpan = new TimeSpan(16, 13, 25);
            DateTime aDateTime = new DateTime(2021, 8, 13, 9, 0, 0);

            DateTime expectedResult = new DateTime(2021, 8, 15, 9, 13, 25);

            DateTime result = aDateTime.Add(StandardHoursDateTimeWindow, durationTimeSpan);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
