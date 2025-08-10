//-----------------------------------------------------------------------
// <copyright file="EventLog.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Event Log data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class EventLog : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The batch name
            /// </summary>
            public const Int32 BatchName = 100;

            /// <summary>
            /// The process name
            /// </summary>
            public const Int32 ProcessName = 100;

            /// <summary>
            /// The task name
            /// </summary>
            public const Int32 TaskName = 100;

            /// <summary>
            /// The result
            /// </summary>
            public const Int32 Result = -1;

            /// <summary>
            /// The information
            /// </summary>
            public const Int32 Information = -1;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => "EventLog";

        /// <summary>
        /// Gets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        public static String ApplicationId => "ApplicationId";

        /// <summary>
        /// Gets the parent identifier.
        /// </summary>
        /// <value>
        /// The parent identifier.
        /// </value>
        public static String ParentId => "ParentId";

        /// <summary>
        /// Gets the log severity identifier.
        /// </summary>
        /// <value>
        /// The log severity identifier.
        /// </value>
        public static String LogSeverityId => "LogSeverityId";


        /// <summary>
        /// Gets the scheduled task identifier.
        /// </summary>
        /// <value>
        /// The scheduled task identifier.
        /// </value>
        public static String ScheduledTaskId => "ScheduledTaskId";

        /// <summary>
        /// Gets the name of the batch.
        /// </summary>
        /// <value>
        /// The name of the batch.
        /// </value>
        public static String BatchName => "BatchName";

        /// <summary>
        /// Gets the name of the process.
        /// </summary>
        /// <value>
        /// The name of the process.
        /// </value>
        public static String ProcessName => "ProcessName";

        /// <summary>
        /// Gets the name of the task.
        /// </summary>
        /// <value>
        /// The name of the task.
        /// </value>
        public static String TaskName => "TaskName";

        /// <summary>
        /// Gets the task status id.
        /// </summary>
        /// <value>
        /// The task status id.
        /// </value>
        public static String TaskStatusId => "TaskStatusId";

        /// <summary>
        /// Gets the started on.
        /// </summary>
        /// <value>
        /// The started on.
        /// </value>
        public static String StartedOn => "StartedOn";

        /// <summary>
        /// Gets the finished on.
        /// </summary>
        /// <value>
        /// The finished on.
        /// </value>
        public static String FinishedOn => "FinishedOn";

        /// <summary>
        /// Gets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        public static String Information => "Information";
    }
}
