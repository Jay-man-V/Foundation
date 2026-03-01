//-----------------------------------------------------------------------
// <copyright file="DataStatus.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Data Status data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class DataStatus : EnumModel
    {
        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        public static String EntityName => nameof(DataStatus);
    }
}
