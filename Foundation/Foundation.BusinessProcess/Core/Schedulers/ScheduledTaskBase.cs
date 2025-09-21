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

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IScheduledTask.Process(LogId, String)"/>
        public abstract void Process(LogId logId, String taskParameters);
    }
}
