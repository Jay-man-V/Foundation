//-----------------------------------------------------------------------
// <copyright file="Language.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.DataColumns
{
    /// <summary>
    /// Language data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class Language : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The english name
            /// </summary>
            public const Int32 EnglishName = 150;

            /// <summary>
            /// The native name
            /// </summary>
            public const Int32 NativeName = 150;

            /// <summary>
            /// The culture code
            /// </summary>
            public const Int32 CultureCode = 10;

            /// <summary>
            /// The UI culture code
            /// </summary>
            public const Int32 UiCultureCode = 10;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(Language);

        /// <summary>
        /// Gets the name of the english.
        /// </summary>
        /// <value>
        /// The name of the english.
        /// </value>
        public static String EnglishName => "EnglishName";

        /// <summary>
        /// Gets the name of the native.
        /// </summary>
        /// <value>
        /// The name of the native.
        /// </value>
        public static String NativeName => "NativeName";

        /// <summary>
        /// Gets the culture code.
        /// </summary>
        /// <value>
        /// The culture code.
        /// </value>
        public static String CultureCode => "CultureCode";

        /// <summary>
        /// Gets the UI culture code.
        /// </summary>
        /// <value>
        /// The UI culture code.
        /// </value>
        public static String UiCultureCode => "UiCultureCode";
    }
}
