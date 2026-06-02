//-----------------------------------------------------------------------
// <copyright file="IScheduledTask.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces.ScheduledTasks
{
    /// <summary>
    /// Defines the behaviour of the Scheduled task
    /// IScheduledTask is an interface that should be implemented by tasks that support Scheduling
    /// </summary>
    public interface IScheduledTask
    {
        /// <summary>
        /// The Date/Time the Scheduled Job was created. This is set when the scheduled task is initialized.
        /// </summary>
        DateTime JobStartTime { get; }

        /// <summary>
        /// The Date/Time the Scheduled Task was started. This is set when the scheduled task runs.
        /// </summary>
        DateTime TaskStartTime { get; }

        /// <summary>
        /// The Date/Time the Scheduled Task last ran. This is set when the scheduled task completes.
        /// </summary>
        DateTime LastRunDateTime { get; }

        /// <summary>
        /// Gets or sets the event handler that is invoked when the task is starting.
        /// </summary>
        /// <remarks>
        /// Attach a handler to perform custom actions immediately before the task begins
        /// execution. If multiple handlers are attached, they are invoked in the order they were added.
        /// </remarks>
        EventHandler<TaskEventArgs>? RunTaskStarting { get; set; }

        /// <summary>
        /// Gets or sets the event handler that is invoked when the task is ending.
        /// </summary>
        /// <remarks>
        /// Assign a handler to perform custom actions when the task completes. The event is
        /// triggered at the end of the task's execution, regardless of success or failure.
        /// </remarks>
        EventHandler<TaskEventArgs>? RunTaskEnding { get; set; }

        /// <summary>
        /// Causes the Scheduled Task to run.
        /// </summary>
        /// <param name="parentLogId"></param>
        /// <param name="taskParameters"></param>
        void RunTask(LogId parentLogId, String taskParameters);
    }
}
