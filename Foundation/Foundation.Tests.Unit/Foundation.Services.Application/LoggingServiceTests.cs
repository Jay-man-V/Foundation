//-----------------------------------------------------------------------
// <copyright file="LoggingServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Services.Application;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    public class LoggingServiceTests : UnitTestBase
    {
        private ILoggingService? TheService { get; set; }
        private IEventLogRepository EventLogRepository { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            EventLogRepository = Substitute.For<IEventLogRepository>();

            TheService = new LoggingService(CoreInstance, RunTimeEnvironmentSettings, DateTimeService, EventLogRepository);
        }

        [TestCase]
        public void Test_GetLatest()
        {

        }

        [TestCase]
        public void Test_StartTask()
        {

        }

        [TestCase]
        public void Test_EndTask()
        {

        }

        [TestCase]
        public void Test_CreateLogEntry_1()
        {

        }

        [TestCase]
        public void Test_CreateLogEntry_2()
        {

        }

        [TestCase]
        public void Test_UpdateLogEntry()
        {

        }
    }
}