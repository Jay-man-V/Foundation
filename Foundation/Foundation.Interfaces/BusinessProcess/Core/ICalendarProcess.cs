//-----------------------------------------------------------------------
// <copyright file="ICalendarProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using FEnums = Foundation.Interfaces;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Calendar Business process 
    /// </summary>
    public interface ICalendarProcess
    {
        /// <summary>
        /// Checks if the supplied <see cref="DateTime"/> is a holiday
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="date"></param>
        /// <returns><see cref="Boolean"/> [True] if it is a holiday, otherwise [False] </returns>
        Boolean IsHoliday(String countryCode, DateTime date);

        /// <summary>
        /// Retrieves the next working day taking in to account Weekends and other non-working days
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="date">current <see cref="DateTime"/></param>
        /// <returns><see cref="DateTime"/> - The next working day</returns>
        DateTime GetNextWorkingDay(String countryCode, DateTime date);

        /// <summary>
        /// Retrieves the next working day taking in to account Weekends and other non-working days
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="date">current <see cref="DateTime"/></param>
        /// <param name="intervalType">The <see cref="ScheduleInterval"/> that is to be added</param>
        /// <param name="interval">The value to be added to <paramref name="date"/></param>
        /// <returns><see cref="DateTime"/> - The next working day</returns>
        DateTime GetNextWorkingDay(String countryCode, DateTime date, FEnums.ScheduleInterval intervalType, Int32 interval);

        /// <summary>
        /// Checks if the supplied <see cref="DateTime"/> is a Working day, if it is then returns.
        /// If it isn't then it finds the next working day
        /// Retrieves the next working day taking in to account Weekends and other non-working days
        /// </summary>
        /// <param name="countryCode"></param>
        /// <param name="date">current <see cref="DateTime"/></param>
        /// <returns><see cref="DateTime"/> - The working day</returns>
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
