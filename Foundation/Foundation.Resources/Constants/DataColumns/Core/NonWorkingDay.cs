//-----------------------------------------------------------------------
// <copyright file="NonWorkingDay.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.DataColumns
{
    /// <summary>
    /// Non Working Day data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class NonWorkingDay : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The description
            /// </summary>
            public const Int32 Description = 150;

            /// <summary>
            /// The notes
            /// </summary>
            public const Int32 Notes = 150;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(NonWorkingDay);

        /// <summary>
        /// Gets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public static String Date => "Date";

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public static String Description => "Description";

        /// <summary>
        /// Gets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public static String Notes => "Notes";

        /// <summary>
        /// Gets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public static String CountryId => "CountryId";
    }
}
