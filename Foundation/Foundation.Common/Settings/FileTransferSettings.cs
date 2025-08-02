//-----------------------------------------------------------------------
// <copyright file="FileTransferSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Net;

using Newtonsoft.Json;

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

        /// <inheritdoc cref="IFileTransferSettings.ToString()"/>
        public override String ToString()
        {
            String retVal = JsonConvert.SerializeObject(this);

            return retVal;
        }
    }
}
