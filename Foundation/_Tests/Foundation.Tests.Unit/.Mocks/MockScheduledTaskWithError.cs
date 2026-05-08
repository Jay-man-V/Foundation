//-----------------------------------------------------------------------
// <copyright file="MockScheduledTaskWithError.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Mocks
{
    public class MockScheduledTaskWithError : MockScheduledTask
    {
        public MockScheduledTaskWithError
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

            LoggingHelpers.TraceCallReturn();
        }

        protected override void ProcessTask(LogId parentLogId)
        {
            throw new Exception("Forced exception to test code");
        }
    }
}
