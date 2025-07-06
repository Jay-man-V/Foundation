//-----------------------------------------------------------------------
// <copyright file="ApprovalStatus.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Available Approval Statuses
    /// </summary>
    public enum ApprovalStatus
    {
        /// <summary>
        /// Not Set
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Not set")]
        NotSet = 0,

        /// <summary>
        /// Approved
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Approved")]
        Approved = 1,

        /// <summary>
        /// Pending
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Pending")]
        Pending = 2,

        /// <summary>
        /// Rejected
        /// </summary>
        [Id(3), Display(Order = 3, Name = "Rejected")]
        Rejected = 3,
    }
}
