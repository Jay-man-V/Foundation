//-----------------------------------------------------------------------
// <copyright file="IEventLogRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Event Log Data Access interface
    /// </summary>
    public interface IEventLogRepository : IFoundationModelRepository<IEventLog>
    {
        /// <summary>
        /// Gets the specified event log.
        /// </summary>
        /// <param name="logId">The event log identifier.</param>
        /// <returns>Loaded event log</returns>
        IEventLog Get(LogId logId);

        /// <summary>
        /// Retrieves the latest <seealso cref="IEventLog"/> entry for the given parameters
        /// regardless of completion status
        /// <para>
        /// <paramref name="isFinished"/> must be specified.
        /// The remaining parameters can be specified or be left as default
        /// </para>
        /// </summary>
        /// <param name="isFinished"></param>
        /// <param name="scheduledTaskId"></param>
        /// <param name="batchName"></param>
        /// <param name="processName"></param>
        /// <param name="taskName"></param>
        /// <returns></returns>
        IEventLog GetLatest(Boolean isFinished, EntityId scheduledTaskId = new(), String? batchName = null, String? processName = null, String? taskName = null);
    }
}
