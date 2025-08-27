//-----------------------------------------------------------------------
// <copyright file="LoggingService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <ineritdoc cref="ILoggingService" />
    [DependencyInjectionTransient]
    public class LoggingService : ServiceBase, ILoggingService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="repository">The data access.</param>
        public LoggingService
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IEventLogRepository repository
        ) : 
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, repository);

            Core = core;
            RunTimeEnvironmentSettings = runTimeEnvironmentSettings;
            DateTimeService = dateTimeService;
            Repository = repository;

            LoggingHelpers.TraceCallReturn();
        }

        private ICore Core { get; }
        private IRunTimeEnvironmentSettings RunTimeEnvironmentSettings { get; }
        private IDateTimeService DateTimeService { get; }
        private IEventLogRepository Repository { get; }

        /// <inheritdoc cref="ILoggingService.GetLatest(Boolean, EntityId, String?, String?, String?)"/>
        public IEventLog? GetLatest(Boolean isFinished, EntityId scheduledTaskId = new (), String? batchName = null, String? processName = null, String? taskName = null)
        {
            LoggingHelpers.TraceCallEnter(isFinished, scheduledTaskId, batchName, processName, taskName);

            IEventLog? retVal = Repository.GetLatest(isFinished, scheduledTaskId, batchName, processName, taskName);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ILoggingService.StartTask(AppId, String, String, String)"/>
        public LogId StartTask(AppId applicationId, String batchName, String processName, String taskName)
        {
            LoggingHelpers.TraceCallEnter(applicationId, batchName, processName, taskName);

            LogId retVal;

            IEventLog entity = Core.IoC.Get<IEventLog>();
            entity.ApplicationId = applicationId;
            entity.BatchName = batchName;
            entity.ProcessName = processName;
            entity.LogSeverityId = new EntityId(LogSeverity.Information.Id());
            entity.TaskName = taskName;
            entity.StartedOn = DateTimeService.SystemDateTimeNow;

            Repository.Save(entity);
            IFoundationModel foundationModel = entity;
            entity.Id = new LogId(foundationModel.Id.TheEntityId);

            retVal = entity.Id;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ILoggingService.EndTask(LogId, LogSeverity, String)" />
        public void EndTask(LogId logId, LogSeverity logSeverity, String information)
        {
            LoggingHelpers.TraceCallEnter(logId, logSeverity, information);

            IEventLog entity = Repository.Get(logId);
            entity.FinishedOn = DateTimeService.SystemDateTimeNow;
            entity.LogSeverityId = new EntityId(logSeverity.Id());

            if (!String.IsNullOrWhiteSpace(information))
            {
                if (!String.IsNullOrWhiteSpace(entity.Information))
                {
                    entity.Information += Environment.NewLine;
                }

                entity.Information += information;
            }

            Repository.Save(entity);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ILoggingService.EndTask(LogId, LogSeverity, Exception)"/>
        public void EndTask(LogId logId, LogSeverity logSeverity, Exception exception)
        {
            LoggingHelpers.TraceCallEnter(logId, logSeverity, exception);

            ExceptionOutput exceptionOutput = MessageFormatter.FormatMessage(RunTimeEnvironmentSettings, DateTimeService, exception);

            EndTask(logId, logSeverity, exceptionOutput.ToString());

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ILoggingService.CreateLogEntry(LogId, AppId, String, String, String, LogSeverity, String)" />
        public LogId CreateLogEntry(LogId parentLogId, AppId applicationId, String batchName, String processName, String taskName, LogSeverity logSeverity, String information)
        {
            LoggingHelpers.TraceCallEnter(parentLogId, batchName, processName, taskName, logSeverity, information);

            LogId retVal;

            IEventLog entity = Core.IoC.Get<IEventLog>();
            entity.ApplicationId = applicationId;
            entity.ParentId = parentLogId;
            entity.BatchName = batchName;
            entity.ProcessName = processName;
            entity.LogSeverityId = new EntityId(logSeverity.Id());
            entity.TaskName = taskName;
            entity.StartedOn = DateTimeService.SystemDateTimeNow;
            entity.Information = information;

            Repository.Save(entity);
            IFoundationModel foundationModel = entity;
            entity.Id = new LogId(foundationModel.Id.TheEntityId);

            retVal = entity.Id;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ILoggingService.CreateLogEntry(LogId, AppId, LogSeverity, Exception)" />
        public LogId CreateLogEntry(LogId parentLogId, AppId applicationId, LogSeverity logSeverity, Exception exception)
        {
            LoggingHelpers.TraceCallEnter(parentLogId, logSeverity, exception);

            LogId retVal;

            ExceptionOutput exceptionOutput = MessageFormatter.FormatMessage(RunTimeEnvironmentSettings, DateTimeService, exception);

            IEventLog entity = Core.IoC.Get<IEventLog>();
            entity.ApplicationId = applicationId;
            entity.ParentId = parentLogId;
            entity.LogSeverityId = new EntityId(logSeverity.Id());
            entity.StartedOn = DateTimeService.SystemDateTimeNow;
            entity.Information = exceptionOutput.ToString();

            Repository.Save(entity);
            IFoundationModel foundationModel = entity;
            entity.Id = new LogId(foundationModel.Id.TheEntityId);

            retVal = entity.Id;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ILoggingService.UpdateLogEntry(LogId, String)" />
        public void UpdateLogEntry(LogId logId, String information)
        {
            LoggingHelpers.TraceCallEnter(logId, information);

            IEventLog entity = Repository.Get(logId);

            if (!String.IsNullOrWhiteSpace(entity.Information))
            {
                entity.Information += Environment.NewLine;
            }

            entity.Information += information;

            Repository.Save(entity);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
