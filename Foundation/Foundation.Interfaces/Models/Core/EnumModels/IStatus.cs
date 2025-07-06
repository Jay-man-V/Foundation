//-----------------------------------------------------------------------
// <copyright file="IStatus.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Status model interface
    /// </summary>
    public interface IStatus : IFoundationModel
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        String Name { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        String Description { get; set; }
    }
}
