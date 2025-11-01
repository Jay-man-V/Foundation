//-----------------------------------------------------------------------
// <copyright file="EventLogApplicationProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess.Log
{
    /// <summary>
    /// The Event Log Application Business Process
    /// </summary>
    [DependencyInjectionTransient]
    public class EventLogApplicationProcess : CommonBusinessProcess<IEventLogApplication, IEventLogApplicationRepository>, IEventLogApplicationProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EventLogApplicationProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="loggingService">The logging service</param>
        /// <param name="repository">The data access</param>
        /// <param name="statusRepository">The status data access</param>
        /// <param name="userProfileRepository">The user profile data access</param>
        /// <param name="applicationProcess">The application process</param>
        /// <param name="reportGenerator">The report generator service</param>
        public EventLogApplicationProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            IEventLogApplicationRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository,
            IReportGenerator reportGenerator,
            IApplicationProcess applicationProcess
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                loggingService,
                repository,
                statusRepository,
                userProfileRepository,
                reportGenerator
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService, repository, statusRepository, userProfileRepository, reportGenerator, applicationProcess);

            ApplicationProcess = applicationProcess;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the application process.
        /// </summary>
        /// <value>
        /// The application process.
        /// </value>
        private IApplicationProcess ApplicationProcess { get; }

        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Event Log Applications";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Event Log Applications:";

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember" />
        public override String ComboBoxDisplayMember => FDC.EventLogApplication.ShortName;

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.EventLogApplication.ApplicationId, "Application", typeof(String))
            {
                DataSource = ApplicationProcess.GetAll(excludeDeleted: false),
                ValueMember = ApplicationProcess.ComboBoxValueMember,
                DisplayMember = ApplicationProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition); gridColumnDefinition.TextAlignment = TextAlignment.Centre;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.EventLogApplication.ShortName, "Short Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.EventLogApplication.ProcessName, "Process Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
