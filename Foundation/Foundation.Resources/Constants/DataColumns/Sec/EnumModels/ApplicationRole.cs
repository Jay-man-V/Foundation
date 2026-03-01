//-----------------------------------------------------------------------
// <copyright file="ApplicationRole.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Application Role data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class ApplicationRole : EnumModel
    {
        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        public static String EntityName => "ApplicationRole";

        /// <summary>
        /// Gets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        public static String ApplicationId => "ApplicationId";

        /// <summary>
        /// Gets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public static String RoleId => "RoleId";
    }
}
