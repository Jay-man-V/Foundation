//-----------------------------------------------------------------------
// <copyright file="EntityStatus.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Entity Status Entity columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class EntityStatus : EnumModel
    {
        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        public static String EntityName => nameof(EntityStatus);
    }
}
