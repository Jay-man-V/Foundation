//-----------------------------------------------------------------------
// <copyright file="IProgressEventTracking.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text;

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// The interface IProgressEventTracker
    /// </summary>
    public interface IProgressEventTracker
    {
        /// <summary>
        /// Occurs when [copy to clip board].
        /// </summary>
        event EventHandler<CopyToClipBoardEventArgs> CopyToClipBoard;

        /// <summary>
        /// Adds the event.
        /// </summary>
        /// <param name="dateTimeService">The date/time service</param>
        /// <param name="progressEvent">The progress event.</param>
        /// <param name="action">The action.</param>
        /// <param name="status">The status.</param>
        /// <param name="message">The message.</param>
        /// <returns>The <see cref="IProgressUpdater"/> for the added event</returns>
        IProgressUpdater AddEvent(IDateTimeService dateTimeService, MessageType progressEvent, String action, String status, String message);

        /// <summary>
        /// Generates the report.
        /// </summary>
        /// <returns>The report based on the added events</returns>
        StringBuilder GenerateReport();

        /// <summary>
        /// Formats the progress item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The formatted Progress Item</returns>
        StringBuilder FormatProgressItem(ProgressItem item);

        /// <summary>
        /// Copies the report to clipboard.
        /// </summary>
        void CopyReportToClipboard();
    }
}
