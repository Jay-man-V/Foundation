//-----------------------------------------------------------------------
// <copyright file="FileTransferSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Net;

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <inheritdoc cref="IFileTransferSettings"/>
    /// <seealso cref="IFileTransferSettings" />
    [DependencyInjectionTransient]
    public class FileTransferSettings : IFileTransferSettings
    {
        /// <inheritdoc cref="IFileTransferSettings.FileTransferMethod"/>
        public FileTransferMethod FileTransferMethod { get; set; }

        /// <inheritdoc cref="IFileTransferSettings.Location"/>
        public String Location { get; set; } = String.Empty;

        /// <inheritdoc cref="IFileTransferSettings.Credentials"/>
        public ICredentials? Credentials { get; set; }
    }
}
