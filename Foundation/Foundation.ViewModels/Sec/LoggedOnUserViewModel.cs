//-----------------------------------------------------------------------
// <copyright file="LoggedOnUserViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.ViewModels.Sec
{
    /// <summary>
    /// The User Interface interaction logic for Logged On User maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{ILoggedOnUser}" />
    [DependencyInjectionTransient]
    public class LoggedOnUserViewModel : GenericDataGridViewModelBase<ILoggedOnUser>, ILoggedOnUserViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LoggedOnUserViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="loggedOnUserProcess">The logged on user process.</param>
        public LoggedOnUserViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            ILoggedOnUserProcess loggedOnUserProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                loggedOnUserProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, loggedOnUserProcess);

            _externalCommandMessage = String.Empty;
            _externalCommandName = String.Empty;

            LoggedOnUserProcess = loggedOnUserProcess;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the logged on user process.
        /// </summary>
        /// <remarks>
        /// This version of the LoggedOnUserProcess is different to the version in the base class
        /// </remarks>
        /// <value>
        /// The logged on user process.
        /// </value>
        private new ILoggedOnUserProcess LoggedOnUserProcess { get; }

        /// <summary>
        /// Gets or sets the quit command timer.
        /// </summary>
        /// <value>
        /// The quit command timer.
        /// </value>
        private DispatcherTimer? QuitCommandTimer { get; set; }

        /// <summary>
        /// Gets the refresh button visibility.
        /// </summary>
        /// <value>
        /// The refresh button visibility.
        /// </value>
        public override Boolean RefreshButtonVisible => CommonBusinessProcess.CanRefreshData();

        /// <summary>
        /// Gets the send quit command.
        /// </summary>
        /// <value>
        /// The send quit command.
        /// </value>
        public ICommand SendQuitCommandCommand => RelayCommandFactory.New<ILoggedOnUser>(OnSendQuitCommand_Execute);

        /// <summary>
        /// Gets the send abort command.
        /// </summary>
        /// <value>
        /// The send abort command.
        /// </value>
        public ICommand SendAbortCommandCommand => RelayCommandFactory.New<ILoggedOnUser>(OnSendAbortCommand_Execute);

        /// <summary>
        /// Gets the send message command.
        /// </summary>
        /// <value>
        /// The send message command.
        /// </value>
        public ICommand SendMessageCommandCommand => RelayCommandFactory.New<ILoggedOnUser>(OnSendMessageCommand_Execute);

        private DateTime _externalCommandTime;
        /// <summary>
        /// Gets the external command time.
        /// </summary>
        /// <value>
        /// The external command time.
        /// </value>
        public DateTime ExternalCommandTime
        {
            get => _externalCommandTime;
            internal set => SetPropertyValue(ref _externalCommandTime, value);
        }

        private String _externalCommandMessage;
        /// <summary>
        /// Gets the external command message.
        /// </summary>
        /// <value>
        /// The external command message.
        /// </value>
        public String ExternalCommandMessage
        {
            get => _externalCommandMessage;
            internal set => SetPropertyValue(ref _externalCommandMessage, value);
        }

        private String _externalCommandName;
        /// <summary>
        /// Gets the name of the external command.
        /// </summary>
        /// <value>
        /// The name of the external command.
        /// </value>
        public String ExternalCommandName
        {
            get => _externalCommandName;
            internal set => SetPropertyValue(ref _externalCommandName, value);
        }

        /// <inheritdoc cref="Initialise()"/>
        public override void Initialise()
        {
            LoggingHelpers.TraceCallEnter();

            base.Initialise();

            SelectedItem = GridDataSource?.FirstOrDefault(lou => lou.CreatedByUserProfileId == Core.CurrentLoggedOnUser.Id);

            SetupLoggedOnUserTimer();

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="RefreshData()"/>
        protected override List<ILoggedOnUser> RefreshData()
        {
            LoggingHelpers.TraceCallEnter();

            List<ILoggedOnUser> loggedOnUsers = LoggedOnUserProcess.GetLoggedOnUsers(Core.ApplicationId);

            GridDataSource = loggedOnUsers;

            ILoggedOnUser? loggedOnUser = loggedOnUsers.FirstOrDefault(lou => lou.CreatedByUserProfileId == Core.CurrentLoggedOnUser.UserProfile.Id &&
                                                                              lou.ApplicationId == Core.ApplicationId);

            if (loggedOnUser == null)
            {
                String message = $"The current logged on user '{RunTimeEnvironmentSettings.UserFullLogonName}' cannot be located";
                throw new InvalidOperationException(message);
            }

            // Nothing to do, exit the function
            if (String.IsNullOrEmpty(loggedOnUser.Command)) return loggedOnUsers;

            // Clear any command that has been set up
            LoggedOnUserProcess.ClearCommand(Core.ApplicationId, loggedOnUser);

            ICommandParser commandParser = Core.IoC.Get<ICommandParser>();
            commandParser.ParseCommand(loggedOnUser.Command);

            // Nothing to do, exit the function
            if (!commandParser.IsValid) return loggedOnUsers;

            ExternalCommandName = commandParser.CommandName;
            String commandParameter = commandParser.Parameters;

            if (ExternalCommandName == CommandNames.Abort)
            {
                if (QuitCommandTimer != null)
                {
                    QuitCommandTimer.Stop();
                    QuitCommandTimer = null;

                    ExternalCommandTime = DateTime.MinValue;
                    ExternalCommandMessage = String.Empty;
                    ExternalCommandName = String.Empty;
                }
            }
            else
            {
                DateTime executionCommandTime = DateTime.Parse(commandParameter);
                if (executionCommandTime > DateTimeService.SystemUtcDateTimeNow)
                {
                    if (ExternalCommandName == CommandNames.Quit)
                    {
                        if (QuitCommandTimer != null)
                        {
                            QuitCommandTimer.Stop();
                            QuitCommandTimer = null;
                        }

                        QuitCommandTimer = new DispatcherTimer();
                        QuitCommandTimer.Tick -= QuitCommandTimer_Tick;
                        QuitCommandTimer.Tick += QuitCommandTimer_Tick;

                        TimeSpan executionDelay = executionCommandTime - DateTimeService.SystemUtcDateTimeNow;

                        QuitCommandTimer.Interval = executionDelay;
#if (DEBUG)
                        QuitCommandTimer.Interval = new TimeSpan(0, 0, 30);
#endif
                        QuitCommandTimer.Start();

                        ExternalCommandTime = executionCommandTime;
                        ExternalCommandMessage = $"Application will shutdown at: {ExternalCommandTime.ToString(Formats.DotNet.DateTimeSeconds)} for system maintenance";
                    }
                    else if (ExternalCommandName == CommandNames.Message)
                    {
                        ExternalCommandMessage = commandParser.Parameters;
                    }

                    // TODO: Display ExternalCommandMessage to user
                }
            }

            LoggingHelpers.TraceCallReturn(loggedOnUsers);

            return loggedOnUsers;
        }

        /// <summary>
        /// Setups the logged on user timer.
        /// </summary>
        private void SetupLoggedOnUserTimer()
        {
            LoggingHelpers.TraceCallEnter();

            DispatcherTimer loggedOnUserTimer = new DispatcherTimer();
            loggedOnUserTimer.Tick += LoggedOnUserTimer_Tick;
            loggedOnUserTimer.Interval = new TimeSpan(0, 0, 30);
            loggedOnUserTimer.Start();

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Handles the Tick event of the LoggedOnUserTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LoggedOnUserTimer_Tick(Object? sender, EventArgs e)
        {
            LoggingHelpers.TraceCallEnter(sender, e);

            if (sender is DispatcherTimer thisTimer)
            {
                try
                {
                    thisTimer.Stop();
                    LoggedOnUserProcess.UpdateLoggedOnUser(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile);
                    OnRefreshCommand_Execute();
                }
                finally
                {
                    thisTimer.Start();
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Handles the Tick event of the QuitCommandTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void QuitCommandTimer_Tick(Object? sender, EventArgs e)
        {
            LoggingHelpers.TraceCallEnter(sender, e);

            Application.Current.Shutdown();

            LoggingHelpers.TraceCallEnter();
        }

        /// <summary>
        /// Called when [send quit command execute].
        /// </summary>
        /// <param name="loggedOnUser">The logged on user.</param>
        private void OnSendQuitCommand_Execute(ILoggedOnUser? loggedOnUser)
        {
            LoggingHelpers.TraceCallEnter(loggedOnUser);

            if (loggedOnUser == null) return;

            using (MouseCursor)
            {
                LoggedOnUserProcess.SendQuitCommand(Core.ApplicationId, loggedOnUser);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [send abort command execute].
        /// </summary>
        /// <param name="loggedOnUser">The logged on user.</param>
        private void OnSendAbortCommand_Execute(ILoggedOnUser? loggedOnUser)
        {
            LoggingHelpers.TraceCallEnter(loggedOnUser);

            if (loggedOnUser == null) return;

            using (MouseCursor)
            {
                LoggedOnUserProcess.SendAbortCommand(Core.ApplicationId, loggedOnUser);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [send message command execute].
        /// </summary>
        /// <param name="loggedOnUser">The logged on user.</param>
        private void OnSendMessageCommand_Execute(ILoggedOnUser? loggedOnUser)
        {
            LoggingHelpers.TraceCallEnter(loggedOnUser);

            if (loggedOnUser == null) return;

            using (MouseCursor)
            {
                String message = "<enter message here>";

                LoggedOnUserProcess.SendMessageCommand(Core.ApplicationId, loggedOnUser, message);
            }

            LoggingHelpers.TraceCallReturn();
        }
    }
}
