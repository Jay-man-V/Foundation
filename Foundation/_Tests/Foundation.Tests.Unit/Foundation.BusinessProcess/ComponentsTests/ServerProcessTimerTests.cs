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

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.ComponentsTests
{
    /// <summary>
    /// Summary description for ServerProcessTimerTests
    /// </summary>
    [TestFixture]
    public class ServerProcessTimerTests : UnitTestBase
    {
        private ICore? Core { get; set; }
        private ICalendarProcess? CalendarProcess { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            Core = Substitute.For<ICore>();
            CalendarProcess = Substitute.For<ICalendarProcess>();

            DateTimeService.ClearSubstitute();
            DateTimeService.SystemDateTimeNowWithoutMilliseconds.Returns(new DateTime(2022, 11, 27, 23, 11, 54));
            DateTimeService.SystemUtcDateTimeNow.Returns(new DateTime(2022, 11, 27, 23, 11, 54, 300));

            SchedulerSupport.Core = Core;
            SchedulerSupport.RunTimeEnvironmentSettings = RunTimeEnvironmentSettings;
            SchedulerSupport.DateTimeService = DateTimeService;
            SchedulerSupport.LoggingService = LoggingService;
        }

        [TestCase]
        public void Test_CreateObject()
        {

            TimeSpan startTime = new TimeSpan(9, 0, 0);
            TimeSpan endTime = new TimeSpan(17, 0, 0);
            DateTime currentDate = DateTimeService.SystemUtcDateTimeNow.Date;

            CalendarProcess!.CheckIsWorkingDayOrGetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, currentDate + startTime).Returns(currentDate + startTime);
            CalendarProcess!.CheckIsWorkingDayOrGetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, currentDate + endTime).Returns(currentDate + endTime);

            IScheduledJobRepository repository = Substitute.For<IScheduledJobRepository>();
            IStatusRepository statusRepository = Substitute.For<IStatusRepository>();
            IUserProfileRepository userProfileRepository = Substitute.For<IUserProfileRepository>();
            IReportGenerator reportGenerator = Substitute.For<IReportGenerator>();
            IScheduleIntervalProcess scheduleIntervalProcess = Substitute.For<IScheduleIntervalProcess>();
            IServiceControlWrapper serviceControlWrapper = Substitute.For<IServiceControlWrapper>();

            IScheduledJob scheduledJob = SchedulerSupport.CreateScheduledJob(SchedulerSupport.Core!, false, currentDate, ScheduleInterval.Seconds, 30);
            IScheduledJobProcess process = new ScheduledJobProcess(SchedulerSupport.Core!, RunTimeEnvironmentSettings, DateTimeService, LoggingService, repository, statusRepository, userProfileRepository, reportGenerator, scheduleIntervalProcess, CalendarProcess, serviceControlWrapper);

            process.AlternateCreateScheduledTaskCalled -= SchedulerSupport.OnAlternateCreateScheduledTaskCalled;
            process.AlternateCreateScheduledTaskCalled += SchedulerSupport.OnAlternateCreateScheduledTaskCalled;
            scheduledJob.ScheduledTask = process.CreateScheduledTask(scheduledJob);

            ServerProcessTimer serverProcessTimer = new ServerProcessTimer(scheduledJob);

            Assert.That(serverProcessTimer.Name, Is.EqualTo(scheduledJob.Name));
            Assert.That(serverProcessTimer.ScheduledJob, Is.EqualTo(scheduledJob));
        }
    }
}
