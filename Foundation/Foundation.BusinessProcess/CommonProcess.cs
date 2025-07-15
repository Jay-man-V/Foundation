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
        /// <param name="dateTimeService">The date time service.</param>
        protected CommonProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService
        )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService);

            Core = core;
            RunTimeEnvironmentSettings = runTimeEnvironmentSettings;
            DateTimeService = dateTimeService;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// The Foundation Core service
        /// </summary>
        protected ICore Core { get; }

        /// <summary>
        /// Gets the run time environment settings service
        /// </summary>
        /// <value>
        /// The run time environment settings.
        /// </value>
        protected IRunTimeEnvironmentSettings RunTimeEnvironmentSettings { get; }

        /// <summary>
        /// The Date Time Service
        /// </summary>
        protected IDateTimeService DateTimeService { get; }
    }
}
