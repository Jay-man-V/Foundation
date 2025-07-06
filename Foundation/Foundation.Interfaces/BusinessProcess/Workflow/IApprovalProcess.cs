//-----------------------------------------------------------------------
// <copyright file="IApprovalProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Approval Process class
    /// </summary>
    public interface IApprovalProcess : ICommonBusinessProcess<IApprovalTask>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="approvalTaskId"></param>
        /// <param name="actionReason"></param>
        void ApproveTask(EntityId approvalTaskId, String actionReason);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="approvalTaskId"></param>
        /// <param name="actionReason"></param>
        void RejectTask(EntityId approvalTaskId, String actionReason);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="approvalTaskId"></param>
        /// <param name="additionalInformation"></param>
        void SendReminder(EntityId approvalTaskId, String additionalInformation);
    }
}
