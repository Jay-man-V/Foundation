//-----------------------------------------------------------------------
// <copyright file="UserProfile.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Currency data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class UserProfile : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The external key identifier
            /// </summary>
            public const Int32 ExternalKeyId = 100;

            /// <summary>
            /// The DomainName
            /// </summary>
            public const Int32 DomainName = 100;

            /// <summary>
            /// The username
            /// </summary>
            public const Int32 Username = 100;

            /// <summary>
            /// The display name
            /// </summary>
            public const Int32 DisplayName = 250;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => "UserProfile";

        /// <summary>
        /// Gets the external key identifier.
        /// </summary>
        /// <value>
        /// The external key identifier.
        /// </value>
        public static String ExternalKeyId => "ExternalKeyId";

        /// <summary>
        /// Gets the DomainName.
        /// </summary>
        /// <value>
        /// The DomainName.
        /// </value>
        public static String DomainName => "DomainName";

        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public static String Username => "Username";

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public static String DisplayName => "DisplayName";

        /// <summary>
        /// Gets the is system support.
        /// </summary>
        /// <value>
        /// The is system support.
        /// </value>
        public static String IsSystemSupport => "IsSystemSupport";

        /// <summary>
        /// Gets the contact detail identifier.
        /// </summary>
        /// <value>
        /// The contact detail identifier.
        /// </value>
        public static String ContactDetailId => "ContactDetailId";
    }
}
