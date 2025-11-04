//-----------------------------------------------------------------------
// <copyright file="ApplicationTypeRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Repository.DataProvider;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Sec
{
    /// <summary>
    /// Defines the Application Type Data Access class
    /// </summary>
    /// <see cref="IApplicationType" />
    [DependencyInjectionTransient]
    public class ApplicationTypeRepository : FoundationModelRepository<IApplicationType>, IApplicationTypeRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationTypeRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="foundationDataAccess">The foundation data access.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        public ApplicationTypeRepository
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
                new SecurityDataProvider(),
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, foundationDataAccess, dateTimeService);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.ApplicationType.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.ApplicationType;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumCreateRole"/>
        protected override ApplicationRole RequiredMinimumCreateRole => ApplicationRole.SystemDataAdministrator;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumEditRole"/>
        protected override ApplicationRole RequiredMinimumEditRole => ApplicationRole.SystemDataAdministrator;
    }
}
