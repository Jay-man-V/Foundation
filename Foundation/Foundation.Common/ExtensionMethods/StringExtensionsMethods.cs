//-----------------------------------------------------------------------
// <copyright file="StringExtensionsMethods.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common
{
    /// <summary>
    /// Defines extension methods for the <see cref="String"/> type
    /// </summary>
    public static class StringExtensionsMethods
    {
        /// <summary>
        /// Determines whether the specified string is null, empty, or contains only whitespace.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is null, empty, or contains only whitespace; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsNullOrEmptyOrWhiteSpace(this String val)
        {
            Boolean retVal = String.IsNullOrWhiteSpace(val) || String.IsNullOrEmpty(val);

            return retVal;
        }
    }
}
