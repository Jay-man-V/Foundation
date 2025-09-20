//-----------------------------------------------------------------------
// <copyright file="ScheduledTaskBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

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
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService"></param>
        /// <param name="loggingService"></param>
        /// <param name="calendarProcess"></param>
        protected ScheduledTaskBase
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            ICalendarProcess calendarProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService, calendarProcess);

            LoggingService = loggingService;
            CalendarProcess = calendarProcess;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the logging service.
        /// </summary>
        /// <value>
        /// The logging service.
        /// </value>
        protected ILoggingService LoggingService { get; }

        /// <summary>
        /// Gets the calendar process.
        /// </summary>
        /// <value>
        /// The calendar process.
        /// </value>
        protected ICalendarProcess CalendarProcess { get; }

        /// <inheritdoc cref="IScheduledTask.Process(LogId, String)"/>
        public abstract void Process(LogId logId, String taskParameters);
    }
}
