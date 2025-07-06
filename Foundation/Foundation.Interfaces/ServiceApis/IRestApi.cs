//-----------------------------------------------------------------------
// <copyright file="IRestApi.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Threading.Tasks;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Describes services for uploading and downloading files from a remote location using a RESTful API
    /// </summary>
    public interface IRestApi : IRemoteServiceApi
    {
        /// <summary>
        /// Downloads the data from the supplied <paramref name="fileTransferSettings"/> and returns it as a <see cref="String"/>
        /// </summary>
        /// <param name="fileTransferSettings"></param>
        /// <returns></returns>
        String DownloadString(IFileTransferSettings fileTransferSettings);

        /// <summary>
        /// Downloads the data from the supplied <paramref name="fileTransferSettings"/> and returns it as a <see cref="String"/>
        /// </summary>
        /// <param name="fileTransferSettings"></param>
        /// <returns></returns>
        Task<String> DownloadStringAsync(IFileTransferSettings fileTransferSettings);
    }
}
