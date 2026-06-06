//-----------------------------------------------------------------------
// <copyright file="ScheduledTaskBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.ScheduledTasks;
using Foundation.Resources;

namespace Foundation.Server.ScheduledTasks
{
    /// <summary>
    /// Provides an abstract base class for implementing scheduled tasks with common process management, configuration,
    /// and logging support.
    /// </summary>
    /// <remarks>
    /// ScheduledTaskBase supplies core functionality for scheduled task execution, including event
    /// hooks, runtime parameter initialization, and tracking of execution times. Derived classes must implement
    /// task-specific logic by overriding abstract members. This class integrates with application configuration and
    /// logging services to support audit and diagnostic scenarios. It is intended to be subclassed for concrete
    /// scheduled task implementations.
    /// </remarks>
    public abstract class ScheduledTaskBase : IScheduledTask
    {
        /// <inheritdoc cref="IScheduledTask.RunTaskStarting"/>
        public EventHandler<TaskEventArgs>? RunTaskStarting { get; set; }

        /// <inheritdoc cref="IScheduledTask.RunTaskEnding"/>
        public EventHandler<TaskEventArgs>? RunTaskEnding { get; set; }

        /// <summary>
        /// Initializes a new instance of the ScheduledTaskBase class with the specified core services and application
        /// configuration service.
        /// </summary>
        /// <param name="core">The core service used for accessing fundamental application functionality. Cannot be null.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings that provide configuration and environment-specific information. Cannot be
        /// null.</param>
        /// <param name="dateTimeService">The date and time service used for obtaining the current system time. Cannot be null.</param>
        /// <param name="loggingService">The logging service used for recording diagnostic and operational information. Cannot be null.</param>
        /// <param name="applicationConfigurationService">The application configuration service used to access application-specific configuration settings. Cannot be
        /// null.</param>
        protected ScheduledTaskBase
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            IApplicationConfigurationService applicationConfigurationService
        )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService);

            Core = core;
            RunTimeEnvironmentSettings = runTimeEnvironmentSettings;
            LoggingService = loggingService;
            DateTimeService = dateTimeService;
            ApplicationConfigurationService = applicationConfigurationService;

            JobStartTime = DateTimeService.SystemUtcDateTimeNow;

            ApplicationName = String.Empty;
            BatchName = String.Empty;
            ProcessName = String.Empty;
            TaskName = String.Empty;

            RunTaskStarting = null;

            TaskParameters = null;

            LoggingHelpers.TraceCallReturn();
        }

        protected ICore Core { get; }
        protected IRunTimeEnvironmentSettings RunTimeEnvironmentSettings { get; }
        protected IDateTimeService DateTimeService { get; }
        protected ILoggingService LoggingService { get; }
        protected IApplicationConfigurationService ApplicationConfigurationService { get; }

        /// <summary>
        /// Gets the name of the application as recognized by the provider.
        /// </summary>
        /// <remarks>
        /// The application name is used to scope data and operations within the provider.
        /// Implementations should ensure that the value uniquely identifies the application context, especially in
        /// multi-application environments.
        /// </remarks>
        protected String ApplicationName { get; set; }

        /// <summary>
        /// Gets the name of the batch associated with the current operation.
        /// </summary>
        protected String BatchName { get; set; }

        /// <summary>
        /// Gets the name of the process associated with the current instance.
        /// </summary>
        protected String ProcessName { get; set; }

        /// <summary>
        /// Gets the name of the task represented by the derived class.
        /// </summary>
        protected String TaskName { get; set; }

        /// <summary>
        /// Gets the configuration key used to store or retrieve the last run date for the current batch task.
        /// </summary>
        /// <remarks>
        /// The key is constructed using the application, batch, process, and task names to
        /// ensure uniqueness across different tasks. Override this property if a custom key format is required.
        /// </remarks>
        protected virtual String LastRunDateKey => $"{ApplicationName}.{BatchName}.{ProcessName}.{TaskName}.LastRunDate";

        /// <inheritdoc cref="IScheduledTask.JobStartTime"/>
        public DateTime JobStartTime { get; }

        /// <inheritdoc cref="IScheduledTask.TaskStartTime"/>
        public DateTime TaskStartTime { get; private set; }

        /// <inheritdoc cref="IScheduledTask.LastRunDateTime"/>
        public DateTime LastRunDateTime { get; private set; }

        protected TaskParameters.TaskParameters? TaskParameters { get; set; }

        /// <summary>
        /// Initializes run-time parameters for the task using the specified parameter string.
        /// </summary>
        /// <remarks>Derived classes should parse and validate the provided parameter string according to
        /// their specific requirements. This method will be called by <see cref="RunTask"/> before executing the task to ensure all necessary
        /// parameters are set.
        /// </remarks>
        /// <param name="taskParameters">A string containing the parameters required to configure the task at run time. The format and required
        /// content are defined by the derived class.</param>
        protected virtual void InitialiseRunTimeParameters(String taskParameters)
        {
            if (TaskParameters is not null)
            {
                ApplicationName = TaskParameters.ApplicationName;
                BatchName = TaskParameters.BatchName;
                ProcessName = TaskParameters.ProcessName;
                TaskName = TaskParameters.TaskName;
            }
        }

        /// <summary>
        /// Retrieves a string representation of the runtime parameters for logging purposes.
        /// </summary>
        /// <remarks>
        /// Override this method to provide custom logging information about runtime parameters
        /// relevant to the derived class. This method is intended to support diagnostic or audit logging
        /// scenarios.
        /// </remarks>
        /// <returns>
        /// A string containing the runtime parameters to be included in log output. The format and content of the
        /// string are determined by the implementing class.
        /// </returns>
        protected abstract String GetRunTimeParametersForLogging();

        /// <summary>
        /// Processes the task.
        /// Base class does not implement this method, it must be implemented in the derived class.
        /// </summary>
        /// <param name="parentLogId"></param>
        protected abstract void ProcessTask(LogId parentLogId);

        /// <inheritdoc cref="IScheduledTask.RunTask(LogId, String)"/>
        public void RunTask(LogId parentLogId, String taskParameters)
        {
            RaiseRunTaskStarting(parentLogId, taskParameters);

            InitialiseRunTimeParameters(taskParameters);

            LogId taskLogId = LoggingService.CreateLogEntry(parentLogId, TaskParameters.BatchName, TaskParameters.ProcessName, TaskParameters.TaskName, LogSeverity.Information, $"Running '{TaskName}'");

            TaskStartTime = DateTimeService.SystemUtcDateTimeNow;
            LastRunDateTime = ApplicationConfigurationService.Get(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, LastRunDateKey, TaskStartTime.AddMonths(-1));

            String runTimeParametersForLogging = GetRunTimeParametersForLogging();
            String message = String.Empty;
            message += $"{BatchName}::{ProcessName}::{TaskName} running at: {TaskStartTime.ToString(Formats.DotNet.DateTimeMilliseconds)}." + Environment.NewLine;
            message += $"LastRunDateTime: {LastRunDateTime.ToString(Formats.DotNet.DateTimeMilliseconds)}" + Environment.NewLine;
            message += $"Task parameters: '{taskParameters}'." + Environment.NewLine;
            message += $"Run time parameters: {runTimeParametersForLogging}" + Environment.NewLine;

            LogId processTaskId = LoggingService.CreateLogEntry(taskLogId, BatchName, ProcessName, TaskName, LogSeverity.Information, message);

            ProcessTask(processTaskId);

            LastRunDateTime = DateTimeService.SystemUtcDateTimeNow;

            Boolean isEncrypted = false;
            ApplicationConfigurationService.SetValue(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ConfigurationScope.Application, isEncrypted, LastRunDateKey, LastRunDateTime);

            LoggingService.CreateLogEntry(processTaskId, BatchName, ProcessName, TaskName, LogSeverity.Information, $"LastRunDateTime: {LastRunDateTime.ToString(Formats.DotNet.DateTimeMilliseconds)}");

            RaiseRunTaskEnding(parentLogId, taskParameters);

            LoggingService.CreateLogEntry(taskLogId, BatchName, ProcessName, TaskName, LogSeverity.Information, "Finished");
        }

        private void RaiseRunTaskStarting(LogId parentLogId, String taskParameters)
        {
            EventHandler<TaskEventArgs>? handler = RunTaskStarting;
            if (handler != null)
            {
                TaskEventArgs eventArgs = new TaskEventArgs(parentLogId, taskParameters);
                handler(this, eventArgs);
            }
        }

        private void RaiseRunTaskEnding(LogId parentLogId, String taskParameters)
        {
            EventHandler<TaskEventArgs>? handler = RunTaskEnding;
            if (handler != null)
            {
                TaskEventArgs eventArgs = new TaskEventArgs(parentLogId, taskParameters);
                handler(this, eventArgs);
            }
        }
    }
}
