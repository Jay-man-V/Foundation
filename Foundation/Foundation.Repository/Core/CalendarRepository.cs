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

namespace Foundation.Repository
{
    /// <summary>
    /// Defines the Calendar Data Access class
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
        /// <param name="databaseProvider"></param>
        /// <param name="dateTimeService"></param>
        public CalendarRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ICoreDatabaseProvider databaseProvider,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                systemConfigurationService,
                databaseProvider
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, databaseProvider, dateTimeService);

            DateTimeService = dateTimeService;

            LoggingHelpers.TraceCallReturn();
        }

        private IDateTimeService DateTimeService { get; }

        /// <inheritdoc cref="ICalendarRepository.IsNonWorkingDay(String, DateTime)"/>
        public Boolean IsNonWorkingDay(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            Boolean retVal;

            StringBuilder sql = new StringBuilder();

            sql.AppendLine($"SELECT {FDC.Functions.IsNonWorkingDay} ( {DataLogicProvider.DatabaseParameterPrefix}{FDC.Country.EntityName}{FDC.Country.IsoCode}, {DataLogicProvider.DatabaseParameterPrefix}{FDC.NonWorkingDay.EntityName}{FDC.NonWorkingDay.Date} )");

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

            sql.AppendLine($"SELECT {FDC.Functions.GetNextWorkingDay.FunctionName} {DataLogicProvider.DatabaseParameterPrefix}( {FDC.Functions.GetNextWorkingDay.Parameters.StartDate}, {DataLogicProvider.DatabaseParameterPrefix}{FDC.Functions.GetNextWorkingDay.Parameters.IntervalType}, {DataLogicProvider.DatabaseParameterPrefix}{FDC.Functions.GetNextWorkingDay.Parameters.Interval} ) OPTION ( MaxRecursion 2000 )");

            DatabaseParameters databaseParameters =
            [
                CreateParameter(FDC.Functions.GetNextWorkingDay.Parameters.StartDate, date),
                CreateParameter(FDC.Functions.GetNextWorkingDay.Parameters.IntervalType, intervalType),
                CreateParameter(FDC.Functions.GetNextWorkingDay.Parameters.Interval, interval),
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

            sql.AppendLine($"SELECT {FDC.Functions.CheckIsWorkingDayOrGetNextWorkingDay.FunctionName} ( {DataLogicProvider.DatabaseParameterPrefix}{FDC.Functions.CheckIsWorkingDayOrGetNextWorkingDay.Parameters.StartDate} ) OPTION ( MaxRecursion 2000 )");

            sql = sql.Replace("@", DataLogicProvider.DatabaseParameterPrefix);

            DatabaseParameters databaseParameters =
            [
                CreateParameter(FDC.Functions.CheckIsWorkingDayOrGetNextWorkingDay.Parameters.StartDate, date),
            ];

            Object? objectValue = ExecuteScalar(sql.ToString(), CommandType.Text, databaseParameters);

            if (objectValue != null)
            {
                retVal = Convert.ToDateTime(objectValue);
            }

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

            DateTime startOfMonth = DateTimeService.GetStartOfMonth(year, month);
            DateTime endOfMonth = DateTimeService.GetEndOfMonth(year, month);

            // Initialise to default values based on calendar dates
            FirstAndLastWorkingDays retVal = new FirstAndLastWorkingDays
            {
                FirstWorkingDay = startOfMonth,
                LastWorkingDay = endOfMonth,
            };

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine($"    MIN({FDC.Functions.GetListOfWorkingDates.Columns.Date}) AS FirstWorkingDayOfMonth,");
            sql.AppendLine($"    MAX({FDC.Functions.GetListOfWorkingDates.Columns.Date}) AS LastWorkingDayOfMonth");
            sql.AppendLine("FROM");
            sql.AppendLine($"    {FDC.Functions.GetListOfWorkingDates.FunctionName} ( {DataLogicProvider.DatabaseParameterPrefix}{FDC.Functions.GetListOfWorkingDates.Parameters.StartDate}, {DataLogicProvider.DatabaseParameterPrefix}{FDC.Functions.GetListOfWorkingDates.Parameters.EndDate} )");
            sql.AppendLine("WHERE");
            sql.AppendLine($"    {FDC.Functions.GetListOfWorkingDates.Columns.DayOfWeekIndex} NOT IN ( 1 /* Sunday */ , 7 /* Saturday */ )"); // TODO: Need to move this to a lookup base on the country code

            DatabaseParameters databaseParameters =
            [
                CreateParameter(FDC.Functions.GetListOfWorkingDates.Parameters.StartDate, startOfMonth.Date),
                CreateParameter(FDC.Functions.GetListOfWorkingDates.Parameters.EndDate, endOfMonth.Date),
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
