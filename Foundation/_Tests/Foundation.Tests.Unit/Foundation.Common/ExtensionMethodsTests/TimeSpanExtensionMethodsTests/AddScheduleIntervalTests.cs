//-----------------------------------------------------------------------
// <copyright file="AddScheduleIntervalTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.TimeSpanExtensionMethodsTests
{
    /// <summary>
    /// Summary description for AddScheduleIntervalTests
    /// </summary>
    [TestFixture]
    public class AddScheduleIntervalTests : UnitTestBase
    {
        [TestCase]
        public void Test_Add_Other()
        {
            const Int32 interval = 0;
            const ScheduleInterval scheduleInterval = ScheduleInterval.Other;
            TimeSpan startTimeSpan = new TimeSpan();
            TimeSpan expectedTimeSpan = new TimeSpan(0, 0, 0, 0, interval);
            TimeSpan actualTimeSpan = startTimeSpan.Add(scheduleInterval, interval);

            Assert.That(actualTimeSpan, Is.EqualTo(expectedTimeSpan));
        }

        [TestCase]
        public void Test_Add_NotSet()
        {
            const Int32 interval = 50 * 1000;
            const ScheduleInterval scheduleInterval = ScheduleInterval.NotSet;
            TimeSpan startTimeSpan = new TimeSpan();
            TimeSpan expectedTimeSpan = new TimeSpan(0, 0, 0, 0, interval);
            TimeSpan actualTimeSpan = startTimeSpan.Add(scheduleInterval, interval);

            Assert.That(actualTimeSpan, Is.EqualTo(expectedTimeSpan));
        }

        [TestCase]
        public void Test_Add_Milliseconds()
        {
            const Int32 interval = 10 * 1000;
            const ScheduleInterval scheduleInterval = ScheduleInterval.Milliseconds;
            TimeSpan startTimeSpan = new TimeSpan();
            TimeSpan expectedTimeSpan = new TimeSpan(0, 0, 0, 0, interval);
            TimeSpan actualTimeSpan = startTimeSpan.Add(scheduleInterval, interval);

            Assert.That(actualTimeSpan, Is.EqualTo(expectedTimeSpan));
        }

        [TestCase]
        public void Test_Add_Seconds()
        {
            const Int32 interval = 30;
            const ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            TimeSpan startTimeSpan = new TimeSpan();
            TimeSpan expectedTimeSpan = new TimeSpan(0, 0, 0, interval, 0);
            TimeSpan actualTimeSpan = startTimeSpan.Add(scheduleInterval, interval);

            Assert.That(actualTimeSpan, Is.EqualTo(expectedTimeSpan));
        }

        [TestCase]
        public void Test_Add_Minutes()
        {
            const Int32 interval = 3;
            const ScheduleInterval scheduleInterval = ScheduleInterval.Minutes;
            TimeSpan startTimeSpan = new TimeSpan();
            TimeSpan expectedTimeSpan = new TimeSpan(0, 0, interval, 0, 0);
            TimeSpan actualTimeSpan = startTimeSpan.Add(scheduleInterval, interval);

            Assert.That(actualTimeSpan, Is.EqualTo(expectedTimeSpan));
        }

        [TestCase]
        public void Test_Add_Hours()
        {
            const Int32 interval = 3;
            const ScheduleInterval scheduleInterval = ScheduleInterval.Hours;
            TimeSpan startTimeSpan = new TimeSpan();
            TimeSpan expectedTimeSpan = new TimeSpan(0, interval, 0, 0, 0);
            TimeSpan actualTimeSpan = startTimeSpan.Add(scheduleInterval, interval);

            Assert.That(actualTimeSpan, Is.EqualTo(expectedTimeSpan));
        }

        [TestCase]
        public void Test_Add_Days()
        {
            const Int32 interval = 3;
            const ScheduleInterval scheduleInterval = ScheduleInterval.Days;
            TimeSpan startTimeSpan = new TimeSpan();
            TimeSpan expectedTimeSpan = new TimeSpan(interval, 0, 0, 0, 0);
            TimeSpan actualTimeSpan = startTimeSpan.Add(scheduleInterval, interval);

            Assert.That(actualTimeSpan, Is.EqualTo(expectedTimeSpan));
        }

        [TestCase]
        public void Test_Add_Weeks()
        {
            const Int32 interval = 3;
            const ScheduleInterval scheduleInterval = ScheduleInterval.Weeks;
            TimeSpan startTimeSpan = new TimeSpan();
            TimeSpan expectedTimeSpan = new TimeSpan(interval * 7, 0, 0, 0, 0);
            TimeSpan actualTimeSpan = startTimeSpan.Add(scheduleInterval, interval);

            // Not fully implemented
            Assert.That(actualTimeSpan, Is.EqualTo(expectedTimeSpan));
        }

        [TestCase]
        public void Test_Add_Months()
        {
            const Int32 interval = 3;
            const ScheduleInterval scheduleInterval = ScheduleInterval.Months;
            TimeSpan startTimeSpan = new TimeSpan();
            TimeSpan expectedTimeSpan = new TimeSpan(interval * 30, 0, 0, 0, 0);
            TimeSpan actualTimeSpan = startTimeSpan.Add(scheduleInterval, interval);

            // Not fully implemented
            Assert.That(actualTimeSpan, Is.EqualTo(expectedTimeSpan));
        }

        [TestCase]
        public void Test_Add_Years()
        {
            const Int32 interval = 3;
            const ScheduleInterval scheduleInterval = ScheduleInterval.Years;
            TimeSpan startTimeSpan = new TimeSpan();
            TimeSpan expectedTimeSpan = new TimeSpan(interval * 365, 0, 0, 0, 0);
            TimeSpan actualTimeSpan = startTimeSpan.Add(scheduleInterval, interval);

            // Not fully implemented
            Assert.That(actualTimeSpan, Is.EqualTo(expectedTimeSpan));
        }

        [TestCase]
        public void Test_Add_Error()
        {
            //const ScheduleType scheduleType = ScheduleType.NotSet;
            //DateTime startDateTime = new DateTime(2020, 12, 24, 15, 48, 55);
            //TimeSpan startTime = new TimeSpan(1, 2, 3);
            //Exception actualException = null;

            //String errorMessage = $"The Schedule Type of '{scheduleType}' is unknown or invalid for the chosen Add method (Parameter 'scheduleType')";

            //try
            //{
            //    DateTime actualRunDateTime = startDateTime.Add(scheduleType, interval, startTime);
            //}
            //catch (Exception exception)
            //{
            //    actualException = exception;
            //}

            //Assert.That(actualException, Is.Not.EqualTo(null));
            //Assert.That(actualException, Is.InstanceOf<ArgumentException>());

            //Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }
    }
}
