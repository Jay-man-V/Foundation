//-----------------------------------------------------------------------
// <copyright file="IRemoteServiceApi.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.IO;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Describes services for uploading and downloading files from a remote location
    /// </summary>
    public interface IRemoteServiceApi
    {
        /// <summary>
        /// Deletes the file
        /// </summary>
        /// <param name="fileTransferSettings"></param>
        void DeleteFile(IFileTransferSettings fileTransferSettings);

        /// <summary>
        /// Deletes the file
        /// </summary>
        /// <param name="fileTransferSettings"></param>
        Task DeleteFileAsync(IFileTransferSettings fileTransferSettings);

        /// <summary>
        /// Downloads the file from the supplied <paramref name="fileTransferSettings"/> and returns it as a <see cref="Stream"/>
        /// </summary>
        /// <param name="fileTransferSettings"></param>
        /// <returns></returns>
        Stream? DownloadFile(IFileTransferSettings fileTransferSettings);

        /// <summary>
        /// Downloads the file from the supplied <paramref name="fileTransferSettings"/> and returns it as a <see cref="Stream"/>
        /// </summary>
        /// <param name="fileTransferSettings"></param>
        /// <returns></returns>
        Task<Stream> DownloadFileAsync(IFileTransferSettings fileTransferSettings);

        /// <summary>
        /// Uploads the file from the supplied <paramref name="fileTransferSettings"/>
        /// </summary>
        /// <param name="fileTransferSettings"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        String UploadFile(IFileTransferSettings fileTransferSettings, String filePath);

        /// <summary>
        /// Uploads the file from the supplied <paramref name="fileTransferSettings"/>
        /// </summary>
        /// <param name="fileTransferSettings"></param>
        /// <param name="fileContent"></param>
        /// <returns></returns>
        String UploadFile(IFileTransferSettings fileTransferSettings, Stream fileContent);

        /// <summary>
        /// Uploads the file from the supplied <paramref name="fileTransferSettings"/>
        /// </summary>
        /// <param name="fileTransferSettings"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<String> UploadFileAsync(IFileTransferSettings fileTransferSettings, String filePath);

        /// <summary>
        /// Uploads the file from the supplied <paramref name="fileTransferSettings"/>
        /// </summary>
        /// <param name="fileTransferSettings"></param>
        /// <param name="fileContent"></param>
        /// <returns></returns>
        Task<String> UploadFileAsync(IFileTransferSettings fileTransferSettings, Stream fileContent);
    }
}
