//-----------------------------------------------------------------------
// <copyright file="TimeWindowTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Interfaces;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Interfaces.CustomTypesTests
{
    /// <summary>
    /// Unit Tests for the Time Window type
    /// </summary>
    [TestFixture]
    public class TimeWindowTests : UnitTestBase
    {
        private readonly TimeSpan _startTime = new (9, 0, 0);
        private readonly TimeSpan _endTime = new (17, 0, 0);

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
            Exception? actualException = null;

            try
            {
                _ = new TimeWindow(_endTime, _startTime);
            }
            catch (Exception exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException, Is.InstanceOf<ArgumentException>());

            String errorMessage = $"The Start Time ({_endTime}) must be before the End Time ({_startTime})";
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_Constructor_ErrorMessage_2()
        {
            Exception? actualException = null;

            try
            {
                _ = new TimeWindow(_startTime, _startTime);
            }
            catch (Exception exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException, Is.InstanceOf<ArgumentException>());

            String errorMessage = $"The Start Time ({_startTime}) cannot be the same as the End Time ({_startTime})";
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }
    }
}
