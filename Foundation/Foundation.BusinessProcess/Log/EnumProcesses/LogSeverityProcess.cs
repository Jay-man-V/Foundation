//-----------------------------------------------------------------------
// <copyright file="LogSeverityProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Models.Specialised;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess.Log.EnumProcesses
{
    /// <summary>
    /// The Log Severity Business Process
    /// </summary>
    [DependencyInjectionTransient]
    public class LogSeverityProcess : CommonBusinessProcess<ILogSeverity, ILogSeverityRepository>, ILogSeverityProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LogSeverityProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="repository">The data access.</param>
        /// <param name="statusRepository">The status data access.</param>
        /// <param name="userProfileRepository">The user profile data access.</param>
        public LogSeverityProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILogSeverityRepository repository,
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
        public override String ScreenTitle => "Log Severities";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Log Severities:";

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember" />
        public override String ComboBoxDisplayMember => FDC.LogSeverity.Code;

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(75, FDC.LogSeverity.Code, "Code", typeof(String))
            {
                TextAlignment = TextAlignment.Centre,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.LogSeverity.Description, "Description", typeof(String));
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
