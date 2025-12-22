//-----------------------------------------------------------------------
// <copyright file="ScheduledDataStatusRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Log
{
    /// <summary>
    /// Defines the Scheduled Task Repository class
    /// </summary>
    /// <see cref="IScheduledDataStatus" />
    [DependencyInjectionTransient]
    public class ScheduledDataStatusRepository : FoundationModelRepository<IScheduledDataStatus>, IScheduledDataStatusRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ScheduledDataStatusRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="logDataProvider">The log data provider.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        public ScheduledDataStatusRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ILogDataProvider logDataProvider,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                systemConfigurationService,
                logDataProvider,
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, logDataProvider, dateTimeService);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.ScheduledDataStatus.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.ScheduledDataStatus;
    }
}
