//-----------------------------------------------------------------------
// <copyright file="TimeSpanExtensionMethods.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the TimeSpanExtensionMethods
    /// </summary>
    public static class TimeSpanExtensionMethods
    {
        /// <summary>
        /// Determines whether the current value is between <paramref name="startValue"/> and <paramref name="endValue"/>
        /// Rule used is: startValue &lt;= currentValue &lt;= endValue 
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="startValue">The start value.</param>
        /// <param name="endValue">The end value.</param>
        /// <returns>
        ///   <c>true</c> if the specified current value is between <paramref name="startValue"/> and <paramref name="endValue"/>; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsBetween(this TimeSpan currentValue, TimeSpan startValue, TimeSpan endValue)
        {
            Boolean retVal = currentValue >= startValue && currentValue <= endValue;

            return retVal;
        }

        /// <summary>
        /// Determines whether the current value is between <paramref name="startValue"/> and <paramref name="endValue"/>
        /// Rule used is: startValue &lt;= currentValue &lt;= endValue 
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="startValue">The start value.</param>
        /// <param name="endValue">The end value.</param>
        /// <returns>
        ///   <c>true</c> if the specified current value is between <paramref name="startValue"/> and <paramref name="endValue"/>; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsBetween(this TimeSpan? currentValue, TimeSpan startValue, TimeSpan endValue)
        {
            Boolean retVal = false;

            if (currentValue.HasValue)
            {
                retVal = currentValue >= startValue && currentValue <= endValue;
            }

            return retVal;
        }

        /// <summary>
        /// Adds an <paramref name="interval"/> to the <paramref name="currentValue"/>
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="scheduleInterval"><see cref="ScheduleInterval"/> describing the <paramref name="interval"/></param>
        /// <param name="interval">Value to add to <paramref name="currentValue"/></param>
        /// <returns></returns>
        public static TimeSpan Add(this TimeSpan currentValue, ScheduleInterval scheduleInterval, Int32 interval)
        {
            TimeSpan retVal = currentValue;
            TimeSpan temp = TimeSpan.Zero;

            switch (scheduleInterval)
            {
                case ScheduleInterval.Milliseconds: temp = new TimeSpan(0, 0, 0, 0, interval); break;
                case ScheduleInterval.Seconds: temp = new TimeSpan(0, 0, 0, interval, 0); break;
                case ScheduleInterval.Minutes: temp = new TimeSpan(0, 0, interval, 0, 0); break;
                case ScheduleInterval.Hours: temp = new TimeSpan(0, interval, 0, 0, 0); break;
                case ScheduleInterval.Days: temp = new TimeSpan(interval, 0, 0, 0, 0); break;
                case ScheduleInterval.Weeks:
                case ScheduleInterval.Months:
                case ScheduleInterval.Years:
                {
                    DateTime zeroDate = new DateTime();
                    DateTime workingDate = zeroDate.Add(scheduleInterval, interval, temp);
                    temp = workingDate - zeroDate;
                    break;
                }
                case ScheduleInterval.Other: /* Do nothing */ break;
                default:
                    {
                        String errorMessage = $"The Schedule Interval of '{scheduleInterval}' is unknown or invalid for the chosen Add method";
                        throw new ArgumentException(errorMessage, nameof(scheduleInterval));
                    }
            }

            retVal += temp;

            return retVal;
        }
    }
}
