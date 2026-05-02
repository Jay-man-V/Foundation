//-----------------------------------------------------------------------
// <copyright file="FileCopyTask.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;

using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.BusinessProcess.Core.Schedulers.StandardScheduler
{
    [DependencyInjectionTransient]
    public abstract class FileCopyTaskBase : ScheduledTaskBase
    {
        protected FileCopyTaskBase
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                loggingService
            )
        {
        }

        protected abstract String SourceFilePathKey { get; }
        protected abstract String DestinationFilePathKey { get; }

        /// <inheritdoc cref="IScheduledTask.Process(LogId, String)"/>
        public override void Process(LogId logId, String taskParameters)
        {
            base.Process(logId, taskParameters);

            DateTime currentDateTime = DateTimeService.SystemUtcDateTimeNow;
            String message = $"ProcessJob running at: {currentDateTime.ToString(Formats.DotNet.DateTimeSeconds)}";

            LoggingService.CreateLogEntry(logId, Core.ApplicationId, "batchName", "processName", "taskName", LogSeverity.Information, message);
            
            Debug.WriteLine(message);
        }
    }
}
