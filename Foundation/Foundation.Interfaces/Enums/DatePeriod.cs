//-----------------------------------------------------------------------
// <copyright file="DatePeriod.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// date period.
    /// <para>
    /// Identifies how the date period should be understood
    /// </para>
    /// </summary>
    [Browsable(true),
     Category("Configuration"),
     Description("Specifies the date period")]
    public enum DatePeriod
    {
        /// <summary>
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Not set")]
        [Range(-1, -1)]
        NotSet = 0,

        /// <summary>
        /// Interval is measured in Days. Normally (1-28).
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Days")]
        [Range(1, 28)]
        Days = 1,

        /// <summary>
        /// Interval is measured in Weeks. Normally (1-52).
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Weeks")]
        [Range(1, 52)]
        Weeks = 2,

        /// <summary>
        /// Interval is measured in Months. Normally (1-120).
        /// </summary>
        [Id(3), Display(Order = 3, Name = "Months")]
        [Range(1, 120)]
        Months = 3,

        /// <summary>
        /// Interval is measured in Years. Normally (1-999,999).
        /// </summary>
        [Id(4), Display(Order = 4, Name = "Years")]
        [Range(1, 999_999)]
        Years = 4,
    }
}
