//-----------------------------------------------------------------------
// <copyright file="CalendarProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.BusinessProcess
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
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="repository">The repository.</param>
        public CalendarProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ICalendarRepository repository
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, repository);

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

            //DateTime startDate = date.Add(intervalType, interval, date.TimeOfDay);

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

        /// <summary>
        /// Determines the first working date of the year/month of the supplied <paramref name="date"/>
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public DateTime GetFirstWorkingDayOfMonth(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = Repository.GetFirstWorkingDayOfMonth(countryCode, date);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Determines the first working date of the year/month of the supplied parameters
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public DateTime GetFirstWorkingDayOfMonth(String countryCode, Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(countryCode, year, month);

            DateTime retVal = Repository.GetFirstWorkingDayOfMonth(countryCode, year, month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Determines the last working date of the year/month of the supplied <paramref name="date"/>
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public DateTime GetLastWorkingDayOfMonth(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = Repository.GetLastWorkingDayOfMonth(countryCode, date);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Determines the first working date of the year/month of the supplied parameters
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        public DateTime GetLastWorkingDayOfMonth(String countryCode, Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(countryCode, year, month);

            DateTime retVal = Repository.GetLastWorkingDayOfMonth(countryCode, year, month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
