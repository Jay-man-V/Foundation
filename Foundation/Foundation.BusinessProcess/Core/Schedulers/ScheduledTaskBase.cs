//-----------------------------------------------------------------------
// <copyright file="ScheduledTaskBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.BusinessProcess.Core.Schedulers
{
    /// <summary>
    /// The base class for scheduled tasks
    /// </summary>
    [DependencyInjectionTransient]
    public abstract class ScheduledTaskBase : CommonProcess, IScheduledTask
    {
        /// <summary>
        /// Initialises the ScheduledTaskBase class.
        /// Base class for all scheduled tasks
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="loggingService">The logging service</param>
        protected ScheduledTaskBase
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

            JobStartTime = DateTimeService.SystemUtcDateTimeNow;

            ProcessJobCalled = null;

            LoggingHelpers.TraceCallReturn();
        }

        protected abstract String BatchName { get; }
        protected virtual String ProcessName => this.GetType().Name;
        protected abstract String TaskName { get; }

        /// <inheritdoc cref="IScheduledTask.JobStartTime"/>
        public DateTime JobStartTime { get; }

        /// <inheritdoc cref="IScheduledTask.ProcessJobCalled"/>
        public EventHandler? ProcessJobCalled { get; set; }

        /// <inheritdoc cref="IScheduledTask.Process(LogId, String)"/>
        public virtual void Process(LogId logId, String taskParameters)
        {
            EventHandler? handler = ProcessJobCalled;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }

            DateTime currentDateTime = DateTimeService.SystemUtcDateTimeNow;
            String message = $"ProcessJob running at: {currentDateTime.ToString(Formats.DotNet.DateTimeSeconds)}";

            LoggingService.CreateLogEntry(logId, Core.ApplicationId, "batchName", "processName", "taskName", LogSeverity.Information, message);

            Debug.WriteLine(message);
        }
    }
}
