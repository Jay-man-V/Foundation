//-----------------------------------------------------------------------
// <copyright file="DataExtractTaskBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Server.ScheduledTasks
{
    public class DataExportTask : ScheduledTaskBase
    {
        public DataExportTask
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
        }

        protected override void InitialiseRunTimeParameters(String taskParameters)
        {
            throw new NotImplementedException();
        }

        protected override String GetRunTimeParametersForLogging()
        {
            throw new NotImplementedException();
        }

        protected override void ProcessTask(LogId parentLogId)
        {
            // Does nothing
        }
    }
}
