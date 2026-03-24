//-----------------------------------------------------------------------
// <copyright file="CalendarRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;

using Foundation.Common;
using Foundation.DataAccess.Database;
using Foundation.Interfaces;
using Foundation.Repository.LocalModels;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Core
{
    /// <summary>
    /// Defines the Calendar Repository class
    /// </summary>
    /// <see cref="INonWorkingDay" />
    [DependencyInjectionTransient]
    public class CalendarRepository : FoundationDataAccess, ICalendarRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="CalendarRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="coreDataProvider">The core data provider.</param>
        /// <param name="dateTimeService">The date time service.</param>
        public CalendarRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ICoreDataProvider coreDataProvider,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                systemConfigurationService,
                coreDataProvider.ConnectionName
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, coreDataProvider, dateTimeService);

            DateTimeService = dateTimeService;

            LoggingHelpers.TraceCallReturn();
        }

        private IDateTimeService DateTimeService { get; }

        /// <inheritdoc cref="ICalendarRepository.IsNonWorkingDay(String, DateTime)"/>
        public Boolean IsNonWorkingDay(String countryIsoCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryIsoCode, date);

            Boolean retVal;

            String sql = GetSqlFromFile("[core].[Calendar]");

            IDatabaseParameters databaseParameters = new DatabaseParameters
            {
                CreateParameter($"{FDC.Country.EntityName}{FDC.Country.IsoCode}", countryIsoCode),
                CreateParameter($"{FDC.NonWorkingDay.EntityName}{FDC.NonWorkingDay.Date}", date.Date),
            };

            Object? result = ExecuteScalar(sql, CommandType.Text, databaseParameters);

            retVal = Convert.ToBoolean(result);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarRepository.GetNextWorkingDay(String, DateTime, ScheduleInterval, Int32)"/>
        public DateTime GetNextWorkingDay(String countryIsoCode, DateTime date, ScheduleInterval intervalType, Int32 interval)
        {
            LoggingHelpers.TraceCallEnter(countryIsoCode, date, interval);

            DateTime retVal = date.Date;

            String sql = GetSqlFromFile("[core].[Calendar]");

            DatabaseParameters databaseParameters =
            [
                CreateParameter(Functions.GetNextWorkingDay.Parameters.CountryIsoCode, countryIsoCode),
                CreateParameter(Functions.GetNextWorkingDay.Parameters.StartDate, date),
                CreateParameter(Functions.GetNextWorkingDay.Parameters.IntervalType, intervalType),
                CreateParameter(Functions.GetNextWorkingDay.Parameters.Interval, interval),
            ];

            Object? objectValue = ExecuteScalar(sql, CommandType.Text, databaseParameters);

            if (objectValue != null)
            {
                retVal = Convert.ToDateTime(objectValue);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarRepository.CheckIsWorkingDayOrGetNextWorkingDay(String, DateTime)"/>
        public DateTime CheckIsWorkingDayOrGetNextWorkingDay(String countryIsoCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryIsoCode, date);

            DateTime retVal = date.Date;

            String sql = GetSqlFromFile("[core].[Calendar]");

            DatabaseParameters databaseParameters =
            [
                CreateParameter(Functions.CheckIsWorkingDayOrGetNextWorkingDay.Parameters.CountryIsoCode, countryIsoCode),
                CreateParameter(Functions.CheckIsWorkingDayOrGetNextWorkingDay.Parameters.StartDate, date),
            ];

            Object? objectValue = ExecuteScalar(sql, CommandType.Text, databaseParameters);

            if (objectValue != null)
            {
                retVal = Convert.ToDateTime(objectValue);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarRepository.GetFirstWorkingDayOfMonth(String, DateTime)"/>
        public DateTime GetFirstWorkingDayOfMonth(String countryIsoCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryIsoCode, date);

            DateTime retVal = GetFirstWorkingDayOfMonth(countryIsoCode, date.Year, date.Month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarRepository.GetFirstWorkingDayOfMonth(String, Int32, Int32)"/>
        public DateTime GetFirstWorkingDayOfMonth(String countryIsoCode, Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(countryIsoCode, year, month);

            FirstAndLastWorkingDays firstAndLastWorkingDays = GetFirstAndLastWorkingDaysOfMonth(countryIsoCode, year, month);
            DateTime retVal = firstAndLastWorkingDays.FirstWorkingDay;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarRepository.GetLastWorkingDayOfMonth(String, DateTime)"/>
        public DateTime GetLastWorkingDayOfMonth(String countryIsoCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryIsoCode, date);

            DateTime retVal = GetLastWorkingDayOfMonth(countryIsoCode, date.Year, date.Month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarRepository.GetLastWorkingDayOfMonth(String, Int32, Int32)"/>
        public DateTime GetLastWorkingDayOfMonth(String countryIsoCode, Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(countryIsoCode, year, month);

            FirstAndLastWorkingDays firstAndLastWorkingDays = GetFirstAndLastWorkingDaysOfMonth(countryIsoCode, year, month);
            DateTime retVal = firstAndLastWorkingDays.LastWorkingDay;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        private FirstAndLastWorkingDays GetFirstAndLastWorkingDaysOfMonth(String countryIsoCode, Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(countryIsoCode, year, month);

            DateTime startOfMonth = DateTimeService.GetStartOfMonth(year, month);
            DateTime endOfMonth = DateTimeService.GetEndOfMonth(year, month);

            // Initialise to default values based on calendar dates
            FirstAndLastWorkingDays retVal = new FirstAndLastWorkingDays
            {
                FirstWorkingDay = startOfMonth,
                LastWorkingDay = endOfMonth,
            };

            String sql = GetSqlFromFile("[core].[Calendar]");

            DatabaseParameters databaseParameters =
            [
                CreateParameter(Functions.GetListOfWorkingDates.Parameters.CountryIsoCode, countryIsoCode),
                CreateParameter(Functions.GetListOfWorkingDates.Parameters.StartDate, startOfMonth.Date),
                CreateParameter(Functions.GetListOfWorkingDates.Parameters.EndDate, endOfMonth.Date),
            ];

            DataTable dt = ExecuteDataTable(sql, CommandType.Text, databaseParameters);

            if (dt.Rows.Count > 0)
            {
                retVal = new FirstAndLastWorkingDays
                {
                    FirstWorkingDay = Convert.ToDateTime(dt.Rows[0]["FirstWorkingDayOfMonth"]),
                    LastWorkingDay = Convert.ToDateTime(dt.Rows[0]["LastWorkingDayOfMonth"]),
                };
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
