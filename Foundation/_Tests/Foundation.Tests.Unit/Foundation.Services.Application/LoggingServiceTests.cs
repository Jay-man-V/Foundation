//-----------------------------------------------------------------------
// <copyright file="LoggingServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Models.Log;
using Foundation.Services.Application;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    public class LoggingServiceTests : UnitTestBase
    {
        private String BatchName => "UnitTesting";

        private ILoggingService? TheService { get; set; }
        private IEventLogRepository? TheRepository { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            ICore core = Substitute.For<ICore>();

            TheRepository = Substitute.For<IEventLogRepository>();

            TheService = new LoggingService(core, RunTimeEnvironmentSettings, DateTimeService, TheRepository);
        }

        public override void TestCleanup()
        {
            TheRepository!.Dispose();
            TheRepository = null;

            TheService = null;

            base.TestCleanup();
        }

        [TestCase]
        public void Test_GetLatest()
        {
            IEventLog eventLog = new EventLog();
            eventLog.Id = new LogId(123);

            TheRepository!.GetLatest(Arg.Any<Boolean>(), Arg.Any<EntityId>(), Arg.Any<String>(), Arg.Any<String>(), Arg.Any<String>()).Returns(eventLog);

            IEventLog? actual = TheService!.GetLatest(true);

            Assert.That(actual, Is.Not.EqualTo(null));
            Assert.That(actual.Id, Is.EqualTo(eventLog.Id));
        }

        [TestCase]
        public void Test_StartTask()
        {
            AppId applicationId = TestingApplicationId;
            String batchName = BatchName;
            String processName = LocationUtils.GetClassName();
            String taskName = LocationUtils.GetFunctionName();
            LogId expected = new LogId(123);

            TheRepository!.Save(Arg.Any<IEventLog>()).Returns(args =>
            {
                IEventLog entity = (IEventLog)args[0];
                entity.Id = new LogId(expected);
                entity.ApplicationId = new AppId(1);

                return entity;
            });

            LogId logId = TheService!.StartTask(applicationId, batchName, processName, taskName);

            Assert.That(logId.TheLogId, Is.EqualTo(expected.TheLogId));
        }

        [TestCase("")]
        [TestCase("A - B - C")]
        public void Test_EndTask_1(String initialEntry)
        {
            LogId logId = new LogId(123);
            LogSeverity logSeverity = LogSeverity.Error;
            String batchName = BatchName;
            String processName = LocationUtils.GetClassName();
            String taskName = LocationUtils.GetFunctionName();
            String information = initialEntry;

            IEventLog entity = new EventLog();
            entity.Id = logId;
            entity.ApplicationId = TestingApplicationId;
            entity.BatchName = batchName;
            entity.ProcessName = processName;
            entity.TaskName = taskName;
            entity.LogSeverityId = new EntityId(logSeverity.Id());
            entity.Information = information;
            entity.StartedOn = SystemDateTimeMs;

            TheRepository!.Get(Arg.Any<LogId>()).Returns(entity);

            IEventLog? savedEventLog = null;
            TheRepository!.Save(Arg.Do<IEventLog>(e => savedEventLog = e));

            String updateMessage = "End Task Called";
            TheService!.EndTask(logId, logSeverity, updateMessage);

            String expected = updateMessage;
            if (!String.IsNullOrEmpty(initialEntry))
            {
                expected = initialEntry + Environment.NewLine + updateMessage;
            }

            Assert.That(savedEventLog!.Information, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_EndTask_2_Exception()
        {
            LogId logId = new LogId(123);
            LogSeverity logSeverity = LogSeverity.Error;
            String batchName = BatchName;
            String processName = LocationUtils.GetClassName();
            String taskName = LocationUtils.GetFunctionName();
            String information = String.Empty;

            IEventLog entity = new EventLog();
            entity.Id = logId;
            entity.ApplicationId = TestingApplicationId;
            entity.BatchName = batchName;
            entity.ProcessName = processName;
            entity.TaskName = taskName;
            entity.LogSeverityId = new EntityId(logSeverity.Id());
            entity.Information = information;
            entity.StartedOn = SystemDateTimeMs;

            TheRepository!.Get(Arg.Any<LogId>()).Returns(entity);

            String updateMessage = String.Empty;
            try
            {
                updateMessage = $"{batchName} - {processName} - {taskName}";
                throw new Exception(updateMessage);
            }
            catch (Exception loggedException)
            {
                TheService!.EndTask(logId, logSeverity, loggedException);
            }

            IEventLog? savedEventLog = null;
            TheRepository!.Save(Arg.Do<IEventLog>(e => savedEventLog = e));

            TheService!.EndTask(logId, logSeverity, updateMessage);

            Assert.That(savedEventLog!.Information.Contains(updateMessage), Is.EqualTo(true));
        }

        [TestCase]
        public void Test_CreateLogEntry_1()
        {
            LogId parentLogId = new LogId(0);
            AppId applicationId = TestingApplicationId;
            String batchName = BatchName;
            String processName = LocationUtils.GetClassName();
            String taskName = LocationUtils.GetFunctionName();
            LogSeverity logSeverity = LogSeverity.Information;
            String information = Guid.NewGuid().ToString();

            IEventLog? savedEventLog = null;
            TheRepository!.Save(Arg.Do<IEventLog>(e => savedEventLog = e));

            TheService!.CreateLogEntry(parentLogId, applicationId, batchName, processName, taskName, logSeverity, information);

            Assert.That(savedEventLog!.ApplicationId.TheAppId, Is.EqualTo(applicationId.TheAppId));
            Assert.That(savedEventLog!.BatchName, Is.EqualTo(batchName));
            Assert.That(savedEventLog!.ProcessName, Is.EqualTo(processName));
            Assert.That(savedEventLog!.TaskName, Is.EqualTo(taskName));
            Assert.That(savedEventLog!.LogSeverityId.TheEntityId, Is.EqualTo(logSeverity.Id()));
            Assert.That(savedEventLog!.StartedOn, Is.EqualTo(DateTimeService.SystemUtcDateTimeNow));
        }

        [TestCase]
        public void Test_CreateLogEntry_2_Exception()
        {
            LogId parentLogId = new LogId(0);
            AppId applicationId = TestingApplicationId;

            LogSeverity logSeverity = LogSeverity.Error;
            String batchName = BatchName;
            String processName = LocationUtils.GetClassName();
            String taskName = LocationUtils.GetFunctionName();

            IEventLog? savedEventLog = null;
            TheRepository!.Save(Arg.Do<IEventLog>(e => savedEventLog = e));

            String updateMessage = String.Empty;
            try
            {
                updateMessage = $"{batchName} - {processName} - {taskName}";
                throw new Exception(updateMessage);
            }
            catch (Exception loggedException)
            {
                TheService!.CreateLogEntry(parentLogId, applicationId, logSeverity, loggedException);
            }

            Assert.That(savedEventLog!.ApplicationId.TheAppId, Is.EqualTo(applicationId.TheAppId));
            Assert.That(savedEventLog!.BatchName, Is.EqualTo(String.Empty));
            Assert.That(savedEventLog!.ProcessName, Is.EqualTo(String.Empty));
            Assert.That(savedEventLog!.TaskName, Is.EqualTo(String.Empty));
            Assert.That(savedEventLog!.LogSeverityId.TheEntityId, Is.EqualTo(logSeverity.Id()));
            Assert.That(savedEventLog!.StartedOn, Is.EqualTo(DateTimeService.SystemUtcDateTimeNow));
            Assert.That(savedEventLog!.Information.Contains(updateMessage), Is.EqualTo(true));
        }

        [TestCase("")]
        [TestCase("A - B - C")]
        public void Test_UpdateLogEntry(String initialEntry)
        {
            LogId logId = new LogId(123);
            LogSeverity logSeverity = LogSeverity.Error;
            String batchName = BatchName;
            String processName = LocationUtils.GetClassName();
            String taskName = LocationUtils.GetFunctionName();
            String information = initialEntry;

            IEventLog entity = new EventLog();
            entity.Id = logId;
            entity.ApplicationId = TestingApplicationId;
            entity.BatchName = batchName;
            entity.ProcessName = processName;
            entity.TaskName = taskName;
            entity.LogSeverityId = new EntityId(logSeverity.Id());
            entity.Information = information;
            entity.StartedOn = SystemDateTimeMs;

            TheRepository!.Get(Arg.Any<LogId>()).Returns(entity);

            IEventLog? savedEventLog = null;
            TheRepository!.Save(Arg.Do<IEventLog>(e => savedEventLog = e));

            String updateMessage = Guid.NewGuid().ToString();
            TheService!.UpdateLogEntry(logId, updateMessage);

            String expected = updateMessage;
            if (!String.IsNullOrEmpty(initialEntry))
            {
                expected = initialEntry + Environment.NewLine + updateMessage;
            }


            Assert.That(savedEventLog!.ApplicationId.TheAppId, Is.EqualTo(TestingApplicationId.TheAppId));
            Assert.That(savedEventLog!.BatchName, Is.EqualTo(batchName));
            Assert.That(savedEventLog!.ProcessName, Is.EqualTo(processName));
            Assert.That(savedEventLog!.TaskName, Is.EqualTo(taskName));
            Assert.That(savedEventLog!.LogSeverityId.TheEntityId, Is.EqualTo(logSeverity.Id()));
            Assert.That(savedEventLog!.StartedOn, Is.EqualTo(DateTimeService.SystemUtcDateTimeNow));
            Assert.That(savedEventLog!.Information, Is.EqualTo(expected));
        }
    }
}