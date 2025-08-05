//-----------------------------------------------------------------------
// <copyright file="IMailAttachment.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Mail Attachment
    /// </summary>
    public interface IMailAttachment : ICloneable
    {
        /// <summary>
        /// Name of the file to be attached
        /// </summary>
        String Filename { get; set; }

        /// <summary>
        /// Gets or sets the subject.
        /// </summary>
        /// <value>
        /// The subject.
        /// </value>
        Byte[] Content { get; set; }
    }
}