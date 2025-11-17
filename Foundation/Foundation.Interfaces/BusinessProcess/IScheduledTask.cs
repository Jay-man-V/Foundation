//-----------------------------------------------------------------------
// <copyright file="IScheduledTask.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Scheduled task
    /// IScheduledTask is an interface that should be implemented by tasks that support Scheduling
    /// </summary>
    public interface IScheduledTask
    {
        EventHandler? ProcessJobCalled { get; set; }

        /// <summary>
        /// Causes the Scheduled Task to run.
        /// </summary>
        /// <param name="logId"></param>
        /// <param name="taskParameters"></param>
        void Process(LogId logId, String taskParameters);
    }
}
