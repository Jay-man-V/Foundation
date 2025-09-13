//-----------------------------------------------------------------------
// <copyright file="OfficeRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Core
{
    /// <summary>
    /// Defines the Office Data Access class
    /// </summary>
    /// <see cref="IOffice" />
    [DependencyInjectionTransient]
    public class OfficeRepository : FoundationModelRepository<IOffice>, IOfficeRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="OfficeRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="databaseProvider"></param>
        /// <param name="dateTimeService"></param>
        public OfficeRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ICoreDatabaseProvider databaseProvider,
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
        protected override String EntityName => FDC.Office.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.Office;
    }
}
