//-----------------------------------------------------------------------
// <copyright file="ScheduledJob.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Scheduled Job data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class ScheduledJob : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The name
            /// </summary>
            public const Int32 Name = 150;

            /// <summary>
            /// The task implementation type
            /// </summary>
            public const Int32 TaskImplementationType = 500;

            /// <summary>
            /// The task parameters
            /// </summary>
            public const Int32 TaskParameters = 1000;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(ScheduledJob);

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public static String Name => "Name";

        /// <summary>
        /// Gets the schedule interval identifier.
        /// </summary>
        /// <value>
        /// The schedule interval identifier.
        /// </value>
        public static String ScheduleIntervalId => "ScheduleIntervalId";

        /// <summary>
        /// Gets the last run date time.
        /// </summary>
        /// <value>
        /// The last run date time.
        /// </value>
        public static String LastRunDateTime => "LastRunDateTime";

        /// <summary>
        /// Gets the next run date time.
        /// </summary>
        /// <value>
        /// The next run date time.
        /// </value>
        public static String NextRunDateTime => "NextRunDateTime";

        /// <summary>
        /// Whether the Job should immediately run once on initialisation, after this, it reverts to its schedule
        /// </summary>
        public static String RunImmediately => "RunImmediately";

        /// <summary>
        /// Gets the start time.
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        public static String StartTime => "StartTime";

        /// <summary>
        /// Gets the end time.
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        public static String EndTime => "EndTime";

        /// <summary>
        /// Gets the interval.
        /// </summary>
        /// <value>
        /// The interval.
        /// </value>
        public static String Interval => "Interval";

        /// <summary>
        /// Gets the is enabled.
        /// </summary>
        /// <value>
        /// The is enabled.
        /// </value>
        public static String IsEnabled => "IsEnabled";

        /// <summary>
        /// Gets the type of the task implementation.
        /// </summary>
        /// <value>
        /// The type of the task implementation.
        /// </value>
        public static String TaskImplementationType => "TaskImplementationType";

        /// <summary>
        /// Gets the task parameters.
        /// </summary>
        /// <value>
        /// The task parameters.
        /// </value>
        public static String TaskParameters => "TaskParameters";
    }
}
