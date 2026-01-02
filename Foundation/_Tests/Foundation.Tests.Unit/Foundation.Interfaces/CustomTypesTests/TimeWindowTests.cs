//-----------------------------------------------------------------------
// <copyright file="TimeWindowTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Interfaces.CustomTypesTests
{
    /// <summary>
    /// Unit Tests for the Time Window type
    /// </summary>
    [TestFixture]
    public class TimeWindowTests : UnitTestBase
    {
        private readonly TimeSpan _startTime = new TimeSpan(9, 0, 0);
        private readonly TimeSpan _endTime = new TimeSpan(17, 0, 0);

        [TestCase]
        public void Test_Constructor_and_Properties()
        {
            Type thisType = typeof(TimeWindow);
            ConstructorInfo[] constructorInfos = thisType.GetConstructors();
            Assert.That(constructorInfos.Length, Is.EqualTo(1));

            TimeWindow dateTimeWindow = new TimeWindow(_startTime, _endTime);

            Assert.That(dateTimeWindow.StartTime, Is.EqualTo(_startTime));
            Assert.That(dateTimeWindow.EndTime, Is.EqualTo(_endTime));
        }

        [TestCase]
        public void Test_Constructor_ErrorMessage_1()
        {
            String errorMessage = $"The Start Time ({_endTime}) must be before the End Time ({_startTime})";
            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                _ = new TimeWindow(_endTime, _startTime);
            });

            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_Constructor_ErrorMessage_2()
        {
            String errorMessage = $"The Start Time ({_startTime}) cannot be the same as the End Time ({_startTime})";
            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                _ = new TimeWindow(_startTime, _startTime);
            });

            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_Constructor_ErrorMessage_3()
        {
            TimeSpan startTime = new TimeSpan(123, 0, 0);

            String errorMessage = $"The Start Time ({startTime}) cannot be more than 24 hours";
            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                _ = new TimeWindow(startTime, _endTime);
            });

            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_Constructor_ErrorMessage_4()
        {
            TimeSpan endTime = new TimeSpan(123, 0, 0);

            String errorMessage = $"The End Time ({endTime}) cannot be more than 24 hours";
            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                _ = new TimeWindow(_startTime, endTime);
            });

            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }
    }
}
