//-----------------------------------------------------------------------
// <copyright file="ICalendarService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines methods for determining working and non-working days, as well as calculating relevant dates based on
    /// country-specific calendars and business rules.
    /// </summary>
    /// <remarks>
    /// Implementations of this interface should account for weekends, public holidays, and other
    /// non-working days as defined by the specified country. Methods support various scenarios, including checking if a
    /// date is a working day, finding the next or previous working day, and determining the first or last working day
    /// of a month. This interface is intended for use in applications that require accurate business day calculations
    /// across different locales.
    /// </remarks>
    public interface ICalendarService
    {
        /// <summary>
        /// Determines whether the specified date is a non-working day in the given country.
        /// </summary>
        /// <param name="countryCode">A two-letter ISO country code representing the country for which to check the non-working day status. Cannot
        /// be null or empty.</param>
        /// <param name="date">The date to evaluate for non-working day status.</param>
        /// <returns>
        /// true if the specified date is a non-working day in the specified country; otherwise, false.
        /// </returns>
        Boolean IsNonWorkingDay(String countryCode, DateTime date);

        /// <summary>
        /// Returns the next working day after the specified date, based on the working calendar of the given country.
        /// </summary>
        /// <remarks>
        /// The definition of a working day may vary by country and typically excludes weekends
        /// and official public holidays. The method does not include the input date itself, even if it is a working
        /// day.
        /// </remarks>
        /// <param name="countryCode">The ISO 3166-1 alpha-2 country code that determines the set of public holidays and weekends to consider when
        /// calculating the next working day. Cannot be null or empty.</param>
        /// <param name="date">The date from which to search for the next working day. The returned date will be after this value.</param>
        /// <returns>
        /// A DateTime value representing the next working day after the specified date, according to the working
        /// calendar of the specified country.
        /// </returns>
        DateTime GetNextWorkingDay(String countryCode, DateTime date);

        /// <summary>
        /// Calculates the next working day that can accommodate a specified duration within a given working time window
        /// for a particular country.
        /// </summary>
        /// <remarks>
        /// The method accounts for weekends and country-specific holidays when determining
        /// working days. If the duration cannot be accommodated on the input date, the search continues on subsequent
        /// working days.
        /// </remarks>
        /// <param name="countryCode">The ISO country code used to determine local working days and holidays. Cannot be null or empty.</param>
        /// <param name="date">The date from which to start the search for the next working day. The time component is considered when
        /// evaluating the working time window.</param>
        /// <param name="workingTimeWindow">The time window representing valid working hours within a day. The duration must fit entirely within this
        /// window.</param>
        /// <param name="duration">The required duration that must fit within the working time window. Must be a positive time span.</param>
        /// <returns>
        /// A DateTime representing the next working day and time when the specified duration can be scheduled within
        /// the working time window. Returns a value greater than or equal to the input date.
        /// </returns>
        DateTime GetNextWorkingDay(String countryCode, DateTime date, TimeWindow workingTimeWindow, TimeSpan duration);

        /// <summary>
        /// Calculates the next working day based on the specified country, starting date, interval type, and interval
        /// count.
        /// </summary>
        /// <remarks>
        /// The calculation takes into account country-specific weekends and public holidays. If
        /// the resulting date falls on a non-working day, it is adjusted to the next available working day.
        /// </remarks>
        /// <param name="countryCode">The ISO country code used to determine the local working days and holidays.</param>
        /// <param name="date">The date from which to start the calculation.</param>
        /// <param name="intervalType">The type of interval to use when calculating the next working day, such as days, weeks, or months.</param>
        /// <param name="interval">The number of intervals to advance from the starting date. Must be a positive integer.</param>
        /// <returns>
        /// A DateTime value representing the next working day after applying the specified interval. The returned date
        /// will fall on a working day according to the rules of the specified country.
        /// </returns>
        DateTime GetNextWorkingDay(String countryCode, DateTime date, ScheduleInterval intervalType, Int32 interval);

        /// <summary>
        /// Determines whether the specified date is a working day in the given country, or returns the next working day
        /// if it is not.
        /// </summary>
        /// <remarks>
        /// The definition of a working day may vary by country and may exclude weekends and
        /// public holidays. The method does not modify the input date if it is already a working day.
        /// </remarks>
        /// <param name="countryCode">The ISO 3166-1 alpha-2 country code used to determine the working day calendar. Cannot be null or empty.</param>
        /// <param name="date">The date to check for being a working day.</param>
        /// <returns>
        /// A DateTime representing the specified date if it is a working day; otherwise, the next working day in the
        /// specified country.
        /// </returns>
        DateTime CheckIsWorkingDayOrGetNextWorkingDay(String countryCode, DateTime date);

        /// <summary>
        /// Returns the first working day of the month for the specified country and date.
        /// </summary>
        /// <remarks>
        /// The definition of a working day may vary by country and can include considerations
        /// for weekends and public holidays. The returned date is always within the same month as the input
        /// date.
        /// </remarks>
        /// <param name="countryCode">The ISO 3166-1 alpha-2 country code used to determine local working days and holidays. Cannot be null or
        /// empty.</param>
        /// <param name="date">A date within the month for which to find the first working day. Only the month and year components are
        /// considered.</param>
        /// <returns>
        /// A DateTime representing the first working day of the specified month according to the country's local
        /// calendar and holidays.
        /// </returns>
        DateTime GetFirstWorkingDayOfMonth(String countryCode, DateTime date);

        /// <summary>
        /// Returns the first working day of the specified month and year for the given country code.
        /// </summary>
        /// <remarks>
        /// A working day is defined based on the standard business days and public holidays of
        /// the specified country. The returned date is always within the specified month.
        /// </remarks>
        /// <param name="countryCode">The ISO 3166-1 alpha-2 country code used to determine local weekends and public holidays. Cannot be null or
        /// empty.</param>
        /// <param name="year">The year for which to find the first working day. Must be a valid calendar year.</param>
        /// <param name="month">The month (1–12) for which to find the first working day.</param>
        /// <returns>
        /// A DateTime representing the first working day of the specified month and year, according to the local
        /// calendar and holidays for the given country code.
        /// </returns>
        DateTime GetFirstWorkingDayOfMonth(String countryCode, Int32 year, Int32 month);

        /// <summary>
        /// Calculates the last working day of the month for a specified country and date.
        /// </summary>
        /// <remarks>
        /// The definition of a working day depends on the country specified by the country code.
        /// Public holidays and weekends are excluded based on local conventions. The returned date is always within the
        /// same month as the input date.
        /// </remarks>
        /// <param name="countryCode">The ISO 3166-1 alpha-2 country code used to determine local weekends and public holidays. Cannot be null or
        /// empty.</param>
        /// <param name="date">A date within the month for which to find the last working day. Only the month and year components are
        /// considered.</param>
        /// <returns>
        /// A DateTime representing the last working day of the specified month, according to the country's weekend and
        /// holiday rules.
        /// </returns>
        DateTime GetLastWorkingDayOfMonth(String countryCode, DateTime date);

        /// <summary>
        /// Returns the date of the last working day of the specified month and year for the given country code.
        /// </summary>
        /// <remarks>
        /// A working day is defined based on the country's standard weekends and recognized
        /// public holidays. The returned date will be the last weekday of the month that is not a weekend or public
        /// holiday in the specified country.
        /// </remarks>
        /// <param name="countryCode">The ISO 3166-1 alpha-2 country code used to determine local weekends and public holidays. Cannot be null or
        /// empty.</param>
        /// <param name="year">The year for which to calculate the last working day. Must be a valid calendar year.</param>
        /// <param name="month">The month (1–12) for which to calculate the last working day.</param>
        /// <returns>
        /// A DateTime representing the last working day of the specified month and year, according to the country's
        /// local calendar.
        /// </returns>
        DateTime GetLastWorkingDayOfMonth(String countryCode, Int32 year, Int32 month);
    }
}
