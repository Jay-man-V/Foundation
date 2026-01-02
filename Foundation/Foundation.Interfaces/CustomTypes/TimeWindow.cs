//-----------------------------------------------------------------------
// <copyright file="TimeWindow.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Use the TimeWindow to specify a StartTime and EndTime.
    /// <para>
    /// Can be used when you need to specify a time range within a day
    /// </para>
    /// <para>
    /// Used in some <see cref="DateTime"/> calculations
    /// </para>
    /// </summary>
    [DebuggerDisplay("{StartTime} - {EndTime}")]
    public readonly struct TimeWindow
    {
        /// <summary>
        /// Creates a new instance of the <see cref="TimeWindow"/>
        /// </summary>
        /// <param name="startTime">The start time of the window</param>
        /// <param name="endTime">The end time of the window</param>
        public TimeWindow(TimeSpan startTime, TimeSpan endTime)
        {
            if (startTime.TotalHours > 24)
            {
                String errorMessage = $"The Start Time ({startTime}) cannot be more than 24 hours";
                throw new ArgumentException(errorMessage);
            }

            if (endTime.TotalHours > 24)
            {
                String errorMessage = $"The End Time ({endTime}) cannot be more than 24 hours";
                throw new ArgumentException(errorMessage);
            }

            if (startTime > endTime)
            {
                String errorMessage = $"The Start Time ({startTime}) must be before the End Time ({endTime})";
                throw new ArgumentException(errorMessage);
            }

            if (startTime == endTime)
            {
                String errorMessage = $"The Start Time ({startTime}) cannot be the same as the End Time ({endTime})";
                throw new ArgumentException(errorMessage);
            }

            StartTime = startTime;
            EndTime = endTime;
        }

        /// <summary>
        /// Start time of the Tine Window
        /// </summary>
        public TimeSpan StartTime { get; }

        /// <summary>
        /// End time of the Tine Window
        /// </summary>
        public TimeSpan EndTime { get; }
    }
}
