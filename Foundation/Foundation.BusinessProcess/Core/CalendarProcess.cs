//-----------------------------------------------------------------------
// <copyright file="CalendarProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.BusinessProcess.Core
{
    /// <summary>
    /// The Calendar Business Process 
    /// </summary>
    [DependencyInjectionTransient]
    public class CalendarProcess : CommonProcess, ICalendarProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="CalendarProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="loggingService">The logging service</param>
        /// <param name="repository">The repository</param>
        public CalendarProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            ICalendarRepository repository
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                loggingService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService, repository);

            Repository = repository;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the data access.
        /// </summary>
        /// <value>
        /// The data access.
        /// </value>
        private ICalendarRepository Repository { get; }

        /// <inheritdoc cref="ICalendarProcess.IsHoliday(String, DateTime)"/>
        public Boolean IsHoliday(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            Boolean retVal = Repository.IsNonWorkingDay(countryCode, date);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarProcess.GetNextWorkingDay(String, DateTime)"/>
        public DateTime GetNextWorkingDay(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = GetNextWorkingDay(countryCode, date, ScheduleInterval.Days, 1);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarProcess.GetNextWorkingDay(String, DateTime, ScheduleInterval, Int32)"/>
        public DateTime GetNextWorkingDay(String countryCode, DateTime date, ScheduleInterval intervalType, Int32 interval)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date, intervalType, interval);

            DateTime retVal = Repository.GetNextWorkingDay(countryCode, date, intervalType, interval);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarProcess.CheckIsWorkingDayOrGetNextWorkingDay(String, DateTime)"/>
        public DateTime CheckIsWorkingDayOrGetNextWorkingDay(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = Repository.CheckIsWorkingDayOrGetNextWorkingDay(countryCode, date);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarProcess.GetFirstWorkingDayOfMonth(String, DateTime)"/>
        public DateTime GetFirstWorkingDayOfMonth(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = Repository.GetFirstWorkingDayOfMonth(countryCode, date);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarProcess.GetFirstWorkingDayOfMonth(String, Int32, Int32)"/>
        public DateTime GetFirstWorkingDayOfMonth(String countryCode, Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(countryCode, year, month);

            DateTime retVal = Repository.GetFirstWorkingDayOfMonth(countryCode, year, month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarProcess.GetLastWorkingDayOfMonth(String, DateTime)"/>
        public DateTime GetLastWorkingDayOfMonth(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = Repository.GetLastWorkingDayOfMonth(countryCode, date);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarProcess.GetLastWorkingDayOfMonth(String, Int32, Int32)"/>
        public DateTime GetLastWorkingDayOfMonth(String countryCode, Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(countryCode, year, month);

            DateTime retVal = Repository.GetLastWorkingDayOfMonth(countryCode, year, month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
