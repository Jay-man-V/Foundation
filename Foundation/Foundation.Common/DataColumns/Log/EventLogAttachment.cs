//-----------------------------------------------------------------------
// <copyright file="EventLogAttachment.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Event Log Attachment data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class EventLogAttachment : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The attachment file name
            /// </summary>
            public const Int32 AttachmentFileName = 300;

            /// <summary>
            /// The attachment
            /// </summary>
            public const Int32 Attachment = -1;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => "EventLogAttachment";

        /// <summary>
        /// Gets the name of the event log id.
        /// </summary>
        /// <value>
        /// The event log id.
        /// </value>
        public static String EventLogId => "EventLogId";

        /// <summary>
        /// Gets the name of the attachment file.
        /// </summary>
        /// <value>
        /// The name of the attachment file.
        /// </value>
        public static String AttachmentFileName => "AttachmentFileName";

        /// <summary>
        /// Gets the attachment.
        /// </summary>
        /// <value>
        /// The attachment.
        /// </value>
        public static String Attachment => "Attachment";
    }
}
