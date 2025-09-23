//-----------------------------------------------------------------------
// <copyright file="ScheduledJobProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Components;
using Foundation.BusinessProcess.Core;
using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Tests.Unit.Mocks;
using Foundation.Tests.Unit.Support;

using FDC = Foundation.Resources.Constants.DataColumns;
using FEnums = Foundation.Interfaces;
using FModels = Foundation.Models.Log;


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

        protected override IScheduledJobRepository CreateRepository()
        {
            IScheduledJobRepository dataAccess = Substitute.For<IScheduledJobRepository>();

            return dataAccess;
        }

        protected override IScheduledJobProcess CreateBusinessProcess()
        {
            IScheduledJobProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IScheduledJobProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            SchedulerSupport.Core = CoreInstance;
            SchedulerSupport.RunTimeEnvironmentSettings = RunTimeEnvironmentSettings;
            SchedulerSupport.DateTimeService = DateTimeService;

            IScheduleIntervalProcess scheduleIntervalProcess = Substitute.For<IScheduleIntervalProcess>();
            ICalendarProcess calendarProcess = Substitute.For<ICalendarProcess>();

            IScheduledJobProcess process = new ScheduledJobProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, scheduleIntervalProcess, calendarProcess);

            process.AlternateCreateScheduledTaskCalled -= SchedulerSupport.OnAlternateCreateScheduledTaskCalled;
            process.AlternateCreateScheduledTaskCalled += SchedulerSupport.OnAlternateCreateScheduledTaskCalled;

            return process;
        }

        protected override IScheduledJob CreateBlankEntity(IScheduledJobProcess process, Int32 entityId)
        {
            IScheduledJob retVal = CoreInstance.IoC.Get<IScheduledJob>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IScheduledJob CreateEntity(IScheduledJobProcess process, Int32 entityId)
        {
            IScheduledJob retVal = CreateBlankEntity(process, entityId);

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
            retVal.LastRunDateTime = DateTimeService.SystemDateTimeNow;
            retVal.NextRunDateTime = DateTimeService.SystemDateTimeNow;
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
            DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
        public void Test_StartJobs_NoInitialise()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
                Thread.Sleep(new TimeSpan(0, 0, 10));
            }

            Assert.That(processJobCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_StartJobs_CheckTaskRuns()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
                Thread.Sleep(new TimeSpan(0, 0, 10));
            }

            Assert.That(processJobCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_StartJobs_CheckTaskRuns_Error()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
                Thread.Sleep(new TimeSpan(0, 0, 10));
            }

            Assert.That(processJobCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_StartJobs_OnElapsed_Error()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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

            while (testStartTime.AddMinutes(1) > DateTime.Now)
            {
                Thread.Sleep(new TimeSpan(0, 0, 10));
            }

            Assert.That(exceptionRaisedDuringTest, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_StartJobs_Enabled()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
                Thread.Sleep(new TimeSpan(0, 0, 10));
            }

            Assert.That(scheduledJobProcess.ScheduledTimers.Count, Is.EqualTo(1));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(true));
            Assert.That(processJobCalled, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_StartJobs_DemoJob()
        {
            DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
            DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
                Thread.Sleep(new TimeSpan(0, 0, 10));
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
            DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
                Thread.Sleep(new TimeSpan(0, 0, 10));
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
                Thread.Sleep(new TimeSpan(0, 0, 10));
            }

            Assert.That(processJobCalled2, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_StopJobs()
        {
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
                while (loopCount < 1000)
                {
                    Thread.Sleep(150);
                    //Debug.WriteLine($"{DateTime.Now:dd-MMM-yyyy HH:mm:ss}");
                    loopCount++;
                }
            };

            Thread.Sleep(250);

            TheProcess!.StartJobs(new LogId(0));
            Assert.That(serverProcessTimer.Enabled, Is.EqualTo(true));

            DateTime testStartTime = DateTime.Now;

            while (!processJobCalled &&
                   testStartTime.AddMinutes(1) > DateTime.Now)
            {
                Thread.Sleep(new TimeSpan(0, 0, 10));
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
            DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
                Thread.Sleep(new TimeSpan(0, 0, 10));
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
                Thread.Sleep(new TimeSpan(0, 0, 10));
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
                DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
                DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
                DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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

        [TestCase]
        public void Test_GetServiceStatus_IScheduledJob_KnownTask()
        {
            ServiceStatus expected = ServiceStatus.Stopped;
            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
            ScheduleInterval scheduleInterval = ScheduleInterval.Seconds;
            Int32 interval = 1;

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, startTime, endTime, scheduleInterval, interval);
            List<IScheduledJob> scheduleTasks = [scheduledJob];

            TheRepository!.GetAllActive().Returns(scheduleTasks);

            TheProcess!.InitialiseJobs(new LogId(0));

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

            ServiceStatus actual = TheProcess!.GetServiceStatus(serverName, serviceName);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_GetServiceStatus_WindowsService_KnownTask_Stopped()
        {
            String serverName = ".";
            String serviceName = "wuauserv"; // Windows Update
            ServiceStatus expected = ServiceStatus.Stopped;

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
                DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
                DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
                DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
            DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;
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
                new FModels.EventLog
                {
                    TaskStatusId = new EntityId(FEnums.TaskStatus.Success.Id())
                }
            );

            TheProcess!.InitialiseJobs(new LogId(0));

            FEnums.TaskStatus actual = TheProcess!.GetJobLastRunStatus(scheduledJob);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
