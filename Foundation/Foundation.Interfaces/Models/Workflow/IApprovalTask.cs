//-----------------------------------------------------------------------
// <copyright file="IApprovalTask.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Approval Task model interface
    /// </summary>
    public interface IApprovalTask : IFoundationModel
    {
        // ProcessName / Approver

        /// <summary>
        /// 4-Eye ?
        /// 6-Eye ?
        /// Approver Position ?
        /// </summary>
        Int32 CurrentApprovalActions { get; set; }

        /// <summary>
        /// 4-Eye ?
        /// 6-Eye ?
        /// Approver Position ?
        /// </summary>
        Int32 RequiredApprovalActions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ApprovalStatus ApprovalStatus { get; }

        /// <summary>
        /// 
        /// </summary>
        EntityId TargetEntityId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        String EntityName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        String ProcessName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        EntityId ApprovalStatusId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        String Summary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        String Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        String ActionReason { get; set; }
    }
}
