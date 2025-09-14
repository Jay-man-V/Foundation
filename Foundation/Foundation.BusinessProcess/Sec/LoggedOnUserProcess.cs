//-----------------------------------------------------------------------
// <copyright file="LoggedOnUserProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.BusinessProcess.Helpers;
using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;
using Foundation.Models.Specialised;
using Foundation.Resources;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess.Sec
{
    /// <summary>
    /// The Logged On User Business Process
    /// </summary>
    [DependencyInjectionTransient]
    public class LoggedOnUserProcess : CommonBusinessProcess<ILoggedOnUser, ILoggedOnUserRepository>, ILoggedOnUserProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LoggedOnUserProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="repository">The data access.</param>
        /// <param name="statusRepository">The status data access.</param>
        /// <param name="userProfileRepository">The user profile data access.</param>
        /// <param name="applicationProcess">The application process.</param>
        /// <param name="roleProcess">The role process.</param>
        /// <param name="userProfileProcess">The user profile process.</param>
        public LoggedOnUserProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggedOnUserRepository repository,
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
                repository,
                statusRepository,
                userProfileRepository
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, repository, statusRepository, userProfileRepository, applicationProcess, roleProcess, userProfileProcess);

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
        public override String ScreenTitle => "Logged On Users";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Logged On Users:";

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember"/>
        public override string ComboBoxDisplayMember => FDC.LoggedOnUser.DisplayName;

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.LoggedOnUser.ApplicationId, "Application Name", typeof(String))
            {
                DataSource = ApplicationProcess.GetAll(excludeDeleted: false),
                ValueMember = ApplicationProcess.ComboBoxValueMember,
                DisplayMember = ApplicationProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.LoggedOnUser.UserProfileId, "Display Name", typeof(String))
            {
                DataSource = UserProfileProcess.GetAll(excludeDeleted: false),
                ValueMember = ApplicationProcess.ComboBoxValueMember,
                DisplayMember = ApplicationProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(170, FDC.LoggedOnUser.LoggedOn, "Logged On Since", typeof(DateTime));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(170, FDC.LoggedOnUser.LastActive, "Last Active", typeof(DateTime));
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ILoggedOnUserProcess.GetColumnDefinitionsForDisplayControl()" />
        public List<IGridColumnDefinition> GetColumnDefinitionsForDisplayControl()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = new List<IGridColumnDefinition>();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(75, FDC.LoggedOnUser.UserProfileId, "User Id", typeof(EntityId));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.LoggedOnUser.RoleId, "Role", typeof(String))
            {
                DataSource = RoleProcess.GetAll(excludeDeleted: false),
                ValueMember = RoleProcess.ComboBoxValueMember,
                DisplayMember = RoleProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.LoggedOnUser.UserProfileId, "User name", typeof(String))
            {
                DataSource = UserProfileProcess.GetAll(excludeDeleted: false),
                ValueMember = UserProfileProcess.ComboBoxValueMember,
                DisplayMember = UserProfileProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(200, FDC.LoggedOnUser.UserProfileId, "Display name", typeof(String))
            {
                DataSource = UserProfileProcess.GetAll(excludeDeleted: false),
                ValueMember = UserProfileProcess.ComboBoxValueMember,
                DisplayMember = UserProfileProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(170, FDC.LoggedOnUser.LoggedOn, "Logged On Since", typeof(DateTime));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(170, FDC.LoggedOnUser.LastActive, "Last Active", typeof(DateTime));
            retVal.Add(gridColumnDefinition);

            if (Core.CurrentLoggedOnUser.IsSystemSupport)
            {
                gridColumnDefinition = new GridColumnDefinition(200, FDC.LoggedOnUser.Command, "Command Message", typeof(String));
                retVal.Add(gridColumnDefinition);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ILoggedOnUserProcess.SendQuitCommand(AppId, ILoggedOnUser)" />
        public void SendQuitCommand(AppId applicationId, ILoggedOnUser loggedOnUser)
        {
            LoggingHelpers.TraceCallEnter(applicationId, loggedOnUser);

            CommandFormatter commandFormatter = new CommandFormatter(CommandNames.Quit, DateTimeService.SystemDateTimeNow.AddMinutes(10));
            String command = commandFormatter.ToString();

            EntityRepository.UpdateCommand(applicationId, loggedOnUser, command);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ILoggedOnUserProcess.SendAbortCommand(AppId, ILoggedOnUser)" />
        public void SendAbortCommand(AppId applicationId, ILoggedOnUser loggedOnUser)
        {
            LoggingHelpers.TraceCallEnter(applicationId, loggedOnUser);

            CommandFormatter commandFormatter = new CommandFormatter(CommandNames.Abort);
            String command = commandFormatter.ToString();

            EntityRepository.UpdateCommand(applicationId, loggedOnUser, command);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ILoggedOnUserProcess.SendMessageCommand(AppId, ILoggedOnUser, String)" />
        public void SendMessageCommand(AppId applicationId, ILoggedOnUser loggedOnUser, String message)
        {
            LoggingHelpers.TraceCallEnter(applicationId, loggedOnUser);

            CommandFormatter commandFormatter = new CommandFormatter(CommandNames.Message, DateTimeService.SystemDateTimeNow, message);
            String command = commandFormatter.ToString();

            EntityRepository.UpdateCommand(applicationId, loggedOnUser, command);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ILoggedOnUserProcess.ClearCommand(AppId, ILoggedOnUser)" />
        public void ClearCommand(AppId applicationId, ILoggedOnUser loggedOnUser)
        {
            LoggingHelpers.TraceCallEnter(applicationId, loggedOnUser);

            EntityRepository.UpdateCommand(applicationId, loggedOnUser, String.Empty);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ILoggedOnUserProcess.LogOnUser(AppId, IUserProfile)" />
        public void LogOnUser(AppId applicationId, IUserProfile userProfile)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile);

            EntityRepository.LogUserOn(applicationId, userProfile);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ILoggedOnUserProcess.UpdateLoggedOnUser(AppId, IUserProfile)" />
        public void UpdateLoggedOnUser(AppId applicationId, IUserProfile userProfile)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile);

            EntityRepository.UpdateLoggedOnUser(applicationId, userProfile);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ILoggedOnUserProcess.GetLoggedOnUsers(AppId)" />
        public List<ILoggedOnUser> GetLoggedOnUsers(AppId applicationId)
        {
            LoggingHelpers.TraceCallEnter(applicationId);

            List<ILoggedOnUser> retVal = EntityRepository.GetLoggedOnUsers(applicationId);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
