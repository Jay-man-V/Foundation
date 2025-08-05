//-----------------------------------------------------------------------
// <copyright file="IScheduledJobProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Scheduled Job Business process 
    /// </summary>
    public interface IScheduledJobProcess : ICommonBusinessProcess<IScheduledJob>
    {
        /// <summary>
        /// 
        /// </summary>
        event EventHandler<CreateScheduledTaskEventArgs> AlternateCreateScheduledTaskCalled;

        /// <summary>
        /// Initialises the schedulers for each of the Job.
        /// The schedulers will not be started after this is called
        /// </summary>
        /// <param name="parentLogId">The parent log id</param>
        void InitialiseJobs(LogId parentLogId);

        /// <summary>
        /// Starts the jobs
        /// </summary>
        /// <param name="parentLogId">The parent log id</param>
        void StartJobs(LogId parentLogId);

        /// <summary>
        /// Resumes the jobs after pausing/stopping
        /// </summary>
        /// <param name="parentLogId">The parent log id</param>
        void ResumeJobs(LogId parentLogId);

        /// <summary>
        /// Stops the jobs
        /// </summary>
        /// <param name="parentLogId">The parent log id</param>
        void StopJobs(LogId parentLogId);

        /// <summary>
        /// Uses Reflection to create an instance of the <see cref="IScheduledJob.TaskImplementationType"/>.
        /// <see cref="IScheduledJob.TaskImplementationType"/> must implement <see cref="IScheduledTask"/>
        /// </summary>
        /// <param name="scheduledJob">The <see cref="IScheduledJob"/> </param>
        /// <returns>Instance of <see cref="IScheduledJob.TaskImplementationType"/></returns>
        IScheduledTask CreateScheduledTask(IScheduledJob scheduledJob);

        /// <summary>
        /// Gets the status of the task that implements <seealso cref="IScheduledJob"/>
        /// </summary>
        /// <param name="scheduledJob"></param>
        /// <returns></returns>
        ServiceStatus GetServiceStatus(IScheduledJob scheduledJob);

        /// <summary>
        /// Gets the status of the Windows Service specified by <paramref name="serverName"/> on the target <paramref name="serverName"/>
        /// </summary>
        /// <param name="serverName">The name of the server hosting the service</param>
        /// <param name="serviceName">The name of the service to query</param>
        /// <returns></returns>
        ServiceStatus GetServiceStatus(String serverName, String serviceName);

        /// <summary>
        /// Determines the last run status of the given <paramref name="scheduledJob"/>
        /// </summary>
        /// <param name="scheduledJob">The <see cref="IScheduledJob"/> </param>
        /// <returns></returns>
        TaskStatus GetJobLastRunStatus(IScheduledJob scheduledJob);

        /// <summary>
        /// Runs the given job
        /// </summary>
        /// <param name="parentLogId"></param>
        /// <param name="scheduledJob"></param>
        /// <returns></returns>
        LogId RunJob(LogId parentLogId, IScheduledJob scheduledJob);
    }
}
