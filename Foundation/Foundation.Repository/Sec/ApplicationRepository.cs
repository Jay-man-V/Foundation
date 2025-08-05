//-----------------------------------------------------------------------
// <copyright file="ApplicationRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Common.DataColumns;

namespace Foundation.Repository
{
    /// <summary>
    /// Defines the Application Data Access class
    /// </summary>
    /// <see cref="IApplication" />
    [DependencyInjectionTransient]
    public class ApplicationRepository : FoundationModelRepository<IApplication>, IApplicationRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="databaseProvider"></param>
        /// <param name="dateTimeService"></param>
        public ApplicationRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ISecurityDatabaseProvider databaseProvider,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                systemConfigurationService,
                databaseProvider,
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, databaseProvider, dateTimeService);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.Application.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.Application;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumCreateRole"/>
        protected override ApplicationRole RequiredMinimumCreateRole => ApplicationRole.SystemDataAdministrator;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumEditRole"/>
        protected override ApplicationRole RequiredMinimumEditRole => ApplicationRole.SystemDataAdministrator;

        /// <inheritdoc cref="IApplicationRepository.Delete(AppId)"/>
        public void Delete(AppId applicationId)
        {
            LoggingHelpers.TraceCallEnter(applicationId);

            base.Delete(applicationId);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IApplicationRepository.Get(AppId)"/>
        public IApplication Get(AppId applicationId)
        {
            LoggingHelpers.TraceCallEnter(applicationId);

            IApplication retVal = base.Get(applicationId);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
