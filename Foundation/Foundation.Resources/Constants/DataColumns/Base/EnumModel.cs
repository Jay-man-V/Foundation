//-----------------------------------------------------------------------
// <copyright file="EnumModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Enum Model data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class EnumModel : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// Represents the maximum length [10], in characters, allowed for the code.
            /// </summary>
            public const Int32 Code = 10;

            /// <summary>
            /// Represents the maximum length [50], in characters, allowed for a short description.
            /// </summary>
            public const Int32 ShortDescription = 50;

            /// <summary>
            /// Represents the maximum length [300], in characters, allowed for a long description.
            /// </summary>
            public const Int32 LongDescription = 300;
        }

        /// <summary>
        /// Gets the constant string value that represents the display sequence column name.
        /// </summary>
        public static String DisplaySequence => "DisplaySequence";

        /// <summary>
        /// Gets the constant string value that represents the code column name.
        /// </summary>
        public static String Code => "Code";

        /// <summary>
        /// Gets the constant string value that represents the short description column name.
        /// </summary>
        public static String ShortDescription => "ShortDescription";

        /// <summary>
        /// Gets the constant string value that represents the long description column name.
        /// </summary>
        public static String LongDescription => "LongDescription";
    }
}
