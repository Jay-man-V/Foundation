//-----------------------------------------------------------------------
// <copyright file="IScheduledJob.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Scheduled Job model interface
    /// </summary>
    public interface IScheduledJob : IFoundationModel
    {
        /// <summary>Gets the schedule interval.</summary>
        /// <value>The schedule interval.</value>
        ScheduleInterval ScheduleInterval { get; }

        /// <summary>
        /// [True] if the task is actively processing/running, otherwise [False]
        /// </summary>
        Boolean IsRunning { get; set; }

        /// <summary>
        /// [True] if the task should stop processing and terminate, otherwise [False]
        /// </summary>
        Boolean FirstRun { get; set; }

        /// <summary>
        /// [True] if the task should stop processing and terminate, otherwise [False]
        /// </summary>
        Boolean CancellationRequested { get; set; }

        /// <summary>
        /// The Scheduled Task that will be run by this Job
        /// </summary>
        IScheduledTask ScheduledTask { get; set; }

        /// <summary>
        /// The next Date/Time the scheduled task is set to run at
        /// </summary>
        DateTime LastRunDateTime { get; set; }

        /// <summary>
        /// The next Date/Time the scheduled task is set to run at
        /// </summary>
        DateTime NextRunDateTime { get; set; }

        /// <summary>Gets the parent scheduled jobs.</summary>
        /// <value>The parent scheduled tasks.</value>
        List<EntityId> ParentScheduledJobs { get; }

        /// <summary>Gets the child scheduled jobs.</summary>
        /// <value>The child scheduled tasks.</value>
        List<EntityId> ChildScheduledJobs { get; }

        /// <summary>
        /// Name of the Scheduled Task
        /// </summary>
        String Name { get; set; }

        /// <summary>
        /// The type of schedule interval.
        /// <para>
        /// <see cref="ScheduleInterval"/>
        /// </para>
        /// </summary>
        EntityId ScheduleIntervalId { get; set; }

        /// <summary>
        /// Whether the Job should immediately run once on initialisation, after this, it reverts to its schedule
        /// </summary>
        Boolean RunImmediately { get; set; }

        /// <summary>
        /// The time that the scheduled task will begin its work
        /// </summary>
        TimeSpan StartTime { get; set; }

        /// <summary>
        /// The time that the scheduled task will stop its work
        /// </summary>
        TimeSpan EndTime { get; set; }

        /// <summary>
        /// Interval between execution runs in Milliseconds|Seconds|Minutes|Hours|Days|Weeks|Months.
        /// Measurement type of the interval is based on the <see cref="ScheduleInterval"/> property.
        /// </summary>
        Int32 Interval { get; set; }

        /// <summary>
        /// Whether the Task is enabled
        /// </summary>
        Boolean IsEnabled { get; set; }

        /// <summary>
        /// The Fully Qualified Type Name of the .Net class that will run this job
        /// <para>
        /// The format of the value should be Xml example:
        /// </para>
        /// <para>
        /// &lt;TaskImplementation assembly="Foundation.BusinessProcess" type="Foundation.BusinessProcess.ScheduledJobProcess" /&gt;
        /// </para>
        /// </summary>
        String TaskImplementationType { get; set; }

        /// <summary>
        /// Parameter values that will be passed to the Task Implementation
        /// </summary>
        String TaskParameters { get; set; }
    }
}
