//-----------------------------------------------------------------------
// <copyright file="IArchiveTransferSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The interface Archive File Transfer Settings definition
    /// </summary>
    public interface IArchiveTransferSettings : IFileTransferSettings
    {
        /// <summary>
        /// The method to use to archive the file
        /// </summary>
        FileTransferArchiveAction FileTransferArchiveAction { get; set; }

        /// <summary>
        /// Whether the file should be removed from the source location
        /// </summary>
        Boolean DeleteSourceFile { get; set; }
    }
}
