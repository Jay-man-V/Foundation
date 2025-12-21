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
        /// Gets the system local date time now.
        /// </summary>
        /// <value>
        /// The system local date time now.
        /// </value>
        DateTime SystemLocalDateTimeNow { get; }

        /// <summary>
        /// Gets the system date time now.
        /// </summary>
        /// <value>
        /// The system date time now.
        /// </value>
        DateTime SystemDateTimeNowWithoutMilliseconds { get; }

        /// <summary>
        /// Makes a Utc version of the supplied <paramref name="date"/>
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        DateTime MakeUtcDateTime(DateTime date);

        /// <summary>
        /// Makes a Utc version of the supplied <paramref name="date"/> and <paramref name="time"/>
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        DateTime MakeUtcDateTime(DateTime date, TimeSpan time);

        /// <summary>
        /// Makes a Utc version of the supplied <paramref name="date"/> and <paramref name="hours"/>, <paramref name="minutes"/>, <paramref name="seconds"/>
        /// </summary>
        /// <param name="date"></param>
        /// <param name="hours"></param>
        /// <param name="minutes"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        DateTime MakeUtcDateTime(DateTime date, Int32 hours, Int32 minutes, Int32 seconds);
    }
}
