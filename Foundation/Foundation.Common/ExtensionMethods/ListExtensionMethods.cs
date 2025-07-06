//-----------------------------------------------------------------------
// <copyright file="ListExtensionMethods.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Foundation.Common
{
    /// <summary>
    /// Defines extension methods for the <see cref="IList"/> type
    /// type
    /// </summary>
    public static class ListExtensionMethods
    {
        /// <summary>
        /// Determines whether this instance has members.
        /// (val != null &amp;&amp; val.Count > 0)
        /// </summary>
        /// <param name="val">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value has members; otherwise, <c>false</c>.
        /// </returns>
        public static Boolean HasItems<TValue>(this List<TValue> val)
        {
            return (val != null && val.Any());
        }

        ///// <summary>
        ///// Clones a list of objects. The contained objects should implement <see cref="ICloneable"/>
        ///// </summary>
        ///// <typeparam name="TValue">The Type of the Objects</typeparam>
        ///// <param name="listToClone">Source list that is to be cloned</param>
        ///// <returns>
        ///// A cloned list
        ///// </returns>
        //public static List<TValue> Clone<TValue>(this List<TValue> listToClone)
        //{
        //    List<TValue> retVal = listToClone.Select(item => item).ToList();

        //    return retVal;
        //}

        /// <summary>
        /// Clones a list of objects. The contained objects should implement <see cref="ICloneable"/>
        /// </summary>
        /// <typeparam name="TValue">The Type of the Objects</typeparam>
        /// <param name="listToClone">Source list that is to be cloned</param>
        /// <returns>
        /// A cloned list
        /// </returns>
        public static List<TValue> Clone<TValue>(this List<TValue> listToClone) where TValue : ICloneable
        {
            List<TValue> retVal = listToClone.Select(item => (TValue)item.Clone()).ToList();

            return retVal;
        }
    }
}
