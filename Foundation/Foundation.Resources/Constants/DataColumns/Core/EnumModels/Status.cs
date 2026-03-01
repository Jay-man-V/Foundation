//-----------------------------------------------------------------------
// <copyright file="Status.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Status data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class Status : EnumModel
    {
        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        public static String EntityName => nameof(Status);
    }
}
