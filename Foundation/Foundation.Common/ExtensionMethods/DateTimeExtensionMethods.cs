//-----------------------------------------------------------------------
// <copyright file="DateTimeExtensionMethods.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the DateTimeExtensionMethods
    /// </summary>
    public static class DateTimeExtensionMethods
    {
        /// <summary>
        /// Returns the date of the start of the week
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="targetTimeZone">The TimeZone to convert the <paramref name="currentValue"/> to</param>
        /// <returns></returns>
        public static DateTime ToTimeZone(this DateTime currentValue, String targetTimeZone)
        {
            TimeZoneInfo targetTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(targetTimeZone);
            DateTime retVal = TimeZoneInfo.ConvertTime(currentValue, targetTimeZoneInfo);

            if (currentValue.Kind == DateTimeKind.Utc)
            {
                retVal = TimeZoneInfo.ConvertTimeFromUtc(currentValue, targetTimeZoneInfo);
            }

            return retVal;
        }

        /// <summary>
        /// Returns the date of the start of the week
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="startOfWeek">The <see cref="DayOfWeek"/> for the start of the week. Default = Monday</param>
        /// <returns></returns>
        public static DateTime StartOfWeek(this DateTime currentValue, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            Int32 diff = (7 + (currentValue.DayOfWeek - startOfWeek)) % 7;
            DateTime retVal = currentValue.AddDays(-1 * diff).Date;

            return retVal;
        }

        /// <summary>
        /// Returns whether the <paramref name="currentValue"/> falls on a Weekend
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <returns></returns>
        public static Boolean IsWeekend(this DateTime currentValue)
        {
            Boolean retVal = (currentValue.DayOfWeek == DayOfWeek.Sunday ||
                              currentValue.DayOfWeek == DayOfWeek.Saturday);

            return retVal;
        }

        /// <summary>
        /// Determines whether the current value is between (&gt;=) <paramref name="startValue"/> and (&lt;=) <paramref name="endValue"/>
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="startValue">The start value.</param>
        /// <param name="endValue">The end value.</param>
        /// <returns>
        ///   <c>true</c> if the specified current value is between <paramref name="startValue"/> and <paramref name="endValue"/>; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsBetween(this DateTime currentValue, DateTime startValue, DateTime endValue)
        {
            Boolean retVal = currentValue >= startValue && currentValue <= endValue;

            return retVal;
        }

        /// <summary>
        /// Determines whether the current value is between (&gt;=) <paramref name="startValue"/> and (&lt;=) <paramref name="endValue"/>
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="startValue">The start value.</param>
        /// <param name="endValue">The end value.</param>
        /// <returns>
        ///   <c>true</c> if the specified current value is between <paramref name="startValue"/> and <paramref name="endValue"/>; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsBetween(this DateTime? currentValue, DateTime startValue, DateTime endValue)
        {
            Boolean retVal = false;

            if (currentValue.HasValue)
            {
                retVal = currentValue >= startValue && currentValue <= endValue;
            }

            return retVal;
        }

        /// <summary>
        /// <para>
        ///  Returns a new <see cref="System.DateTime"/> that adds the specified number of weeks to the value of this instance.
        /// </para>
        /// <para>
        /// Routine will multiply the <paramref name="value"/> by 7 and then <see cref="DateTime.AddDays(Double)"/>
        /// to the <paramref name="currentValue"/>
        /// </para>
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="value">The number of weeks to add.</param>
        /// <returns>
        /// <see cref="DateTime"/> with seven days added
        /// </returns>
        public static DateTime AddWeeks(this DateTime currentValue, Int32 value)
        {
            DateTime retVal = currentValue.AddDays(value * 7);

            return retVal;
        }

        /// <summary>
        /// Adds an <paramref name="interval"/> to the <paramref name="currentValue"/>
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="scheduleInterval"><see cref="ScheduleInterval"/> describing the <paramref name="interval"/></param>
        /// <param name="interval">Value to add to <paramref name="currentValue"/></param>
        /// <param name="startTime">The <see cref="TimeSpan"/> to use with the new <see cref="DateTime"/></param>
        /// <returns></returns>
        public static DateTime Add(this DateTime currentValue, ScheduleInterval scheduleInterval, Int32 interval, TimeSpan startTime)
        {
            DateTime retVal = currentValue;

            switch (scheduleInterval)
            {
                case ScheduleInterval.NotSet: retVal = retVal.AddMilliseconds(interval); break;
                case ScheduleInterval.Milliseconds: retVal = retVal.AddMilliseconds(interval); break;
                case ScheduleInterval.Seconds: retVal = retVal.AddSeconds(interval); break;
                case ScheduleInterval.Minutes: retVal = retVal.AddMinutes(interval); break;
                case ScheduleInterval.Hours: retVal = retVal.AddHours(interval); break;
                case ScheduleInterval.Days: retVal = retVal.Date.Date.AddDays(interval) + startTime; break;
                case ScheduleInterval.Weeks: retVal = retVal.Date.AddWeeks(interval) + startTime; break;
                case ScheduleInterval.Months: retVal = retVal.Date.AddMonths(interval) + startTime; break;
                case ScheduleInterval.Years: retVal = retVal.Date.AddYears(interval) + startTime; break;
                case ScheduleInterval.Other: /* Do nothing */ break;
                default:
                {
                    String errorMessage = $"The Schedule Interval of '{scheduleInterval}' is unknown or invalid for the chosen Add method";
                    throw new ArgumentException(errorMessage, nameof(scheduleInterval));
                }
            }

            return retVal;
        }

        /// <summary>
        /// Adds the <paramref name="duration"/> to the <paramref name="currentValue"/> adjusting for the <paramref name="workingTimeWindow"/>
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="workingTimeWindow">The start/end times to take in to consideration</param>
        /// <param name="duration">value to add to <paramref name="currentValue"/></param>
        /// <returns></returns>
        public static DateTime Add(this DateTime currentValue, TimeWindow workingTimeWindow, TimeSpan duration)
        {
            DateTime retVal = currentValue;
            TimeSpan adjustingTimeSpan = duration;

            // Calculate the length of a day based on the given Start and End times
            TimeSpan oneDayTimeSpan = workingTimeWindow.EndTime - workingTimeWindow.StartTime;

            // Adjust the TimeOfDay based on the Start and End times of the workingTimeWindow
            if (retVal.TimeOfDay < workingTimeWindow.StartTime) { retVal = retVal.Date + workingTimeWindow.StartTime; }
            if (retVal.TimeOfDay > workingTimeWindow.EndTime) { retVal = retVal.Date.AddDays(1) + workingTimeWindow.StartTime; }

            // Now adjust the calculated DateTime for the number of Working days spanned by the duration
            while(adjustingTimeSpan.TotalMilliseconds > oneDayTimeSpan.TotalMilliseconds)
            {
                adjustingTimeSpan = adjustingTimeSpan.Subtract(oneDayTimeSpan);

                retVal = retVal.AddDays(1);
            }

            // Finally, add the remaining minutes
            retVal = retVal.Add(adjustingTimeSpan);

            return retVal;
        }
    }
}
