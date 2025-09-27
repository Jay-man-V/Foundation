//-----------------------------------------------------------------------
// <copyright file="ProgressItem.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// The ProgressItem class
    /// </summary>
    public class ProgressItem
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ProgressItem"/> class.
        /// </summary>
        /// <param name="dateTimeService">The date/time service.</param>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="action">The action.</param>
        /// <param name="status">The status.</param>
        /// <param name="message">The message.</param>
        public ProgressItem(IDateTimeService dateTimeService, MessageType eventType, String action, String status, String message)
        {
            DateTimeService = dateTimeService;

            Index = 0;
            TimeOfEntry = DateTimeService.SystemUtcDateTimeNow;
            History = [];

            EventType = eventType;
            Action = action;
            Status = status;
            Message = message;
        }

        /// <summary>
        /// The date/time service
        /// </summary>
        protected IDateTimeService DateTimeService { get; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public Int32 Index { get; set; }

        /// <summary>
        /// Gets or sets the time of entry.
        /// </summary>
        /// <value>
        /// The time of entry.
        /// </value>
        public DateTime TimeOfEntry { get; set; }

        /// <summary>
        /// Gets or sets the history.
        /// </summary>
        /// <value>
        /// The history.
        /// </value>
        public List<ProgressItem> History { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        public String Action { get; set; }

        /// <summary>
        /// Gets or sets the type of the event.
        /// </summary>
        /// <value>
        /// The type of the event.
        /// </value>
        public MessageType EventType { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public String Status { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public String Message { get; set; }

        /// <summary>
        /// Adds the history.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The newly added Progress Item</returns>
        public ProgressItem AddHistory(ProgressItem item)
        {
            item.Index = History.Count + 1;
            History.Add(item);

            return item;
        }

        /// <summary>
        /// Adds the history.
        /// </summary>
        /// <param name="eventType">Type of the event.</param>
        /// <param name="status">The status.</param>
        /// <param name="message">The message.</param>
        /// <returns>The newly added Progress Item</returns>
        public ProgressItem AddHistory(MessageType eventType, String status, String message)
        {
            ProgressItem newItem = new ProgressItem(DateTimeService, eventType, Action, status, message);
            ProgressItem retVal = AddHistory(newItem);

            return retVal;
        }
    }
}
