//-----------------------------------------------------------------------
// <copyright file="EnumerableExtensionMethods.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;

namespace Foundation.Common
{
    /// <summary>
    /// Defines extension methods for the <see cref="IEnumerable{TValue}"/> type
    /// type
    /// </summary>
    public static class EnumerableExtensionMethods
    {
        /// <summary>
        /// Determines whether this instance has members.
        /// (val != null &amp;&amp; val.Any())
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value has members; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean HasItems<TValue>(this IEnumerable<TValue>? val)
        {
            return val != null && val.Any();
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
        public static Boolean HasItems<TValue>(this IEnumerable<TValue>? val, Func<TValue, Boolean> predicate)
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
        public static Boolean None<TValue>(this IEnumerable<TValue>? val)
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
        public static Boolean None<TValue>(this IEnumerable<TValue>? val, Func<TValue, Boolean> predicate)
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
        [return: NotNull]
        public static IEnumerable<TValue> Clone<TValue>(this IEnumerable<TValue> listToClone)
        {
            IEnumerable<TValue> retVal = listToClone.Select(item =>
            {
                if (item is ICloneable cloneable)
                {
                    return (TValue)cloneable.Clone();
                }
                return item;
            }).ToList();

            return retVal;
        }

        ///// <summary>
        ///// Clones a list of objects. The contained objects should implement <see cref="ICloneable"/>
        ///// </summary>
        ///// <typeparam name="TValue">The Type of the Objects</typeparam>
        ///// <param name="listToClone">Source list that is to be cloned</param>
        ///// <returns>
        ///// A cloned list
        ///// </returns>
        //public static IEnumerable<TValue> Clone<TValue>(this IEnumerable<TValue> listToClone) where TValue : ICloneable
        //{
        //    List<TValue> retVal = listToClone.Select(item => (TValue)item.Clone()).ToList();

        //    return retVal;
        //}
    }
}
