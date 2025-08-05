//-----------------------------------------------------------------------
// <copyright file="UInt32ExtensionMethods.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common
{
    /// <summary>
    /// Defines the UInt32ExtensionMethods
    /// </summary>
    public static class UInt32ExtensionMethods
    {
        /// <summary>
        /// Determines whether the current value is between (&gt;=) <paramref name="startValue"/> and (&lt;=) <paramref name="endValue"/>
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="startValue">The start value.</param>
        /// <param name="endValue">The end value.</param>
        /// <returns>
        ///   <c>true</c> if the specified current value is between <paramref name="startValue"/> and <paramref name="endValue"/>; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsBetween(this UInt32 currentValue, Int32 startValue, Int32 endValue)
        {
            Boolean retVal = currentValue >= startValue && currentValue <= endValue;

            return retVal;
        }

        /// <summary>
        /// Determines whether the current value is between (&gt;=) <paramref name="startValue"/> and (&lt;=) <paramref name="endValue"/>
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="startValue">The start value.</param>
        /// <param name="endValue">The end value.</param>
        /// <returns>
        ///   <c>true</c> if the specified current value is between <paramref name="startValue"/> and <paramref name="endValue"/>; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsBetween(this UInt32 currentValue, UInt32 startValue, UInt32 endValue)
        {
            Boolean retVal = currentValue >= startValue && currentValue <= endValue;

            return retVal;
        }

        /// <summary>
        /// Determines whether the current value is between (&gt;=) <paramref name="startValue"/> and (&lt;=) <paramref name="endValue"/>
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="startValue">The start value.</param>
        /// <param name="endValue">The end value.</param>
        /// <returns>
        ///   <c>true</c> if the specified current value is between <paramref name="startValue"/> and <paramref name="endValue"/>; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsBetween(this UInt32? currentValue, Int32 startValue, Int32 endValue)
        {
            Boolean retVal = false;

            if (currentValue.HasValue)
            {
                retVal = currentValue >= startValue && currentValue <= endValue;
            }

            return retVal;
        }

        /// <summary>
        /// Determines whether the current value is between (&gt;=) <paramref name="startValue"/> and (&lt;=) <paramref name="endValue"/>
        /// </summary>
        /// <param name="currentValue">The current value.</param>
        /// <param name="startValue">The start value.</param>
        /// <param name="endValue">The end value.</param>
        /// <returns>
        ///   <c>true</c> if the specified current value is between <paramref name="startValue"/> and <paramref name="endValue"/>; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean IsBetween(this UInt32? currentValue, UInt32 startValue, UInt32 endValue)
        {
            Boolean retVal = false;

            if (currentValue.HasValue)
            {
                retVal = currentValue >= startValue && currentValue <= endValue;
            }

            return retVal;
        }
    }
}
