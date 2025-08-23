//-----------------------------------------------------------------------
// <copyright file="FileTransferService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.IO;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <inheritdoc cref="IFileTransferService"/>
    [DependencyInjectionTransient]
    public class FileTransferService : ServiceBase, IFileTransferService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailApi"></param>
        /// <param name="fileApi"></param>
        /// <param name="httpApi"></param>
        /// <param name="ftpApi"></param>
        /// <param name="restApi"></param>
        /// <param name="mqApi"></param>
        public FileTransferService
        (
            IEmailApi emailApi,
            IFileApi fileApi,
            IHttpApi httpApi,
            IFtpApi ftpApi,
            IRestApi restApi,
            IMqApi mqApi
        ) :
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter(emailApi, fileApi, httpApi, ftpApi, restApi, mqApi);

            EmailApi = emailApi;
            FileApi = fileApi;
            HttpApi = httpApi;
            FtpApi = ftpApi;
            RestApi = restApi;
            MqApi = mqApi;

            LoggingHelpers.TraceCallReturn();
        }

        private IEmailApi EmailApi { get; }
        private IFileApi FileApi { get; }
        private IHttpApi HttpApi { get; }
        private IFtpApi FtpApi { get; }
        private IRestApi RestApi { get; }
        private IMqApi MqApi { get; }

        /// <inheritdoc cref="IFileTransferService.TransferFile(IFileTransferSettings)"/>
        public Stream TransferFile(IFileTransferSettings sourceFileTransferSettings)
        {
            LoggingHelpers.TraceCallEnter(sourceFileTransferSettings);

            Stream? retVal = null;

            switch(sourceFileTransferSettings.FileTransferMethod)
            {
                case FileTransferMethod.Email:
                {
                    retVal = EmailApi.DownloadFile(sourceFileTransferSettings);
                    break;
                }

                case FileTransferMethod.FileSystem:
                {
                    retVal = FileApi.GetFileContentsAsStream(sourceFileTransferSettings.Location);
                    break;
                }

                case FileTransferMethod.Ftp:
                {
                    retVal = FtpApi.DownloadFile(sourceFileTransferSettings);
                    break;
                }

                case FileTransferMethod.Http:
                {
                    retVal = HttpApi.DownloadFile(sourceFileTransferSettings);
                    break;
                }

                case FileTransferMethod.Rest:
                {
                    retVal = RestApi.DownloadFile(sourceFileTransferSettings);
                    break;
                }

                case FileTransferMethod.Mq:
                {
                    retVal = MqApi.DownloadFile(sourceFileTransferSettings);
                    break;
                }
            }

            if (retVal == null)
            {
                String message = $"Unable to retrieve file from source '{sourceFileTransferSettings}'";
                throw new InvalidOperationException(message);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileTransferService.TransferFile(IFileTransferSettings, IFileTransferSettings, IArchiveTransferSettings)"/>
        public void TransferFile
        (
            IFileTransferSettings sourceFileTransferSettings,
            IFileTransferSettings destinationFileTransferSettings,
            IArchiveTransferSettings? archiveTransferSettings
        )
        {
            LoggingHelpers.TraceCallEnter(sourceFileTransferSettings, destinationFileTransferSettings, archiveTransferSettings);

            Stream fileContent = TransferFile(sourceFileTransferSettings);

            switch (destinationFileTransferSettings.FileTransferMethod)
            {
                case FileTransferMethod.Email:
                {
                    EmailApi.UploadFile(destinationFileTransferSettings, fileContent);
                    break;
                }

                case FileTransferMethod.FileSystem:
                {
                    FileApi.UploadFile(destinationFileTransferSettings, fileContent);
                    break;
                }

                case FileTransferMethod.Ftp:
                {
                    FtpApi.UploadFile(destinationFileTransferSettings, fileContent);
                    break;
                }

                case FileTransferMethod.Http:
                {
                    HttpApi.UploadFile(destinationFileTransferSettings, fileContent);
                    break;
                }

                case FileTransferMethod.Rest:
                {
                    RestApi.UploadFile(destinationFileTransferSettings, fileContent);
                    break;
                }

                case FileTransferMethod.Mq:
                {
                    MqApi.UploadFile(destinationFileTransferSettings, fileContent);
                    break;
                }
            }

            if (archiveTransferSettings != null)
            {
                ArchiveFile(sourceFileTransferSettings, archiveTransferSettings, fileContent);
            }

            LoggingHelpers.TraceCallReturn();
        }

        private void ArchiveFile
        (
            IFileTransferSettings sourceFileTransferSettings,
            IArchiveTransferSettings archiveTransferSettings,
            Stream fileContent
        )
        {
            LoggingHelpers.TraceCallEnter(archiveTransferSettings);

            // Archive the file as required by the supplied settings
            switch (archiveTransferSettings.FileTransferMethod)
            {
                case FileTransferMethod.Email:
                {
                    EmailApi.UploadFile(archiveTransferSettings, fileContent);
                    break;
                }

                case FileTransferMethod.FileSystem:
                {
                    FileApi.UploadFile(archiveTransferSettings, fileContent);
                    break;
                }

                case FileTransferMethod.Ftp:
                {
                    FtpApi.UploadFile(archiveTransferSettings, fileContent);
                    break;
                }

                case FileTransferMethod.Http:
                {
                    HttpApi.UploadFile(archiveTransferSettings, fileContent);
                    break;
                }

                case FileTransferMethod.Rest:
                {
                    RestApi.UploadFile(archiveTransferSettings, fileContent);
                    break;
                }

                case FileTransferMethod.Mq:
                {
                    MqApi.UploadFile(archiveTransferSettings, fileContent);
                    break;
                }
            }

            fileContent.Close();
            fileContent.Dispose();

            // Now deal with the source file, we can assume the Archive action worked otherwise an exception
            // would've been thrown
            switch (sourceFileTransferSettings.FileTransferMethod)
            {
                case FileTransferMethod.Email:
                {
                    FtpApi.DeleteFile(sourceFileTransferSettings);
                    break;
                }

                case FileTransferMethod.FileSystem:
                {
                    // Ignore all other options as they will preserve the original file
                    if (archiveTransferSettings.FileTransferArchiveAction == FileTransferArchiveAction.Move)
                    {
                        FileApi.DeleteFile(sourceFileTransferSettings);
                    }
                    break;
                }

                case FileTransferMethod.Ftp:
                {
                    FtpApi.DeleteFile(sourceFileTransferSettings);
                    break;
                }

                case FileTransferMethod.Http:
                {
                    HttpApi.DeleteFile(sourceFileTransferSettings);
                    break;
                }

                case FileTransferMethod.Rest:
                {
                    RestApi.DeleteFile(sourceFileTransferSettings);
                    break;
                }

                case FileTransferMethod.Mq:
                {
                    MqApi.DeleteFile(sourceFileTransferSettings);
                    break;
                }
            }

            LoggingHelpers.TraceCallReturn();
        }
    }
}
