//-----------------------------------------------------------------------
// <copyright file="IMailMessage.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Mail Message
    /// </summary>
    public interface IMailMessage : ICloneable
    {
        /// <summary>
        /// Gets or sets from address.
        /// </summary>
        /// <value>
        /// From address.
        /// </value>
        String FromAddress { get; set; }

        /// <summary>
        /// Gets or sets the display name of from address.
        /// </summary>
        /// <value>
        /// The display name of from address.
        /// </value>
        String FromAddressDisplayName { get; set; }

        /// <summary>
        /// Gets or sets to address.
        /// </summary>
        /// <value>
        /// To address.
        /// </value>
        List<String> ToAddress { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        String Body { get; set; }

        /// <summary>
        /// Gets or sets is body html.
        /// </summary>
        /// <value>
        /// Boolean.
        /// </value>
        Boolean IsBodyHtml { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        String Subject { get; set; }

        /// <summary>
        /// Gets the attachments.
        /// </summary>
        /// <value>
        /// The attachments.
        /// </value>
        List<IMailAttachment> Attachments { get; set; }
    }
}
