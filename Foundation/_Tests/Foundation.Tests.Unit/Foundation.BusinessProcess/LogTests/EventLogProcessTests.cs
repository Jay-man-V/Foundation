//-----------------------------------------------------------------------
// <copyright file="EventLogProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Common;
using Foundation.BusinessProcess.Log;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;
using FEnums = Foundation.Interfaces;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.LogTests
{
    /// <summary>
    /// Summary description for EventLogProcessTests
    /// </summary>
    [TestFixture]
    public class EventLogProcessTests : CommonBusinessProcessTests<IEventLog, IEventLogProcess, IEventLogRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 14;
        protected override String ExpectedScreenTitle => "Event Logs";
        protected override String ExpectedStatusBarText => "Number of Event Logs:";

        protected override String ExpectedComboBoxDisplayMember => FDC.EventLog.BatchName;

        protected override IEventLogRepository CreateRepository()
        {
            IEventLogRepository dataAccess = Substitute.For<IEventLogRepository>();

            return dataAccess;
        }

        protected override IEventLogProcess CreateBusinessProcess()
        {
            IEventLogProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IEventLogProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            ILogSeverityProcess logSeverityProcess = Substitute.For<ILogSeverityProcess>();
            ITaskStatusProcess taskStatusProcess = Substitute.For<ITaskStatusProcess>();

            IEventLogProcess process = new EventLogProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, TheRepository!, StatusRepository!, UserProfileRepository!, logSeverityProcess, taskStatusProcess);

            return process;
        }

        protected override IEventLog CreateBlankEntity(IEventLogProcess process, Int32 entityId)
        {
            IEventLog retVal = CoreInstance.IoC.Get<IEventLog>();

            retVal.Id = new LogId(entityId);

            return retVal;
        }

        protected override IEventLog CreateEntity(IEventLogProcess process, Int32 entityId)
        {
            IEventLog retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.ApplicationId = new AppId(1);
            retVal.ParentId = new LogId(1);
            retVal.LogSeverityId = new EntityId(1);
            retVal.ScheduledTaskId = new EntityId(1);
            retVal.BatchName = Guid.NewGuid().ToString();
            retVal.ProcessName = Guid.NewGuid().ToString();
            retVal.TaskName = Guid.NewGuid().ToString();
            retVal.TaskStatusId = new EntityId(1);
            retVal.StartedOn = DateTime.Now;
            retVal.FinishedOn = DateTime.Now;
            retVal.Information = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IEventLog entity)
        {
            Assert.That(entity.ApplicationId, Is.EqualTo(new AppId(0)));
            Assert.That(entity.ParentId, Is.EqualTo(new LogId(0)));
            Assert.That(entity.LogSeverityId, Is.EqualTo(new EntityId(0)));
            Assert.That(entity.ScheduledTaskId, Is.EqualTo(new EntityId(0)));
            Assert.That(entity.BatchName, Is.EqualTo(String.Empty));
            Assert.That(entity.ProcessName, Is.EqualTo(String.Empty));
            Assert.That(entity.TaskName, Is.EqualTo(String.Empty));
            Assert.That(entity.TaskStatusId, Is.EqualTo(new EntityId(0)));
            Assert.That(entity.StartedOn, Is.EqualTo(DateTime.MinValue));
            Assert.That(entity.FinishedOn, Is.EqualTo(DateTime.MinValue));
            Assert.That(entity.Information, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IEventLog entity)
        {
            Assert.That(entity.BatchName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IEventLog entity)
        {
            Assert.That(entity.BatchName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IEventLog entity1, IEventLog entity2)
        {
            Assert.That(entity2.BatchName, Is.EqualTo(entity1.BatchName));
            Assert.That(entity2.ProcessName, Is.EqualTo(entity1.ProcessName));
            Assert.That(entity2.TaskName, Is.EqualTo(entity1.TaskName));
            Assert.That(entity2.TaskStatusId, Is.EqualTo(entity1.TaskStatusId));
            Assert.That(entity2.StartedOn, Is.EqualTo(entity1.StartedOn));
            Assert.That(entity2.FinishedOn, Is.EqualTo(entity1.FinishedOn));
            Assert.That(entity2.Information, Is.EqualTo(entity1.Information));

            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Parent Id,Log Severity,Batch Name,Process Name,Task Name,Task Status,Start On,Finished On,Information" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,1,e2b0b601-6929-4408-ab4d-84caf3730e92,b5fabecb-f5a1-4f42-bc49-798fc72933ce,4cbc495e-22c7-471c-8fe5-526ea894f6d0,1,2025-09-21T09:37:37.321,2025-09-21T09:38:37.321,21c2aec4-b4d5-415c-9293-886d574d0702" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,1,618a7534-d2bf-444d-9532-496ee5128645,ea21b7f9-599c-4175-a186-da173b1da5f2,5b607aa7-476c-4f53-9fbc-b547e10f2cfd,1,2025-09-21T09:37:37.321,2025-09-21T09:38:37.321,93c582df-943e-463c-8e49-ea713bbd8fc6" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,1,6a2571cb-887d-44f2-8b98-e548dbb5f9aa,efb7cb99-8b53-417d-9bef-c45ebe1e4a87,cee19a79-5230-4e32-98a9-fae4a9ae98bf,1,2025-09-21T09:37:37.321,2025-09-21T09:38:37.321,dd0e8c51-f568-4d9b-b0a1-a31f620c50f5" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,1,f6a47492-49e5-43e5-9a42-7158e973676d,93f136f3-4077-4d81-9924-dc8e6b27e6cd,90c84f35-c2b3-45cd-9b96-9b61424b849c,1,2025-09-21T09:37:37.321,2025-09-21T09:38:37.321,af1b3628-3c3a-4e3f-b2b4-f61a819f8855" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,1,592e76a8-10e5-45d9-8e40-43ed7578a961,17ccc55e-ddb4-44cf-a955-6d540d123c33,4bbee387-2d5b-4893-9140-dcf24b5f8d86,1,2025-09-21T09:37:37.321,2025-09-21T09:38:37.321,5413bd3b-c888-484f-99d5-62ac752c996d" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,1,d2a545fd-419b-48e0-b79b-266d2b6d450c,5ed77477-e328-4c84-9374-2dee52c637e9,428b61ae-592e-47ae-afb6-1e11a0d4f2fd,1,2025-09-21T09:37:37.321,2025-09-21T09:38:37.321,b28583bd-6a96-43a9-8f77-7a20be94a399" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,1,2ca607dc-3bcb-43d0-b0c5-95d8133c7a36,bc9dc450-e10a-41bb-9aba-2cfd145b8766,840eb984-d469-47cd-b5e9-69ff659a214e,1,2025-09-21T09:37:37.321,2025-09-21T09:38:37.321,0972b961-b6f1-4168-9a2d-e49573fca10b" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,1,9e974881-0361-4551-9e91-1b138ae743b1,3641bac0-6663-49d7-9105-5d89f076756c,e31407d0-625d-4c36-9841-996ef26a39e5,1,2025-09-21T09:37:37.321,2025-09-21T09:38:37.321,3040976e-eab4-4e6b-ab75-08ba098b4049" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,1,34d868f6-f1c4-4a40-9309-a01efc3de8d8,52812dfa-3a30-4aa2-97fc-f2de1e95d0c4,3ae4287d-6f52-42d0-abc8-9dbb497d74af,1,2025-09-21T09:37:37.321,2025-09-21T09:38:37.321,a9c39784-653a-490e-84dd-6fa6cf29e5b3" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,1,38007a95-67a8-4260-8079-20d19eadcb0d,5e96476a-63a4-4a51-b973-bc2dd1fa63e2,29fe511f-0045-4559-af7b-0fbc974cf6a0,1,2025-09-21T09:37:37.321,2025-09-21T09:38:37.321,fdd5f618-5bc3-4e36-94d0-9a700c1378b9" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IEventLog entity)
        {
            entity.BatchName += "Updated";
            entity.ProcessName += "Updated";
            entity.TaskName += "Updated";
            entity.TaskStatusId = new EntityId(1);
            entity.FinishedOn = entity.StartedOn.AddDays(10);
            entity.Information += "Updated";
        }

        [TestCase]
        public override void Test_Delete_Entity_Id()
        {
            TheRepository!
                .When(da => da.Delete(Arg.Any<EntityId>()))
                .Do(x => throw new NotImplementedException("Event Log Entries cannot be deleted"));

            NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
            {
                TheProcess!.Delete(new EntityId(1));
            });

            Assert.That(actualException, Is.Not.Null);
        }

        [TestCase]
        public override void Test_Delete_Entity_Object()
        {
            TheRepository!
                .When(da => da.Delete(Arg.Any<IEventLog>()))
                .Do(x => throw new NotImplementedException("Event Log Entries cannot be deleted"));

            NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
            {
                IEventLog entity = CoreInstance.IoC.Get<IEventLog>();
                TheProcess!.Delete(entity);
            });

            Assert.That(actualException, Is.Not.Null);
        }

        [TestCase]
        public override void Test_Delete_MultipleEntities()
        {
            List<IEventLog> eventLogs = new List<IEventLog>
            {
                CoreInstance.IoC.Get<IEventLog>(),
                CoreInstance.IoC.Get<IEventLog>(),
            };

            TheRepository!
                .When(da => da.Delete(Arg.Any<List<IEventLog>>()))
                .Do(x => throw new NotImplementedException("Event Log Entries cannot be deleted"));

            NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
            {
                TheProcess!.Delete(eventLogs);
            });

            Assert.That(actualException, Is.Not.Null);
        }

        //[TestCase(FEnums.TaskStatus.NotSet, true, 0, null, null, null)]
        //[TestCase(FEnums.TaskStatus.NotSet, true, 1, null, null, null)]
        //[TestCase(FEnums.TaskStatus.NotSet, true, 0, "UnitTesting", null, null)]
        //[TestCase(FEnums.TaskStatus.NotSet, true, 0, null, "UnitTesting", null)]
        //[TestCase(FEnums.TaskStatus.NotSet, true, 0, null, null, "UnitTesting")]
        //public void Test_GetLatest(FEnums.TaskStatus expectedTaskStatus, Boolean isFinished, Int32 scheduledTaskId, String batchName, String processName, String taskName)
        //{
        //    FEnums.TaskStatus actual = FEnums.TaskStatus.NotSet;

        //    IEventLog eventLog = TheProcess!.GetLatest(isFinished, new EntityId(scheduledTaskId), batchName, processName, taskName);

        //    if (eventLog != null)
        //    {
        //        actual = eventLog.TaskStatus;
        //    }

        //    Assert.That(expectedTaskStatus, Is.EqualTo(actual));
        //}

        //[TestCase]
        //public void Test_StartTask()
        //{
        //    AppId applicationId = CoreInstance.ApplicationId;
        //    String batchName = "UnitTesting";
        //    String processName = LocationUtils.GetClassName();
        //    String taskName = LocationUtils.GetFunctionName();

        //    TheRepository!.Save(Arg.Any<IEventLog>()).Returns(args =>
        //    {
        //        IEventLog entity = (IEventLog)args[0];
        //        entity.Id = new LogId(1);
        //        entity.ApplicationId = new AppId(1);

        //        return entity;
        //    });

        //    TheRepository!.Get(Arg.Any<LogId>()).Returns(args =>
        //    {
        //        IEventLog entity = CoreInstance.IoC.Get<IEventLog>();
        //        entity.Id = new LogId(1);
        //        entity.ApplicationId = new AppId(1);
        //        entity.BatchName = batchName;
        //        entity.ProcessName = processName;
        //        entity.TaskName = taskName;
        //        entity.LogSeverityId = new EntityId(LogSeverity.Information.Id());
        //        entity.StartedOn = DateTimeService.SystemDateTimeNow;

        //        return entity;
        //    });

        //    LogId logId = TheProcess!.StartTask(applicationId, batchName, processName, taskName);

        //    Assert.That(logId.TheLogId > 0);

        //    IEventLog eventLog = TheProcess!.Get(logId);

        //    Assert.That(eventLog.Id.TheLogId, Is.EqualTo(logId.TheLogId));
        //    Assert.That(eventLog.ApplicationId.TheAppId, Is.EqualTo(applicationId.TheAppId));
        //    Assert.That(eventLog.BatchName, Is.EqualTo(batchName));
        //    Assert.That(eventLog.ProcessName, Is.EqualTo(processName));
        //    Assert.That(eventLog.TaskName, Is.EqualTo(taskName));
        //    Assert.That(eventLog.LogSeverityId.ToInteger(), Is.EqualTo(LogSeverity.Information.Id()));
        //    Assert.That(eventLog.StartedOn, Is.EqualTo(DateTimeService.SystemDateTimeNow));
        //}

        //[TestCase]
        //public void Test_EndTask_1()
        //{
        //    AppId applicationId = CoreInstance.ApplicationId;
        //    String batchName = "UnitTesting";
        //    String processName = LocationUtils.GetClassName();
        //    String taskName = LocationUtils.GetFunctionName();
        //    LogSeverity logSeverity = LogSeverity.Warning;

        //    TheRepository!.Save(Arg.Any<IEventLog>()).Returns(args =>
        //    {
        //        IEventLog entity = (IEventLog)args[0];
        //        entity.Id = new LogId(1);

        //        return entity;
        //    });

        //    TheRepository!.Get(Arg.Any<LogId>()).Returns(args =>
        //    {
        //        IEventLog entity = CoreInstance.IoC.Get<IEventLog>();
        //        entity.Id = new LogId(1);
        //        entity.ApplicationId = new AppId(1);
        //        entity.BatchName = batchName;
        //        entity.ProcessName = processName;
        //        entity.TaskName = taskName;
        //        entity.LogSeverityId = new EntityId(logSeverity.Id());
        //        entity.StartedOn = DateTimeService.SystemDateTimeNow;

        //        return entity;
        //    });

        //    LogId logId = TheProcess!.StartTask(applicationId, batchName, processName, taskName);

        //    try
        //    {
        //        String message = $"{batchName} - {processName} - {taskName}";
        //        throw new Exception(message);
        //    }
        //    catch (Exception exception)
        //    {
        //        TheProcess!.EndTask(logId, logSeverity, exception);
        //    }

        //    IEventLog eventLog = TheProcess!.Get(logId);

        //    Assert.That(eventLog.Id.TheLogId, Is.EqualTo(logId.TheLogId));
        //    Assert.That(eventLog.ApplicationId.TheAppId, Is.EqualTo(applicationId.TheAppId));
        //    Assert.That(eventLog.BatchName, Is.EqualTo(batchName));
        //    Assert.That(eventLog.ProcessName, Is.EqualTo(processName));
        //    Assert.That(eventLog.TaskName, Is.EqualTo(taskName));
        //    Assert.That(eventLog.LogSeverityId.ToInteger(), Is.EqualTo(logSeverity.Id()));
        //    Assert.That(eventLog.StartedOn, Is.EqualTo(DateTimeService.SystemDateTimeNow));
        //}

        //[TestCase]
        //public void Test_EndTask_2()
        //{
        //    AppId applicationId = CoreInstance.ApplicationId;
        //    String batchName = "UnitTesting";
        //    String processName = LocationUtils.GetClassName();
        //    String taskName = LocationUtils.GetFunctionName();
        //    String message = $"{batchName} - {processName} - {taskName}";
        //    LogSeverity logSeverity = LogSeverity.Warning;

        //    TheRepository!.Save(Arg.Any<IEventLog>()).Returns(args =>
        //    {
        //        IEventLog entity = (IEventLog)args[0];
        //        entity.Id = new LogId(1);

        //        return entity;
        //    });

        //    TheRepository!.Get(Arg.Any<LogId>()).Returns(args =>
        //    {
        //        IEventLog entity = CoreInstance.IoC.Get<IEventLog>();
        //        entity.Id = new LogId(1);
        //        entity.ApplicationId = new AppId(1);
        //        entity.BatchName = batchName;
        //        entity.ProcessName = processName;
        //        entity.TaskName = taskName;
        //        entity.LogSeverityId = new EntityId(logSeverity.Id());
        //        entity.Information = message;
        //        entity.StartedOn = DateTimeService.SystemDateTimeNow;

        //        return entity;
        //    });

        //    LogId logId = TheProcess!.StartTask(applicationId, batchName, processName, taskName);

        //    TheProcess!.EndTask(logId, logSeverity, message);

        //    IEventLog eventLog = TheProcess!.Get(logId);

        //    Assert.That(eventLog.Id.TheLogId, Is.EqualTo(logId.TheLogId));
        //    Assert.That(eventLog.ApplicationId.TheAppId, Is.EqualTo(applicationId.TheAppId));
        //    Assert.That(eventLog.BatchName, Is.EqualTo(batchName));
        //    Assert.That(eventLog.ProcessName, Is.EqualTo(processName));
        //    Assert.That(eventLog.TaskName, Is.EqualTo(taskName));
        //    Assert.That(eventLog.LogSeverityId.ToInteger(), Is.EqualTo(logSeverity.Id()));
        //    Assert.That(eventLog.Information, Is.EqualTo(message));
        //    Assert.That(eventLog.StartedOn, Is.EqualTo(DateTimeService.SystemDateTimeNow));
        //}

        //[TestCase]
        //public void Test_Update_EndTask()
        //{
        //    AppId applicationId = CoreInstance.ApplicationId;
        //    String batchName = "UnitTesting";
        //    String processName = LocationUtils.GetClassName();
        //    String taskName = LocationUtils.GetFunctionName();
        //    String message = $"{batchName} - {processName} - {taskName}";
        //    LogSeverity logSeverity = LogSeverity.Warning;

        //    TheRepository!.Save(Arg.Any<IEventLog>()).Returns(args =>
        //    {
        //        IEventLog entity = (IEventLog)args[0];
        //        entity.Id = new LogId(1);

        //        return entity;
        //    });

        //    TheRepository!.Get(Arg.Any<LogId>()).Returns(args =>
        //    {
        //        IEventLog entity = CoreInstance.IoC.Get<IEventLog>();
        //        entity.Id = new LogId(1);
        //        entity.ApplicationId = new AppId(1);
        //        entity.BatchName = batchName;
        //        entity.ProcessName = processName;
        //        entity.TaskName = taskName;
        //        entity.LogSeverityId = new EntityId(logSeverity.Id());
        //        entity.Information = message + Environment.NewLine + message;
        //        entity.StartedOn = DateTimeService.SystemDateTimeNow;

        //        return entity;
        //    });

        //    LogId logId = TheProcess!.StartTask(applicationId, batchName, processName, taskName);

        //    TheProcess!.UpdateLogEntry(logId, message);

        //    TheProcess!.EndTask(logId, logSeverity, message);

        //    IEventLog eventLog = TheProcess!.Get(logId);

        //    Assert.That(eventLog.Id.TheLogId, Is.EqualTo(logId.TheLogId));
        //    Assert.That(eventLog.ApplicationId.TheAppId, Is.EqualTo(applicationId.TheAppId));
        //    Assert.That(eventLog.BatchName, Is.EqualTo(batchName));
        //    Assert.That(eventLog.ProcessName, Is.EqualTo(processName));
        //    Assert.That(eventLog.TaskName, Is.EqualTo(taskName));
        //    Assert.That(eventLog.LogSeverityId.ToInteger(), Is.EqualTo(logSeverity.Id()));
        //    Assert.That(eventLog.Information, Is.EqualTo(message + Environment.NewLine + message));
        //    Assert.That(eventLog.StartedOn, Is.EqualTo(DateTimeService.SystemDateTimeNow));
        //}

        //[TestCase]
        //public void Test_CreateLogEntry_Handling_ExceptionObjects()
        //{
        //    AppId applicationId = CoreInstance.ApplicationId;
        //    String batchName = "UnitTesting";
        //    String processName = LocationUtils.GetClassName();
        //    String taskName = LocationUtils.GetFunctionName();
        //    LogSeverity logSeverity = LogSeverity.Warning;

        //    TheRepository!.Save(Arg.Any<IEventLog>()).Returns(args =>
        //    {
        //        IEventLog entity = (IEventLog)args[0];
        //        entity.Id = new LogId(1);

        //        return entity;
        //    });

        //    TheRepository!.Get(Arg.Any<LogId>()).Returns(args =>
        //    {
        //        IEventLog entity = CoreInstance.IoC.Get<IEventLog>();
        //        entity.Id = new LogId(1);
        //        entity.ParentId = new LogId(1);
        //        entity.BatchName = String.Empty;
        //        entity.ProcessName = String.Empty;
        //        entity.TaskName = String.Empty;
        //        entity.LogSeverityId = new EntityId(logSeverity.Id());
        //        entity.StartedOn = DateTimeService.SystemDateTimeNow;

        //        return entity;
        //    });

        //    LogId logId = TheProcess!.StartTask(applicationId, batchName, processName, taskName);
        //    LogId updateLogId;

        //    try
        //    {
        //        String message = $"{batchName} - {processName} - {taskName}";
        //        throw new Exception(message);
        //    }
        //    catch (Exception exception)
        //    {
        //        updateLogId = TheProcess!.CreateLogEntry(logId, applicationId, logSeverity, exception);
        //    }

        //    IEventLog eventLog = TheProcess!.Get(new EntityId(updateLogId.ToInteger()));

        //    Assert.That(eventLog.Id.TheLogId, Is.EqualTo(updateLogId.TheLogId));
        //    Assert.That(eventLog.ParentId.TheLogId, Is.EqualTo(logId.TheLogId));
        //    Assert.That(eventLog.BatchName, Is.EqualTo(String.Empty));
        //    Assert.That(eventLog.ProcessName, Is.EqualTo(String.Empty));
        //    Assert.That(eventLog.TaskName, Is.EqualTo(String.Empty));
        //    Assert.That(eventLog.LogSeverityId.ToInteger(), Is.EqualTo(logSeverity.Id()));
        //    Assert.That(eventLog.StartedOn, Is.EqualTo(DateTimeService.SystemDateTimeNow));
        //}

        //[TestCase]
        //public void Test_CreateLogEntry_Parent_Child()
        //{
        //    AppId applicationId = CoreInstance.ApplicationId;
        //    String batchName = "UnitTesting";
        //    String processName = LocationUtils.GetClassName();
        //    String taskName = LocationUtils.GetFunctionName();
        //    String message = $"{batchName} - {processName} - {taskName}";
        //    LogSeverity logSeverity = LogSeverity.Trace;

        //    TheRepository!.Save(Arg.Any<IEventLog>()).Returns(args =>
        //    {
        //        IEventLog entity = (IEventLog)args[0];
        //        entity.Id = new LogId(1);

        //        return entity;
        //    });

        //    TheRepository!.Get(Arg.Any<LogId>()).Returns(args =>
        //    {
        //        IEventLog entity = CoreInstance.IoC.Get<IEventLog>();
        //        entity.Id = new LogId(1);
        //        entity.ParentId = new LogId(1);
        //        entity.BatchName = batchName;
        //        entity.ProcessName = processName;
        //        entity.TaskName = taskName;
        //        entity.LogSeverityId = new EntityId(logSeverity.Id());
        //        entity.Information = message;
        //        entity.StartedOn = DateTimeService.SystemDateTimeNow;

        //        return entity;
        //    });

        //    LogId parentLogId = TheProcess!.StartTask(CoreInstance.ApplicationId, batchName, processName, taskName);

        //    LogId logId = TheProcess!.CreateLogEntry(parentLogId, applicationId, batchName, processName, taskName, logSeverity, String.Empty);

        //    TheProcess!.EndTask(logId, logSeverity, message);

        //    IEventLog eventLog = TheProcess!.Get(logId);

        //    Assert.That(eventLog.Id.TheLogId, Is.EqualTo(logId.TheLogId));
        //    Assert.That(eventLog.ParentId.TheLogId, Is.EqualTo(parentLogId.TheLogId));
        //    Assert.That(eventLog.BatchName, Is.EqualTo(batchName));
        //    Assert.That(eventLog.ProcessName, Is.EqualTo(processName));
        //    Assert.That(eventLog.TaskName, Is.EqualTo(taskName));
        //    Assert.That(eventLog.LogSeverityId.ToInteger(), Is.EqualTo(logSeverity.Id()));
        //    Assert.That(eventLog.Information, Is.EqualTo(message));
        //    Assert.That(eventLog.StartedOn, Is.EqualTo(DateTimeService.SystemDateTimeNow));
        //}

        //[TestCase]
        //public void Test_Update_1()
        //{
        //    AppId applicationId = CoreInstance.ApplicationId;
        //    String batchName = "UnitTesting";
        //    String processName = LocationUtils.GetClassName();
        //    String taskName = LocationUtils.GetFunctionName();
        //    String message = $"{batchName} - {processName} - {taskName}";
        //    LogSeverity logSeverity = LogSeverity.Information;

        //    TheRepository!.Save(Arg.Any<IEventLog>()).Returns(args =>
        //    {
        //        IEventLog entity = (IEventLog)args[0];
        //        entity.Id = new LogId(1);

        //        return entity;
        //    });

        //    TheRepository!.Get(Arg.Any<LogId>()).Returns(args =>
        //    {
        //        IEventLog entity = CoreInstance.IoC.Get<IEventLog>();
        //        entity.Id = new LogId(1);
        //        entity.ApplicationId = new AppId(1);
        //        entity.BatchName = batchName;
        //        entity.ProcessName = processName;
        //        entity.TaskName = taskName;
        //        entity.LogSeverityId = new EntityId(logSeverity.Id());
        //        entity.Information = message + Environment.NewLine + message;
        //        entity.StartedOn = DateTimeService.SystemDateTimeNow;

        //        return entity;
        //    });

        //    LogId logId = TheProcess!.StartTask(applicationId, batchName, processName, taskName);

        //    TheProcess!.UpdateLogEntry(logId, message);
        //    TheProcess!.UpdateLogEntry(logId, message);

        //    IEventLog eventLog = TheProcess!.Get(logId);

        //    Assert.That(eventLog.Id.TheLogId, Is.EqualTo(logId.TheLogId));
        //    Assert.That(eventLog.ApplicationId.TheAppId, Is.EqualTo(applicationId.TheAppId));
        //    Assert.That(eventLog.BatchName, Is.EqualTo(batchName));
        //    Assert.That(eventLog.ProcessName, Is.EqualTo(processName));
        //    Assert.That(eventLog.TaskName, Is.EqualTo(taskName));
        //    Assert.That(eventLog.LogSeverityId.ToInteger(), Is.EqualTo(logSeverity.Id()));
        //    Assert.That(eventLog.Information, Is.EqualTo(message + Environment.NewLine + message));
        //    Assert.That(eventLog.StartedOn, Is.EqualTo(DateTimeService.SystemDateTimeNow));
        //}
    }
}
