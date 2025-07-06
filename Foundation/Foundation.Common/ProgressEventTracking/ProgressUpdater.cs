//-----------------------------------------------------------------------
// <copyright file="ProgressUpdater.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Text;

using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.Common
{
    /// <summary>
    /// The Progress Updater class
    /// </summary>
    public abstract class ProgressUpdater : IProgressUpdater
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ProgressUpdater"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        protected ProgressUpdater(ProgressItem item)
        {
            ProgressItem = item;
        }

        /// <summary>
        /// Gets the progress.
        /// </summary>
        /// <value>
        /// The progress.
        /// </value>
        public virtual Int32 Progress { get; private set; }

        /// <summary>
        /// Gets or sets the maximum.
        /// </summary>
        /// <value>
        /// The maximum.
        /// </value>
        public virtual Int32 Maximum { get; set; }

        /// <summary>
        /// Gets or sets the minimum.
        /// </summary>
        /// <value>
        /// The minimum.
        /// </value>
        public virtual Int32 Minimum { get; set; }

        /// <summary>
        /// Gets or sets the step amount.
        /// </summary>
        /// <value>
        /// The step amount.
        /// </value>
        public virtual Int32 StepAmount { get; set; }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public String Action => ProgressItem.Action;

        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        /// <value>
        /// The type of the event.
        /// </value>
        public MessageType EventType
        {
            get => ProgressItem.EventType;
            set
            {
                ProgressItem.EventType = value;
                UpdateEventType(ProgressItem.EventType);
            }
        }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public String Status
        {
            get => ProgressItem.Status;
            set
            {
                ProgressItem.Status = value;
                UpdateEventStatus(ProgressItem.Status);
            }
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public String Message
        {
            get => ProgressItem.Message;
            set
            {
                ProgressItem.Message = value;
                UpdateEventMessage(ProgressItem.Message);
            }
        }

        /// <summary>
        /// Gets or sets the progress item.
        /// </summary>
        /// <value>
        /// The progress item.
        /// </value>
        protected ProgressItem ProgressItem { get; set; }

        /// <summary>
        /// Starts the event.
        /// </summary>
        public abstract void StartEvent();

        /// <summary>
        /// Formats the progress item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The formatted progress item</returns>
        public virtual StringBuilder FormatProgressItem(ProgressItem item)
        {
            StringBuilder line = new();

            line.Append(item.TimeOfEntry.ToString(Formats.DotNet.DateTimeMilliseconds));
            line.Append(" ");
            line.Append(item.Action);
            line.Append(" ");
            line.Append(item.Status);
            line.Append(" ");
            line.Append(item.Message);
            line.Append(Environment.NewLine);

            return line;
        }

        /// <summary>
        /// Updates the event.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="status">The status.</param>
        /// <param name="message">The message.</param>
        public void UpdateEvent(MessageType eventType, string status, string message)
        {
            ProgressItem newItem = ProgressItem.AddHistory(eventType, status, message);

            UpdateEvent(newItem);
        }

        /// <summary>
        /// Increments this instance.
        /// </summary>
        /// <returns>
        /// Increments the progress by one
        /// </returns>
        public virtual Int32 Increment()
        {
            return Increment(StepAmount);
        }

        /// <summary>
        /// Increments the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns>
        /// Increments the progress by the specified amount
        /// </returns>
        public virtual Int32 Increment(Int32 amount)
        {
            Progress += amount;

            return Progress;
        }

        /// <summary>
        /// Updates the event.
        /// </summary>
        /// <param name="item">The item.</param>
        protected abstract void UpdateEvent(ProgressItem item);

        /// <summary>
        /// Updates the type of the event.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        protected void UpdateEventType(MessageType eventType)
        {
            ProgressItem newItem = ProgressItem.AddHistory(eventType, ProgressItem.Status, ProgressItem.Message);

            UpdateEvent(newItem);
        }

        /// <summary>
        /// Updates the event status.
        /// </summary>
        /// <param name="status">The status.</param>
        protected void UpdateEventStatus(String status)
        {
            ProgressItem newItem = ProgressItem.AddHistory(ProgressItem.EventType, status, ProgressItem.Message);

            UpdateEvent(newItem);
        }

        /// <summary>
        /// Updates the event message.
        /// </summary>
        /// <param name="message">The message.</param>
        protected void UpdateEventMessage(String message)
        {
            ProgressItem newItem = ProgressItem.AddHistory(ProgressItem.EventType, ProgressItem.Status, message);

            UpdateEvent(newItem);
        }
    }
}
