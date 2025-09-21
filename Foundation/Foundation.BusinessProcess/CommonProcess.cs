//-----------------------------------------------------------------------
// <copyright file="CommonProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// Defines common business process behaviours and actions
    /// </summary>
    public abstract class CommonProcess : ICommonProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="CommonProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="loggingService">The logging service</param>
        protected CommonProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService
        )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService);

            Core = core;
            RunTimeEnvironmentSettings = runTimeEnvironmentSettings;
            DateTimeService = dateTimeService;
            LoggingService = loggingService;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// The Foundation Core service
        /// </summary>
        protected internal ICore Core { get; }

        /// <summary>
        /// Gets the run time environment settings service
        /// </summary>
        /// <value>
        /// The run time environment settings.
        /// </value>
        protected internal IRunTimeEnvironmentSettings RunTimeEnvironmentSettings { get; }

        /// <summary>
        /// Gets the Date/Time Service
        /// </summary>
        /// <value>
        /// The date/time service.
        /// </value>
        protected internal IDateTimeService DateTimeService { get; }

        /// <summary>
        /// Gets the logging service.
        /// </summary>
        /// <value>
        /// The logging service.
        /// </value>
        protected ILoggingService LoggingService { get; }
    }
}
