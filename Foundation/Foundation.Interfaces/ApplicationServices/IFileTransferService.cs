//-----------------------------------------------------------------------
// <copyright file="IFileTransferService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.IO;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the File Transfer Service
    /// </summary>
    public interface IFileTransferService
    {
        /// <summary>
        /// Transfers a file from the Source location and returns a <see cref="Stream"/> of its contents.
        /// </summary>
        /// <param name="sourceFileTransferSettings"><see cref="IFileTransferSettings"/> for the source file location</param>
        Stream TransferFile(IFileTransferSettings sourceFileTransferSettings);

        /// <summary>
        /// Transfers a file from the Source location and places it in the Destination Location.
        /// </summary>
        /// <param name="sourceFileTransferSettings"><see cref="IFileTransferSettings"/> for the source file location</param>
        /// <param name="destinationFileTransferSettings"><see cref="IFileTransferSettings"/> for the destination file location</param>
        /// <param name="archiveTransferSettings"><see cref="IArchiveTransferSettings"/> for the archive file location</param>
        void TransferFile(IFileTransferSettings sourceFileTransferSettings, IFileTransferSettings destinationFileTransferSettings, IArchiveTransferSettings archiveTransferSettings);
    }
}
