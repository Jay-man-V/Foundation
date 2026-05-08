//-----------------------------------------------------------------------
// <copyright file="TaskStatus.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Task Status data columns
    /// </summary>
    /// <seealso cref="EnumModel" />
    public abstract class TaskStatus : EnumModel
    {
        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(TaskStatus);
    }
}
