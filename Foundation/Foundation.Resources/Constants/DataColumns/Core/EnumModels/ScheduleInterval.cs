//-----------------------------------------------------------------------
// <copyright file="ScheduleInterval.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Schedule Interval data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class ScheduleInterval : EnumModel
    {
        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        public static String EntityName => nameof(ScheduleInterval);
    }
}
