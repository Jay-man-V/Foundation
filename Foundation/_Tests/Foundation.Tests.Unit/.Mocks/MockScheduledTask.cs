//-----------------------------------------------------------------------
// <copyright file="MockScheduledTask.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Server.ScheduledTasks;

namespace Foundation.Tests.Unit.Mocks
{
    public class MockScheduledTask : ScheduledTaskBase
    {
        public MockScheduledTask
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            IApplicationConfigurationService applicationConfigurationService
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                loggingService,
                applicationConfigurationService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService, applicationConfigurationService);

            ApplicationName = "MockApplication";
            BatchName = "MockBatch";
            TaskName = "MockTask";

            LoggingHelpers.TraceCallReturn();
        }

        protected override void InitialiseRunTimeParameters(String taskParameters)
        {
            TaskParameters = new FileCopyTaskParameters();
        }

        protected override String GetRunTimeParametersForLogging()
        {
            // Does nothing
            return String.Empty;
        }

        protected override void ProcessTask(LogId parentLogId)
        {
            // Does nothing
        }
    }
}
