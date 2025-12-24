//-----------------------------------------------------------------------
// <copyright file="TimeSpanExtensionMethodsTests.cs" company="JDV Software Ltd">
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
    /// Summary description for AddScheduleIntervalTests
    /// </summary>
    [TestFixture]
    public class TimeSpanExtensionMethodsTests : UnitTestBase
    {
        [TestCase("0,0,0,0,0", 0, ScheduleInterval.Other)]
        [TestCase("0,0,0,0,50000", 50 * 1000, ScheduleInterval.NotSet)]
        [TestCase("0,0,0,0,10000", 10 * 1000, ScheduleInterval.Milliseconds)]
        [TestCase("0,0,0,30,0", 30, ScheduleInterval.Seconds)]
        [TestCase("0,0,3,0,0", 3, ScheduleInterval.Minutes)]
        [TestCase("0,3,0,0,0", 3, ScheduleInterval.Hours)]
        [TestCase("3,0,0,0,0", 3, ScheduleInterval.Days)]
        [TestCase("21,0,0,0,0", 3, ScheduleInterval.Weeks)]
        [TestCase("90,0,0,0,0", 3, ScheduleInterval.Months)]
        [TestCase("1095,0,0,0,0", 3, ScheduleInterval.Years)]
        public void Test_Add(String inputString, Int32 interval, ScheduleInterval scheduleInterval)
        {
            Int32[] inputs = inputString.Split(',').Select(Int32.Parse).ToArray();
            TimeSpan expectedTimeSpan = new TimeSpan(inputs[0], inputs[1], inputs[2], inputs[3], inputs[4]);

            TimeSpan startTimeSpan = TimeSpan.Zero;
            TimeSpan actualTimeSpan = startTimeSpan.Add(scheduleInterval, interval);

            Assert.That(actualTimeSpan, Is.EqualTo(expectedTimeSpan));
        }

        [TestCase]
        public void Test_Add_Exception()
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

        [TestCase(true, "20:10:00", "20:00:00", "21:00:00", "True")]
        [TestCase(false, "20:10:00", "21:00:00", "22:00:00", "False")]
        [TestCase(true, "20:10:00", "20:10:00", "20:10:00", "SameValue")]
        [TestCase(true, "20:10:00", "20:10:00", "21:00:00", "StartSameValue")]
        [TestCase(true, "21:00:00", "20:10:00", "21:00:00", "EndSameValue")]
        public void Test_IsBetween_True(Boolean expected, String workingTimeSpanString, String lowerValueString, String upperValueString, String comment)
        {
            TimeSpan workingTimeSpan = TimeSpan.ParseExact(workingTimeSpanString, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            TimeSpan lowerValue = TimeSpan.ParseExact(lowerValueString, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            TimeSpan upperValue = TimeSpan.ParseExact(upperValueString, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);

            Boolean actualResult = workingTimeSpan.IsBetween(lowerValue, upperValue);

            Assert.That(actualResult, Is.EqualTo(expected), comment);
        }

        [TestCase(false, null, "20:00:00", "21:00:00", "True")]
        [TestCase(true, "20:10:00", "20:00:00", "21:00:00", "True")]
        [TestCase(false, "20:10:00", "21:00:00", "22:00:00", "False")]
        [TestCase(true, "20:10:00", "20:10:00", "20:10:00", "SameValue")]
        [TestCase(true, "20:10:00", "20:10:00", "21:00:00", "StartSameValue")]
        [TestCase(true, "21:00:00", "20:10:00", "21:00:00", "EndSameValue")]
        public void Test_Nullable_IsBetween(Boolean expected, String? workingTimeSpanString, String lowerValueString, String upperValueString, String comment)
        {
            TimeSpan? workingTimeSpan = (String.IsNullOrEmpty(workingTimeSpanString)) ? null : TimeSpan.ParseExact(workingTimeSpanString, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            TimeSpan lowerValue = TimeSpan.ParseExact(lowerValueString, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);
            TimeSpan upperValue = TimeSpan.ParseExact(upperValueString, "hh\\:mm\\:ss", CultureInfo.InvariantCulture);

            Boolean actualResult = workingTimeSpan.IsBetween(lowerValue, upperValue);

            Assert.That(actualResult, Is.EqualTo(expected));
        }
    }
}
