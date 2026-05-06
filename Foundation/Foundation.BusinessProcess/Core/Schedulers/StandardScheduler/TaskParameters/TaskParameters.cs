//-----------------------------------------------------------------------
// <copyright file="TaskParameters.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.BusinessProcess.Core.Schedulers.StandardScheduler.TaskParameters
{
    /// <summary>
    /// Represents the base class for parameter objects used to configure tasks.
    /// </summary>
    /// <remarks>
    /// Inherit from this class to define strongly typed parameters for specific task
    /// implementations. This class is intended to be extended and does not contain any members itself.
    /// </remarks>
    public abstract class TaskParameters
    {
        /// <summary>
        /// Gets or sets the name of the application associated with the current context.
        /// </summary>
        public String ApplicationName { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the name of the batch associated with the operation.
        /// </summary>
        public String BatchName { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the name of the task.
        /// </summary>
        public String TaskName { get; set; } = String.Empty;
    }
}
