//-----------------------------------------------------------------------
// <copyright file="Service.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Service
{
    public interface IMyService
    {
        /// <summary>
        /// 
        /// </summary>
        void Start();

        /// <summary>
        /// 
        /// </summary>
        void Stop();
    }

    [DependencyInjectionTransient]
    public class MyService : IMyService
    {
        public MyService
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ILoggingService loggingService,
            IScheduledJobProcess scheduledJobProcess
        )
        {
            Core = core;
            RunTimeEnvironmentSettings = runTimeEnvironmentSettings;
            LoggingService = loggingService;
            ScheduledJobProcess = scheduledJobProcess;
        }

        private ICore Core { get; }
        private IRunTimeEnvironmentSettings RunTimeEnvironmentSettings { get; }
        private ILoggingService LoggingService { get; }
        private IScheduledJobProcess ScheduledJobProcess { get; }

        private LogId ParentLogId { get; set; }

        public void Start()
        {
            LoggingHelpers.TraceCallEnter();

            LoggingHelpers.LogInformationMessage("Service starting");

            ParentLogId = LoggingService.StartTask(Core.ApplicationId, "Scheduler Service", "Scheduler Service", "Start");

            ScheduledJobProcess.StartJobs(ParentLogId);

            LoggingHelpers.LogInformationMessage("Service started");

            LoggingHelpers.TraceCallReturn();
        }

        public void Stop()
        {
            LoggingHelpers.TraceCallEnter();

            LoggingHelpers.LogInformationMessage("Service stopping");

            ScheduledJobProcess.StopJobs(ParentLogId);

            LoggingService.CreateLogEntry(ParentLogId, Core.ApplicationId, "Scheduler Service", "Scheduler Service", "Stop", LogSeverity.Information, "Stop");

            LoggingService.EndTask(ParentLogId, LogSeverity.Information, "Scheduler stopped");

            LoggingHelpers.LogInformationMessage("Service stopped");

            LoggingHelpers.TraceCallReturn();
        }
    }
}
