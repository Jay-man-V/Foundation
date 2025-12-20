//-----------------------------------------------------------------------
// <copyright file="EntityStatus.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Entity Status Enumeration
    /// </summary>
    [Browsable(true),
     Category("Status"),
     Description("Specifies the entity status")]
    public enum EntityStatus
    {
        /// <summary>
        /// The entity is Inactive
        /// </summary>
        [Id(-1), Display(Order = 1, Name = "Inactive")]
        Inactive = -1,

        /// <summary>
        /// The entity is Active
        /// </summary>
        [Id(0), Display(Order = 2, Name = "Active")]
        Active = 0,

        /// <summary>
        /// Record is Approved for normal usage
        /// </summary>
        [Id(1), Display(Order = 3, Name = "Record is Approved for normal usage")]
        Approved = 1,

        /// <summary>
        /// Record is pending approval for normal usage
        /// </summary>
        [Id(2), Display(Order = 4, Name = "Record is pending approval for normal usage")]
        PendingApproval = 2,

        /// <summary>
        /// Record is not yet complete
        /// </summary>
        [Id(3), Display(Order = 5, Name = "Record is not yet complete")]
        Incomplete = 3,

        /// <summary>
        /// Record is rejected for usage
        /// </summary>
        [Id(4), Display(Order = 6, Name = "Record is rejected for usage")]
        Rejected = 4,
    }
}
