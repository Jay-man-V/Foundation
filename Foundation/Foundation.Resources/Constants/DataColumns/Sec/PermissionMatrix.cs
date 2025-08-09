//-----------------------------------------------------------------------
// <copyright file="PermissionMatrix.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.DataColumns
{
    /// <summary>
    /// PermissionMatrix data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class PermissionMatrix : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The name
            /// </summary>
            public const Int32 FunctionKey = 500;

            /// <summary>
            /// The description
            /// </summary>
            public const Int32 Permission = 500;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => "PermissionMatrix";

        /// <summary>
        /// Gets the application id.
        /// </summary>
        /// <value>
        /// The application id.
        /// </value>
        public static String ApplicationId => "ApplicationId";

        /// <summary>
        /// Gets the role id.
        /// </summary>
        /// <value>
        /// The role id.
        /// </value>
        public static String RoleId => "RoleId";

        /// <summary>
        /// Gets the user profile id.
        /// </summary>
        /// <value>
        /// The user profile id.
        /// </value>
        public static String UserProfileId => "UserProfileId";

        /// <summary>
        /// Gets the function key.
        /// </summary>
        /// <value>
        /// The function key.
        /// </value>
        public static String FunctionKey => "FunctionKey";

        /// <summary>
        /// Gets the Permission.
        /// </summary>
        /// <value>
        /// The Permission.
        /// </value>
        public static String Permission => "Permission";
    }
}
