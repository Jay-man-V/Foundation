//-----------------------------------------------------------------------
// <copyright file="CalendarService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <ineritdoc cref="ICalendarService" />
    [DependencyInjectionTransient]
    public class CalendarService : ServiceBase, ICalendarService
    {
        /// <summary>
        /// 
        /// </summary>
        public CalendarService
        (
            IDateTimeService dateTimeService,
            ICalendarRepository calendarRepository
        ) :
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter();

            DateTimeService = dateTimeService;
            CalendarRepository = calendarRepository;

            LoggingHelpers.TraceCallReturn();
        }

        private IDateTimeService DateTimeService { get; }
        private ICalendarRepository CalendarRepository { get; }

        /// <inheritdoc cref="ICalendarService.IsHoliday(String, DateTime)"/>
        public Boolean IsHoliday(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            Boolean retVal = CalendarRepository.IsNonWorkingDay(countryCode, date);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetNextWorkingDay(String, DateTime)"/>
        public DateTime GetNextWorkingDay(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = GetNextWorkingDay(countryCode, date, ScheduleInterval.Days, 1);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetNextWorkingDay(String, DateTime, ScheduleInterval, Int32)"/>
        public DateTime GetNextWorkingDay(String countryCode, DateTime date, ScheduleInterval intervalType, Int32 interval)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date, intervalType, interval);

            DateTime retVal = CalendarRepository.GetNextWorkingDay(countryCode, date, intervalType, interval);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.CheckIsWorkingDayOrGetNextWorkingDay(String, DateTime)"/>
        public DateTime CheckIsWorkingDayOrGetNextWorkingDay(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = CalendarRepository.CheckIsWorkingDayOrGetNextWorkingDay(countryCode, date);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
        /// <inheritdoc cref="ICalendarService.GetFirstWorkingDayOfMonth(String, DateTime)"/>
        public DateTime GetFirstWorkingDayOfMonth(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = CalendarRepository.GetFirstWorkingDayOfMonth(countryCode, date);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetFirstWorkingDayOfMonth(String, Int32, Int32)"/>
        public DateTime GetFirstWorkingDayOfMonth(String countryCode, Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(countryCode, year, month);

            DateTime retVal = CalendarRepository.GetFirstWorkingDayOfMonth(countryCode, year, month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetLastWorkingDayOfMonth(String, DateTime)"/>
        public DateTime GetLastWorkingDayOfMonth(String countryCode, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryCode, date);

            DateTime retVal = CalendarRepository.GetLastWorkingDayOfMonth(countryCode, date);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetLastWorkingDayOfMonth(String, Int32, Int32)"/>
        public DateTime GetLastWorkingDayOfMonth(String countryCode, Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(countryCode, year, month);

            DateTime retVal = CalendarRepository.GetLastWorkingDayOfMonth(countryCode, year, month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.StartOfMonth"/>
        public DateTime StartOfMonth()
        {
            DateTime currentDateTime = DateTimeService.SystemUtcDateTimeNow;
            DateTime retVal = GetStartOfMonth(currentDateTime);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.EndOfMonth"/>
        public DateTime EndOfMonth()
        {
            DateTime currentDateTime = DateTimeService.SystemUtcDateTimeNow;
            DateTime retVal = GetEndOfMonth(currentDateTime);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.StartOfLastMonth"/>
        public DateTime StartOfLastMonth()
        {
            DateTime lastMonth = DateTimeService.SystemUtcDateTimeNow.AddMonths(-1);
            DateTime retVal = GetStartOfMonth(lastMonth);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.EndOfLastMonth"/>
        public DateTime EndOfLastMonth()
        {
            DateTime lastMonth = DateTimeService.SystemUtcDateTimeNow.AddMonths(-1);
            DateTime retVal = GetEndOfMonth(lastMonth);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetStartOfMonth(DateTime)"/>
        public DateTime GetStartOfMonth(DateTime targetMonth)
        {
            LoggingHelpers.TraceCallEnter(targetMonth);

            Int32 year = targetMonth.Year;
            Int32 month = targetMonth.Month;

            DateTime retVal = GetStartOfMonth(year, month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetStartOfMonth(Int32, Int32)"/>
        public DateTime GetStartOfMonth(Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(year, month);

            DateTime retVal = CalendarRepository.GetStartOfMonth(year, month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetEndOfMonth(DateTime)"/>
        public DateTime GetEndOfMonth(DateTime targetMonth)
        {
            LoggingHelpers.TraceCallEnter(targetMonth);

            Int32 year = targetMonth.Year;
            Int32 month = targetMonth.Month;

            DateTime retVal = GetEndOfMonth(year, month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetEndOfMonth(Int32, Int32)"/>
        public DateTime GetEndOfMonth(Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(year, month);

            DateTime retVal = CalendarRepository.GetEndOfMonth(year, month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetStartOfPreviousPeriod()"/>
        public DateTime GetStartOfPreviousPeriod()
        {
            LoggingHelpers.TraceCallEnter();

            throw new NotImplementedException();

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICalendarService.GetEndOfPreviousPeriod()"/>
        public DateTime GetEndOfPreviousPeriod()
        {
            LoggingHelpers.TraceCallEnter();

            throw new NotImplementedException();

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICalendarService.GetStartOfPreviousQuarter()"/>
        public DateTime GetStartOfPreviousQuarter()
        {
            LoggingHelpers.TraceCallEnter();

            DateTime currentDateTime = DateTimeService.SystemUtcDateTimeNow.Date;
            Int32 currentYear = currentDateTime.Year;
            Int32 currentMonth = currentDateTime.Month;

            // Month = 01...03 => Previous Quarter = 10->12, Oct, Nov, Dec
            // Month = 04...06 => Previous Quarter = 01->03, Jan, Feb, Mar
            // Month = 07...09 => Previous Quarter = 04->06, Apr, May, Jun
            // Month = 10...12 => Previous Quarter = 07->09, Jul, Aug, Sep

            DateTime retVal = currentDateTime;

            if (currentMonth.IsBetween(01, 03))
            {
                retVal = new DateTime(currentYear - 1, 10, 01);
            }

            if (currentMonth.IsBetween(04, 06))
            {
                retVal = new DateTime(currentYear, 01, 01);
            }

            if (currentMonth.IsBetween(07, 09))
            {
                retVal = new DateTime(currentYear, 04, 01);
            }

            if (currentMonth.IsBetween(10, 12))
            {
                retVal = new DateTime(currentYear, 07, 01);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetEndOfPreviousQuarter()"/>
        public DateTime GetEndOfPreviousQuarter()
        {
            LoggingHelpers.TraceCallEnter();

            DateTime currentDateTime = DateTimeService.SystemUtcDateTimeNow.Date;
            Int32 currentYear = currentDateTime.Year;
            Int32 currentMonth = currentDateTime.Month;

            // Month = 01...03 => Previous Quarter = 10->12, Oct, Nov, Dec
            // Month = 04...06 => Previous Quarter = 01->03, Jan, Feb, Mar
            // Month = 07...09 => Previous Quarter = 04->06, Apr, May, Jun
            // Month = 10...12 => Previous Quarter = 07->09, Jul, Aug, Sep

            DateTime retVal = currentDateTime;

            if (currentMonth.IsBetween(01, 03))
            {
                retVal = new DateTime(currentYear - 1, 12, 31);
            }

            if (currentMonth.IsBetween(04, 06))
            {
                retVal = new DateTime(currentYear, 03, 31);
            }

            if (currentMonth.IsBetween(07, 09))
            {
                retVal = new DateTime(currentYear, 06, 30);
            }

            if (currentMonth.IsBetween(10, 12))
            {
                retVal = new DateTime(currentYear, 09, 30);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetStartOfCurrentQuarter()"/>
        public DateTime GetStartOfCurrentQuarter()
        {
            LoggingHelpers.TraceCallEnter();

            DateTime currentDateTime = DateTimeService.SystemUtcDateTimeNow.Date;
            Int32 currentYear = currentDateTime.Year;
            Int32 currentMonth = currentDateTime.Month;

            // Month = 01...03 => Current Quarter = 01->03, Jan, Feb, Mar
            // Month = 04...06 => Current Quarter = 04->06, Apr, May, Jun
            // Month = 07...09 => Current Quarter = 07->09, Jul, Aug, Sep
            // Month = 10...12 => Current Quarter = 10->12, Oct, Nov, Dec

            DateTime retVal = currentDateTime;

            if (currentMonth.IsBetween(01, 03))
            {
                retVal = new DateTime(currentYear, 01, 01);
            }

            if (currentMonth.IsBetween(04, 06))
            {
                retVal = new DateTime(currentYear, 04, 01);
            }

            if (currentMonth.IsBetween(07, 09))
            {
                retVal = new DateTime(currentYear, 07, 01);
            }

            if (currentMonth.IsBetween(10, 12))
            {
                retVal = new DateTime(currentYear, 10, 01);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetEndOfCurrentQuarter()"/>
        public DateTime GetEndOfCurrentQuarter()
        {
            LoggingHelpers.TraceCallEnter();

            DateTime currentDateTime = DateTimeService.SystemUtcDateTimeNow.Date;
            Int32 currentYear = currentDateTime.Year;
            Int32 currentMonth = currentDateTime.Month;

            // Month = 01...03 => Current Quarter = 01->03, Jan, Feb, Mar
            // Month = 04...06 => Current Quarter = 04->06, Apr, May, Jun
            // Month = 07...09 => Current Quarter = 07->09, Jul, Aug, Sep
            // Month = 10...12 => Current Quarter = 10->12, Oct, Nov, Dec

            DateTime retVal = currentDateTime;

            if (currentMonth.IsBetween(01, 03))
            {
                retVal = new DateTime(currentYear, 03, 31);
            }

            if (currentMonth.IsBetween(04, 06))
            {
                retVal = new DateTime(currentYear, 06, 30);
            }

            if (currentMonth.IsBetween(07, 09))
            {
                retVal = new DateTime(currentYear, 09, 30);
            }

            if (currentMonth.IsBetween(10, 12))
            {
                retVal = new DateTime(currentYear, 12, 31);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetStartOfNextQuarter()"/>
        public DateTime GetStartOfNextQuarter()
        {
            LoggingHelpers.TraceCallEnter();

            DateTime currentDateTime = DateTimeService.SystemUtcDateTimeNow.Date;
            Int32 currentYear = currentDateTime.Year;
            Int32 currentMonth = currentDateTime.Month;

            // Month = 01...03 => Next Quarter = 04->06, Apr, May, Jun
            // Month = 04...06 => Next Quarter = 07->09, Jul, Aug, Sep
            // Month = 07...09 => Next Quarter = 10->12, Oct, Nov, Dec
            // Month = 10...12 => Next Quarter = 01->03, Jan, Feb, Mar

            DateTime retVal = currentDateTime;

            if (currentMonth.IsBetween(01, 03))
            {
                retVal = new DateTime(currentYear, 04, 01);
            }

            if (currentMonth.IsBetween(04, 06))
            {
                retVal = new DateTime(currentYear, 07, 01);
            }

            if (currentMonth.IsBetween(07, 09))
            {
                retVal = new DateTime(currentYear, 10, 01);
            }

            if (currentMonth.IsBetween(10, 12))
            {
                retVal = new DateTime(currentYear + 1, 01, 01);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICalendarService.GetEndOfCurrentQuarter()"/>
        public DateTime GetEndOfNextQuarter()
        {
            LoggingHelpers.TraceCallEnter();

            DateTime currentDateTime = DateTimeService.SystemUtcDateTimeNow.Date;
            Int32 currentYear = currentDateTime.Year;
            Int32 currentMonth = currentDateTime.Month;

            // Month = 01...03 => Next Quarter = 04->06, Apr, May, Jun
            // Month = 04...06 => Next Quarter = 07->09, Jul, Aug, Sep
            // Month = 07...09 => Next Quarter = 10->12, Oct, Nov, Dec
            // Month = 10...12 => Next Quarter = 01->03, Jan, Feb, Mar

            DateTime retVal = currentDateTime;

            if (currentMonth.IsBetween(01, 03))
            {
                retVal = new DateTime(currentYear, 06, 30);
            }

            if (currentMonth.IsBetween(04, 06))
            {
                retVal = new DateTime(currentYear, 09, 30);
            }

            if (currentMonth.IsBetween(07, 09))
            {
                retVal = new DateTime(currentYear, 12, 31);
            }

            if (currentMonth.IsBetween(10, 12))
            {
                retVal = new DateTime(currentYear + 1, 03, 31);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
