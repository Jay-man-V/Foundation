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
        /// <param name="injectedSystemDateTime"></param>
        internal DateTimeService
        (
            DateTime injectedSystemDateTime
        ) :
            this()
        {
            InjectedSystemDateTime = injectedSystemDateTime;
            UseInjectedSystemDateTime = true;
        }

        private Boolean UseInjectedSystemDateTime { get; }
        private DateTime InjectedSystemDateTime { get; }
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
        public DayOfWeek StartOfWeek => DayOfWeek.Monday;

        /// <inheritdoc cref="IDateTimeService.SystemDateTimeNow"/>
        public DateTime SystemDateTimeNow
        {
            get
            {
                DateTime retVal = DateTime.UtcNow;

#if (DEBUG)
                if (UseInjectedSystemDateTime)
                {
                    retVal = InjectedSystemDateTime;
                }
#endif

                return retVal;
            }
        }

        /// <inheritdoc cref="IDateTimeService.SystemDateTimeNowWithoutMilliseconds"/>
        public DateTime SystemDateTimeNowWithoutMilliseconds
        {
            get
            {
                DateTime retVal = SystemDateTimeNow;
                retVal = retVal.AddTicks(-(retVal.Ticks % TimeSpan.TicksPerSecond));
                return retVal;
            }
        }

        /// <inheritdoc cref="IDateTimeService.StartOfMonth"/>
        public DateTime StartOfMonth
        {
            get
            {
                DateTime currentDateTime = SystemDateTimeNow;
                DateTime retVal = GetStartOfMonth(currentDateTime);

                return retVal;
            }
        }

        /// <inheritdoc cref="IDateTimeService.EndOfMonth"/>
        public DateTime EndOfMonth
        {
            get
            {
                DateTime currentDateTime = SystemDateTimeNow;
                DateTime retVal = GetEndOfMonth(currentDateTime);

                return retVal;
            }
        }

        /// <inheritdoc cref="IDateTimeService.StartOfLastMonth"/>
        public DateTime StartOfLastMonth
        {
            get
            {
                DateTime lastMonth = SystemDateTimeNow.AddMonths(-1);
                DateTime retVal = GetStartOfMonth(lastMonth);

                return retVal;
            }
        }

        /// <inheritdoc cref="IDateTimeService.EndOfLastMonth"/>
        public DateTime EndOfLastMonth
        {
            get
            {
                DateTime lastMonth = SystemDateTimeNow.AddMonths(-1);
                DateTime retVal = GetEndOfMonth(lastMonth);

                return retVal;
            }
        }

        /// <inheritdoc cref="IDateTimeService.GetStartOfMonth(DateTime)"/>
        public DateTime GetStartOfMonth(DateTime targetMonth)
        {
            LoggingHelpers.TraceCallEnter(targetMonth);

            Int32 year = targetMonth.Year;
            Int32 month = targetMonth.Month;

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
        public DateTime GetEndOfMonth(DateTime targetMonth)
        {
            LoggingHelpers.TraceCallEnter(targetMonth);

            Int32 year = targetMonth.Year;
            Int32 month = targetMonth.Month;

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

        /// <inheritdoc cref="IDateTimeService.MakeUtcDateTime(DateTime)"/>
        public DateTime MakeUtcDateTime(DateTime date)
        {
            LoggingHelpers.TraceCallEnter(date);

            DateTime retVal = MakeUtcDateTime(date, date.TimeOfDay);

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

        /// <inheritdoc cref="IDateTimeService.GetStartOfPreviousQuarter()"/>
        public DateTime GetStartOfPreviousQuarter()
        {
            LoggingHelpers.TraceCallEnter();

            DateTime currentDateTime = SystemDateTimeNow.Date;
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

            DateTime currentDateTime = SystemDateTimeNow.Date;
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

            DateTime currentDateTime = SystemDateTimeNow.Date;
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

            DateTime currentDateTime = SystemDateTimeNow.Date;
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

            DateTime currentDateTime = SystemDateTimeNow.Date;
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

            DateTime currentDateTime = SystemDateTimeNow.Date;
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
