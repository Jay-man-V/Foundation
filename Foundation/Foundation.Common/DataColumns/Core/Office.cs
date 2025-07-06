//-----------------------------------------------------------------------
// <copyright file="Office.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Office data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class Office : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The code
            /// </summary>
            public const Int32 Code = 10;

            /// <summary>
            /// The short name
            /// </summary>
            public const Int32 ShortName = 50;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(Office);

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public static String Code => "Code";

        /// <summary>
        /// Gets the short name.
        /// </summary>
        /// <value>
        /// The short name.
        /// </value>
        public static String ShortName => "ShortName";

        /// <summary>
        /// Gets the contact detail identifier.
        /// </summary>
        /// <value>
        /// The contact detail identifier.
        /// </value>
        public static String ContactDetailId => "ContactDetailId";

        /// <summary>
        /// Gets the office week calendar identifier.
        /// </summary>
        /// <value>
        /// The office week calendar identifier.
        /// </value>
        public static String OfficeWeekCalendarId => "OfficeWeekCalendarId";
    }
}
