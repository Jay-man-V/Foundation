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
        public EventHandler? ProcessJobCalled;

        public MockScheduledTask
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            ICalendarProcess calendarProcess
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                loggingService,
                calendarProcess
            )
        {
        }

        /// <inheritdoc cref="IScheduledTask.Process(LogId, String)"/>
        public override void Process(LogId logId, String taskParameters)
        {
            DateTime currentDateTime = DateTimeService.SystemDateTimeNow;
            String message = $"ProcessJob running at: {currentDateTime.ToString(Formats.DotNet.DateTimeSeconds)}";
            
            Debug.WriteLine(message);

            if (CalendarProcess == null)
            {
                throw new ArgumentNullException(nameof(CalendarProcess));
            }

            if (LoggingService == null)
            {
                throw new ArgumentNullException(nameof(LoggingService));
            }

            EventHandler? handler = ProcessJobCalled;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
