//-----------------------------------------------------------------------
// <copyright file="OfficeWeekCalendar.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// OFfice Week Calendar data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class OfficeWeekCalendar : FoundationEntity
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
        public static String EntityName => nameof(OfficeWeekCalendar);

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
        /// Gets the mon.
        /// </summary>
        /// <value>
        /// The mon.
        /// </value>
        public static String Mon => "Mon";

        /// <summary>
        /// Gets the tue.
        /// </summary>
        /// <value>
        /// The tue.
        /// </value>
        public static String Tue => "Tue";

        /// <summary>
        /// Gets the wed.
        /// </summary>
        /// <value>
        /// The wed.
        /// </value>
        public static String Wed => "Wed";

        /// <summary>
        /// Gets the thu.
        /// </summary>
        /// <value>
        /// The thu.
        /// </value>
        public static String Thu => "Thu";

        /// <summary>
        /// Gets the fri.
        /// </summary>
        /// <value>
        /// The fri.
        /// </value>
        public static String Fri => "Fri";

        /// <summary>
        /// Gets the sat.
        /// </summary>
        /// <value>
        /// The sat.
        /// </value>
        public static String Sat => "Sat";

        /// <summary>
        /// Gets the sun.
        /// </summary>
        /// <value>
        /// The sun.
        /// </value>
        public static String Sun => "Sun";
    }
}
