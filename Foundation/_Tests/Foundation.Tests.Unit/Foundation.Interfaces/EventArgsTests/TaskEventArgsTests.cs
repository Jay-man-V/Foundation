//-----------------------------------------------------------------------
// <copyright file="TaskEventArgsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Interfaces.EventArgsTests
{
    /// <summary>
    /// Task Event Args Tests
    /// </summary>
    [TestFixture]
    public class TaskEventArgsTests : UnitTestBase
    {
        /// <summary>
        /// Tests the default constructor.
        /// </summary>
        [TestCase]
        public void Test_ConstructorDefault()
        {
            LogId logId = new LogId(123456);
            String taskParameters = $"Test Parameters - ({Guid.NewGuid()})";
            TaskEventArgs eventArgs = new TaskEventArgs(logId, taskParameters);

            Assert.That(eventArgs.LogId, Is.EqualTo(logId));
            Assert.That(eventArgs.TaskParameters, Is.EqualTo(taskParameters));
        }
    }
}
