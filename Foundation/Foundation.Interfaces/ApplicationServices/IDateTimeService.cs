//-----------------------------------------------------------------------
// <copyright file="IDateTimeService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Date/Time Service
    /// </summary>
    public interface IDateTimeService
    {
        /// <summary>
        /// Gets the start of week. This is currently Monday
        /// </summary>
        /// <value>
        /// The start of week.
        /// </value>
        DayOfWeek StartOfWeek { get; }

        /// <summary>
        /// Gets the utc date time now.
        /// </summary>
        /// <value>
        /// The Utc date time now.
        /// </value>
        DateTime SystemUtcDateTimeNow { get; }

        /// <summary>
        /// Gets the system date time now.
        /// </summary>
        /// <value>
        /// The system date time now.
        /// </value>
        DateTime SystemUtcDateTimeNowWithoutMilliseconds { get; }

        /// <summary>
        /// Gets the local date time now.
        /// </summary>
        /// <value>
        /// The local date time now.
        /// </value>
        DateTime LocalDateTimeNow { get; }

        /// <summary>
        /// Makes a UTC version of the supplied <paramref name="dateTime"/>
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        DateTime MakeUtcDateTime(DateTime dateTime);

        /// <summary>
        /// Makes a UTC version of the supplied <paramref name="date"/> and <paramref name="time"/>
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        DateTime MakeUtcDateTime(DateTime date, TimeSpan time);

        /// <summary>
        /// Makes a UTC version of the supplied <paramref name="date"/> and <paramref name="hours"/>, <paramref name="minutes"/>, <paramref name="seconds"/>
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        DateTime MakeUtcDateTime(DateTime date, Int32 hours, Int32 minutes, Int32 seconds);

        /// <summary>
        /// Gets the start of last week.
        /// </summary>
        /// <value>
        /// The start of last week.
        /// </value>
        DateTime GetStartOfLastWeek();

        /// <summary>
        /// Gets the end of last week.
        /// </summary>
        /// <value>
        /// The end of last week.
        /// </value>
        DateTime GetEndOfLastWeek();

        /// <summary>
        /// Gets the start of current week.
        /// </summary>
        /// <value>
        /// The start of week.
        /// </value>
        DateTime GetStartOfCurrentWeek();

        /// <summary>
        /// Gets the end of current week.
        /// </summary>
        /// <value>
        /// The end of week.
        /// </value>
        DateTime GetEndOfCurrentWeek();

        /// <summary>
        /// Gets the start of next week.
        /// </summary>
        /// <value>
        /// The start of last week.
        /// </value>
        DateTime GetStartOfNextWeek();

        /// <summary>
        /// Gets the end of next week.
        /// </summary>
        /// <value>
        /// The end of last week.
        /// </value>
        DateTime GetEndOfNextWeek();

        /// <summary>
        /// Gets the start of the week
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        DateTime GetStartOfWeek(Int32 year, Int32 month, Int32 day);

        /// <summary>
        /// Gets the start of the <paramref name="targetDate"/>
        /// </summary>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        DateTime GetStartOfWeek(DateTime targetDate);

        /// <summary>
        /// Gets the end of the week
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        DateTime GetEndOfWeek(Int32 year, Int32 month, Int32 day);

        /// <summary>
        /// Gets the end of the <paramref name="targetDate"/>
        /// </summary>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        DateTime GetEndOfWeek(DateTime targetDate);

        /// <summary>
        /// Gets the start of last month.
        /// </summary>
        /// <value>
        /// The start of last month.
        /// </value>
        DateTime GetStartOfLastMonth();

        /// <summary>
        /// Gets the end of last month.
        /// </summary>
        /// <value>
        /// The end of last month.
        /// </value>
        DateTime GetEndOfLastMonth();

        /// <summary>
        /// Gets the start of current month/year.
        /// </summary>
        /// <value>
        /// The start of month.
        /// </value>
        DateTime GetStartOfCurrentMonth();

        /// <summary>
        /// Gets the end of current month/year.
        /// </summary>
        /// <value>
        /// The end of month.
        /// </value>
        DateTime GetEndOfCurrentMonth();

        /// <summary>
        /// Gets the start of next month.
        /// </summary>
        /// <value>
        /// The start of last month.
        /// </value>
        DateTime GetStartOfNextMonth();

        /// <summary>
        /// Gets the end of next month.
        /// </summary>
        /// <value>
        /// The end of last month.
        /// </value>
        DateTime GetEndOfNextMonth();

        /// <summary>
        /// Gets the start of the <paramref name="targetDate"/>
        /// </summary>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        DateTime GetStartOfMonth(DateTime targetDate);

        /// <summary>
        /// Gets the start of the month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        DateTime GetStartOfMonth(Int32 year, Int32 month);

        /// <summary>
        /// Gets the end of the <paramref name="targetDate"/>
        /// </summary>
        /// <param name="targetDate"></param>
        /// <returns></returns>
        DateTime GetEndOfMonth(DateTime targetDate);

        /// <summary>
        /// Gets the end of the month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        DateTime GetEndOfMonth(Int32 year, Int32 month);

        /// <summary>
        /// Gets the first date of the previous period.
        /// It uses the current date to determine the rolling period based on the supplied <paramref name="datePeriod"/>
        /// <example>
        /// If today is 15th June 2024.
        /// StartOfRollingPeriod(DatePeriod.Months, 3) => 1st March 2024
        /// </example>
        /// </summary>
        /// <param name="datePeriod">>The <see cref="DatePeriod"/></param>
        /// <param name="interval">The number of <paramref name="datePeriod"/> to consider</param>
        /// <returns></returns>
        DateTime GetStartOfRollingPeriod(DatePeriod datePeriod, Int32 interval);

        /// <summary>
        /// Gets the last date of the Rolling Period
        /// It uses the current date to determine the rolling period based on the supplied <paramref name="datePeriod"/>
        /// <example>
        /// If today is 15th June 2024.
        /// EndOfRollingPeriod(DatePeriod.Months, 3) => 30th April 2024
        /// </example>
        /// </summary>
        /// <param name="datePeriod">>The <see cref="DatePeriod"/></param>
        /// <param name="interval">The number of <paramref name="datePeriod"/> to consider</param>
        /// <returns></returns>
        DateTime GetEndOfRollingPeriod(DatePeriod datePeriod, Int32 interval);

        /// <summary>
        /// Gets the first date of the previous quarter
        /// <para>
        /// Month = 01...03 => Previous Quarter = 10->12, Oct, Nov, Dec
        /// </para>
        /// <para>
        /// Month = 04...06 => Previous Quarter = 01->03, Jan, Feb, Mar
        /// </para>
        /// <para>
        /// Month = 07...09 => Previous Quarter = 04->06, Apr, May, Jun
        /// </para>
        /// <para>
        /// Month = 10...12 => Previous Quarter = 07->09, Jul, Aug, Sep
        /// </para>
        /// </summary>
        /// <returns></returns>
        DateTime GetStartOfPreviousQuarter();

        /// <summary>
        /// Gets the last date of the previous quarter
        /// <para>
        /// Month = 01...03 => Previous Quarter = 10->12, Oct, Nov, Dec
        /// </para>
        /// <para>
        /// Month = 04...06 => Previous Quarter = 01->03, Jan, Feb, Mar
        /// </para>
        /// <para>
        /// Month = 07...09 => Previous Quarter = 04->06, Apr, May, Jun
        /// </para>
        /// <para>
        /// Month = 10...12 => Previous Quarter = 07->09, Jul, Aug, Sep
        /// </para>
        /// </summary>
        /// <returns></returns>
        DateTime GetEndOfPreviousQuarter();

        /// <summary>
        /// Gets the first date of the current quarter
        /// <para>
        /// Month = 01...03 => Current Quarter = 01->03, Jan, Feb, Mar
        /// </para>
        /// <para>
        /// Month = 04...06 => Current Quarter = 04->06, Apr, May, Jun
        /// </para>
        /// <para>
        /// Month = 07...09 => Current Quarter = 07->09, Jul, Aug, Sep
        /// </para>
        /// <para>
        /// Month = 10...12 => Current Quarter = 10->12, Oct, Nov, Dec
        /// </para>
        /// </summary>
        /// <returns></returns>
        DateTime GetStartOfCurrentQuarter();

        /// <summary>
        /// Gets the last date of the current quarter
        /// <para>
        /// Month = 01...03 => Current Quarter = 01->03, Jan, Feb, Mar
        /// </para>
        /// <para>
        /// Month = 04...06 => Current Quarter = 04->06, Apr, May, Jun
        /// </para>
        /// <para>
        /// Month = 07...09 => Current Quarter = 07->09, Jul, Aug, Sep
        /// </para>
        /// <para>
        /// Month = 10...12 => Current Quarter = 10->12, Oct, Nov, Dec
        /// </para>
        /// </summary>
        /// <returns></returns>
        DateTime GetEndOfCurrentQuarter();

        /// <summary>
        /// Gets the first date of the next quarter
        /// <para>
        /// Month = 01...03 => Next Quarter = 04->06, Apr, May, Jun
        /// </para>
        /// <para>
        /// Month = 04...06 => Next Quarter = 07->09, Jul, Aug, Sep
        /// </para>
        /// <para>
        /// Month = 07...09 => Next Quarter = 10->12, Oct, Nov, Dec
        /// </para>
        /// <para>
        /// Month = 10...12 => Next Quarter = 01->03, Jan, Feb, Mar
        /// </para>
        /// </summary>
        /// <returns></returns>
        DateTime GetStartOfNextQuarter();

        /// <summary>
        /// Gets the last date of the next quarter
        /// <para>
        /// Month = 01...03 => Next Quarter = 04->06, Apr, May, Jun
        /// </para>
        /// <para>
        /// Month = 04...06 => Next Quarter = 07->09, Jul, Aug, Sep
        /// </para>
        /// <para>
        /// Month = 07...09 => Next Quarter = 10->12, Oct, Nov, Dec
        /// </para>
        /// <para>
        /// Month = 10...12 => Next Quarter = 01->03, Jan, Feb, Mar
        /// </para>
        /// </summary>
        /// <returns></returns>
        DateTime GetEndOfNextQuarter();
    }
}
