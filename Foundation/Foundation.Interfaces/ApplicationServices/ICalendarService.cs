//-----------------------------------------------------------------------
// <copyright file="ICalendarService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Calendar Service
    /// </summary>
    public interface ICalendarService
    {
        /// <summary>
        /// Checks if the supplied <see cref="DateTime"/> is a holiday
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="date"></param>
        /// <returns><see cref="Boolean"/> [True] if it is a holiday, otherwise [False] </returns>
        Boolean IsHoliday(String countryCode, DateTime date);

        /// <summary>
        /// Retrieves the next working day taking into account Weekends and other non-working days
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="date">current <see cref="DateTime"/></param>
        /// <returns><see cref="DateTime"/> - The next working day</returns>
        DateTime GetNextWorkingDay(String countryCode, DateTime date);

        /// <summary>
        /// Retrieves the next working day taking into account Weekends and other non-working days
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="date">current <see cref="DateTime"/></param>
        /// <param name="intervalType">The <see cref="ScheduleInterval"/> that is to be added</param>
        /// <param name="interval">The value to be added to <paramref name="date"/></param>
        /// <returns><see cref="DateTime"/> - The next working day</returns>
        DateTime GetNextWorkingDay(String countryCode, DateTime date, ScheduleInterval intervalType, Int32 interval);

        /// <summary>
        /// Checks if the supplied <see cref="DateTime"/> is a Working day, if it is then returns.
        /// If it isn't then it finds the next working day
        /// Retrieves the next working day taking into account Weekends and other non-working days
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="date">current <see cref="DateTime"/></param>
        /// <returns><see cref="DateTime"/> - The working day</returns>
        DateTime CheckIsWorkingDayOrGetNextWorkingDay(String countryCode, DateTime date);

        /// <summary>
        /// Gets the start of current month/year.
        /// </summary>
        /// <value>
        /// The start of month.
        /// </value>
        DateTime StartOfMonth();

        /// <summary>
        /// Gets the end of current month/year.
        /// </summary>
        /// <value>
        /// The end of month.
        /// </value>
        DateTime EndOfMonth();

        /// <summary>
        /// Gets the start of last month.
        /// </summary>
        /// <value>
        /// The start of last month.
        /// </value>
        DateTime StartOfLastMonth();

        /// <summary>
        /// Gets the end of last month.
        /// </summary>
        /// <value>
        /// The end of last month.
        /// </value>
        DateTime EndOfLastMonth();

        /// <summary>
        /// Gets the start of the <paramref name="targetMonth"/>
        /// </summary>
        /// <param name="targetMonth"></param>
        /// <returns></returns>
        DateTime GetStartOfMonth(DateTime targetMonth);

        /// <summary>
        /// Gets the start of the month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        DateTime GetStartOfMonth(Int32 year, Int32 month);

        /// <summary>
        /// Gets the end of the <paramref name="targetMonth"/>
        /// </summary>
        /// <param name="targetMonth"></param>
        /// <returns></returns>
        DateTime GetEndOfMonth(DateTime targetMonth);

        /// <summary>
        /// Gets the end of the month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        DateTime GetEndOfMonth(Int32 year, Int32 month);

        /// <summary>
        /// Determines the first working date of the year/month of the supplied <paramref name="date"/>
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        DateTime GetFirstWorkingDayOfMonth(String countryCode, DateTime date);

        /// <summary>
        /// Determines the first working date of the year/month of the supplied parameters
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        DateTime GetFirstWorkingDayOfMonth(String countryCode, Int32 year, Int32 month);

        /// <summary>
        /// Determines the last working date of the year/month of the supplied <paramref name="date"/>
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        DateTime GetLastWorkingDayOfMonth(String countryCode, DateTime date);

        /// <summary>
        /// Determines the first working date of the year/month of the supplied parameters
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <returns></returns>
        DateTime GetLastWorkingDayOfMonth(String countryCode, Int32 year, Int32 month);

        /// <summary>
        /// Gets the first date of the previous period
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
        DateTime GetStartOfPreviousPeriod();

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
        DateTime GetEndOfPreviousPeriod();

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
