//-----------------------------------------------------------------------
// <copyright file="ApprovalStatusRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Repository
{
    /// <summary>
    /// Defines the Enum Model Repository class
    /// </summary>
    /// <see cref="IEnumModel" />
    public abstract class FoundationEnumModelRepository<TEnumModel> : FoundationModelRepository<TEnumModel>, IFoundationEnumModelRepository<TEnumModel>
        where TEnumModel : IEnumModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="FoundationEnumModelRepository{TEnumModel}"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="dataProvider">The data provider.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        protected FoundationEnumModelRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            IDataProvider dataProvider,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                systemConfigurationService,
                dataProvider,
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, dataProvider, dateTimeService);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
