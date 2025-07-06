//-----------------------------------------------------------------------
// <copyright file="ICalendarRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Non-Working Day Data Access interface
    /// </summary>
    public interface ICalendarRepository
    {
        /// <summary>Determines whether [is non-working day] [the specified country code].</summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="date">The date.</param>
        /// <returns>
        ///   <c>true</c> if [is non-working day] [the specified country code]; otherwise, <c>false</c>.
        /// </returns>
        Boolean IsNonWorkingDay(String countryCode, DateTime date);

        /// <summary>
        /// Gets the next working day.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="date">The date.</param>
        /// <param name="intervalType">The interval type.</param>
        /// <param name="interval">The interval.</param>
        /// <returns></returns>
        DateTime GetNextWorkingDay(String countryCode, DateTime date, ScheduleInterval intervalType, Int32 interval);

        /// <summary>
        /// Gets the next working day.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        DateTime CheckIsWorkingDayOrGetNextWorkingDay(String countryCode, DateTime date);

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
    }
}
