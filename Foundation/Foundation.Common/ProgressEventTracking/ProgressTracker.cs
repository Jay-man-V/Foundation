//-----------------------------------------------------------------------
// <copyright file="ProgressTracker.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text;

using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.Common
{
    /// <summary>
    /// The ProgressTracker class
    /// </summary>
    public abstract class ProgressTracker : IProgressEventTracker
    {
        /// <summary>
        /// Occurs when [copy to clip board].
        /// </summary>
        public event EventHandler<CopyToClipBoardEventArgs>? CopyToClipBoard;

        /// <summary>
        /// Initialises a new instance of the <see cref="ProgressTracker"/> class.
        /// </summary>
        protected ProgressTracker()
        {
            ProgressItems = [];
        }

        /// <summary>
        /// Gets the progress items.
        /// </summary>
        /// <value>
        /// The progress items.
        /// </value>
        protected List<ProgressItem> ProgressItems { get; }

        /// <inheritdoc cref="IProgressEventTracker.AddEvent(IDateTimeService, MessageType, String, String, String)"/>
        public IProgressUpdater AddEvent(IDateTimeService dateTimeService, MessageType progressEvent, String action, String status, String message)
        {
            ProgressItem newItem = new ProgressItem(dateTimeService, progressEvent, action, status, message);

            ProgressItems.Add(newItem);

            IProgressUpdater retVal = AddEvent(newItem);

            return retVal;
        }

        /// <inheritdoc cref="IProgressEventTracker.GenerateReport()"/>
        public StringBuilder GenerateReport()
        {
            const String separator = "-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-";
            StringBuilder retVal = new StringBuilder();
            foreach (ProgressItem item in ProgressItems)
            {
                StringBuilder line = GenerateReport(item);

                retVal.Append(line);

                retVal.Append(Environment.NewLine);
                retVal.Append(separator);
                retVal.Append(Environment.NewLine);
                retVal.Append(Environment.NewLine);
            }

            return retVal;
        }

        /// <inheritdoc cref="IProgressEventTracker.FormatProgressItem(ProgressItem)"/>
        public virtual StringBuilder FormatProgressItem(ProgressItem item)
        {
            StringBuilder retVal = new StringBuilder();

            retVal.Append(" - ");
            retVal.Append(item.TimeOfEntry.ToString(Formats.DotNet.DateTimeMilliseconds));
            retVal.Append(" ");
            retVal.Append(item.Action);
            retVal.Append(" ");
            retVal.Append(item.Status);
            retVal.Append(" ");
            retVal.Append(item.Message);
            retVal.Append(Environment.NewLine);

            return retVal;
        }

        /// <inheritdoc cref="IProgressEventTracker.CopyReportToClipboard()"/>
        public void CopyReportToClipboard()
        {
            EventHandler<CopyToClipBoardEventArgs>? handler = CopyToClipBoard;
            if (handler != null)
            {
                StringBuilder reportString = GenerateReport();
                CopyToClipBoardEventArgs eventArgs = new CopyToClipBoardEventArgs(reportString.ToString());
                handler.Invoke(this, eventArgs);
            }
        }

        /// <summary>
        /// Generates the report.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The generated report</returns>
        protected StringBuilder GenerateReport(ProgressItem item)
        {
            StringBuilder retVal = new StringBuilder();

            retVal.Append(FormatProgressItem(item));
            retVal.Append(Environment.NewLine);

            foreach (ProgressItem childItem in item.History)
            {
                StringBuilder line = GenerateReport(childItem);

                retVal.Append(line);
            }

            return retVal;
        }

        /// <summary>
        /// Adds the event.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The progress updater related to the added event</returns>
        protected abstract IProgressUpdater AddEvent(ProgressItem item);
    }
}
