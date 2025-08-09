//-----------------------------------------------------------------------
// <copyright file="NationalRegion.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.DataColumns
{
    /// <summary>
    /// National Region data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class NationalRegion : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The abbreviation
            /// </summary>
            public const Int32 Abbreviation = 50;

            /// <summary>
            /// The short name
            /// </summary>
            public const Int32 ShortName = 50;

            /// <summary>
            /// The full name
            /// </summary>
            public const Int32 FullName = 150;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(NationalRegion);

        /// <summary>
        /// Gets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public static String CountryId => "CountryId";

        /// <summary>
        /// Gets the abbreviation.
        /// </summary>
        /// <value>
        /// The abbreviation.
        /// </value>
        public static String Abbreviation => "Abbreviation";

        /// <summary>
        /// Gets the short name.
        /// </summary>
        /// <value>
        /// The short name.
        /// </value>
        public static String ShortName => "ShortName";

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public static String FullName => "FullName";
    }
}
