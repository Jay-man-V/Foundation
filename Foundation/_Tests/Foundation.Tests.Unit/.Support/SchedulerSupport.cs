//-----------------------------------------------------------------------
// <copyright file="SchedulerTestBaseClass.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Server.ScheduledTasks;

using Foundation.Tests.Unit.Mocks;

namespace Foundation.Tests.Unit.Support
{
    /// <summary>
    /// Defines Scheduler Support functions
    /// </summary>
    internal static class SchedulerSupport
    {
        public const String TaskImplementationAssembly = "Foundation.Tests.Unit";
        public static String TaskImplementationType = typeof(MockScheduledTask).FullName!;
        public static String TaskImplementationTypeWithError = typeof(MockScheduledTaskWithError).FullName!;

        public const String DemoTaskImplementationAssembly = "Foundation.Server.ScheduledTasks";
        public static String DemoTaskImplementationType = typeof(DemoScheduledTask).FullName!;

        public static ICore? Core { get; set; }
        public static IRunTimeEnvironmentSettings? RunTimeEnvironmentSettings { get; set; }
        public static IDateTimeService? DateTimeService { get; set; }
        public static ILoggingService? LoggingService { get; set; }

        public static DateTime AdjustForWeekend(DateTime dateTime)
        {
            DateTime retVal = dateTime.Date;

            if (retVal.DayOfWeek == DayOfWeek.Saturday)
            {
                retVal = retVal.AddDays(2);
            }
            else if (retVal.DayOfWeek == DayOfWeek.Sunday)
            {
                retVal = retVal.AddDays(1);
            }

            retVal = retVal.Date + dateTime.TimeOfDay;

            return retVal;
        }

        public static IScheduledJob CreateScheduledDemoJob(ICore core, Boolean runImmediately, DateTime currentDate, ScheduleInterval scheduleInterval, Int32 interval)
        {
            DateTime nextRunDateTime = currentDate + new TimeSpan(9, 0, 0);
            DateTime lastRunDateTime = currentDate + new TimeSpan(17, 0, 0);

            IScheduledJob retVal = core.IoC.Get<IScheduledJob>();

            retVal.Name = LocationUtils.GetFunctionName();
            retVal.NextRunDateTime = AdjustForWeekend(nextRunDateTime);
            retVal.LastRunDateTime = AdjustForWeekend(lastRunDateTime);
            retVal.RunImmediately = runImmediately;
            retVal.StartTime = new TimeSpan(9, 0, 0);
            retVal.EndTime = new TimeSpan(17, 0, 0);
            retVal.IsEnabled = true;
            retVal.TaskImplementationType = $"""<TaskImplementation assembly="{DemoTaskImplementationAssembly}" type="{DemoTaskImplementationType}" />""";
            retVal.TaskParameters = String.Empty;
            retVal.EntityStatus = EntityStatus.Active;
            retVal.ScheduleIntervalId = new EntityId(scheduleInterval.Id());
            retVal.Interval = interval;

            return retVal;
        }

        public static IScheduledJob CreateScheduledJob(ICore core, Boolean runImmediately, DateTime currentDate, ScheduleInterval scheduleInterval, Int32 interval)
        {
            DateTime nextRunDateTime = currentDate + new TimeSpan(9, 0, 0);
            DateTime lastRunDateTime = currentDate + new TimeSpan(17, 0, 0);

            IScheduledJob retVal = core.IoC.Get<IScheduledJob>();

            retVal.Name = LocationUtils.GetFunctionName();
            retVal.NextRunDateTime = AdjustForWeekend(nextRunDateTime);
            retVal.LastRunDateTime = AdjustForWeekend(lastRunDateTime);
            retVal.RunImmediately = runImmediately;
            retVal.StartTime = new TimeSpan(9, 0, 0);
            retVal.EndTime = new TimeSpan(17, 0, 0);
            retVal.IsEnabled = true;
            retVal.TaskImplementationType = $"""<TaskImplementation assembly="{TaskImplementationAssembly}" type="{TaskImplementationType}" />""";
            retVal.TaskParameters = String.Empty;
            retVal.EntityStatus = EntityStatus.Active;
            retVal.ScheduleIntervalId = new EntityId(scheduleInterval.Id());
            retVal.Interval = interval;

            return retVal;
        }

        public static IScheduledJob CreateScheduledJob(ICore core, Boolean runImmediately, DateTime currentDate, TimeSpan startTime, TimeSpan endTime, ScheduleInterval scheduleInterval, Int32 interval)
        {
            DateTime nextRunDateTime = currentDate + startTime;
            DateTime lastRunDateTime = currentDate + endTime;

            IScheduledJob retVal = core.IoC.Get<IScheduledJob>();

            retVal.Name = LocationUtils.GetFunctionName();
            retVal.NextRunDateTime = AdjustForWeekend(nextRunDateTime);
            retVal.LastRunDateTime = AdjustForWeekend(lastRunDateTime);
            retVal.RunImmediately = runImmediately;
            retVal.StartTime = startTime;
            retVal.EndTime = endTime;
            retVal.IsEnabled = true;
            retVal.TaskImplementationType = $"""<TaskImplementation assembly="{TaskImplementationAssembly}" type="{TaskImplementationType}" />""";
            retVal.TaskParameters = String.Empty;
            retVal.EntityStatus = EntityStatus.Active;
            retVal.ScheduleIntervalId = new EntityId(scheduleInterval.Id());
            retVal.Interval = interval;

            return retVal;
        }

        public static IScheduledJob CreateScheduledJobWithError(ICore core, Boolean runImmediately, DateTime currentDate, TimeSpan startTime, TimeSpan endTime, ScheduleInterval scheduleInterval, Int32 interval)
        {
            IScheduledJob retVal = CreateScheduledJob(core, runImmediately, currentDate, startTime, endTime, scheduleInterval, interval);
            retVal.Name = LocationUtils.GetFunctionName();
            retVal.TaskImplementationType = $"""<TaskImplementation assembly="{TaskImplementationAssembly}" type="{TaskImplementationTypeWithError}" />""";

            return retVal;
        }

        public static void OnAlternateCreateScheduledTaskCalled(Object? sender, CreateScheduledTaskEventArgs eventArgs)
        {
            FullyQualifiedTypeName fullyQualifiedTypeName = eventArgs.FullyQualifiedTypeName;

            if (fullyQualifiedTypeName.TypeName == TaskImplementationType)
            {
                ICalendarProcess calendarProcess = Substitute.For<ICalendarProcess>();
                eventArgs.ServiceInstance = new MockScheduledTask(Core!, RunTimeEnvironmentSettings!, DateTimeService!, LoggingService!);
            }
            else if (fullyQualifiedTypeName.TypeName == TaskImplementationTypeWithError)
            {
                ICalendarProcess calendarProcess = Substitute.For<ICalendarProcess>();
                eventArgs.ServiceInstance = new MockScheduledTaskWithError(Core!, RunTimeEnvironmentSettings!, DateTimeService!, LoggingService!);
            }
        }
    }
}
