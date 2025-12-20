//-----------------------------------------------------------------------
// <copyright file="ScheduleInterval.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Scheduled Type.
    /// <para>
    /// Identifies how the Schedule Interval should be understood
    /// </para>
    /// </summary>
    [Browsable(true),
     Category("Process"),
     Description("Specifies the schedule interval")]
    public enum ScheduleInterval
    {
        /// <summary>
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Not set")]
        [Range(-1, -1)]
        NotSet = 0,

        /// <summary>
        /// Interval is measured in Milliseconds. Normally (1-60,000).
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Milliseconds")]
        [Range(1, 60_000)]
        Milliseconds = 1,

        /// <summary>
        /// Interval is measured in Seconds. Normally (1-3,600).
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Seconds")]
        [Range(1, 3_600)]
        Seconds = 2,

        /// <summary>
        /// Interval is measured in Minutes. Normally (1-1,440).
        /// </summary>
        [Id(3), Display(Order = 3, Name = "Minutes")]
        [Range(1, 1_440)]
        Minutes = 3,

        /// <summary>
        /// Interval is measured in Hours. Normally (1-168).
        /// </summary>
        [Id(4), Display(Order = 4, Name = "Hours")]
        [Range(1, 168)]
        Hours = 4,

        /// <summary>
        /// Interval is measured in Days. Normally (1-28).
        /// </summary>
        [Id(5), Display(Order = 5, Name = "Days")]
        [Range(1, 28)]
        Days = 5,

        /// <summary>
        /// Interval is measured in Weeks. Normally (1-52).
        /// </summary>
        [Id(6), Display(Order = 6, Name = "Weeks")]
        [Range(1, 52)]
        Weeks = 6,

        /// <summary>
        /// Interval is measured in Months. Normally (1-120).
        /// </summary>
        [Id(7), Display(Order = 7, Name = "Months")]
        [Range(1, 120)]
        Months = 7,

        /// <summary>
        /// Interval is measured in Years. Normally (1-999,999).
        /// </summary>
        [Id(8), Display(Order = 8, Name = "Years")]
        [Range(1, 999_999)]
        Years = 8,

        /// <summary>
        /// There is no specific Interval.
        /// A non-scheduled action such as a FileSystemWatcher is used
        /// </summary>
        [Id(100), Display(Order = 100, Name = "Other")]
        [Range(0, 0)]
        Other = 100,
    }
}
