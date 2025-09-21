//-----------------------------------------------------------------------
// <copyright file="ApplicationUserRoleProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;
using Foundation.Models.Specialised;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess.Sec
{
    /// <summary>
    /// The Application User Role Process
    /// </summary>
    [DependencyInjectionTransient]
    public class ApplicationUserRoleProcess : CommonBusinessProcess<IApplicationUserRole, IApplicationUserRoleRepository>, IApplicationUserRoleProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationUserRoleProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="loggingService">The logging service</param>
        /// <param name="repository">The data access</param>
        /// <param name="statusRepository">The status data access</param>
        /// <param name="userProfileRepository">The user profile data access</param>
        /// <param name="applicationProcess">The application process</param>
        /// <param name="roleProcess">The role process</param>
        /// <param name="userProfileProcess">The user profile process</param>
        public ApplicationUserRoleProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            IApplicationUserRoleRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository,
            IApplicationProcess applicationProcess,
            IRoleProcess roleProcess,
            IUserProfileProcess userProfileProcess
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                loggingService,
                repository,
                statusRepository,
                userProfileRepository
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService, repository, statusRepository, userProfileRepository, applicationProcess, roleProcess, userProfileProcess);

            ApplicationProcess = applicationProcess;
            RoleProcess = roleProcess;
            UserProfileProcess = userProfileProcess;

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

        /// <summary>
        /// Gets the user profile process.
        /// </summary>
        /// <value>
        /// The user profile process.
        /// </value>
        private IUserProfileProcess UserProfileProcess { get; }

        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Application/User/Roles";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Application/User/Roles:";

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ApplicationUserRole.ApplicationId, "Application", typeof(String))
            {
                DataSource = ApplicationProcess.GetAll(excludeDeleted: false),
                ValueMember = ApplicationProcess.ComboBoxValueMember,
                DisplayMember = ApplicationProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ApplicationUserRole.RoleId, "Role", typeof(String))
            {
                DataSource = RoleProcess.GetAll(excludeDeleted: false),
                ValueMember = RoleProcess.ComboBoxValueMember,
                DisplayMember = RoleProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ApplicationUserRole.UserProfileId, "User Display Name", typeof(String))
            {
                DataSource = UserProfileProcess.GetAll(excludeDeleted: false),
                ValueMember = UserProfileProcess.ComboBoxValueMember,
                DisplayMember = UserProfileProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ApplicationUserRole.UserProfileId, "User Logon Name", typeof(String))
            {
                DataSource = UserProfileProcess.GetAll(excludeDeleted: false),
                ValueMember = UserProfileProcess.ComboBoxValueMember,
                DisplayMember = UserProfileProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
