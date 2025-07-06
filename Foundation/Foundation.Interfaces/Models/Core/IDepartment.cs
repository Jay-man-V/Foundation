//-----------------------------------------------------------------------
// <copyright file="IDepartment.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Department model interface
    /// </summary>
    public interface IDepartment : IFoundationModel
    {
        /// <summary>Gets or sets the code.</summary>
        /// <value>The code.</value>
        String Code { get; set; }

        /// <summary>Gets or sets the short name.</summary>
        /// <value>The short name.</value>
        String ShortName { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        String Description { get; set; }
    }
}
