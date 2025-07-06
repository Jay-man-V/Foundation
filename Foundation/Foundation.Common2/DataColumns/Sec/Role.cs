//-----------------------------------------------------------------------
// <copyright file="Role.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Role data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class Role : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The name
            /// </summary>
            public const Int32 Name = 50;

            /// <summary>
            /// The description
            /// </summary>
            public const Int32 Description = 150;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => "Role";

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public static String Name => "Name";

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public static String Description => "Description";

        /// <summary>
        /// Gets the system support only.
        /// </summary>
        /// <value>
        /// The system support only.
        /// </value>
        public static String SystemSupportOnly => "SystemSupportOnly";
    }
}
