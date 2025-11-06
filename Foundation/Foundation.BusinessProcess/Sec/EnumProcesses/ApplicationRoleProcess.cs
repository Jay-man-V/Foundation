//-----------------------------------------------------------------------
// <copyright file="ApplicationRoleProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess.Sec.EnumProcesses
{
    /// <summary>
    /// The Application Role Business Process
    /// </summary>
    [DependencyInjectionTransient]
    public class ApplicationRoleProcess : CommonBusinessProcess<IApplicationRole, IApplicationRoleDataAccess>, IApplicationRoleProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationRoleProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="loggingService">The logging service</param>
        /// <param name="repository">The data access</param>
        /// <param name="statusRepository">The status data access</param>
        /// <param name="userProfileRepository">The user profile data access</param>
        /// <param name="reportGenerator">The report generator service</param>
        /// <param name="applicationProcess">The application process</param>
        /// <param name="roleProcess">The role process</param>
        public ApplicationRoleProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            IApplicationRoleDataAccess repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository,
            IReportGenerator reportGenerator,
            IApplicationProcess applicationProcess,
            IRoleProcess roleProcess
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
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService, repository, statusRepository, userProfileRepository, reportGenerator, applicationProcess, roleProcess);

            ApplicationProcess = applicationProcess;
            RoleProcess = roleProcess;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the application process.
        /// </summary>
        /// <value>
        /// The application process.
        /// </value>
        private IApplicationProcess ApplicationProcess { get; }

        /// <summary>
        /// Gets the role process.
        /// </summary>
        /// <value>
        /// The role process.
        /// </value>
        private IRoleProcess RoleProcess { get; }

        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Application Roles";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Application Roles:";

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ApplicationRole.ApplicationId, "Application", typeof(String))
            {
                DataSource = ApplicationProcess.GetAll(excludeDeleted: false),
                ValueMember = ApplicationProcess.ComboBoxValueMember,
                DisplayMember = ApplicationProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ApplicationRole.RoleId, "Role", typeof(String))
            {
                DataSource = RoleProcess.GetAll(excludeDeleted: false),
                ValueMember = RoleProcess.ComboBoxValueMember,
                DisplayMember = RoleProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
