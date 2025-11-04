//-----------------------------------------------------------------------
// <copyright file="EventLogApplicationRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Repository.DataProvider;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Log
{
    /// <summary>
    /// Defines the EventLogApplication Data Access class
    /// </summary>
    /// <see cref="IEventLogApplication" />
    [DependencyInjectionTransient]
    public class EventLogApplicationRepository : FoundationModelRepository<IEventLogApplication>, IEventLogApplicationRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EventLogApplicationRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="foundationDataAccess">The foundation data access.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        public EventLogApplicationRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            IFoundationDataAccess foundationDataAccess,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                systemConfigurationService,
                foundationDataAccess,
                new LogDataProvider(),
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, foundationDataAccess, dateTimeService);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.EventLogApplication.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.EventLogApplication;
    }
}
