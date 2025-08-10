//-----------------------------------------------------------------------
// <copyright file="Country.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Country data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class Country : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The iso code
            /// </summary>
            public const Int32 ISOCode = 10;

            /// <summary>
            /// The abbreviated name
            /// </summary>
            public const Int32 AbbreviatedName = 50;

            /// <summary>
            /// The full name
            /// </summary>
            public const Int32 FullName = 250;

            /// <summary>
            /// The native name
            /// </summary>
            public const Int32 NativeName = 250;

            /// <summary>
            /// The dialling code
            /// </summary>
            public const Int32 DiallingCode = 10;

            /// <summary>
            /// The post code format
            /// </summary>
            public const Int32 PostCodeFormat = 100;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(Country);

        /// <summary>
        /// Gets the iso code.
        /// </summary>
        /// <value>
        /// The iso code.
        /// </value>
        public static String IsoCode => "IsoCode";

        /// <summary>
        /// Gets the name of the abbreviated.
        /// </summary>
        /// <value>
        /// The name of the abbreviated.
        /// </value>
        public static String AbbreviatedName => "AbbreviatedName";

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public static String FullName => "FullName";

        /// <summary>
        /// Gets the name of the native.
        /// </summary>
        /// <value>
        /// The name of the native.
        /// </value>
        public static String NativeName => "NativeName";

        /// <summary>
        /// Gets the dialing code.
        /// </summary>
        /// <value>
        /// The dialing code.
        /// </value>
        public static String DialingCode => "DialingCode";

        /// <summary>
        /// Gets the post code format.
        /// </summary>
        /// <value>
        /// The post code format.
        /// </value>
        public static String PostCodeFormat => "PostCodeFormat";

        /// <summary>
        /// Gets the currency identifier.
        /// </summary>
        /// <value>
        /// The currency identifier.
        /// </value>
        public static String CurrencyId => "CurrencyId";

        /// <summary>
        /// Gets the language identifier.
        /// </summary>
        /// <value>
        /// The language identifier.
        /// </value>
        public static String LanguageId => "LanguageId";

        /// <summary>
        /// Gets the time zone identifier.
        /// </summary>
        /// <value>
        /// The time zone identifier.
        /// </value>
        public static String TimeZoneId => "TimeZoneId";

        /// <summary>
        /// Gets the world region identifier.
        /// </summary>
        /// <value>
        /// The world region identifier.
        /// </value>
        public static String WorldRegionId => "WorldRegionId";

        /// <summary>
        /// Gets the country flag.
        /// </summary>
        /// <value>
        /// The country flag.
        /// </value>
        public static String CountryFlag => "CountryFlag";
    }
}
