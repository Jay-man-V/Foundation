//-----------------------------------------------------------------------
// <copyright file="FileApi.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.Services.Application
{
    /// <inheritdoc cref="IFileApi"/>
    [DependencyInjectionTransient]
    public class FileService : ServiceBase, IFileApi
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="core">The Foundation Core Service.</param>
        /// <param name="applicationConfigurationService">The application configuration service.</param>
        public FileService
        (
            ICore core,
            IApplicationConfigurationService applicationConfigurationService
        ) :
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter(core, applicationConfigurationService);

            Core = core;
            ApplicationConfigurationService = applicationConfigurationService;

            LoggingHelpers.TraceCallReturn();
        }

        private ICore Core { get; }
        private IApplicationConfigurationService ApplicationConfigurationService { get; }


        /// <inheritdoc cref="IFileApi.UserDataPath"/>
        public String UserDataPath
        {
            get
            {
                String configuredUserDataPath = ApplicationConfigurationService.Get<String>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.UserDataPath);
                String retVal = MakeDataPath(configuredUserDataPath, String.Empty);

                return retVal;
            }
        }

        /// <inheritdoc cref="IFileApi.SystemDataPath"/>
        public String SystemDataPath
        {
            get
            {
                String configuredSystemDataPath = ApplicationConfigurationService.Get<String>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.SystemDataPath);
                String retVal = MakeDataPath(configuredSystemDataPath, String.Empty);

                return retVal;
            }
        }

        /// <inheritdoc cref="IFileApi.MakeDataPath(String, String)"/>
        public String MakeDataPath(String baseFolder, String targetFolder)
        {
            LoggingHelpers.TraceCallEnter(baseFolder, targetFolder);

            String retVal = Path.Combine(baseFolder, targetFolder);

            if (!retVal.Trim().EndsWith(@"\"))
            {
                retVal += @"\";
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileApi.MakeDataPath(String, String, String)"/>
        public String MakeDataPath(String baseFolder, String targetFolder, String targetFileName)
        {
            LoggingHelpers.TraceCallEnter(baseFolder, targetFolder, targetFileName);

            String retVal = Path.Combine(baseFolder, targetFolder, targetFileName);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileApi.GetNewTempFilePath(String, String)"/>
        public String GetNewTempFilePath(String baseFolder, String filePrefix)
        {
            LoggingHelpers.TraceCallEnter(baseFolder);

            String tempFileName = filePrefix + Path.GetRandomFileName();
            String tempPath = Path.GetTempPath();

            String retVal = Path.Combine(tempPath, baseFolder, tempFileName);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileApi.EnsureFileExists(String)"/>
        public void EnsureFileExists(String filePath)
        {
            LoggingHelpers.TraceCallEnter(filePath);

            if (!File.Exists(filePath))
            {
                String message = $"The file '{filePath}' does not exist or access to it is denied";
                throw new FileNotFoundException(message, filePath);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IFileApi.EnsureDirectoryExists(String)"/>
        public void EnsureDirectoryExists(String directoryPath)
        {
            LoggingHelpers.TraceCallEnter(directoryPath);

            if (!Directory.Exists(directoryPath))
            {
                String message = $"The directory '{directoryPath}' does not exist or access to it is denied";
                throw new DirectoryNotFoundException(message);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IFileApi.DoesFileExist(String)"/>
        public Boolean DoesFileExist(String filePath)
        {
            LoggingHelpers.TraceCallEnter(filePath);

            Boolean retVal = Directory.Exists(filePath) || File.Exists(filePath);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileApi.DoesDirectoryExist(String)"/>
        public Boolean DoesDirectoryExist(String directoryPath)
        {
            LoggingHelpers.TraceCallEnter(directoryPath);

            Boolean retVal = Directory.Exists(directoryPath) || File.Exists(directoryPath);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileApi.GetFileContentsAsStream(String)"/>
        public Stream GetFileContentsAsStream(String filePath)
        {
            LoggingHelpers.TraceCallEnter(filePath);

            EnsureFileExists(filePath);

            Stream retVal = File.OpenRead(filePath);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileApi.GetFileContentsAsText(String, Encoding)"/>
        public String GetFileContentsAsText(String filePath, Encoding encoding)
        {
            LoggingHelpers.TraceCallEnter(filePath);

            EnsureFileExists(filePath);

            String retVal = File.ReadAllText(filePath, encoding);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileApi.GetFileContentsAsByteArray(String)"/>
        public Byte[] GetFileContentsAsByteArray(String filePath)
        {
            LoggingHelpers.TraceCallEnter(filePath);

            EnsureFileExists(filePath);

            Byte[] retVal = File.ReadAllBytes(filePath);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileApi.GetAssemblyResource(Assembly, String)"/>
        public Stream GetAssemblyResource(Assembly targetAssembly, String resourceName)
        {
            LoggingHelpers.TraceCallEnter(targetAssembly, resourceName);

#if(DEBUG)
            // Handy bit of debug code to list all the resource names in case there
            // is an issue trying to find/load a resource
            String[] resourceNames = targetAssembly.GetManifestResourceNames();
            resourceNames.ToList().ForEach(rs => Debug.WriteLine(rs));
#endif

            Stream? retVal = targetAssembly.GetManifestResourceStream(resourceName);

            if (retVal == null)
            {
                String resourceName2 = targetAssembly.GetName().Name + "." + resourceName;
                retVal = targetAssembly.GetManifestResourceStream(resourceName2);
            }

            if (retVal == null)
            {
                String errorMessage = $"Resource File '{resourceName}' does not exist in the Assembly '{targetAssembly.FullName}'";
                throw new MissingManifestResourceException(errorMessage);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileApi.GetFileContentsAsTextFromAssembly(Assembly, String, Encoding)"/>
        public String GetFileContentsAsTextFromAssembly(Assembly targetAssembly, String filePath, Encoding encoding)
        {
            LoggingHelpers.TraceCallEnter(filePath);

            String retVal;
            using (Stream resourceStream = GetAssemblyResource(targetAssembly, filePath))
            {
                using (StreamReader reader = new StreamReader(resourceStream, encoding))
                {
                    retVal = reader.ReadToEnd();
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileApi.GetFileContentsAsByteArrayFromAssembly(Assembly, String)"/>
        public Byte[] GetFileContentsAsByteArrayFromAssembly(Assembly targetAssembly, String filePath)
        {
            LoggingHelpers.TraceCallEnter(filePath);

            Byte[] retVal;
            using (Stream resourceStream = GetAssemblyResource(targetAssembly, filePath))
            {
                Int64 fileSize = resourceStream.Length;
                retVal = new Byte[fileSize];

                _ = resourceStream.Read(retVal, 0, (Int32)fileSize);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileApi.OpenFileForReading(String, Encoding)"/>
        public TextReader OpenFileForReading(String filePath, Encoding encoding)
        {
            LoggingHelpers.TraceCallEnter(filePath);

            EnsureFileExists(filePath);

            TextReader retVal = File.OpenText(filePath);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileApi.OpenFileForWriting(String, Encoding, Boolean)"/>
        public TextWriter OpenFileForWriting(String filePath, Encoding encoding, Boolean appendToFile = false)
        {
            LoggingHelpers.TraceCallEnter(filePath, encoding, appendToFile);

            if (appendToFile)
            {
                EnsureFileExists(filePath);
            }
            else
            {
                Boolean fileExists = DoesFileExist(filePath);

                if (fileExists)
                {
                    String exceptionMessage = $"The file '{filePath}' already exists and cannot be created";
                    throw new UnauthorizedAccessException(exceptionMessage);
                }
            }

            TextWriter retVal = new StreamWriter(filePath, appendToFile, encoding);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileApi.CopyFile(String, String)"/>
        public void CopyFile(String sourceFilePath, String destinationFilePath)
        {
            LoggingHelpers.TraceCallEnter(sourceFilePath, destinationFilePath);

            Boolean destinationFileExists = DoesFileExist(destinationFilePath);
            if (destinationFileExists)
            {
                String errorMessage = $"The destination file path '{destinationFilePath}' already exists.";
                throw new IOException(errorMessage);
            }

            File.Copy(sourceFilePath, destinationFilePath, overwrite: false);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IFileApi.MoveFile(String, String)"/>
        public void MoveFile(String sourceFilePath, String destinationFilePath)
        {
            LoggingHelpers.TraceCallEnter(sourceFilePath, destinationFilePath);

            Boolean destinationFileExists = DoesFileExist(destinationFilePath);
            if (destinationFileExists)
            {
                String errorMessage = $"The destination file path '{destinationFilePath}' already exists.";
                throw new IOException(errorMessage);
            }

            File.Move(sourceFilePath, destinationFilePath);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IFileApi.DeleteFile(String)"/>
        public void DeleteFile(String filePath)
        {
            LoggingHelpers.TraceCallEnter(filePath);

            File.Delete(filePath);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IFileApi.CreateDirectory(String, String, Boolean)"/>
        public DirectoryInfo CreateDirectory(String basePath, String newDirectoryName, Boolean throwExceptionIfExists)
        {
            LoggingHelpers.TraceCallEnter(basePath, newDirectoryName, throwExceptionIfExists);

            EnsureDirectoryExists(basePath);

            DirectoryInfo baseDirectoryInfo = new DirectoryInfo(basePath);

            String newDirectoryPath = Path.Combine(basePath, newDirectoryName);

            Boolean newDirectoryExists = DoesDirectoryExist(newDirectoryPath);
            if (throwExceptionIfExists && newDirectoryExists)
            {
                String errorMessage = $"The directory path '{newDirectoryPath}' already exists, the directory '{newDirectoryName}' cannot be created again";
                throw new IOException(errorMessage);
            }

            DirectoryInfo retVal = baseDirectoryInfo.CreateSubdirectory(newDirectoryName);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileApi.DeleteDirectory(String, Boolean)"/>
        public void DeleteDirectory(String directoryPath, Boolean recursive)
        {
            LoggingHelpers.TraceCallEnter(directoryPath, recursive);

            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            Boolean directoryExists = directoryInfo.Exists;

            if (directoryExists)
            {
                directoryInfo.Delete(recursive);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IFileApi.GetNewTempFolderPath(String, Boolean)"/>
        public String GetNewTempFolderPath(String folderName, Boolean createFolder)
        {
            LoggingHelpers.TraceCallEnter(folderName, createFolder);

            String tempFolderName = Path.GetRandomFileName();
            String tempPath = Path.GetTempPath();
            String targetFolderPath = Path.Combine(tempPath, folderName);
            String retVal = Path.Combine(targetFolderPath, tempFolderName);

            if (createFolder)
            {
                CreateDirectory(tempPath, folderName, throwExceptionIfExists: false);
                CreateDirectory(targetFolderPath, tempFolderName, throwExceptionIfExists: true);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFileApi.WriteFileContent(String, Stream, Boolean)"/>
        public String WriteFileContent(String filePath, Stream fileContent, Boolean overwriteIfFileExists = false)
        {
            LoggingHelpers.TraceCallEnter(filePath);

            String retVal = filePath;

            Boolean fileExists = DoesFileExist(retVal);

            if (fileExists && overwriteIfFileExists)
            {
                DeleteFile(retVal);
            }

            using (FileStream fileStream = File.Create(retVal))
            {
                if (fileContent is { CanSeek: true, Length: > 0 })
                {
                    fileContent.Position = 0;
                }

                fileContent.CopyTo(fileStream);
                fileStream.Flush();
                fileStream.Close();
            }

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

        /// <inheritdoc cref="IRemoteServiceApi.DeleteFile(IFileTransferSettings)"/>
        public async Task DeleteFileAsync(IFileTransferSettings fileTransferSettings)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings);

            Task t = Task.Run(() => DeleteFile(fileTransferSettings.Location));
            await t;

            LoggingHelpers.TraceCallReturn();
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

            Task<Stream> t = Task.Run(() => GetFileContentsAsStream(fileTransferSettings.Location));
            await t;
            Stream retVal = t.Result;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRemoteServiceApi.UploadFile(IFileTransferSettings, String)"/>
        public String UploadFile(IFileTransferSettings fileTransferSettings, String filePath)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings, filePath);

            String retVal;
            using (Stream stream = File.OpenRead(filePath))
            {
                retVal = UploadFile(fileTransferSettings, stream);
            }

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

        /// <inheritdoc cref="IRemoteServiceApi.UploadFile(IFileTransferSettings, String)"/>
        public async Task<String> UploadFileAsync(IFileTransferSettings fileTransferSettings, String filePath)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings, filePath);

            String retVal;
            await using (Stream stream = File.OpenRead(filePath))
            {
                Task<String> t = UploadFileAsync(fileTransferSettings, stream);
                await t;
                retVal = t.Result;
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IRemoteServiceApi.UploadFileAsync(IFileTransferSettings, Stream)"/>
        public async Task<String> UploadFileAsync(IFileTransferSettings fileTransferSettings, Stream fileContent)
        {
            LoggingHelpers.TraceCallEnter(fileTransferSettings, fileContent);

            Task<String> t = Task.Run(() => WriteFileContent(fileTransferSettings.Location, fileContent));
            await t;
            String retVal = t.Result;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
