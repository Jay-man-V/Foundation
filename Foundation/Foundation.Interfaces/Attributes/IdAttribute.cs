//-----------------------------------------------------------------------
// <copyright file="IdAttribute.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the Id Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class IdAttribute : Attribute
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="IdAttribute" /> class.
        /// </summary>
        /// <param name="newId">The new Id.</param>
        public IdAttribute(Int32 newId)
        {
            Id = newId;
        }

        /// <summary>
        /// Gets the Id.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public Int32 Id { get; }
    }
}
