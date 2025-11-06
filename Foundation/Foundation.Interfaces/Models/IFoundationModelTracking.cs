//-----------------------------------------------------------------------
// <copyright file="IFoundationModelTracking.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The interface Foundation Model Tracking definition
    /// </summary>
    [DependencyInjectionIgnore]
    public interface IFoundationModelTracking
    {
        /// <summary>
        /// Gets the entity life.
        /// </summary>
        /// <value>
        /// The entity life.
        /// </value>
        EntityLife EntityLife { get; set; }

        /// <summary>
        /// Gets the state of the entity.
        /// </summary>
        /// <value>
        /// The state of the entity.
        /// </value>
        EntityState EntityState { get; set; }
    }
}
