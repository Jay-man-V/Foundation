//-----------------------------------------------------------------------
// <copyright file="DemoScheduledTask.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Server.ScheduledTasks
{
    /// <summary>
    /// Demo Scheduled Task
    /// </summary>
    [DependencyInjectionTransient]
    public class DemoScheduledTask : ScheduledTaskBase
    {
        /// <summary>
        /// Demo Scheduled Task
        /// </summary>
        /// <param name="core"></param>
        /// <param name="runTimeEnvironmentSettings"></param>
        /// <param name="dateTimeService">The date/time service.</param>
        /// <param name="loggingService"></param>
        /// <param name="applicationConfigurationService"></param>
        public DemoScheduledTask
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            IApplicationConfigurationService applicationConfigurationService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                loggingService,
                applicationConfigurationService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService, applicationConfigurationService);

            ApplicationName = "UnitTest";
            BatchName = "DemoBatch";
            TaskName = "DemoTask";

            LoggingHelpers.TraceCallReturn();
        }

        protected override void InitialiseRunTimeParameters(String taskParameters)
        {
            // Does nothing
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
