//-----------------------------------------------------------------------
// <copyright file="StringBuilderExtensionsMethods.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text;

namespace Foundation.Common
{
    /// <summary>
    /// Defines extension methods for the <see cref="StringBuilder"/> type
    /// </summary>
    public static class StringBuilderExtensionsMethods
    {
        /// <summary>
        /// Appends the string returned by Processing a composite format string, which contains
        /// zero or more format items, to this instance. Each format item is replaced by
        /// the string representation of a corresponding argument in a parameter array.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="args">An array of objects to format.</param>
        /// <returns>
        /// A reference to this instance with format appended. Each format item in format
        /// is replaced by the string representation of the corresponding object argument.
        /// </returns>
        /// <exception cref="T:ArgumentNullException">format or args is null</exception>
        /// <exception cref="T:FormatException">format is invalid. -or-The index of a format item is less than 0 (zero), or greater than or equal to the length of the args array.</exception>
        /// <exception cref="T:ArgumentOutOfRangeException">The length of the expanded string would exceed StringBuilder.MaxCapacity.</exception>
        public static StringBuilder AppendFormatLine(this StringBuilder val, String format, params Object[] args)
        {
            val.AppendFormat(format, args);
            val.AppendLine();

            return val;
        }
    }
}
