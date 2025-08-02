//-----------------------------------------------------------------------
// <copyright file="IListExtensionMethods.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;

namespace Foundation.Common
{
    /// <summary>
    /// Defines extension methods for the <see cref="IList"/> type
    /// type
    /// </summary>
    public static class IListExtensionMethods
    {
        /// <summary>
        /// Determines whether this instance has members.
        /// (val != null &amp;&amp; val.Count > 0)
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value has members; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean HasItems<TValue>(this IList<TValue>? val)
        {
            return (val != null && val.Any());
        }

        /// <summary>
        /// Determines whether this instance has members.
        /// (val != null &amp;&amp; val.Any(predicate))
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="predicate">The predicate to be applied to the check</param>
        /// <returns>
        ///   <c>true</c> if the specified value has members; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean HasItems<TValue>(this IList<TValue>? val, Func<TValue, Boolean> predicate)
        {
            return val != null && val.Any(predicate);
        }

        /// <summary>
        /// Determines whether this instance has members.
        /// (val == null || !val.Any())
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>
        ///   <c>false</c> if the specified value has members; otherwise, <c>true</c>.
        /// </returns>
        public static Boolean None<TValue>(this IList<TValue>? val)
        {
            return val == null || !val.Any();
        }

        /// <summary>
        /// Determines whether this instance has members.
        /// (val == null || !val.Any(predicate))
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="predicate">The predicate to be applied to the check</param>
        /// <returns>
        ///   <c>false</c> if the specified value has members; otherwise, <c>true</c>.
        /// </returns>
        public static Boolean None<TValue>(this IList<TValue>? val, Func<TValue, Boolean> predicate)
        {
            return val == null || !val.Any(predicate);
        }

        /// <summary>
        /// Clones a list of objects. The contained objects should implement <see cref="ICloneable"/>
        /// </summary>
        /// <typeparam name="TValue">The Type of the Objects</typeparam>
        /// <param name="listToClone">Source list that is to be cloned</param>
        /// <returns>
        /// A cloned list
        /// </returns>
        public static IList<TValue> Clone<TValue>(this IList<TValue> listToClone) where TValue : ICloneable
        {
            List<TValue> retVal = listToClone.Select(item => (TValue)item.Clone()).ToList();

            return retVal;
        }
    }
}
