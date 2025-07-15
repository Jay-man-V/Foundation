//-----------------------------------------------------------------------
// <copyright file="ServerProcessTimer.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// ServiceProcessTimer class inherits <see cref="System.Timers.Timer"/> to provide a customised Timer component
    /// </summary>
    internal class ServerProcessTimer : System.Timers.Timer
    {
        private static readonly Int32 DefaultInterval = (Int32) new TimeSpan(0, 0, 30).TotalMilliseconds; // Default to 30 seconds

        /// <summary>
        /// Uses the <paramref name="scheduledJob"/> to set up the <see cref="System.Timers.Timer"/> with a Default Interval of 30,000ms
        /// </summary>
        /// <param name="scheduledJob">Encapsulated <see cref="IScheduledJob"/> that will be executed by this Timer</param>
        public ServerProcessTimer
        (
            IScheduledJob scheduledJob
        )
            : base
            (
                DefaultInterval
            )
        {
            LoggingHelpers.TraceCallEnter(scheduledJob);

            ScheduledJob = scheduledJob;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the encapsulated <see cref="IScheduledTask"/>.
        /// </summary>
        /// <value>
        /// The scheduled task.
        /// </value>
        public IScheduledJob ScheduledJob { get; }

        /// <summary>
        /// Gets the name of the Scheduled Job.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public String Name => ScheduledJob.Name;
    }
}
