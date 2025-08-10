//-----------------------------------------------------------------------
// <copyright file="TimeZone.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Time Zone data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class TimeZone : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The code
            /// </summary>
            public const Int32 Code = 6;

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
        public static String EntityName => nameof(TimeZone);

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public static String Code => "Code";

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public static String Description => "Description";

        /// <summary>
        /// Gets the offset.
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        public static String Offset => "Offset";

        /// <summary>
        /// Gets the has daylight savings.
        /// </summary>
        /// <value>
        /// The has daylight savings.
        /// </value>
        public static String HasDaylightSavings => "HasDaylightSavings";
    }
}
