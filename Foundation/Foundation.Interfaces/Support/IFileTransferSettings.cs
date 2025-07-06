//-----------------------------------------------------------------------
// <copyright file="IFileTransferSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Net;

namespace Foundation.Interfaces
{
    /// <summary>
    /// The interface File Transfer Settings definition
    /// </summary>
    public interface IFileTransferSettings
    {
        /// <summary>
        /// The method to use to transfer the file from the <see cref="Location"/>
        /// </summary>
        FileTransferMethod FileTransferMethod { get; set; }

        /// <summary>
        /// The location of the file and its name.
        /// <para>
        /// Examples:
        /// </para>
        /// <para>
        /// Local File Path -> D:\Applications\Data\Inbox\SourceFile.txt
        /// </para>
        /// <para>
        /// UNC File Path -> \\Server\Share\Applications\Data\Inbox\SourceFile.txt
        /// </para>
        /// <para>
        /// Internet Url path -> http://server.company.com/Applications/Data/Inbox/SourceFile.txt
        /// </para>
        /// </summary>
        String Location { get; set; }

        /// <summary>
        /// The credentials to be used when connection to the <see cref="Location"/> location
        /// <para>
        /// If no credentials are supplied, then the context of the running thread is used.
        /// </para>
        /// </summary>
        ICredentials? Credentials { get; set; }
    }
}
