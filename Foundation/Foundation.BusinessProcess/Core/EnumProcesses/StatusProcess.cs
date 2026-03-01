//-----------------------------------------------------------------------
// <copyright file="StatusProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.BusinessProcess.Core.EnumProcesses
{
    /// <summary>
    /// The Status Business Process 
    /// </summary>
    [DependencyInjectionTransient]
    public class StatusProcess : EnumModelProcess<IStatus, IStatusRepository>, IStatusProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="StatusProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="loggingService">The logging service</param>
        /// <param name="repository">The data access</param>
        /// <param name="statusRepository">The status data access</param>
        /// <param name="userProfileRepository">The user profile data access</param>
        /// <param name="reportGenerator">The report generator service</param>
        public StatusProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            IStatusRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository,
            IReportGenerator reportGenerator
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                loggingService,
                repository,
                statusRepository,
                userProfileRepository,
                reportGenerator
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService, repository, statusRepository, userProfileRepository, reportGenerator);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Statuses";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Statuses:";
    }
}
