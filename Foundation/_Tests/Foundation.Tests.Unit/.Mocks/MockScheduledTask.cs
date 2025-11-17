//-----------------------------------------------------------------------
// <copyright file="MockScheduledTask.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;

using Foundation.BusinessProcess.Core.Schedulers;
using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.Tests.Unit.Mocks
{
    public class MockScheduledTask : ScheduledTaskBase
    {
        public MockScheduledTask
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
