//-----------------------------------------------------------------------
// <copyright file="ApplicationType.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Application Type data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class ApplicationType : FoundationEntity
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
            public const Int32 Description = 200;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => "ApplicationType";

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
    }
}
