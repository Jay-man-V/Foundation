//-----------------------------------------------------------------------
// <copyright file="Entity.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Foundation Entity data columns
    /// </summary>
    public abstract class FoundationEntity
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public static String Id => "Id";

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public static String Timestamp => "Timestamp";

        /// <summary>
        /// Gets the status identifier.
        /// </summary>
        /// <value>
        /// The status identifier.
        /// </value>
        public static String StatusId => "StatusId";

        /// <summary>
        /// Gets the created by user profile identifier.
        /// </summary>
        /// <value>
        /// The created by user profile identifier.
        /// </value>
        public static String CreatedByUserProfileId => "CreatedByUserProfileId";

        /// <summary>
        /// Gets the last updated by user profile identifier.
        /// </summary>
        /// <value>
        /// The last updated by user profile identifier.
        /// </value>
        public static String LastUpdatedByUserProfileId => "LastUpdatedByUserProfileId";

        /// <summary>
        /// Gets the created on.
        /// </summary>
        /// <value>
        /// The created on.
        /// </value>
        public static String CreatedOn => "CreatedOn";

        /// <summary>
        /// Gets the last updated on.
        /// </summary>
        /// <value>
        /// The last updated on.
        /// </value>
        public static String LastUpdatedOn => "LastUpdatedOn";

        /// <summary>
        /// Gets the valid from.
        /// </summary>
        /// <value>
        /// The valid from.
        /// </value>
        public static String ValidFrom => "ValidFrom";

        /// <summary>
        /// Gets the valid to.
        /// </summary>
        /// <value>
        /// The valid to.
        /// </value>
        public static String ValidTo => "ValidTo";
    }
}
