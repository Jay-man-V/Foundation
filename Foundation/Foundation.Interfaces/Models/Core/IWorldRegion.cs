//-----------------------------------------------------------------------
// <copyright file="IWorldRegion.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The World Region model interface
    /// </summary>
    public interface IWorldRegion : IFoundationModel
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        String Name { get; set; }
    }
}
