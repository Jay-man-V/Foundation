//-----------------------------------------------------------------------
// <copyright file="IEventLogAttachment.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Event Log Attachment model interface
    /// </summary>
    public interface IEventLogAttachment : IFoundationModel
    {
        /// <summary>Gets or sets the name of the event log id.</summary>
        /// <value>The event log id.</value>
        LogId EventLogId { get; set; }

        /// <summary>Gets or sets the name of the attachment file.</summary>
        /// <value>The name of the attachment file.</value>
        String AttachmentFileName { get; set; }

        /// <summary>Gets or sets the attachment.</summary>
        /// <value>The attachment.</value>
        Byte[]? Attachment { get; set; }
    }
}
