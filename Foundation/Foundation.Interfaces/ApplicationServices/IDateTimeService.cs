//-----------------------------------------------------------------------
// <copyright file="IDateTimeService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines a contract for retrieving and manipulating date and time values, including current system times, week,
    /// month, quarter, and year boundaries, as well as utility methods for constructing UTC date and time values.
    /// </summary>
    /// <remarks>
    /// This interface provides a comprehensive set of methods and properties for working with dates
    /// and times in both local and UTC contexts. It is intended for scenarios where consistent and testable access to
    /// date and time information is required, such as in business logic, scheduling, or reporting. Implementations
    /// should ensure thread safety if used in multithreaded environments.
    /// </remarks>
    public interface IDateTimeService
    {
        /// <summary>
        /// Gets the day of the week that is considered the start of the week for this context.
        /// </summary>
        DayOfWeek StartOfWeek { get; }

        /// <summary>
        /// Gets the current date and time in Coordinated Universal Time (UTC) as provided by the system clock.
        /// </summary>
        /// <returns>
        /// A DateTime value representing the current date and time in UTC.
        /// </returns>
        DateTime SystemUtcDateTimeNow { get; }

        /// <summary>
        /// Gets the current system UTC date and time with the milliseconds component set to zero.
        /// </summary>
        /// <returns>
        /// A DateTime value representing the current system UTC date and time with the milliseconds component set to zero.
        /// </returns>
        DateTime SystemUtcDateTimeNowWithoutMilliseconds { get; }

        /// <summary>
        /// Gets the local date and time as provided by the system clock.
        /// </summary>
        /// <returns>
        /// A DateTime value representing the current local date and time.
        /// </returns>
        DateTime LocalDateTimeNow { get; }

        /// <summary>
        /// Makes a UTC version of the supplied <paramref name="dateTime"/>
        /// </summary>
        /// <param name="dateTime">The date and time to convert to UTC.</param>
        /// <returns>
        /// A DateTime value representing the specified date and time in UTC.
        /// </returns>
        DateTime MakeUtcDateTime(DateTime dateTime);

        /// <summary>
        /// Makes a UTC version of the supplied <paramref name="date"/> and <paramref name="time"/>
        /// </summary>
        /// <param name="date">The date component.</param>
        /// <param name="time">The time component.</param>
        /// <returns>
        /// A DateTime value representing the specified date and time in UTC.
        /// </returns>
        DateTime MakeUtcDateTime(DateTime date, TimeSpan time);

        /// <summary>
        /// Makes a UTC version of the supplied <paramref name="date"/> and time components (<paramref name="hours"/>, <paramref name="minutes"/>, <paramref name="seconds"/>).
        /// </summary>
        /// <param name="date">The date component.</param>
        /// <param name="hours">The hours component.</param>
        /// <param name="minutes">The minutes component.</param>
        /// <param name="seconds">The seconds component.</param>
        /// <returns>
        /// A DateTime value representing the specified date and time in UTC.
        /// </returns>
        DateTime MakeUtcDateTime(DateTime date, Int32 hours, Int32 minutes, Int32 seconds);

        /// <summary>
        /// Gets the start of last week.
        /// </summary>
        /// <returns>
        /// A DateTime value representing the start of last week.
        /// </returns>
        DateTime GetStartOfLastWeek();

        /// <summary>
        /// Gets the end of last week.
        /// </summary>
        /// <returns>
        /// A DateTime value representing the end of last week.
        /// </returns>
        DateTime GetEndOfLastWeek();

        /// <summary>
        /// Gets the start of the current week.
        /// </summary>
        /// <value>
        /// The start of the current week.
        /// </value>
        DateTime GetStartOfCurrentWeek();

        /// <summary>
        /// Gets the end of the current week.
        /// </summary>
        /// <value>
        /// The end of week.
        /// </value>
        DateTime GetEndOfCurrentWeek();

        /// <summary>
        /// Gets the start of next week.
        /// </summary>
        /// <value>
        /// The start of next week.
        /// </value>
        DateTime GetStartOfNextWeek();

        /// <summary>
        /// Gets the end of next week.
        /// </summary>
        /// <value>
        /// The end of next week.
        /// </value>
        DateTime GetEndOfNextWeek();

        /// <summary>
        /// Gets the start of the week
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns>
        /// The start of next week.
        /// </returns>
        DateTime GetStartOfWeek(Int32 year, Int32 month, Int32 day);

        /// <summary>
        /// Gets the start of the <paramref name="targetDate"/>
        /// </summary>
        /// <param name="targetDate"></param>
        /// <returns>
        /// The start of next week.
        /// </returns>
        DateTime GetStartOfWeek(DateTime targetDate);

        /// <summary>
        /// Gets the end of the week
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns>
        /// The end of next week.
        /// </returns>
        DateTime GetEndOfWeek(Int32 year, Int32 month, Int32 day);

        /// <summary>
        /// Gets the end of the <paramref name="targetDate"/>
        /// </summary>
        /// <param name="targetDate"></param>
        /// <returns>
        /// The start of next week.
        /// </returns>
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
        /// The start of the current month/year.
        /// </value>
        DateTime GetStartOfCurrentMonth();

        /// <summary>
        /// Gets the end of current month/year.
        /// </summary>
        /// <value>
        /// The end of the current month/year.
        /// </value>
        DateTime GetEndOfCurrentMonth();

        /// <summary>
        /// Gets the start of next month.
        /// </summary>
        /// <value>
        /// The start of the next month/year.
        /// </value>
        DateTime GetStartOfNextMonth();

        /// <summary>
        /// Gets the end of next month.
        /// </summary>
        /// <value>
        /// The end of the next month/year.
        /// </value>
        DateTime GetEndOfNextMonth();

        /// <summary>
        /// Gets the start of the <paramref name="targetDate"/>
        /// </summary>
        /// <param name="targetDate"></param>
        /// <value>
        /// The start of the month/year.
        /// </value>
        DateTime GetStartOfMonth(DateTime targetDate);

        /// <summary>
        /// Gets the start of the month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <value>
        /// The start of the month/year.
        /// </value>
        DateTime GetStartOfMonth(Int32 year, Int32 month);

        /// <summary>
        /// Gets the end of the <paramref name="targetDate"/>
        /// </summary>
        /// <param name="targetDate"></param>
        /// <value>
        /// The end of the month/year.
        /// </value>
        DateTime GetEndOfMonth(DateTime targetDate);

        /// <summary>
        /// Gets the end of the month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <value>
        /// The end of the month/year.
        /// </value>
        DateTime GetEndOfMonth(Int32 year, Int32 month);


        /// <summary>
        /// Gets the start of last year.
        /// </summary>
        /// <value>
        /// The start of last year.
        /// </value>
        DateTime GetStartOfLastYear();

        /// <summary>
        /// Gets the end of last year.
        /// </summary>
        /// <value>
        /// The end of last year.
        /// </value>
        DateTime GetEndOfLastYear();

        /// <summary>
        /// Gets the start of current year.
        /// </summary>
        /// <value>
        /// The start of the current year.
        /// </value>
        DateTime GetStartOfCurrentYear();

        /// <summary>
        /// Gets the end of current month/year.
        /// </summary>
        /// <value>
        /// The end of the current year.
        /// </value>
        DateTime GetEndOfCurrentYear();

        /// <summary>
        /// Gets the start of next year.
        /// </summary>
        /// <value>
        /// The start of next year.
        /// </value>
        DateTime GetStartOfNextYear();

        /// <summary>
        /// Gets the end of next year.
        /// </summary>
        /// <value>
        /// The end of next year.
        /// </value>
        DateTime GetEndOfNextYear();

        /// <summary>
        /// Gets the start of the <paramref name="targetDate"/>
        /// </summary>
        /// <param name="targetDate"></param>
        /// <value>
        /// The start of next year.
        /// </value>
        DateTime GetStartOfYear(DateTime targetDate);

        /// <summary>
        /// Gets the start of the month
        /// </summary>
        /// <param name="year"></param>
        /// <value>
        /// The start of next year.
        /// </value>
        DateTime GetStartOfYear(Int32 year);

        /// <summary>
        /// Gets the end of the <paramref name="targetDate"/>
        /// </summary>
        /// <param name="targetDate"></param>
        /// <value>
        /// The end of next year.
        /// </value>
        DateTime GetEndOfYear(DateTime targetDate);

        /// <summary>
        /// Gets the end of the year
        /// </summary>
        /// <param name="year"></param>
        /// <value>
        /// The end of next year.
        /// </value>
        DateTime GetEndOfYear(Int32 year);

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
        /// <value>
        /// The start of the rolling period.
        /// </value>
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
        /// <value>
        /// The end of the rolling period.
        /// </value>
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
