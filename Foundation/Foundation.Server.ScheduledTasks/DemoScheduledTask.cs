//-----------------------------------------------------------------------
// <copyright file="DemoScheduledTask.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.BusinessProcess.Core.Schedulers;
using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.Server.ScheduledTasks
{
    /// <summary>
    /// Demo Scheduled Task
    /// </summary>
    [DependencyInjectionTransient]
    public class DemoScheduledTask : ScheduledTaskBase
    {
        /// <summary>
        /// Demo Scheduled Task
        /// </summary>
        /// <param name="core"></param>
        /// <param name="runTimeEnvironmentSettings"></param>
        /// <param name="dateTimeService">The date/time service.</param>
        /// <param name="loggingService"></param>
        /// <param name="calendarProcess"></param>
        public DemoScheduledTask
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                loggingService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IScheduledTask.Process(LogId, String)"/>
        public override void Process(LogId logId, String taskParameters)
        {
            base.Process(logId, taskParameters);

            DateTime currentDateTime = DateTimeService.SystemUtcDateTimeNow;
            String message = $"{GetType()}::ProcessJob running at: {currentDateTime.ToString(Formats.DotNet.DateTimeSeconds)} with Task Parameters: '{taskParameters}'";
            LoggingHelpers.LogInformationMessage(message);
        }
    }
}
