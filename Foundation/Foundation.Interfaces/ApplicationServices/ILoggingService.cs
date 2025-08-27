//-----------------------------------------------------------------------
// <copyright file="ILoggingService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILoggingService
    {
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
        IEventLog? GetLatest(Boolean isFinished, EntityId scheduledTaskId = new(), String? batchName = null, String? processName = null, String? taskName = null);

        /// <summary>
        /// Logs a Start Task message with the supplied parameters
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="batchName"></param>
        /// <param name="processName"></param>
        /// <param name="taskName"></param>
        /// <returns></returns>
        LogId StartTask(AppId applicationId, String batchName, String processName, String taskName);

        /// <summary>
        /// Logs an End Task message with the supplied parameters
        /// </summary>
        /// <param name="logId"></param>
        /// <param name="logSeverity"></param>
        /// <param name="information"></param>
        void EndTask(LogId logId, LogSeverity logSeverity, String information);

        /// <summary>
        /// Logs an End Task message with the supplied parameters
        /// </summary>
        /// <param name="logId"></param>
        /// <param name="logSeverity"></param>
        /// <param name="exception"></param>
        void EndTask(LogId logId, LogSeverity logSeverity, Exception exception);

        /// <summary>
        /// Creates a log entry with the supplied parameters
        /// </summary>
        /// <param name="parentLogId"></param>
        /// <param name="applicationId"></param>
        /// <param name="batchName"></param>
        /// <param name="processName"></param>
        /// <param name="taskName"></param>
        /// <param name="logSeverity"></param>
        /// <param name="information"></param>
        /// <returns></returns>
        LogId CreateLogEntry(LogId parentLogId, AppId applicationId, String batchName, String processName, String taskName, LogSeverity logSeverity, String information);

        /// <summary>
        /// Creates a log entry with the supplied parameters
        /// </summary>
        /// <param name="parentLogId"></param>
        /// <param name="applicationId"></param>
        /// <param name="logSeverity"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        LogId CreateLogEntry(LogId parentLogId, AppId applicationId, LogSeverity logSeverity, Exception exception);

        /// <summary>
        /// Updates an existing log entry
        /// </summary>
        /// <param name="logId"></param>
        /// <param name="information"></param>
        void UpdateLogEntry(LogId logId, String information);
    }
}
