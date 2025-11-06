//-----------------------------------------------------------------------
// <copyright file="IFoundationObjectId.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The interface Foundation Object Id definition
    /// </summary>
    [DependencyInjectionIgnore]
    public interface IFoundationObjectId
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        EntityId Id { get; set; }
    }
}
