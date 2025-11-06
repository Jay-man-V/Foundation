//-----------------------------------------------------------------------
// <copyright file="ImportExportControlRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Log
{
    /// <summary>
    /// Defines the ImportExportControl Data Access class
    /// </summary>
    /// <see cref="IImportExportControl" />
    [DependencyInjectionTransient]
    public class ImportExportControlRepository : FoundationModelRepository<IImportExportControl>, IImportExportControlRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ImportExportControlRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="logDataProvider">The log data provider.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        public ImportExportControlRepository
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

        /// <inheritdoc cref="FoundationModelRepository{TModel}.HasValidityPeriodColumns"/>
        public override Boolean HasValidityPeriodColumns => false;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.ImportExportControl.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.ImportExportControl;
    }
}
