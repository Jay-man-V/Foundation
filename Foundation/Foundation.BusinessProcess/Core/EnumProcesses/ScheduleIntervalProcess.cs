//-----------------------------------------------------------------------
// <copyright file="ScheduleIntervalProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.BusinessProcess.Core.EnumProcesses
{
    /// <summary>
    /// The Schedule Interval Business Process 
    /// </summary>
    [DependencyInjectionTransient]
    public class ScheduleIntervalProcess : EnumModelProcess<IScheduleInterval, IScheduleIntervalRepository>, IScheduleIntervalProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ScheduleIntervalProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="loggingService">The logging service</param>
        /// <param name="repository">The data access</param>
        /// <param name="statusRepository">The status data access</param>
        /// <param name="userProfileRepository">The user profile data access</param>
        /// <param name="reportGenerator">The report generator service</param>
        public ScheduleIntervalProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            IScheduleIntervalRepository repository,
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
        public override String ScreenTitle => "Scheduled Intervals";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Schedule Intervals:";
    }
}
