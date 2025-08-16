//-----------------------------------------------------------------------
// <copyright file="IdGeneratorProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// The Id Generator Business Process 
    /// </summary>
    [DependencyInjectionTransient]
    public class IdGeneratorProcess : CommonBusinessProcess<IIdGenerator, IIdGeneratorRepository>, IIdGeneratorProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="IdGeneratorProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="repository">The data access.</param>
        /// <param name="statusRepository">The status data access.</param>
        /// <param name="userProfileRepository">The user profile data access.</param>
        public IdGeneratorProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IIdGeneratorRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                repository,
                statusRepository,
                userProfileRepository
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, repository, statusRepository, userProfileRepository);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Id Generator";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Ids:";

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember" />
        public override String ComboBoxDisplayMember => FDC.IdGenerator.IdName;

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.IdGenerator.ApplicationId, "Application Id", typeof(AppId));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.IdGenerator.ConfigurationScopeId, "Configuration Scope", typeof(EntityId));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.IdGenerator.IdName, "Id Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.IdGenerator.LastId, "Last Id", typeof(Int32));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.IdGenerator.ResetOnNewDate, "Reset On New Date", typeof(Boolean));
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
