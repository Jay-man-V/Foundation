//-----------------------------------------------------------------------
// <copyright file="TaskEventArgs.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logId"></param>
        /// <param name="taskParameters"></param>
        public TaskEventArgs(LogId logId, String taskParameters)
        {
            LogId = logId;
            TaskParameters = taskParameters;
        }

        /// <summary>
        /// Gets the log id.
        /// </summary>
        public LogId LogId { get; }

        /// <summary>
        /// Gets the task parameters.
        /// </summary>
        public String TaskParameters { get; }
    }
}
