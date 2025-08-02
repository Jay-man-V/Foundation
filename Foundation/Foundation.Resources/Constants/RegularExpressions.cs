//-----------------------------------------------------------------------
// <copyright file="RegularExpressions.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources
{
    /// <summary>
    /// Common Regular Expressions
    /// </summary>
    public static class RegularExpressions
    {
        /// <summary>
        /// RegEx value = "^[A-Z]$"
        /// </summary>
        public static String AlphaUpperCaseOnly => "^[A-Z]*$";

        /// <summary>
        /// RegEx value = "^[a-z]$"
        /// </summary>
        public static String LowerUpperCaseOnly => "^[a-z]*$";

        /// <summary>
        /// RegEx value = "^[^a-zA-Z\d\s]*$"
        /// </summary>
        public static String NonAlphaChars => @"^[^a-zA-Z\d\s]*$";

        /// <summary>
        /// RegEx value = "[0-9]*$"
        /// </summary>
        public static String IntegerMultipleDigits => "^[0-9]*$";

        /// <summary>
        /// RegEx value = "^[0-9]$"
        /// </summary>
        public static String IntegerSingleDigit => "^[0-9]$";

        /// <summary>
        /// RegEx value = "^([0-9]\d*)(\.\d+)?$"
        /// </summary>
        public static String PositiveDecimalNumber => @"^([0-9]\d*)(\.\d+)?$";

        /// <summary>
        /// RegEx value = "."
        /// </summary>
        public static String AllCharacters => "[.]*";
    }
}
