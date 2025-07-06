//-----------------------------------------------------------------------
// <copyright file="ArchiveTransferSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <inheritdoc cref="IArchiveTransferSettings"/>
    /// <seealso cref="IArchiveTransferSettings" />
    [DependencyInjectionTransient]
    public class ArchiveTransferSettings : FileTransferSettings, IArchiveTransferSettings
    {
        /// <inheritdoc cref="IArchiveTransferSettings.FileTransferArchiveAction"/>
        public FileTransferArchiveAction FileTransferArchiveAction { get; set; }

        /// <inheritdoc cref="IArchiveTransferSettings.DeleteSourceFile"/>
        public Boolean DeleteSourceFile { get; set; }
    }
}
