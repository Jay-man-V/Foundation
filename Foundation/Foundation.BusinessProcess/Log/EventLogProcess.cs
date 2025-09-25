//-----------------------------------------------------------------------
// <copyright file="EventLogProcess.cs" company="JDV Software Ltd">
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
    /// The Event Log Business Process
    /// </summary>
    [DependencyInjectionTransient]
    public class EventLogProcess : CommonBusinessProcess<IEventLog, IEventLogRepository>, IEventLogProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EventLogProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="loggingService">The logging service</param>
        /// <param name="repository">The data access</param>
        /// <param name="statusRepository">The status data access</param>
        /// <param name="userProfileRepository">The user profile data access</param>
        /// <param name="logSeverityProcess">The log severity process</param>
        /// <param name="taskStatusProcess">The task status process</param>
        public EventLogProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            IEventLogRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository,
            ILogSeverityProcess logSeverityProcess,
            ITaskStatusProcess taskStatusProcess
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
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService, repository, statusRepository, userProfileRepository, logSeverityProcess, taskStatusProcess);

            LogSeverityProcess = logSeverityProcess;
            TaskStatusProcess = taskStatusProcess;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the log severity process.
        /// </summary>
        /// <value>
        /// The log severity process.
        /// </value>
        private ILogSeverityProcess LogSeverityProcess { get; }

        /// <summary>
        /// Gets the log severity process.
        /// </summary>
        /// <value>
        /// The log severity process.
        /// </value>
        private ITaskStatusProcess TaskStatusProcess { get; }

        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Event Logs";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Event Logs:";

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember" />
        public override String ComboBoxDisplayMember => FDC.EventLog.BatchName;

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions(idColumnType: typeof(LogId));
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.EventLog.ParentId, "Parent Id", typeof(LogId));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.EventLog.LogSeverityId, "Log Severity", typeof(String))
            {
                DataSource = LogSeverityProcess.GetAll(excludeDeleted: false),
                ValueMember = LogSeverityProcess.ComboBoxValueMember,
                DisplayMember = LogSeverityProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.EventLog.BatchName, "Batch Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.EventLog.ProcessName, "Process Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.EventLog.TaskName, "Task Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.EventLog.TaskStatusId, "Task Status", typeof(String))
            {
                DataSource = TaskStatusProcess.GetAll(excludeDeleted: false),
                ValueMember = TaskStatusProcess.ComboBoxValueMember,
                DisplayMember = TaskStatusProcess.ComboBoxDisplayMember,
            }
            ;
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(170, FDC.EventLog.StartedOn, "Start On", typeof(DateTime));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(170, FDC.EventLog.FinishedOn, "Finished On", typeof(DateTime));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.EventLog.Information, "Information", typeof(String));
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.Get(EntityId)"/>
        public override IEventLog Get(EntityId entityId)
        {
            LoggingHelpers.TraceCallEnter(entityId);

            IEventLog retVal = Get(new LogId(entityId.TheEntityId));

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IEventLogProcess.Get(LogId)"/>
        public IEventLog Get(LogId logId)
        {
            LoggingHelpers.TraceCallEnter(logId);

            IEventLog retVal = EntityRepository.Get(logId);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
