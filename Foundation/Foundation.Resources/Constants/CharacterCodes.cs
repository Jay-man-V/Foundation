//-----------------------------------------------------------------------
// <copyright file="CharacterCodes.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources
{
    /// <summary>
    /// Character Codes constants used in various parts of the application
    /// </summary>
    public static class CharacterCodes
    {
        /*
         * Commonly used for file parsing
         */

        /// <summary>
        /// \r or (Char)13
        /// </summary>
        public static Char CarriageReturn => '\r';

        /// <summary>
        /// "
        /// </summary>
        public static Char DoubleQuote => '"';

        /// <summary>
        /// ,
        /// </summary>
        public static Char FieldDelimiter => ',';

        /// <summary>
        /// \n or (Char)10
        /// </summary>
        public static Char NewLine => '\n';

        /// <summary>
        /// '
        /// </summary>
        public static Char SingleQuote => '\'';

        /*
         * Commonly used for random generation
         */
        
        /// <summary>
        /// List of English alphabetical upper case characters (A-Z)
        /// </summary>
        public static String AlphaUpperCaseOnly => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// List of English alphabetical lower case characters (a-z)
        /// </summary>
        public static String AlphaLowerCaseOnly => "abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        /// List of numbers (0-9)
        /// </summary>
        public static String NumericOnly => "0123456789";

        /// <summary>
        /// List of all the non-alphabetic characters (!"£$%^&amp;*() _-+={}[]#:@;'&lt;&gt;?,./|\)
        /// </summary>
        public static String NonAlphaChars => @"!""£$%^&*() _-+={}[]#:@;'<>?,./|\";

        /// <summary>
        /// Combination of <see cref="AlphaUpperCaseOnly"/>, <see cref="AlphaLowerCaseOnly"/>, and <see cref="NumericOnly"/>
        /// </summary>
        public static String AlphaNumeric => AlphaUpperCaseOnly + AlphaLowerCaseOnly + NumericOnly;

        /// <summary>
        /// Combination of <see cref="AlphaUpperCaseOnly"/>, <see cref="AlphaLowerCaseOnly"/>, <see cref="NumericOnly"/>, and <see cref="NonAlphaChars"/>
        /// </summary>
        public static String AllChars => AlphaUpperCaseOnly + AlphaLowerCaseOnly + NumericOnly + NonAlphaChars;
    }
}
