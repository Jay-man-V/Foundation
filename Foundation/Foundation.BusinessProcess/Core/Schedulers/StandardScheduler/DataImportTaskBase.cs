//-----------------------------------------------------------------------
// <copyright file="DataImportTaskBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.BusinessProcess.Core.Schedulers.StandardScheduler
{
    public abstract class DataImportTaskBase : ScheduledTaskBase
    {
        protected DataImportTaskBase
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

        protected override void ProcessTask(LogId parentLogId, string taskParameters)
        {
            // Does nothing
        }
    }
}
