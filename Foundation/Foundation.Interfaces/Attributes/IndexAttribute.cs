//-----------------------------------------------------------------------
// <copyright file="IndexAttribute.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the Index Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IndexAttribute : Attribute
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="IndexAttribute" /> class.
        /// </summary>
        /// <param name="newIndex">The new Index.</param>
        public IndexAttribute(Int32 newIndex)
        {
            Index = newIndex;
        }

        /// <summary>
        /// Gets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public Int32 Index { get; }
    }
}
