//-----------------------------------------------------------------------
// <copyright file="CalendarRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Text;

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
        public CalendarRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ICoreDataProvider coreDataProvider
        ) :
            base
            (
                core,
                systemConfigurationService,
                coreDataProvider.ConnectionName
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, coreDataProvider);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICalendarRepository.IsNonWorkingDay(String, DateTime)"/>
        public Boolean IsNonWorkingDay(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            Boolean retVal;

            StringBuilder sql = new StringBuilder();

            sql.AppendLine($"SELECT {Functions.IsNonWorkingDay} ( {DataLogicProvider.DatabaseParameterPrefix}{FDC.Country.EntityName}{FDC.Country.IsoCode}, {DataLogicProvider.DatabaseParameterPrefix}{FDC.NonWorkingDay.EntityName}{FDC.NonWorkingDay.Date} )");

            IDatabaseParameters databaseParameters = new DatabaseParameters
            {
                CreateParameter($"{FDC.Country.EntityName}{FDC.Country.IsoCode}", countryCode),
                CreateParameter($"{FDC.NonWorkingDay.EntityName}{FDC.NonWorkingDay.Date}", date.Date),
            };

            Object? result = ExecuteScalar(sql.ToString(), CommandType.Text, databaseParameters);

            retVal = Convert.ToBoolean(result);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarRepository.GetNextWorkingDay(String, DateTime, ScheduleInterval, Int32)"/>
        public DateTime GetNextWorkingDay(String countryCode, DateTime date, ScheduleInterval intervalType, Int32 interval)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date, interval);

            DateTime retVal = date.Date;

            StringBuilder sql = new StringBuilder();

            sql.AppendLine($"SELECT {Functions.GetNextWorkingDay.FunctionName} ( {DataLogicProvider.DatabaseParameterPrefix}{Functions.GetNextWorkingDay.Parameters.CountryIsoCode}, {DataLogicProvider.DatabaseParameterPrefix}{Functions.GetNextWorkingDay.Parameters.StartDate}, {DataLogicProvider.DatabaseParameterPrefix}{Functions.GetNextWorkingDay.Parameters.IntervalType}, {DataLogicProvider.DatabaseParameterPrefix}{Functions.GetNextWorkingDay.Parameters.Interval} ) OPTION ( MaxRecursion 2000 )");

            DatabaseParameters databaseParameters =
            [
                CreateParameter(Functions.GetNextWorkingDay.Parameters.CountryIsoCode, countryCode),
                CreateParameter(Functions.GetNextWorkingDay.Parameters.StartDate, date),
                CreateParameter(Functions.GetNextWorkingDay.Parameters.IntervalType, intervalType),
                CreateParameter(Functions.GetNextWorkingDay.Parameters.Interval, interval),
            ];

            Object? objectValue = ExecuteScalar(sql.ToString(), CommandType.Text, databaseParameters);

            if (objectValue != null)
            {
                retVal = Convert.ToDateTime(objectValue);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarRepository.CheckIsWorkingDayOrGetNextWorkingDay(String, DateTime)"/>
        public DateTime CheckIsWorkingDayOrGetNextWorkingDay(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = date.Date;

            StringBuilder sql = new StringBuilder();

            sql.AppendLine($"SELECT {Functions.CheckIsWorkingDayOrGetNextWorkingDay.FunctionName} ( {DataLogicProvider.DatabaseParameterPrefix}{Functions.CheckIsWorkingDayOrGetNextWorkingDay.Parameters.CountryIsoCode},  {DataLogicProvider.DatabaseParameterPrefix}{Functions.CheckIsWorkingDayOrGetNextWorkingDay.Parameters.StartDate} ) OPTION ( MaxRecursion 2000 )");

            DatabaseParameters databaseParameters =
            [
                CreateParameter(Functions.CheckIsWorkingDayOrGetNextWorkingDay.Parameters.CountryIsoCode, countryCode),
                CreateParameter(Functions.CheckIsWorkingDayOrGetNextWorkingDay.Parameters.StartDate, date),
            ];

            Object? objectValue = ExecuteScalar(sql.ToString(), CommandType.Text, databaseParameters);

            if (objectValue != null)
            {
                retVal = Convert.ToDateTime(objectValue);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarRepository.GetStartOfMonth(Int32, Int32)"/>
        public DateTime GetStartOfMonth(Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(year, month);

            DateTime retVal = new DateTime(year, month, 1);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarRepository.GetEndOfMonth(Int32, Int32)"/>
        public DateTime GetEndOfMonth(Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(year, month);

            Int32 lastDay = DateTime.DaysInMonth(year, month);

            DateTime retVal = new DateTime(year, month, lastDay);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarRepository.GetFirstWorkingDayOfMonth(String, DateTime)"/>
        public DateTime GetFirstWorkingDayOfMonth(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = GetFirstWorkingDayOfMonth(countryCode, date.Year, date.Month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarRepository.GetFirstWorkingDayOfMonth(String, Int32, Int32)"/>
        public DateTime GetFirstWorkingDayOfMonth(String countryCode, Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(countryCode, year, month);

            FirstAndLastWorkingDays firstAndLastWorkingDays = GetFirstAndLastWorkingDaysOfMonth(countryCode, year, month);
            DateTime retVal = firstAndLastWorkingDays.FirstWorkingDay;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarRepository.GetLastWorkingDayOfMonth(String, DateTime)"/>
        public DateTime GetLastWorkingDayOfMonth(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = GetLastWorkingDayOfMonth(countryCode, date.Year, date.Month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarRepository.GetLastWorkingDayOfMonth(String, Int32, Int32)"/>
        public DateTime GetLastWorkingDayOfMonth(String countryCode, Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(countryCode, year, month);

            FirstAndLastWorkingDays firstAndLastWorkingDays = GetFirstAndLastWorkingDaysOfMonth(countryCode, year, month);
            DateTime retVal = firstAndLastWorkingDays.LastWorkingDay;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        private FirstAndLastWorkingDays GetFirstAndLastWorkingDaysOfMonth(String countryCode, Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(countryCode, year, month);

            DateTime startOfMonth = GetStartOfMonth(year, month);
            DateTime endOfMonth = GetEndOfMonth(year, month);

            // Initialise to default values based on calendar dates
            FirstAndLastWorkingDays retVal = new FirstAndLastWorkingDays
            {
                FirstWorkingDay = startOfMonth,
                LastWorkingDay = endOfMonth,
            };

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine($"    MIN({Functions.GetListOfWorkingDates.Columns.Date}) AS FirstWorkingDayOfMonth,");
            sql.AppendLine($"    MAX({Functions.GetListOfWorkingDates.Columns.Date}) AS LastWorkingDayOfMonth");
            sql.AppendLine("FROM");
            sql.AppendLine($"    {Functions.GetListOfWorkingDates.FunctionName} ( {DataLogicProvider.DatabaseParameterPrefix}{Functions.GetListOfWorkingDates.Parameters.StartDate}, {DataLogicProvider.DatabaseParameterPrefix}{Functions.GetListOfWorkingDates.Parameters.EndDate} )");
            sql.AppendLine("WHERE");
            sql.AppendLine($"    {Functions.GetListOfWorkingDates.Columns.DayOfWeekIndex} NOT IN ( 1 /* Sunday */ , 7 /* Saturday */ )"); // TODO: Need to move this to a lookup based on the country code

            DatabaseParameters databaseParameters =
            [
                CreateParameter(Functions.GetListOfWorkingDates.Parameters.StartDate, startOfMonth.Date),
                CreateParameter(Functions.GetListOfWorkingDates.Parameters.EndDate, endOfMonth.Date),
            ];

            DataTable dt = ExecuteDataTable(sql.ToString(), CommandType.Text, databaseParameters);

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
