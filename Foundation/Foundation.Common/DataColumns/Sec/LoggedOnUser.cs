//-----------------------------------------------------------------------
// <copyright file="LoggedOnUser.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Logged On User data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class LoggedOnUser : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The command
            /// </summary>
            public const Int32 Command = -1;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => "LoggedOnUser";

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public static String DisplayName => "DisplayName";

        /// <summary>
        /// Gets the Username.
        /// </summary>
        /// <value>
        /// The Username.
        /// </value>
        public static String Username => "Username";

        /// <summary>
        /// Gets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        public static String ApplicationId => "ApplicationId";

        /// <summary>
        /// Gets the user profile identifier.
        /// </summary>
        /// <value>
        /// The user profile identifier.
        /// </value>
        public static String UserProfileId => "UserProfileId";

        /// <summary>
        /// Gets the logged on.
        /// </summary>
        /// <value>
        /// The logged on.
        /// </value>
        public static String LoggedOn => "LoggedOn";

        /// <summary>
        /// Gets the last active.
        /// </summary>
        /// <value>
        /// The last active.
        /// </value>
        public static String LastActive => "LastActive";

        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public static String Command => "Command";

        // Internal properties mapped from other objects

        /// <summary>
        /// Gets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public static String RoleId => "RoleId";

        /// <summary>
        /// Gets the role description.
        /// </summary>
        /// <value>
        /// The role description.
        /// </value>
        public static String RoleDescription => "RoleDescription";

        /// <summary>
        /// Gets the is system support.
        /// </summary>
        /// <value>
        /// The is system support.
        /// </value>
        public static String IsSystemSupport => "IsSystemSupport";
    }
}
