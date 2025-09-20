//-----------------------------------------------------------------------
// <copyright file="ServerProcessTimerTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;
using NSubstitute.ClearExtensions;

using Foundation.BusinessProcess.Components;
using Foundation.BusinessProcess.Core;
using Foundation.Interfaces;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.ComponentsTests
{
    /// <summary>
    /// Summary description for ServerProcessTimerTests
    /// </summary>
    [TestFixture]
    public class ServerProcessTimerTests : UnitTestBase
    {
        private ICalendarProcess? CalendarProcess { get; set; }
        private ILoggingService LoggingService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            CalendarProcess = Substitute.For<ICalendarProcess>();

            DateTimeService.ClearSubstitute();
            DateTimeService.SystemDateTimeNowWithoutMilliseconds.Returns(new DateTime(2022, 11, 27, 23, 11, 54));
            DateTimeService.SystemDateTimeNow.Returns(new DateTime(2022, 11, 27, 23, 11, 54, 300));

            LoggingService = Substitute.For<ILoggingService>();

            SchedulerSupport.Core = CoreInstance;
            SchedulerSupport.RunTimeEnvironmentSettings = RunTimeEnvironmentSettings;
            SchedulerSupport.DateTimeService = DateTimeService;
            SchedulerSupport.LoggingService = LoggingService;
        }

        [TestCase]
        public void Test_CreateObject()
        {

            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemDateTimeNow.Date;

            CalendarProcess!.CheckIsWorkingDayOrGetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, currentDate + startTime).Returns(currentDate + startTime);
            CalendarProcess!.CheckIsWorkingDayOrGetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, currentDate + endTime).Returns(currentDate + endTime);

            IScheduledJobRepository repository = Substitute.For<IScheduledJobRepository>();
            IStatusRepository statusRepository = Substitute.For<IStatusRepository>();
            IUserProfileRepository userProfileRepository = Substitute.For<IUserProfileRepository>();
            IScheduleIntervalProcess scheduleIntervalProcess = Substitute.For<IScheduleIntervalProcess>();

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(CoreInstance, false, currentDate, ScheduleInterval.Seconds, 30);
            IScheduledJobProcess process = new ScheduledJobProcess(CoreInstance, RunTimeEnvironmentSettings, DateTimeService, repository, statusRepository, userProfileRepository, LoggingService, scheduleIntervalProcess, CalendarProcess);

            process.AlternateCreateScheduledTaskCalled -= SchedulerSupport.OnAlternateCreateScheduledTaskCalled;
            process.AlternateCreateScheduledTaskCalled += SchedulerSupport.OnAlternateCreateScheduledTaskCalled;
            scheduledJob.ScheduledTask = process.CreateScheduledTask(scheduledJob);

            ServerProcessTimer serverProcessTimer = new ServerProcessTimer(scheduledJob);

            Assert.That(serverProcessTimer.Name, Is.EqualTo(scheduledJob.Name));
            Assert.That(serverProcessTimer.ScheduledJob, Is.EqualTo(scheduledJob));
        }
    }
}
