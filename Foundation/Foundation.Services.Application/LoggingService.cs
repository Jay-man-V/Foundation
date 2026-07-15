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
        public IEventLog? GetLatest(Boolean isFinished, EntityId scheduledTaskId = new EntityId(), String? batchName = null, String? processName = null, String? taskName = null)
        {
            LoggingHelpers.TraceCallEnter(isFinished, scheduledTaskId, batchName, processName, taskName);

            IEventLog? retVal = Repository.GetLatest(isFinished, scheduledTaskId, batchName, processName, taskName);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ILoggingService.CreateLogEntry(String, String, String, String?)"/>
        public LogId CreateLogEntry(String batchName, String processName, String taskName, String? information = null)
        {
            LoggingHelpers.TraceCallEnter(batchName, processName, taskName, information);

            LogId retVal;

            IEventLog entity = Core.IoC.Get<IEventLog>();
            entity.ApplicationId = Core.ApplicationId;
            entity.BatchName = batchName;
            entity.ProcessName = processName;
            entity.LogSeverityId = new EntityId(LogSeverity.Information.Id());
            entity.TaskName = taskName;
            entity.Information = information ?? String.Empty;

            IEventLog savedEventLog = Repository.Save(entity);
            IFoundationModel foundationModel = savedEventLog;
            entity.Id = new LogId(foundationModel.Id.TheEntityId);

            retVal = entity.Id;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ILoggingService.CreateLogEntry(LogId, String, String, String, LogSeverity, String)" />
        public LogId CreateLogEntry(LogId parentLogId, String batchName, String processName, String taskName, LogSeverity logSeverity, String information)
        {
            LoggingHelpers.TraceCallEnter(parentLogId, batchName, processName, taskName, logSeverity, information);

            LogId retVal;

            IEventLog entity = Core.IoC.Get<IEventLog>();
            entity.ApplicationId = Core.ApplicationId;
            entity.BatchName = batchName;
            entity.ProcessName = processName;
            entity.TaskName = taskName;
            entity.ParentId = parentLogId;
            entity.LogSeverityId = new EntityId(logSeverity.Id());
            entity.Information = information;

            IEventLog savedEventLog = Repository.Save(entity);
            IFoundationModel foundationModel = savedEventLog;
            entity.Id = new LogId(foundationModel.Id.TheEntityId);

            retVal = entity.Id;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ILoggingService.CreateLogEntry(LogId, String, String, String, LogSeverity, Exception)" />
        public LogId CreateLogEntry(LogId parentLogId, String batchName, String processName, String taskName, LogSeverity logSeverity, Exception exception)
        {
            LoggingHelpers.TraceCallEnter(parentLogId, batchName, processName, taskName, logSeverity, exception);

            LogId retVal;

            ExceptionOutput exceptionOutput = MessageFormatter.FormatMessage(RunTimeEnvironmentSettings, exception);

            retVal = CreateLogEntry(parentLogId, batchName, processName, taskName, logSeverity, exceptionOutput.ToString());

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
