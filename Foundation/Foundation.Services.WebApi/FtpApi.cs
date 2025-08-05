//-----------------------------------------------------------------------
// <copyright file="FtpApi.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.IO;
using System.Net.Http;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.WebApi
{
    /// <inheritdoc cref="IFtpApi"/>
    [DependencyInjectionTransient]
    public class FtpApi : IFtpApi
    {
        /// <summary>
        /// 
        /// </summary>
        // /// <param name="core"></param>
        public FtpApi
        (
            //ICore core
        ) :
            this
            (
                //core,
                new HttpClientHandler()
            )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public FtpApi
        (
            //ICore core,
            HttpMessageHandler httpMessageHandler
        )
        {
            //Core = core;
            HttpMessageHandler = httpMessageHandler;
        }

        //private ICore Core { get; }

        /// <summary>
        /// Gets the Http Message Handler
        /// </summary>
        private HttpMessageHandler HttpMessageHandler { get; }

        /// <summary>
        /// Common method for opening a new <see cref="HttpClient"/> connection
        /// </summary>
        /// <param name="fileTransferSettings"></param>
        /// <returns></returns>
        private HttpClient OpenHttpConnection(IFileTransferSettings fileTransferSettings)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings);

            if (HttpMessageHandler is HttpClientHandler clientHandler)
            {
                if (fileTransferSettings.Credentials == null)
                {
                    clientHandler.UseDefaultCredentials = true;
                }
                else
                {
                    clientHandler.UseDefaultCredentials = false;
                    clientHandler.Credentials = fileTransferSettings.Credentials;
                }
            }

            HttpClient retVal = new HttpClient(HttpMessageHandler);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRemoteServiceApi.DeleteFile(IFileTransferSettings)"/>
        public void DeleteFile(IFileTransferSettings fileTransferSettings)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings);

            Task t = DeleteFileAsync(fileTransferSettings);
            t.Wait();

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IRemoteServiceApi.DeleteFileAsync(IFileTransferSettings)"/>
        public Task DeleteFileAsync(IFileTransferSettings fileTransferSettings)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IRemoteServiceApi.DownloadFile(IFileTransferSettings)"/>
        public Stream DownloadFile(IFileTransferSettings fileTransferSettings)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings);

            Task<Stream> t = DownloadFileAsync(fileTransferSettings);
            t.Wait();
            Stream retVal = t.Result;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRemoteServiceApi.DownloadFileAsync(IFileTransferSettings)"/>
        public async Task<Stream> DownloadFileAsync(IFileTransferSettings fileTransferSettings)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings);

            Stream retVal;
            using (HttpClient client = OpenHttpConnection(fileTransferSettings))
            {
                await using Stream downloadStream = await client.GetStreamAsync(fileTransferSettings.Location).ConfigureAwait(false);
                if (downloadStream.CanSeek &&
                    downloadStream.Length > 0)
                {
                    downloadStream.Position = 0;
                }

                retVal = new MemoryStream();
                await downloadStream.CopyToAsync(retVal).ConfigureAwait(false);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRemoteServiceApi.UploadFile(IFileTransferSettings, String)"/>
        public String UploadFile(IFileTransferSettings fileTransferSettings, String filePath)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings, filePath);

            Task<String> t = UploadFileAsync(fileTransferSettings, filePath);
            t.Wait();
            String retVal = t.Result;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRemoteServiceApi.UploadFile(IFileTransferSettings, Stream)"/>
        public String UploadFile(IFileTransferSettings fileTransferSettings, Stream fileContent)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings, fileContent);

            Task<String> t = UploadFileAsync(fileTransferSettings, fileContent);
            t.Wait();
            String retVal = t.Result;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRemoteServiceApi.UploadFileAsync(IFileTransferSettings, String)"/>
        public async Task<String> UploadFileAsync(IFileTransferSettings fileTransferSettings, String filePath)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings, filePath);

            String retVal;
            await using Stream stream = File.OpenRead(filePath);
            Task<String> t = UploadFileAsync(fileTransferSettings, stream);
            await t;
            retVal = t.Result;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRemoteServiceApi.UploadFileAsync(IFileTransferSettings, Stream)"/>
        public Task<String> UploadFileAsync(IFileTransferSettings fileTransferSettings, Stream fileContent)
        {
            //https://medium.com/@niteshsinghal85/file-upload-to-web-api-with-different-http-clients-in-c-ae123555ef49
            throw new NotImplementedException();
        }
    }
}
