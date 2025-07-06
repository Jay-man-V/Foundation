//-----------------------------------------------------------------------
// <copyright file="ObjectExtensionsMethods.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Common
{
    /// <summary>
    /// Defines extension methods for the <see cref="object"/> type
    /// </summary>
    public static class ObjectExtensionsMethods
    {
        /// <summary>
        /// Determines whether this instance is null.
        /// (val == null || val == DBNull.Value)
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is null; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsNull(this Object val)
        {
            return (val == null || val == DBNull.Value);
        }

        /// <summary>
        /// Determines whether this instance is not null.
        /// (val != null &amp;&amp; val != DBNull.Value)
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>
        ///   <c>true</c> if [is not null] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsNotNull(this Object val)
        {
            return (val != null && val != DBNull.Value);
        }

        /// <summary>
        /// Determines whether this instance is a native .Net type.
        /// Boolean
        /// TimeSpan
        /// DateTime
        /// Guid
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
        public static Boolean IsNativeType(this Object val)
        {
            Boolean retVal = val is Boolean ||
                             val is TimeSpan ||
                             val is DateTime ||
                             val is Guid ||
                             val is Char ||
                             val is String ||
                             val is Int16 ||
                             val is UInt16 ||
                             val is Int32 ||
                             val is UInt32 ||
                             val is Int64 ||
                             val is UInt64 ||
                             val is Decimal ||
                             val is Double ||
                             val is Single ||
                             val is Byte ||
                             val is SByte;

            return retVal;
        }

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
        public static Boolean IsNumericType(this Object val)
        {
            Boolean retVal = val is Int16 ||
                             val is UInt16 ||
                             val is Int32 ||
                             val is UInt32 ||
                             val is Int64 ||
                             val is UInt64 ||
                             val is Decimal ||
                             val is Double ||
                             val is Single ||
                             val is Byte ||
                             val is SByte;

            return retVal;
        }
    }
}
