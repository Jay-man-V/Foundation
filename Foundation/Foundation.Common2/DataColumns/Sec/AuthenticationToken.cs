//-----------------------------------------------------------------------
// <copyright file="AuthenticationToken.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Authentication Token data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class AuthenticationToken : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The name
            /// </summary>
            public const Int32 Token = 200;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => "AuthenticationToken";

        /// <summary>
        /// Gets the application id.
        /// </summary>
        /// <value>
        /// The application id.
        /// </value>
        public static String ApplicationId => "ApplicationId";

        /// <summary>
        /// Gets the user profile id.
        /// </summary>
        /// <value>
        /// The application id.
        /// </value>
        public static String UserProfileId => "UserProfileId";

        /// <summary>
        /// Gets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public static String Token => "Token";

        /// <summary>
        /// Gets the acquired.
        /// </summary>
        /// <value>
        /// The acquired.
        /// </value>
        public static String Acquired => "Acquired";

        /// <summary>
        /// Gets the last refreshed.
        /// </summary>
        /// <value>
        /// The last refreshed.
        /// </value>
        public static String LastRefreshed => "LastRefreshed";
    }
}
