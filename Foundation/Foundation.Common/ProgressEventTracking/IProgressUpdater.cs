//-----------------------------------------------------------------------
// <copyright file="IProgressUpdater.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// The interface IProgressUpdater
    /// </summary>
    public interface IProgressUpdater
    {
        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        /// <value>
        /// The type of the event.
        /// </value>
        MessageType EventType { get; set; }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        String Action { get; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        String Status { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        String Message { get; set; }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>
        /// The maximum.
        /// </value>
        Int32 Maximum { get; set; }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>
        /// The minimum.
        /// </value>
        Int32 Minimum { get; set; }

        /// <summary>
        /// Gets or sets the step amount.
        /// </summary>
        /// <value>
        /// The step amount.
        /// </value>
        Int32 StepAmount { get; set; }

        /// <summary>
        /// Gets the progress.
        /// </summary>
        /// <value>
        /// The progress.
        /// </value>
        Int32 Progress { get; }

        /// <summary>
        /// Increments this instance.
        /// </summary>
        /// <returns>Increments the progress by one</returns>
        Int32 Increment();

        /// <summary>
        /// Increments the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns>Increments the progress by the specified amount</returns>
        Int32 Increment(Int32 amount);

        /// <summary>
        /// Starts the event.
        /// </summary>
        void StartEvent();

        /// <summary>
        /// Updates the event.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="status">The status.</param>
        /// <param name="message">The message.</param>
        void UpdateEvent(MessageType eventType, String status, String message);
    }
}
