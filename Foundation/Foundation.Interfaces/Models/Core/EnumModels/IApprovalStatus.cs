//-----------------------------------------------------------------------
// <copyright file="IApprovalStatus.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Approval Status model interface
    /// </summary>
    public interface IApprovalStatus : IFoundationModel
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        String Name { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        String Description { get; set; }
    }
}
