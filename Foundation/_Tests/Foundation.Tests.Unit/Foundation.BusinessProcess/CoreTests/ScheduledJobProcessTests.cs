//-----------------------------------------------------------------------
// <copyright file="ScheduledJobProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.BusinessProcess.Components;
using Foundation.BusinessProcess.Core;
using Foundation.BusinessProcess.Core.EnumProcesses;
using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;
using Foundation.Tests.Unit.Mocks;
using Foundation.Tests.Unit.Support;

using NSubstitute;

using System.Globalization;
using System.ServiceProcess;
using NSubstitute.ClearExtensions;
using FDC = Foundation.Resources.Constants.DataColumns;
using FEnums = Foundation.Interfaces;
using FModels = Foundation.Models;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests
{
    /// <summary>
    /// Summary description for ScheduledJobProcessTests
    /// </summary>
    [TestFixture]
    public class ScheduledJobProcessTests : CommonBusinessProcessTests<IScheduledJob, IScheduledJobProcess, IScheduledJobRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 18;
        protected override String ExpectedScreenTitle => "Scheduled Jobs";
        protected override String ExpectedStatusBarText => "Number of Scheduled Jobs:";

        protected override String ExpectedComboBoxDisplayMember => FDC.ScheduledJob.Name;

        private IServiceControlWrapper? ServiceControlWrapper { get; set; }

        public override void TestCleanup()
        {
            ServiceControlWrapper?.Dispose();
            ServiceControlWrapper = null;

            base.TestCleanup();
        }

        protected override IScheduledJobRepository CreateRepository()
        {
            IScheduledJobRepository retVal = Substitute.For<IScheduledJobRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IScheduledJobProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            SchedulerSupport.Core = CoreInstance;
            SchedulerSupport.RunTimeEnvironmentSettings = RunTimeEnvironmentSettings;
            SchedulerSupport.DateTimeService = DateTimeService;
            SchedulerSupport.LoggingService = LoggingService;

            IScheduleIntervalProcess scheduleIntervalProcess = Substitute.For<IScheduleIntervalProcess>();
            ICalendarProcess calendarProcess = Substitute.For<ICalendarProcess>();
            ServiceControlWrapper = Substitute.For<IServiceControlWrapper>();

            IScheduledJobProcess process = new ScheduledJobProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, scheduleIntervalProcess, calendarProcess, ServiceControlWrapper);

            process.AlternateCreateScheduledTaskCalled -= SchedulerSupport.OnAlternateCreateScheduledTaskCalled;
            process.AlternateCreateScheduledTaskCalled += SchedulerSupport.OnAlternateCreateScheduledTaskCalled;

            return process;
        }

        protected override IScheduledJob CreateBlankEntity(Int32 entityId)
        {
            IScheduledJob retVal = new FModels.Core.ScheduledJob();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IScheduledJob CreateEntity(IScheduledJobProcess process, Int32 entityId)
        {
            IScheduledJob retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = TheProcess!.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = TheProcess!.DefaultValidFromDateTime;
            retVal.ValidTo = TheProcess!.DefaultValidToDateTime;

            retVal.Name = Guid.NewGuid().ToString();
            retVal.RunImmediately = false;
            retVal.StartTime = new TimeSpan(09, 00, 00);
            retVal.EndTime = new TimeSpan(17, 00, 00);
            retVal.Interval = 15;
            retVal.ScheduleIntervalId = new EntityId(2);
            retVal.IsEnabled = true;
            retVal.LastRunDateTime = DateTimeService.SystemUtcDateTimeNow;
            retVal.NextRunDateTime = DateTimeService.SystemUtcDateTimeNow;
            retVal.TaskImplementationType = Guid.NewGuid().ToString();
            retVal.TaskParameters = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IScheduledJob entity)
        {
            Assert.That(entity.Name, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IScheduledJob entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IScheduledJob entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IScheduledJob entity1, IScheduledJob entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Name, Is.EqualTo(entity1.Name));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Job Name,Schedule Type,Last Run Date Time,Next Run Date Time,Run Immediately,Start Time,End Time,Interval,Enabled,Implementation Type,Parameters" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,bc260751-9932-4f67-98a5-93e4a57cdfce,2,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,False,09:00:00,17:00:00,15,True,71b44957-4a5e-4778-b60c-7213e6578616,109081d5-be07-4723-be0a-714248f94c5e" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,0272c324-07d8-43fb-aa11-9742f5a2a76a,2,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,False,09:00:00,17:00:00,15,True,81ed040e-ac1d-4ca8-aedb-9d4548a251f8,9c2fb18e-bc56-4770-9dba-6fa68e80fbbd" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,d63fc4c7-9f64-4f51-98ad-60d4f1f8227d,2,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,False,09:00:00,17:00:00,15,True,a4c644f3-af87-4550-8642-61f377d9163e,cfeb0968-19cf-4f1c-afbf-36ae37866155" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,15aae8ee-306e-4f1c-a926-0a3a8040a5d6,2,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,False,09:00:00,17:00:00,15,True,baaac5c9-accf-4ecf-9dc2-774c44e32564,f5b5cd98-a866-4d3a-97ca-2485b091bcb1" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,5124696a-fb9b-43a9-93ba-3eb9e1416126,2,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,False,09:00:00,17:00:00,15,True,52c3b253-f237-4cc3-8b5b-5ba5b0e35754,a4c132dc-5ed8-4a46-b4ba-ade940c3ccff" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,84966321-c9c6-4a35-bb90-01fd800de6da,2,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,False,09:00:00,17:00:00,15,True,43bc68f6-d8f3-427d-a36b-c2985bd8dafb,b8fa2d4d-fb77-4618-b725-b47ab84a9d33" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,e42e6dfe-4221-48cf-b0b8-ad8952f5f772,2,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,False,09:00:00,17:00:00,15,True,8dc1de93-531a-4200-bf24-b80c85aff0ad,5dd309b1-cbad-472f-a7c0-e13a2ec8292d" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,9d9d86e2-274f-4c11-8013-209b4b8cc9c5,2,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,False,09:00:00,17:00:00,15,True,3e7e6a3c-dc67-493e-851c-b6ba0c76ad93,9b2437c9-3ec9-43cd-b07d-b48979a59121" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,9f2508db-9b22-4684-8121-88cda9cfd8be,2,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,False,09:00:00,17:00:00,15,True,21e8e5f0-7fbf-4935-a9ee-793e0051be4e,cdeee2e3-c7e8-4071-9212-3ca3a34aad1a" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,7f92fd25-b565-4267-ad71-1a4d182aad79,2,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,False,09:00:00,17:00:00,15,True,e5d28246-2258-4f1f-937a-2ba146823855,f6ef6918-f687-4793-93f9-9d002b266441" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IScheduledJob entity)
        {
            entity.Name = "Updated";
        }

        [TestCase]
        public void Test_InitialiseJobs()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            Int32 interval = 1;

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
            List<IScheduledJob> scheduleTasks = [scheduledJob];

            TheRepository!.GetAllActive().Returns(scheduleTasks);

            ScheduledJobProcess scheduledJobProcess = (ScheduledJobProcess)TheProcess!;
            Dictionary<String, ServerProcessTimer> scheduledTimers = scheduledJobProcess.ScheduledTimers;

            Assert.That(scheduledTimers.Count, Is.Zero);

            TheProcess!.InitialiseJobs(new LogId(0));

            Assert.That(scheduledTimers.Count, Is.Not.Zero);
        }

        [TestCase]
        public void Test_RunJob()
        {
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            Int32 interval = 1;

            LoggingService.StartTask(Arg.Any<AppId>(), Arg.Any<String>(), Arg.Any<String>(), Arg.Any<String>()).Returns(new LogId(1));

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, scheduleInterval, interval);
            scheduledJob.ScheduledTask = TheProcess!.CreateScheduledTask(scheduledJob);
            MockScheduledTask? mockScheduledTask = (MockScheduledTask?)scheduledJob.ScheduledTask;

            Boolean processJobCalled = false;
            mockScheduledTask!.ProcessJobCalled += (_, _) =>
            {
                processJobCalled = true;
            };

            LogId logId = TheProcess!.RunJob(new LogId(0), scheduledJob);

            Assert.That(processJobCalled, Is.EqualTo(true));
            Assert.That(logId, Is.EqualTo(new LogId(1)));
        }

        [TestCase]
        public void Test_StartJobs_NoInitialise()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            Int32 interval = 1;

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
            List<IScheduledJob> scheduleTasks = [scheduledJob];

            TheRepository!.GetAllActive().Returns(scheduleTasks);

            ScheduledJobProcess scheduledJobProcess = (ScheduledJobProcess)TheProcess!;
            TheProcess!.StartJobs(new LogId(0));

            ServerProcessTimer serverProcessTimer = scheduledJobProcess.ScheduledTimers[scheduledJob.Name];
            MockScheduledTask? mockScheduledTask = (MockScheduledTask?)serverProcessTimer.ScheduledJob.ScheduledTask;

            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            //Assert.That(serverProcessTimer.Enabled, Is.EqualTo(false));

            Boolean processJobCalled = false;
            mockScheduledTask!.ProcessJobCalled += (_, _) =>
            {
                processJobCalled = true;
            };

            DateTime testStartTime = DateTime.Now;

            while (!processJobCalled &&
                   testStartTime.AddMinutes(1) > DateTime.Now)
            {
                Thread.Sleep(new TimeSpan(0, 0, 2));
            }

            Assert.That(processJobCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_StartJobs_NoJobs()
        {
            LogId logId = new LogId(0);
            List<IScheduledJob> scheduleTasks = [];

            TheRepository!.GetAllActive().Returns(scheduleTasks);

            ScheduledJobProcess scheduledJobProcess = (ScheduledJobProcess)TheProcess!;
            TheProcess!.StartJobs(logId);

            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(0));

            String batchName = "Batch Scheduler";
            String processName = nameof(ScheduledJobProcess);
            LoggingService.Received(1).CreateLogEntry(logId, CoreInstance.ApplicationId, batchName, processName, Arg.Any<String>(), LogSeverity.Information, "No jobs found to start");

        }

        [TestCase]
        public void Test_StartJobs_CheckTaskRuns()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            Int32 interval = 1;

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
            List<IScheduledJob> scheduleTasks = [scheduledJob];

            TheRepository!.GetAllActive().Returns(scheduleTasks);

            ScheduledJobProcess scheduledJobProcess = (ScheduledJobProcess)TheProcess!;
            TheProcess!.InitialiseJobs(new LogId(0));

            ServerProcessTimer serverProcessTimer = scheduledJobProcess.ScheduledTimers[scheduledJob.Name];
            MockScheduledTask? mockScheduledTask = (MockScheduledTask?)serverProcessTimer.ScheduledJob.ScheduledTask;

            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(false));

            Boolean processJobCalled = false;
            mockScheduledTask!.ProcessJobCalled += (_, _) =>
            {
                processJobCalled = true;
            };

            TheProcess!.StartJobs(new LogId(0));

            DateTime testStartTime = DateTime.Now;

            while (!processJobCalled &&
                   testStartTime.AddMinutes(1) > DateTime.Now)
            {
                Thread.Sleep(new TimeSpan(0, 0, 2));
            }

            Assert.That(processJobCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_StartJobs_CheckTaskRuns_Error()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            Int32 interval = 1;

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJobWithError(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
            List<IScheduledJob> scheduleTasks = [scheduledJob];

            TheRepository!.GetAllActive().Returns(scheduleTasks);

            ScheduledJobProcess scheduledJobProcess = (ScheduledJobProcess)TheProcess!;
            TheProcess!.InitialiseJobs(new LogId(0));

            ServerProcessTimer serverProcessTimer = scheduledJobProcess.ScheduledTimers[scheduledJob.Name];
            MockScheduledTaskWithError? mockScheduledTask = (MockScheduledTaskWithError?)serverProcessTimer.ScheduledJob.ScheduledTask;

            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(false));

            Boolean processJobCalled = false;
            mockScheduledTask!.ProcessJobCalled += (_, _) =>
            {
                processJobCalled = true;
            };

            TheProcess!.StartJobs(new LogId(0));

            DateTime testStartTime = DateTime.Now;

            while (!processJobCalled &&
                   testStartTime.AddMinutes(1) > DateTime.Now)
            {
                Thread.Sleep(new TimeSpan(0, 0, 2));
            }

            Assert.That(processJobCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_StartJobs_OnElapsed_Error()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            Int32 interval = 1;

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJobWithError(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
            List<IScheduledJob> scheduleTasks = [scheduledJob];

            TheRepository!.GetAllActive().Returns(scheduleTasks);

            ScheduledJobProcess scheduledJobProcess = (ScheduledJobProcess)TheProcess!;
            TheProcess!.InitialiseJobs(new LogId(0));

            ServerProcessTimer serverProcessTimer = scheduledJobProcess.ScheduledTimers[scheduledJob.Name];
            MockScheduledTaskWithError? mockScheduledTask = (MockScheduledTaskWithError?)serverProcessTimer.ScheduledJob.ScheduledTask;

            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(false));

            Boolean exceptionRaisedDuringTest = false;

            mockScheduledTask!.ProcessJobCalled += (_, _) =>
            {
                exceptionRaisedDuringTest = true;
                String errorMessage = "Exception raised during checking CanExecute";
                throw new Exception(errorMessage);
            };

            TheProcess!.StartJobs(new LogId(0));

            DateTime testStartTime = DateTime.Now;

            while (!exceptionRaisedDuringTest &&
                   testStartTime.AddMinutes(1) > DateTime.Now)
            {
                Thread.Sleep(new TimeSpan(0, 0, 2));
            }

            Assert.That(exceptionRaisedDuringTest, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_StartJobs_Enabled()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            Int32 interval = 1;

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
            List<IScheduledJob> scheduleTasks = [scheduledJob];

            TheRepository!.GetAllActive().Returns(scheduleTasks);

            ScheduledJobProcess scheduledJobProcess = (ScheduledJobProcess)TheProcess!;
            TheProcess!.InitialiseJobs(new LogId(0));

            ServerProcessTimer serverProcessTimer = scheduledJobProcess.ScheduledTimers[scheduledJob.Name];
            MockScheduledTask? mockScheduledTask = (MockScheduledTask?)serverProcessTimer.ScheduledJob.ScheduledTask;

            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(false));

            Boolean processJobCalled = false;
            mockScheduledTask!.ProcessJobCalled += (_, _) =>
            {
                processJobCalled = true;
            };

            TheProcess!.StartJobs(new LogId(0));

            DateTime testStartTime = DateTime.Now;

            while (!processJobCalled &&
                   testStartTime.AddMinutes(1) > DateTime.Now)
            {
                Thread.Sleep(new TimeSpan(0, 0, 2));
            }

            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(true));
            Assert.That(processJobCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_StartJobs_DemoJob()
        {
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            Int32 interval = 1;

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledDemoJob(CoreInstance, false, currentDate, scheduleInterval, interval);
            List<IScheduledJob> scheduleTasks = [scheduledJob];

            TheRepository!.GetAllActive().Returns(scheduleTasks);

            ScheduledJobProcess scheduledJobProcess = (ScheduledJobProcess)TheProcess!;
            TheProcess!.InitialiseJobs(new LogId(0));

            ServerProcessTimer serverProcessTimer = scheduledJobProcess.ScheduledTimers[scheduledJob.Name];

            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(false));

            TheProcess!.StartJobs(new LogId(0));

            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_StartJobs_Disabled()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            Int32 interval = 1;

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
            scheduledJob.IsEnabled = false;
            List<IScheduledJob> scheduleTasks = [scheduledJob];

            TheRepository!.GetAllActive().Returns(scheduleTasks);

            ScheduledJobProcess scheduledJobProcess = (ScheduledJobProcess)TheProcess!;
            TheProcess!.InitialiseJobs(new LogId(0));

            ServerProcessTimer serverProcessTimer = scheduledJobProcess.ScheduledTimers[scheduledJob.Name];
            MockScheduledTask? mockScheduledTask = (MockScheduledTask?)serverProcessTimer.ScheduledJob.ScheduledTask;

            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(false));

            Boolean processJobCalled = false;
            mockScheduledTask!.ProcessJobCalled += (_, _) =>
            {
                processJobCalled = true;
            };

            TheProcess!.StartJobs(new LogId(0));

            DateTime testStartTime = DateTime.Now;

            while (!processJobCalled &&
                   testStartTime.AddMinutes(1) > DateTime.Now)
            {
                Thread.Sleep(new TimeSpan(0, 0, 2));
            }

            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(true));
            Assert.That(processJobCalled, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_StartStopStartJobs()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            Int32 interval = 1;

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
            List<IScheduledJob> scheduleTasks = [scheduledJob];

            TheRepository!.GetAllActive().Returns(scheduleTasks);

            ScheduledJobProcess scheduledJobProcess = (ScheduledJobProcess)TheProcess!;
            TheProcess!.InitialiseJobs(new LogId(0));

            ServerProcessTimer serverProcessTimer = scheduledJobProcess.ScheduledTimers[scheduledJob.Name];
            MockScheduledTask? mockScheduledTask = (MockScheduledTask?)serverProcessTimer.ScheduledJob.ScheduledTask;

            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(false));

            Boolean processJobCalled1 = false;
            mockScheduledTask!.ProcessJobCalled += (_, _) =>
            {
                processJobCalled1 = true;
            };

            TheProcess!.StartJobs(new LogId(0));
            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(true));

            DateTime testStartTime = DateTime.Now;

            while (!processJobCalled1 &&
                   testStartTime.AddMinutes(1) > DateTime.Now)
            {
                Thread.Sleep(new TimeSpan(0, 0, 2));
            }

            Assert.That(processJobCalled1, Is.EqualTo(true));

            TheProcess!.StopJobs(new LogId(0));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(false));

            Boolean processJobCalled2 = false;
            mockScheduledTask.ProcessJobCalled += (_, _) =>
            {
                processJobCalled2 = true;
            };

            TheProcess!.StartJobs(new LogId(0));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(true));

            testStartTime = DateTime.Now;

            while (!processJobCalled2 &&
                   testStartTime.AddMinutes(1) > DateTime.Now)
            {
                Thread.Sleep(new TimeSpan(0, 0, 2));
            }

            Assert.That(processJobCalled2, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_StopJobs()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            Int32 interval = 1;

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
            List<IScheduledJob> scheduleTasks = [scheduledJob];

            TheRepository!.GetAllActive().Returns(scheduleTasks);

            ScheduledJobProcess scheduledJobProcess = (ScheduledJobProcess)TheProcess!;
            TheProcess!.InitialiseJobs(new LogId(0));

            ServerProcessTimer serverProcessTimer = scheduledJobProcess.ScheduledTimers[scheduledJob.Name];
            MockScheduledTask? mockScheduledTask = (MockScheduledTask?)serverProcessTimer.ScheduledJob.ScheduledTask;

            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(false));

            Boolean processJobCalled = false;
            mockScheduledTask!.ProcessJobCalled += (_, _) =>
            {
                processJobCalled = true;

                Int32 loopCount = 0;
                while (loopCount < 10)
                {
                    Thread.Sleep(new TimeSpan(0, 0, 0, 150));
                    //Debug.WriteLine($"{DateTime.Now:dd-MMM-yyyy HH:mm:ss}");
                    loopCount++;
                }
            };

            Thread.Sleep(new TimeSpan(0, 0, 0, 250));

            TheProcess!.StartJobs(new LogId(0));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(true));

            DateTime testStartTime = DateTime.Now;

            while (!processJobCalled &&
                   testStartTime.AddMinutes(1) > DateTime.Now)
            {
                Thread.Sleep(new TimeSpan(0, 0, 0, 150));
            }

            TheProcess!.StopJobs(new LogId(0));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(false));

            Assert.That(processJobCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_ResumeTasks()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            Int32 interval = 1;

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
            List<IScheduledJob> scheduleTasks = [scheduledJob];

            TheRepository!.GetAllActive().Returns(scheduleTasks);

            ScheduledJobProcess scheduledJobProcess = (ScheduledJobProcess)TheProcess!;
            TheProcess!.InitialiseJobs(new LogId(0));

            ServerProcessTimer serverProcessTimer = scheduledJobProcess.ScheduledTimers[scheduledJob.Name];
            MockScheduledTask? mockScheduledTask = (MockScheduledTask?)serverProcessTimer.ScheduledJob.ScheduledTask;

            Boolean processJobCalled1 = false;
            mockScheduledTask!.ProcessJobCalled += (_, _) =>
            {
                processJobCalled1 = true;
            };

            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(false));

            TheProcess!.StartJobs(new LogId(0));
            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(true));

            DateTime testStartTime = DateTime.Now;

            while (!processJobCalled1 &&
                   testStartTime.AddMinutes(1) > DateTime.Now)
            {
                Thread.Sleep(new TimeSpan(0, 0, 2));
            }

            TheProcess!.StopJobs(new LogId(0));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(false));

            Boolean processJobCalled2 = false;
            mockScheduledTask.ProcessJobCalled += (_, _) =>
            {
                processJobCalled2 = true;
            };

            TheProcess!.ResumeJobs(new LogId(0));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(true));

            testStartTime = DateTime.Now;

            while (!processJobCalled2 &&
                   testStartTime.AddMinutes(1) > DateTime.Now)
            {
                Thread.Sleep(new TimeSpan(0, 0, 2));
            }

            Assert.That(processJobCalled1, Is.EqualTo(true));
            Assert.That(processJobCalled2, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_GetServiceStatus_IScheduledJob_NotInitialised()
        {
            String errorMessage = $"{nameof(ScheduledJobProcess)} has not been initialised";
            InvalidOperationException actualException = Assert.Throws<InvalidOperationException>(() =>
            {
                TimeSpan startTime = new TimeSpan(9, 0, 0);
                TimeSpan endTime = new TimeSpan(17, 0, 0);
                DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
                ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
                Int32 interval = 1;

                IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
                List<IScheduledJob> scheduleTasks = [scheduledJob];

                TheRepository!.GetAllActive().Returns(scheduleTasks);

                TheProcess!.GetServiceStatus(scheduledJob);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_GetServiceStatus_IScheduledJob_UnknownTask()
        {
            String jobName = nameof(SchedulerSupport.CreateScheduledJobWithError);
            String paramName = "scheduledJob";
            String errorMessage = $"Scheduled Job with name '{jobName}' does not exist or was not loaded (Parameter '{paramName}')";
            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                TimeSpan startTime = new TimeSpan(9, 0, 0);
                TimeSpan endTime = new TimeSpan(17, 0, 0);
                DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
                ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
                Int32 interval = 1;

                IScheduledJob scheduledJob1 = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
                IScheduledJob scheduledJob2 = SchedulerSupport.CreateScheduledJobWithError(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
                List<IScheduledJob> scheduleTasks = [scheduledJob1];

                TheRepository!.GetAllActive().Returns(scheduleTasks);

                TheProcess!.InitialiseJobs(new LogId(0));

                TheProcess!.GetServiceStatus(scheduledJob2);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        [TestCase]
        public void Test_GetServiceStatus_IScheduledJob_NoTasks()
        {
            String errorMessage = $"{nameof(ScheduledJobProcess)} has not been initialised";
            InvalidOperationException actualException = Assert.Throws<InvalidOperationException>(() =>
            {
                TimeSpan startTime = new TimeSpan(9, 0, 0);
                TimeSpan endTime = new TimeSpan(17, 0, 0);
                DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
                ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
                Int32 interval = 1;

                IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
                List<IScheduledJob> scheduleTasks = [];

                TheRepository!.GetAllActive().Returns(scheduleTasks);

                TheProcess!.InitialiseJobs(new LogId(0));

                TheProcess!.GetServiceStatus(scheduledJob);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_GetServiceStatus_IScheduledJob_Null()
        {
            String paramName = "scheduledJob";
            String errorMessage = String.Format(StandardErrorMessages.ArgumentNullExpectedErrorMessage, paramName);
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                List<IScheduledJob> scheduleTasks = [];

                TheRepository!.GetAllActive().Returns(scheduleTasks);

                TheProcess!.InitialiseJobs(new LogId(0));

                TheProcess!.GetServiceStatus(null);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        [TestCase(ServiceStatus.Stopped, false, false)]
        [TestCase(ServiceStatus.Running, false, true)]
        [TestCase(ServiceStatus.Running, true, true)]
        [TestCase(ServiceStatus.Running, true, false)]
        public void Test_GetServiceStatus_IScheduledJob_KnownTask(ServiceStatus expected, Boolean timerEnabled, Boolean jobRunning)
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            Int32 interval = 1;

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
            scheduledJob.IsRunning = jobRunning;
            List<IScheduledJob> scheduleTasks = [scheduledJob];

            TheRepository!.GetAllActive().Returns(scheduleTasks);

            TheProcess!.InitialiseJobs(new LogId(0));
            ScheduledJobProcess scheduledJobProcess = (ScheduledJobProcess)TheProcess!;
            Dictionary<String, ServerProcessTimer> scheduledTimers = scheduledJobProcess.ScheduledTimers;
            scheduledTimers[scheduledJob.Name].Enabled = timerEnabled;

            ServiceStatus actual = TheProcess!.GetServiceStatus(scheduledJob);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_GetServiceStatus_WindowsService_Null()
        {
            String serverName = ".";
            String? serviceName = null;

            String paramName = "serviceName";
            String errorMessage = String.Format(StandardErrorMessages.ArgumentNullExpectedErrorMessage, paramName);
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                TheProcess!.GetServiceStatus(serverName, serviceName);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        [TestCase]
        public void Test_GetServiceStatus_WindowsService_UnknownTask()
        {
            String serverName = ".";
            String serviceName = Guid.NewGuid().ToString();

            String errorMessage = $"Service '{serviceName}' was not found on computer '{serverName}'.";

            ServiceControlWrapper!
                .When(scw => scw.SetupController(Arg.Any<String>(), Arg.Any<String>()))
                .Do(_ => throw new InvalidOperationException(errorMessage));

            InvalidOperationException actualException = Assert.Throws<InvalidOperationException>(() =>
            {
                TheProcess!.GetServiceStatus(serverName, serviceName);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_GetServiceStatus_WindowsService_KnownTask_Started()
        {
            String serverName = ".";
            String serviceName = "EventLog";
            ServiceStatus expected = ServiceStatus.Running;

            ServiceControlWrapper!.SetupController(Arg.Any<String>(), Arg.Any<String>()).Returns(ServiceControlWrapper);
            ServiceControlWrapper!.Status.Returns(ServiceControllerStatus.Running);

            ServiceStatus actual = TheProcess!.GetServiceStatus(serverName, serviceName);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(ServiceStatus.Stopped, ServiceControllerStatus.Stopped)]
        [TestCase(ServiceStatus.StartPending, ServiceControllerStatus.StartPending)]
        [TestCase(ServiceStatus.StopPending, ServiceControllerStatus.StopPending)]
        [TestCase(ServiceStatus.Running, ServiceControllerStatus.Running)]
        [TestCase(ServiceStatus.ContinuePending, ServiceControllerStatus.ContinuePending)]
        [TestCase(ServiceStatus.PauseEnding, ServiceControllerStatus.PausePending)]
        [TestCase(ServiceStatus.Paused, ServiceControllerStatus.Paused)]
        public void Test_GetServiceStatus_WindowsService_KnownTask_Stopped(ServiceStatus expected, ServiceControllerStatus serviceControllerStatus)
        {
            String serverName = ".";
            String serviceName = "Service";

            ServiceControlWrapper!.SetupController(Arg.Any<String>(), Arg.Any<String>()).Returns(ServiceControlWrapper);
            ServiceControlWrapper!.Status.Returns(serviceControllerStatus);

            ServiceStatus actual = TheProcess!.GetServiceStatus(serverName, serviceName);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_GetJobLastRunStatus_IScheduledJob_NotInitialised()
        {
            String errorMessage = $"{nameof(ScheduledJobProcess)} has not been initialised";
            InvalidOperationException actualException = Assert.Throws<InvalidOperationException>(() =>
            {
                TimeSpan startTime = new TimeSpan(9, 0, 0);
                TimeSpan endTime = new TimeSpan(17, 0, 0);
                DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
                ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
                Int32 interval = 1;

                IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
                List<IScheduledJob> scheduleTasks = [scheduledJob];

                TheRepository!.GetAllActive().Returns(scheduleTasks);

                TheProcess!.GetJobLastRunStatus(scheduledJob);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_GetJobLastRunStatus_IScheduledJob_UnknownTask()
        {
            String jobName = nameof(SchedulerSupport.CreateScheduledJobWithError);
            String paramName = "scheduledJob";
            String errorMessage = $"Scheduled Job with name '{jobName}' does not exist or was not loaded (Parameter '{paramName}')";
            ArgumentException actualException = Assert.Throws<ArgumentException>(() =>
            {
                TimeSpan startTime = new TimeSpan(9, 0, 0);
                TimeSpan endTime = new TimeSpan(17, 0, 0);
                DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
                ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
                Int32 interval = 1;

                IScheduledJob scheduledJob1 = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
                IScheduledJob scheduledJob2 = SchedulerSupport.CreateScheduledJobWithError(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
                List<IScheduledJob> scheduleTasks = [scheduledJob1];

                TheRepository!.GetAllActive().Returns(scheduleTasks);

                TheProcess!.InitialiseJobs(new LogId(0));

                TheProcess!.GetJobLastRunStatus(scheduledJob2);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        [TestCase]
        public void Test_GetJobLastRunStatus_IScheduledJob_NoTasks()
        {
            String errorMessage = "No scheduled jobs available";
            InvalidOperationException actualException = Assert.Throws<InvalidOperationException>(() =>
            {
                TimeSpan startTime = new TimeSpan(9, 0, 0);
                TimeSpan endTime = new TimeSpan(17, 0, 0);
                DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
                ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
                Int32 interval = 1;

                IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
                List<IScheduledJob> scheduleTasks = [];

                TheRepository!.GetAllActive().Returns(scheduleTasks);

                TheProcess!.InitialiseJobs(new LogId(0));

                TheProcess!.GetJobLastRunStatus(scheduledJob);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_GetJobLastRunStatus_IScheduledJob_Null()
        {
            String paramName = "scheduledJob";
            String errorMessage = String.Format(StandardErrorMessages.ArgumentNullExpectedErrorMessage, paramName);
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                List<IScheduledJob> scheduleTasks = [];

                TheRepository!.GetAllActive().Returns(scheduleTasks);

                TheProcess!.InitialiseJobs(new LogId(0));

                TheProcess!.GetJobLastRunStatus(null);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        [TestCase]
        public void Test_GetJobLastRunStatus_IScheduledJob_KnownTask()
        {
            FEnums.TaskStatus expected = FEnums.TaskStatus.Success;
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            Int32 interval = 1;

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
            List<IScheduledJob> scheduleTasks =
            [
                scheduledJob
            ];

            TheRepository!.GetAllActive().Returns(scheduleTasks);
            LoggingService.GetLatest(isFinished: true, Arg.Any<EntityId>()).Returns
            (
                new FModels.Log.EventLog
                {
                    TaskStatusId = new EntityId(FEnums.TaskStatus.Success.Id())
                }
            );

            TheProcess!.InitialiseJobs(new LogId(0));

            FEnums.TaskStatus actual = TheProcess!.GetJobLastRunStatus(scheduledJob);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(ScheduleInterval.NotSet, 100, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Milliseconds, 0, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Milliseconds, 100, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Seconds, 30, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Minutes, 30, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Hours, 3, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Days, 3, "2022-11-30 09:00:00.000")]
        [TestCase(ScheduleInterval.Weeks, 3, "2022-12-18 09:00:00.000")]
        [TestCase(ScheduleInterval.Months, 3, "2023-02-27 09:00:00.000")]
        [TestCase(ScheduleInterval.Years, 3, "2025-11-27 09:00:00.000")]
        [TestCase(ScheduleInterval.Other, 100, "2022-11-28 09:00:00.000")]
        public void Test_ScheduleNextRun(ScheduleInterval scheduleInterval, Int32 interval, String expectedNextRunDate)
        {
            DateTime expectedNextRunDateTime = DateTime.ParseExact(expectedNextRunDate, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);

            LogId parentLogId = new LogId(0);

            DateTimeService.ClearSubstitute();
            DateTimeService.SystemDateTimeNowWithoutMilliseconds.Returns(new DateTime(2022, 11, 27, 12, 11, 54));
            DateTimeService.SystemUtcDateTimeNow.Returns(new DateTime(2022, 11, 27, 12, 11, 54, 300));

            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            DateTime nextDate = currentDate.AddDays(1);

            ICalendarProcess calendarProcess = Substitute.For<ICalendarProcess>();
            IScheduleIntervalProcess scheduleIntervalProcess = Substitute.For<IScheduleIntervalProcess>();

            calendarProcess.CheckIsWorkingDayOrGetNextWorkingDay(Arg.Any<String>(), currentDate + startTime).Returns(nextDate + startTime);
            calendarProcess.CheckIsWorkingDayOrGetNextWorkingDay(Arg.Any<String>(), currentDate + endTime).Returns(nextDate + endTime);

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, true, currentDate, startTime, endTime, scheduleInterval, interval);
            DateTime checkDate = DateTimeService.SystemDateTimeNowWithoutMilliseconds.Add(scheduledJob.ScheduleInterval, scheduledJob.Interval, scheduledJob.StartTime).Date;
            DateTime returnDate = DateTimeService.SystemDateTimeNowWithoutMilliseconds.Add(scheduledJob.ScheduleInterval, scheduledJob.Interval, scheduledJob.StartTime).Date;
            calendarProcess.CheckIsWorkingDayOrGetNextWorkingDay(Arg.Any<String>(), checkDate).Returns(returnDate);

            IScheduledJobProcess scheduledJobProcess = new ScheduledJobProcess(CoreInstance, RunTimeEnvironmentSettings, DateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, scheduleIntervalProcess, calendarProcess, ServiceControlWrapper!);

            SchedulerSupport.Core = CoreInstance;
            SchedulerSupport.RunTimeEnvironmentSettings = RunTimeEnvironmentSettings;
            SchedulerSupport.DateTimeService = DateTimeService;
            SchedulerSupport.LoggingService = LoggingService;
            scheduledJobProcess.AlternateCreateScheduledTaskCalled -= SchedulerSupport.OnAlternateCreateScheduledTaskCalled;
            scheduledJobProcess.AlternateCreateScheduledTaskCalled += SchedulerSupport.OnAlternateCreateScheduledTaskCalled;

            scheduledJob.ScheduledTask = scheduledJobProcess.CreateScheduledTask(scheduledJob);

            scheduledJobProcess.RunJob(parentLogId, scheduledJob);

            DateTime actualNextRun = scheduledJob.NextRunDateTime;

            Assert.That(actualNextRun, Is.EqualTo(expectedNextRunDateTime));
        }

        [TestCase(ScheduleInterval.NotSet, 100, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Milliseconds, 0, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Milliseconds, 100, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Seconds, 30, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Minutes, 30, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Hours, 3, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Days, 3, "2022-11-30 09:00:00.000")]
        [TestCase(ScheduleInterval.Weeks, 3, "2022-12-18 09:00:00.000")]
        [TestCase(ScheduleInterval.Months, 3, "2023-02-27 09:00:00.000")]
        [TestCase(ScheduleInterval.Years, 3, "2025-11-27 09:00:00.000")]
        [TestCase(ScheduleInterval.Other, 100, "2022-11-28 09:00:00.000")]
        public void Test_RunBeforeStartTime(ScheduleInterval scheduleInterval, Int32 interval, String expectedNextRunDate)
        {
            DateTime expectedNextRunDateTime = DateTime.ParseExact(expectedNextRunDate, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);

            LogId parentLogId = new LogId(0);

            DateTimeService.ClearSubstitute();
            DateTimeService.SystemDateTimeNowWithoutMilliseconds.Returns(new DateTime(2022, 11, 27, 04, 11, 54));
            DateTimeService.SystemUtcDateTimeNow.Returns(new DateTime(2022, 11, 27, 12, 04, 54, 300));

            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            DateTime nextDate = currentDate.AddDays(1);

            ICalendarProcess calendarProcess = Substitute.For<ICalendarProcess>();
            IScheduleIntervalProcess scheduleIntervalProcess = Substitute.For<IScheduleIntervalProcess>();

            calendarProcess.CheckIsWorkingDayOrGetNextWorkingDay(Arg.Any<String>(), currentDate + startTime).Returns(nextDate + startTime);
            calendarProcess.CheckIsWorkingDayOrGetNextWorkingDay(Arg.Any<String>(), currentDate + endTime).Returns(nextDate + endTime);

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, true, currentDate, startTime, endTime, scheduleInterval, interval);
            DateTime checkDate = DateTimeService.SystemDateTimeNowWithoutMilliseconds.Add(scheduledJob.ScheduleInterval, scheduledJob.Interval, scheduledJob.StartTime).Date;
            DateTime returnDate = DateTimeService.SystemDateTimeNowWithoutMilliseconds.Add(scheduledJob.ScheduleInterval, scheduledJob.Interval, scheduledJob.StartTime).Date;
            calendarProcess.CheckIsWorkingDayOrGetNextWorkingDay(Arg.Any<String>(), checkDate).Returns(returnDate);

            IScheduledJobProcess scheduledJobProcess = new ScheduledJobProcess(CoreInstance, RunTimeEnvironmentSettings, DateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, scheduleIntervalProcess, calendarProcess, ServiceControlWrapper!);

            SchedulerSupport.Core = CoreInstance;
            SchedulerSupport.RunTimeEnvironmentSettings = RunTimeEnvironmentSettings;
            SchedulerSupport.DateTimeService = DateTimeService;
            SchedulerSupport.LoggingService = LoggingService;
            scheduledJobProcess.AlternateCreateScheduledTaskCalled -= SchedulerSupport.OnAlternateCreateScheduledTaskCalled;
            scheduledJobProcess.AlternateCreateScheduledTaskCalled += SchedulerSupport.OnAlternateCreateScheduledTaskCalled;

            scheduledJob.ScheduledTask = scheduledJobProcess.CreateScheduledTask(scheduledJob);

            scheduledJobProcess.RunJob(parentLogId, scheduledJob);

            DateTime actualNextRun = scheduledJob.NextRunDateTime;

            Assert.That(actualNextRun, Is.EqualTo(expectedNextRunDateTime));
        }

        [TestCase(ScheduleInterval.NotSet, 100, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Milliseconds, 0, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Milliseconds, 100, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Seconds, 30, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Minutes, 30, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Hours, 3, "2022-11-28 09:00:00.000")]
        [TestCase(ScheduleInterval.Days, 3, "2022-11-30 09:00:00.000")]
        [TestCase(ScheduleInterval.Weeks, 3, "2022-12-18 09:00:00.000")]
        [TestCase(ScheduleInterval.Months, 3, "2023-02-27 09:00:00.000")]
        [TestCase(ScheduleInterval.Years, 3, "2025-11-27 09:00:00.000")]
        [TestCase(ScheduleInterval.Other, 100, "2022-11-28 09:00:00.000")]
        public void Test_RunAfterEndTime(ScheduleInterval scheduleInterval, Int32 interval, String expectedNextRunDate)
        {
            DateTime expectedNextRunDateTime = DateTime.ParseExact(expectedNextRunDate, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);

            LogId parentLogId = new LogId(0);

            DateTimeService.ClearSubstitute();
            DateTimeService.SystemDateTimeNowWithoutMilliseconds.Returns(new DateTime(2022, 11, 27, 23, 11, 54));
            DateTimeService.SystemUtcDateTimeNow.Returns(new DateTime(2022, 11, 27, 12, 23, 54, 300));

            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;
            DateTime nextDate = currentDate.AddDays(1);

            ICalendarProcess calendarProcess = Substitute.For<ICalendarProcess>();
            IScheduleIntervalProcess scheduleIntervalProcess = Substitute.For<IScheduleIntervalProcess>();

            calendarProcess.CheckIsWorkingDayOrGetNextWorkingDay(Arg.Any<String>(), currentDate + startTime).Returns(nextDate + startTime);
            calendarProcess.CheckIsWorkingDayOrGetNextWorkingDay(Arg.Any<String>(), currentDate + endTime).Returns(nextDate + endTime);

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, true, currentDate, startTime, endTime, scheduleInterval, interval);
            DateTime checkDate = DateTimeService.SystemDateTimeNowWithoutMilliseconds.Add(scheduledJob.ScheduleInterval, scheduledJob.Interval, scheduledJob.StartTime).Date;
            DateTime returnDate = DateTimeService.SystemDateTimeNowWithoutMilliseconds.Add(scheduledJob.ScheduleInterval, scheduledJob.Interval, scheduledJob.StartTime).Date;
            calendarProcess.CheckIsWorkingDayOrGetNextWorkingDay(Arg.Any<String>(), checkDate).Returns(returnDate);

            IScheduledJobProcess scheduledJobProcess = new ScheduledJobProcess(CoreInstance, RunTimeEnvironmentSettings, DateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, scheduleIntervalProcess, calendarProcess, ServiceControlWrapper!);

            SchedulerSupport.Core = CoreInstance;
            SchedulerSupport.RunTimeEnvironmentSettings = RunTimeEnvironmentSettings;
            SchedulerSupport.DateTimeService = DateTimeService;
            SchedulerSupport.LoggingService = LoggingService;
            scheduledJobProcess.AlternateCreateScheduledTaskCalled -= SchedulerSupport.OnAlternateCreateScheduledTaskCalled;
            scheduledJobProcess.AlternateCreateScheduledTaskCalled += SchedulerSupport.OnAlternateCreateScheduledTaskCalled;

            scheduledJob.ScheduledTask = scheduledJobProcess.CreateScheduledTask(scheduledJob);

            scheduledJobProcess.RunJob(parentLogId, scheduledJob);

            DateTime actualNextRun = scheduledJob.NextRunDateTime;

            Assert.That(actualNextRun, Is.EqualTo(expectedNextRunDateTime));
        }

        [TestCase(ScheduleInterval.Seconds, 60)]
        public void Test_ScheduleNextRun_WithError(ScheduleInterval scheduleInterval, Int32 interval)
        {
            DateTimeService.ClearSubstitute();
            DateTimeService.SystemDateTimeNowWithoutMilliseconds.Returns(new DateTime(2022, 11, 27, 12, 11, 54));
            DateTimeService.SystemUtcDateTimeNow.Returns(new DateTime(2022, 11, 27, 12, 11, 54, 300));

            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;

            ICalendarProcess calendarProcess = Substitute.For<ICalendarProcess>();
            IScheduleIntervalProcess scheduleIntervalProcess = Substitute.For<IScheduleIntervalProcess>();

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJobWithError(CoreInstance, true, currentDate, startTime, endTime, scheduleInterval, interval);
            DateTime checkDate = DateTimeService.SystemDateTimeNowWithoutMilliseconds.Add(scheduledJob.ScheduleInterval, scheduledJob.Interval, scheduledJob.StartTime).Date;
            DateTime returnDate = DateTimeService.SystemDateTimeNowWithoutMilliseconds.Add(scheduledJob.ScheduleInterval, scheduledJob.Interval, scheduledJob.StartTime).Date;
            calendarProcess.CheckIsWorkingDayOrGetNextWorkingDay(Arg.Any<String>(), checkDate).Returns(returnDate);

            IScheduledJobProcess scheduledJobProcess = new ScheduledJobProcess(CoreInstance, RunTimeEnvironmentSettings, DateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, scheduleIntervalProcess, calendarProcess, ServiceControlWrapper!);

            SchedulerSupport.Core = CoreInstance;
            SchedulerSupport.RunTimeEnvironmentSettings = RunTimeEnvironmentSettings;
            SchedulerSupport.DateTimeService = DateTimeService;
            SchedulerSupport.LoggingService = LoggingService;
            scheduledJobProcess.AlternateCreateScheduledTaskCalled -= SchedulerSupport.OnAlternateCreateScheduledTaskCalled;
            scheduledJobProcess.AlternateCreateScheduledTaskCalled += SchedulerSupport.OnAlternateCreateScheduledTaskCalled;

            scheduledJob.ScheduledTask = scheduledJobProcess.CreateScheduledTask(scheduledJob);

            TheRepository!.GetAllActive().Returns([scheduledJob]);
            scheduledJobProcess.InitialiseJobs(Arg.Any<LogId>());
            scheduledJobProcess.StartJobs(Arg.Any<LogId>());

            Thread.Sleep(new TimeSpan(0, 0, 15));

            DateTime actualNextRun = scheduledJob.NextRunDateTime;

            Assert.That(actualNextRun, Is.EqualTo(DateTimeService.SystemDateTimeNowWithoutMilliseconds.AddSeconds(interval)));
        }
    }
}
