//-----------------------------------------------------------------------
// <copyright file="ConfigurationScopeRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Repository.DataProvider;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Core.EnumRepositories
{
    /// <summary>
    /// Defines the Configuration Scope Data Access class
    /// </summary>
    /// <see cref="IConfigurationScope" />
    [DependencyInjectionTransient]
    public class ConfigurationScopeRepository : FoundationModelRepository<IConfigurationScope>, IConfigurationScopeRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ConfigurationScopeRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="foundationDataAccess">The foundation data access.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        public ConfigurationScopeRepository
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
                new CoreDataProvider(),
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, foundationDataAccess, dateTimeService);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.HasValidityPeriodColumns"/>
        public override Boolean HasValidityPeriodColumns => false;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.ConfigurationScope.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.ConfigurationScope;
    }
}
