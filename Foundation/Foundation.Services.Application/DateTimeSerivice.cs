//-----------------------------------------------------------------------
// <copyright file="DateTimeService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <ineritdoc cref="IDateTimeService" />
    [DependencyInjectionTransient]
    public class DateTimeService : ServiceBase, IDateTimeService
    {
#if (DEBUG)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startOfWeek"></param>
        /// <param name="injectedSystemUtcDateTime"></param>
        /// <param name="injectedSystemLocalDateTime"></param>
        internal DateTimeService
        (
            DayOfWeek startOfWeek,
            DateTime injectedSystemUtcDateTime,
            DateTime injectedSystemLocalDateTime
        ) :
            this()
        {
            LoggingHelpers.TraceCallEnter();

            UseInjectedValues = true;

            InjectedStartOfWeek = startOfWeek;
            InjectedSystemUtcDateTime = injectedSystemUtcDateTime;
            InjectedSystemLocalDateTime = injectedSystemLocalDateTime;

            LoggingHelpers.TraceCallReturn();
        }

        private Boolean UseInjectedValues { get; }

        private DayOfWeek InjectedStartOfWeek { get; }
        private DateTime InjectedSystemUtcDateTime { get; }
        private DateTime InjectedSystemLocalDateTime { get; }
#endif

        /// <summary>
        /// 
        /// </summary>
        public DateTimeService
        (
        ) :
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter();

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IDateTimeService.StartOfWeek"/>
        public DayOfWeek StartOfWeek
        {
            get
            {
                DayOfWeek retVal = DayOfWeek.Monday;

#if (DEBUG)
                if (UseInjectedValues)
                {
                    retVal = InjectedStartOfWeek;
                }
#endif

                return retVal;
            }
        }

        /// <inheritdoc cref="IDateTimeService.SystemUtcDateTimeNow"/>
        public DateTime SystemUtcDateTimeNow
        {
            get
            {
                DateTime retVal = DateTime.UtcNow;

#if (DEBUG)
                if (UseInjectedValues)
                {
                    retVal = InjectedSystemUtcDateTime;
                }
#endif

                return retVal;
            }
        }

        /// <inheritdoc cref="IDateTimeService.SystemUtcDateTimeNowWithoutMilliseconds"/>
        public DateTime SystemUtcDateTimeNowWithoutMilliseconds
        {
            get
            {
                DateTime retVal = SystemUtcDateTimeNow;
                retVal = retVal.AddTicks(-(retVal.Ticks % TimeSpan.TicksPerSecond));
                return retVal;
            }
        }

        /// <inheritdoc cref="IDateTimeService.LocalDateTimeNow"/>
        public DateTime LocalDateTimeNow
        {
            get
            {
                DateTime retVal = DateTime.Now;

#if (DEBUG)
                if (UseInjectedValues)
                {
                    retVal = InjectedSystemLocalDateTime;
                }
#endif

                return retVal;
            }
        }

        /// <inheritdoc cref="IDateTimeService.MakeUtcDateTime(DateTime)"/>
        public DateTime MakeUtcDateTime(DateTime dateTime)
        {
            LoggingHelpers.TraceCallEnter(dateTime);

            DateTime retVal = MakeUtcDateTime(dateTime.Date, dateTime.TimeOfDay);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.MakeUtcDateTime(DateTime, TimeSpan)"/>
        public DateTime MakeUtcDateTime(DateTime date, TimeSpan time)
        {
            LoggingHelpers.TraceCallEnter(date, time);

            DateTime retVal = MakeUtcDateTime(date, time.Hours, time.Minutes, time.Seconds);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.MakeUtcDateTime(DateTime, Int32, Int32, Int32)"/>
        public DateTime MakeUtcDateTime(DateTime date, Int32 hours, Int32 minutes, Int32 seconds)
        {
            LoggingHelpers.TraceCallEnter(date, hours, minutes, seconds);

            DateTime retVal = new DateTime(date.Year, date.Month, date.Day, hours, minutes, seconds, DateTimeKind.Utc);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetStartOfLastWeek()"/>
        public DateTime GetStartOfLastWeek()
        {
            DateTime lastWeek = SystemUtcDateTimeNow.AddWeeks(-1);
            DateTime retVal = GetStartOfWeek(lastWeek);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetEndOfLastWeek()"/>
        public DateTime GetEndOfLastWeek()
        {
            DateTime lastWeek = SystemUtcDateTimeNow.AddWeeks(-1);
            DateTime retVal = GetEndOfWeek(lastWeek);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetStartOfCurrentWeek()"/>
        public DateTime GetStartOfCurrentWeek()
        {
            DateTime currentDateTime = SystemUtcDateTimeNow;
            DateTime retVal = GetStartOfWeek(currentDateTime);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetEndOfCurrentWeek()"/>
        public DateTime GetEndOfCurrentWeek()
        {
            DateTime currentDateTime = SystemUtcDateTimeNow;
            DateTime retVal = GetEndOfWeek(currentDateTime);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetStartOfNextWeek()"/>
        public DateTime GetStartOfNextWeek()
        {
            DateTime lastWeek = SystemUtcDateTimeNow.AddWeeks(1);
            DateTime retVal = GetStartOfWeek(lastWeek);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetEndOfNextWeek()"/>
        public DateTime GetEndOfNextWeek()
        {
            DateTime lastWeek = SystemUtcDateTimeNow.AddWeeks(1);
            DateTime retVal = GetEndOfWeek(lastWeek);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetStartOfWeek(Int32, Int32, Int32)"/>
        public DateTime GetStartOfWeek(Int32 year, Int32 month, Int32 day)
        {
            LoggingHelpers.TraceCallEnter(year, month, day);

            DateTime workingDate = new DateTime(year, month, day);
            DateTime retVal = GetStartOfWeek(workingDate);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetStartOfWeek(DateTime)"/>
        public DateTime GetStartOfWeek(DateTime targetDate)
        {
            LoggingHelpers.TraceCallEnter(targetDate);

            Int32 adjustment = ((Int32)targetDate.DayOfWeek - (Int32)StartOfWeek);
            if (adjustment < 0) adjustment += 7;

            DateTime retVal = targetDate.AddDays(adjustment * -1);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetEndOfWeek(Int32, Int32, Int32)"/>
        public DateTime GetEndOfWeek(Int32 year, Int32 month, Int32 day)
        {
            LoggingHelpers.TraceCallEnter(year, month, day);

            DateTime workingDate = new DateTime(year, month, day);
            DateTime retVal = GetEndOfWeek(workingDate);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetEndOfWeek(DateTime)"/>
        public DateTime GetEndOfWeek(DateTime targetDate)
        {
            LoggingHelpers.TraceCallEnter(targetDate);

            Int32 adjustment = 6 - ((Int32)targetDate.DayOfWeek - (Int32)StartOfWeek);
            if (adjustment >= 7) adjustment -= 7;

            DateTime retVal = targetDate.AddDays(adjustment);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetStartOfLastMonth"/>
        public DateTime GetStartOfLastMonth()
        {
            DateTime lastMonth = SystemUtcDateTimeNow.AddMonths(-1);
            DateTime retVal = GetStartOfMonth(lastMonth);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetEndOfLastMonth"/>
        public DateTime GetEndOfLastMonth()
        {
            DateTime lastMonth = SystemUtcDateTimeNow.AddMonths(-1);
            DateTime retVal = GetEndOfMonth(lastMonth);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetStartOfCurrentMonth()"/>
        public DateTime GetStartOfCurrentMonth()
        {
            DateTime currentDateTime = SystemUtcDateTimeNow;
            DateTime retVal = GetStartOfMonth(currentDateTime);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetEndOfCurrentMonth"/>
        public DateTime GetEndOfCurrentMonth()
        {
            DateTime currentDateTime = SystemUtcDateTimeNow;
            DateTime retVal = GetEndOfMonth(currentDateTime);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetStartOfNextMonth"/>
        public DateTime GetStartOfNextMonth()
        {
            DateTime lastMonth = SystemUtcDateTimeNow.AddMonths(1);
            DateTime retVal = GetStartOfMonth(lastMonth);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetEndOfNextMonth"/>
        public DateTime GetEndOfNextMonth()
        {
            DateTime lastMonth = SystemUtcDateTimeNow.AddMonths(1);
            DateTime retVal = GetEndOfMonth(lastMonth);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetStartOfMonth(DateTime)"/>
        public DateTime GetStartOfMonth(DateTime targetDate)
        {
            LoggingHelpers.TraceCallEnter(targetDate);

            Int32 year = targetDate.Year;
            Int32 month = targetDate.Month;

            DateTime retVal = GetStartOfMonth(year, month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetStartOfMonth(Int32, Int32)"/>
        public DateTime GetStartOfMonth(Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(year, month);

            DateTime retVal = new DateTime(year, month, 1);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetEndOfMonth(DateTime)"/>
        public DateTime GetEndOfMonth(DateTime targetDate)
        {
            LoggingHelpers.TraceCallEnter(targetDate);

            Int32 year = targetDate.Year;
            Int32 month = targetDate.Month;

            DateTime retVal = GetEndOfMonth(year, month);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetEndOfMonth(Int32, Int32)"/>
        public DateTime GetEndOfMonth(Int32 year, Int32 month)
        {
            LoggingHelpers.TraceCallEnter(year, month);

            Int32 lastDay = DateTime.DaysInMonth(year, month);

            DateTime retVal = new DateTime(year, month, lastDay);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetStartOfRollingPeriod(DatePeriod, Int32)"/>
        public DateTime GetStartOfRollingPeriod(DatePeriod datePeriod, Int32 interval)
        {
            LoggingHelpers.TraceCallEnter(datePeriod, interval);

            DateTime retVal = SystemUtcDateTimeNow.Date.Add(datePeriod, (interval * -1));
            switch (datePeriod)
            {
                case DatePeriod.Days: /* No change needed */ break;
                case DatePeriod.Weeks: retVal = GetStartOfWeek(retVal); break;
                case DatePeriod.Months:
                case DatePeriod.Years: retVal = GetStartOfMonth(retVal); break;
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetEndOfRollingPeriod(DatePeriod, Int32)"/>
        public DateTime GetEndOfRollingPeriod(DatePeriod datePeriod, Int32 interval)
        {
            LoggingHelpers.TraceCallEnter(datePeriod, interval);

            DateTime workingDate = SystemUtcDateTimeNow.Date.Add(datePeriod, -1);
            DateTime retVal = workingDate;
            switch (datePeriod)
            {
                case DatePeriod.Days: /* No change needed */ break;
                case DatePeriod.Weeks: retVal = GetStartOfWeek(retVal); break;
                case DatePeriod.Months:
                case DatePeriod.Years: retVal = GetEndOfMonth(retVal); break;
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDateTimeService.GetStartOfPreviousQuarter()"/>
        public DateTime GetStartOfPreviousQuarter()
        {
            LoggingHelpers.TraceCallEnter();

            DateTime currentDateTime = SystemUtcDateTimeNow.Date;
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

        /// <inheritdoc cref="IDateTimeService.GetEndOfPreviousQuarter()"/>
        public DateTime GetEndOfPreviousQuarter()
        {
            LoggingHelpers.TraceCallEnter();

            DateTime currentDateTime = SystemUtcDateTimeNow.Date;
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

        /// <inheritdoc cref="IDateTimeService.GetStartOfCurrentQuarter()"/>
        public DateTime GetStartOfCurrentQuarter()
        {
            LoggingHelpers.TraceCallEnter();

            DateTime currentDateTime = SystemUtcDateTimeNow.Date;
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

        /// <inheritdoc cref="IDateTimeService.GetEndOfCurrentQuarter()"/>
        public DateTime GetEndOfCurrentQuarter()
        {
            LoggingHelpers.TraceCallEnter();

            DateTime currentDateTime = SystemUtcDateTimeNow.Date;
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

        /// <inheritdoc cref="IDateTimeService.GetStartOfNextQuarter()"/>
        public DateTime GetStartOfNextQuarter()
        {
            LoggingHelpers.TraceCallEnter();

            DateTime currentDateTime = SystemUtcDateTimeNow.Date;
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

        /// <inheritdoc cref="IDateTimeService.GetEndOfCurrentQuarter()"/>
        public DateTime GetEndOfNextQuarter()
        {
            LoggingHelpers.TraceCallEnter();

            DateTime currentDateTime = SystemUtcDateTimeNow.Date;
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
