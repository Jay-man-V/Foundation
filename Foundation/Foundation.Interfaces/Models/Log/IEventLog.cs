//-----------------------------------------------------------------------
// <copyright file="IEventLog.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Event Log model interface
    /// </summary>
    public interface IEventLog : IFoundationModel
    {
        /// <inheritdoc cref="IFoundationObjectId.Id"/>
        new LogId Id { get; set; }

        /// <summary>Gets or sets the application identifier.</summary>
        /// <value>The application identifier.</value>
        AppId ApplicationId { get; set; }

        /// <summary>Gets or sets the parent identifier.</summary>
        /// <value>The parent identifier.</value>
        LogId ParentId { get; set; }

        /// <summary>Gets the log severity.</summary>
        /// <value>The log severity.</value>
        LogSeverity LogSeverity { get; }

        /// <summary>Gets or sets the log severity identifier.</summary>
        /// <value>The log severity identifier.</value>
        EntityId LogSeverityId { get; set; }

        /// <summary>Gets or sets the scheduled task identifier.</summary>
        /// <value>The scheduled task identifier.</value>
        EntityId ScheduledTaskId { get; set; }

        /// <summary>Gets or sets the name of the batch.</summary>
        /// <value>The name of the batch.</value>
        String BatchName { get; set; }

        /// <summary>Gets or sets the name of the process.</summary>
        /// <value>The name of the process.</value>
        String ProcessName { get; set; }

        /// <summary>Gets or sets the name of the task.</summary>
        /// <value>The name of the task.</value>
        String TaskName { get; set; }

        /// <summary>Gets or sets the task status.</summary>
        /// <value>The task status.</value>
        TaskStatus TaskStatus { get; }

        /// <summary>Gets or sets the task status id.</summary>
        /// <value>The task status id.</value>
        EntityId TaskStatusId { get; set; }

        /// <summary>Gets or sets the started on.</summary>
        /// <value>The started on.</value>
        DateTime StartedOn { get; set; }

        /// <summary>Gets or sets the finished on.</summary>
        /// <value>The finished on.</value>
        DateTime FinishedOn { get; set; }

        /// <summary>Gets or sets the information.</summary>
        /// <value>The information.</value>
        String Information { get; set; }
    }
}
