//-----------------------------------------------------------------------
// <copyright file="ExecutionTimerTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.UtilsTests
{
    /// <summary>
    /// The Execution Timer Tests
    /// </summary>
    [TestFixture]
    public class ExecutionTimerTests : UnitTestBase
    {
        /// <summary>
        /// Tests the constructor.
        /// </summary>
        [TestCase]
        public void Test_Constructor()
        {
            ExecutionTimer executionTimer = new ExecutionTimer();

            Assert.That(executionTimer.ProcessName, Is.EqualTo("Test_Constructor"));
        }

        /// <summary>
        /// Tests the start timer.
        /// </summary>
        [TestCase]
        public void Test_StartTimer()
        {
            ExecutionTimer executionTimer = new ExecutionTimer();

            executionTimer.StartTimer();
        }

        /// <summary>
        /// Tests the stop timer.
        /// </summary>
        [TestCase]
        public void Test_StopTimer()
        {
            ExecutionTimer executionTimer = new ExecutionTimer();

            executionTimer.StartTimer();
            executionTimer.StopTimer();
        }

        /// <summary>
        /// Tests the duration.
        /// </summary>
        [TestCase]
        public void Test_Duration()
        {
            ExecutionTimer executionTimer = new ExecutionTimer();

            executionTimer.StartTimer();
            executionTimer.StopTimer();

            Object duration = executionTimer.Duration;
            Assert.That(duration, Is.Not.EqualTo(null));
            Assert.That(duration, Is.InstanceOf<TimeSpan>());
        }

        /// <summary>
        /// Tests the duration as seconds.
        /// </summary>
        [TestCase]
        public void Test_DurationAsSeconds()
        {
            ExecutionTimer executionTimer = new ExecutionTimer();

            const Int32 delayTime = 1000;

            executionTimer.StartTimer();
            Thread.Sleep(delayTime);
            executionTimer.StopTimer();

            Double duration = executionTimer.DurationAsSeconds;

            Assert.That(duration > 0d);
            Assert.That(duration >= (Double)delayTime / 1000);
            Assert.That(executionTimer.ToString(), Is.Not.EqualTo(String.Empty));

            String durationAsString = executionTimer;
            Assert.That(durationAsString, Is.Not.EqualTo(String.Empty));
        }
    }
}
