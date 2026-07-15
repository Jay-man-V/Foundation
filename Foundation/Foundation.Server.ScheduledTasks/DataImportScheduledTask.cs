//-----------------------------------------------------------------------
// <copyright file="DataImportScheduledTask.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Server.ScheduledTasks
{
    public class DataImportScheduledTask : ScheduledTaskBase, IDataImportScheduledTask
    {
        public DataImportScheduledTask
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
            LoggingHelpers.TraceCallEnter();

            // Does nothing

            LoggingHelpers.TraceCallReturn();
        }

        protected override void InitialiseRunTimeParameters(String taskParameters)
        {
            LoggingHelpers.TraceCallEnter(taskParameters);

            TaskParameters = new TaskParameters();

            LoggingHelpers.TraceCallReturn();
        }

        protected override String GetRunTimeParametersForLogging()
        {
            LoggingHelpers.TraceCallEnter();

            String retVal = String.Empty;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        protected override void ProcessTask(LogId parentLogId)
        {
            LoggingHelpers.TraceCallEnter(parentLogId);

            // Does nothing

            LoggingHelpers.TraceCallReturn();
        }
    }
}
