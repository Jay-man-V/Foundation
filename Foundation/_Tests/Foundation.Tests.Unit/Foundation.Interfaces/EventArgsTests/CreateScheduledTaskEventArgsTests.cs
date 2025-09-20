//-----------------------------------------------------------------------
// <copyright file="CreateScheduledTaskEventArgsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Interfaces.EventArgsTests
{
    /// <summary>
    /// Create Scheduled Task Event Args Tests
    /// </summary>
    [TestFixture]
    public class CreateScheduledTaskEventArgsTests : UnitTestBase
    {
        private const String AssemblyName = "Foundation.BusinessProcess";
        private const String TypeName = "Foundation.BusinessProcess.ScheduledJobProcess";
        private readonly String _fullyQualifiedTypeNameString = $@"<TaskImplementation assembly=""{AssemblyName}"" type=""{TypeName}"" />";

        /// <summary>
        /// Tests the default constructor.
        /// </summary>
        [TestCase]
        public void Test_ConstructorDefault()
        {
            FullyQualifiedTypeName fullyQualifiedTypeName = new FullyQualifiedTypeName(_fullyQualifiedTypeNameString);
            IScheduledTask serviceTask = CoreInstance.IoC.Get<IScheduledTask>();

            CreateScheduledTaskEventArgs eventArgs = new(fullyQualifiedTypeName);
            eventArgs.ServiceInstance = serviceTask;

            Assert.That(eventArgs.FullyQualifiedTypeName, Is.EqualTo(fullyQualifiedTypeName));
            Assert.That(eventArgs.ServiceInstance, Is.EqualTo(serviceTask));
        }
    }
}
