//-----------------------------------------------------------------------
// <copyright file="TypeExtensionsMethods.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common
{
    /// <summary>
    /// Defines extension methods for the <see cref="object"/> type
    /// </summary>
    public static class TypeExtensionsMethods
    {
        /// <summary>
        /// Determines whether this instance is a numeric type.
        /// Int16
        /// UInt16
        /// Int32
        /// UInt32
        /// Int64
        /// UInt64
        /// Decimal
        /// Double
        /// Single
        /// SByte
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is numeric type] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsNumericType(this Type val)
        {
            Boolean retVal = val == typeof(Int16) ||
                             val == typeof(UInt16) ||
                             val == typeof(Int32) ||
                             val == typeof(UInt32) ||
                             val == typeof(Int64) ||
                             val == typeof(UInt64) ||
                             val == typeof(Decimal) ||
                             val == typeof(Double) ||
                             val == typeof(Single) ||
                             val == typeof(Byte) ||
                             val == typeof(SByte);

            return retVal;
        }


        /// <summary>
        /// Determines whether this instance is a native .Net type.
        /// Boolean
        /// Int16
        /// UInt16
        /// Int32
        /// UInt32
        /// Int64
        /// UInt64
        /// Decimal
        /// Double
        /// Single
        /// Char
        /// String
        /// SByte
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is native type] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsNativeType(this Type val)
        {
            Boolean retVal = val == typeof(Boolean) ||
                             val == typeof(DateTime) ||
                             val == typeof(Char) ||
                             val == typeof(String) ||
                             val == typeof(Int16) ||
                             val == typeof(UInt16) ||
                             val == typeof(Int32) ||
                             val == typeof(UInt32) ||
                             val == typeof(Int64) ||
                             val == typeof(UInt64) ||
                             val == typeof(Decimal) ||
                             val == typeof(Double) ||
                             val == typeof(Single) ||
                             val == typeof(Byte) ||
                             val == typeof(SByte);

            return retVal;
        }
    }
}
