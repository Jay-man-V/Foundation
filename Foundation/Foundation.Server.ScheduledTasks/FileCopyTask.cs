//-----------------------------------------------------------------------
// <copyright file="FileCopyTask.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.IO;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Server.ScheduledTasks.TaskParameters;

namespace Foundation.Server.ScheduledTasks
{
    /// <summary>
    /// Default implementation of a file copy task that can be scheduled to run at specific intervals.
    /// This class provides the base functionality for copying files from a source path to a destination path
    /// <para>
    /// It is designed to be extended by concrete implementations that specify the
    /// <para>
    /// source path
    /// </para>
    /// <para>
    /// destination path
    /// </para>
    /// <para>
    /// copy files since the last run
    /// </para>
    /// </para>
    /// </summary>
    [DependencyInjectionTransient]
    public class FileCopyTask : ScheduledTaskBase, IFileCopyTask
    {
        /// <summary>
        /// Initializes a new instance of the FileCopyTask class with the specified core services and file transfer
        /// service.
        /// </summary>
        /// <param name="core">The core application service used for fundamental operations and dependency resolution.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings that provide configuration and context for the task execution.</param>
        /// <param name="dateTimeService">The service used to obtain date and time information, enabling consistent time-related operations.</param>
        /// <param name="loggingService">The logging service used to record diagnostic and operational information during task execution.</param>
        /// <param name="applicationConfigurationService">The service that provides access to application configuration settings required by the task.</param>
        /// <param name="mailWrapper">The mail wrapper service used for sending email notifications.</param>
        /// <param name="fileApi">The file API service used for file system operations.</param>
        /// <param name="fileTransferService">The file transfer service responsible for handling file copy operations.</param>
        public FileCopyTask
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            IApplicationConfigurationService applicationConfigurationService,
            IMailWrapper mailWrapper,
            IFileApi fileApi,
            IFileTransferService fileTransferService
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                loggingService,
                applicationConfigurationService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService, applicationConfigurationService, fileApi, fileTransferService);

            FileApi = fileApi;
            FileTransferService = fileTransferService;
            MailWrapper = mailWrapper.SetupMailer();

            FileCopyTaskParameters = new FileCopyTaskParameters();

            LoggingHelpers.TraceCallReturn();
        }

        protected IMailWrapper MailWrapper { get; }
        protected IFileApi FileApi { get; }
        protected IFileTransferService FileTransferService { get; }

        protected FileCopyTaskParameters FileCopyTaskParameters { get; set; }

        /// <inheritdoc cref="ScheduledTaskBase.ProcessTask(LogId)"/>
        protected override void InitialiseRunTimeParameters(String taskParameters)
        {
            LoggingHelpers.TraceCallEnter(taskParameters);

            TaskParameters = SerialisationHelpers.Deserialise<FileCopyTaskParameters>(taskParameters);
            FileCopyTaskParameters = (FileCopyTaskParameters)TaskParameters;

            base.InitialiseRunTimeParameters(taskParameters);

            LoggingHelpers.TraceCallReturn();
        }

        protected override String GetRunTimeParametersForLogging()
        {
            LoggingHelpers.TraceCallEnter();

            String retVal = "<none>";

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ScheduledTaskBase.ProcessTask(LogId)"/>
        protected override void ProcessTask(LogId parentLogId)
        {
            LoggingHelpers.TraceCallEnter(parentLogId);

            // Get the source, destination, and archive file transfer settings based on the task parameters.
            // These settings will be used to perform the file transfer operation.
            // Need to ensure that the source file exists and the destination path is valid before attempting the transfer.
            // The archive settings will determine whether the source file is deleted after the transfer and where it is archived.
            // The FileTransferService will handle the actual file transfer operation based on the provided settings.
            // The FileCopyTaskParameters.SourceFileMask can be used to filter which files to copy from the source directory.

            // Validate that the source file path exists and is accessible.
            FileApi.EnsureDirectoryExists(FileCopyTaskParameters.SourceFilePath);

            // Validate that we can read from the source file path.
            FileApi.EnsureCanReadFromFolderPath(FileCopyTaskParameters.SourceFilePath);

            // Validate that the destination file path exists and is accessible.
            FileApi.EnsureDirectoryExists(FileCopyTaskParameters.DestinationFilePath);

            // Validate that we can write to the destination file path.
            FileApi.EnsureCanWriteToFolderPath(FileCopyTaskParameters.DestinationFilePath); 

            // Validate that the archive file path exists and is accessible if archiving is enabled.
            if (!String.IsNullOrWhiteSpace(FileCopyTaskParameters.ArchiveFilePath) &&
                !Directory.Exists(FileCopyTaskParameters.ArchiveFilePath))
            {
                throw new DirectoryNotFoundException($"Archive file path '{FileCopyTaskParameters.ArchiveFilePath}' does not exist.");
            }
            // Validate that we can write to the archive file path if archiving is enabled.
            if (!String.IsNullOrWhiteSpace(FileCopyTaskParameters.ArchiveFilePath))
            {
                try
                {
                    String testFilePath = Path.Combine(FileCopyTaskParameters.ArchiveFilePath, "test.txt");
                    File.WriteAllText(testFilePath, "Test");
                    File.Delete(testFilePath);
                }
                catch (Exception ex)
                {
                    throw new IOException($"Unable to access archive file path '{FileCopyTaskParameters.ArchiveFilePath}'.", ex);
                }
            }

            Boolean includeSubDirectories = false; // Set to true if you want to include subdirectories in the file copy operation.
            List<String> filenames = FileApi.GetListOfFiles(FileCopyTaskParameters.SourceFilePath, FileCopyTaskParameters.SourceFileMask, includeSubDirectories);

            IMailMessage mailMessage = Core.IoC.Get<IMailMessage>();

            foreach (String filename in filenames)
            {
                FileInfo fileInfo = new FileInfo(filename);

                IFileTransferSettings sourceSettings = GetSourceFileSettings(fileInfo.Name);
                IFileTransferSettings destinationSettings = GetDestinationFileSettings(fileInfo.Name);
                IArchiveTransferSettings? archiveSettings = null;
                
                if (!String.IsNullOrWhiteSpace(FileCopyTaskParameters.ArchiveFilePath))
                {
                    archiveSettings = GetArchiveFileSettings(fileInfo.Name);
                }

                IMailAttachment mailAttachment = GetFileContentForAttachment(sourceSettings);
                mailMessage.Attachments.Add(mailAttachment);

                FileTransferService.TransferFile(sourceSettings, destinationSettings, archiveSettings);
            }

            // Send email notification
            if (FileCopyTaskParameters.EmailAfterCopy)
            {
                SendEmailNotification(mailMessage, filenames);
            }

            LoggingHelpers.TraceCallReturn();
        }

        private void SendEmailNotification(IMailMessage mailMessage, List<String> filenames)
        {
            String toAddressTemp = ApplicationConfigurationService.Get<String>(Core.ApplicationId, Core.SystemUserProfile, FileCopyTaskParameters.EmailToAddressesConfigKey);
            List<String> toAddresses = toAddressTemp.Split(";").ToList();
            String ccAddressTemp = ApplicationConfigurationService.Get<String>(Core.ApplicationId, Core.SystemUserProfile, FileCopyTaskParameters.EmailCcAddressesConfigKey);
            List<String> ccAddresses = ccAddressTemp.Split(";").ToList();

            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = FileCopyTaskParameters.EmailSubject;
            mailMessage.FromAddress = ApplicationConfigurationService.Get<String>(Core.ApplicationId, Core.SystemUserProfile, FileCopyTaskParameters.EmailFromAddressesConfigKey);
            mailMessage.ToAddress = toAddresses;
            mailMessage.CcAddress = ccAddresses;

            mailMessage.Body = String.Empty;
            mailMessage.Body += "<p>" + Environment.NewLine;
            mailMessage.Body += "The following files have been copied successfully.<br/>" + Environment.NewLine;
            mailMessage.Body += $"From: {FileCopyTaskParameters.SourceFilePath}<br/>" + Environment.NewLine;
            mailMessage.Body += $"To: {FileCopyTaskParameters.DestinationFilePath}<br/>" + Environment.NewLine;

            if (!String.IsNullOrWhiteSpace(FileCopyTaskParameters.ArchiveFilePath))
            {
                mailMessage.Body += $"Archive: {FileCopyTaskParameters.ArchiveFilePath}<br/>" + Environment.NewLine;
            }

            mailMessage.Body += "</p>" + Environment.NewLine;

            String fileList = "<ul>";
            foreach (String filename in filenames)
            {
                FileInfo fileInfo = new FileInfo(filename);

                fileList += $"<li>{fileInfo.Name}</li>";
            }
            fileList += "</ul>";
            mailMessage.Body += fileList;


            MailWrapper.Send(mailMessage);
        }

        private IMailAttachment GetFileContentForAttachment(IFileTransferSettings fileTransferSettings)
        {
            // If the AttachFilesToEmail parameter is set to true, read the file content and attach it to the email message.
            // This allows the copied files to be included as attachments in the email notification sent after the copy operation.
            // The file content is read into a byte array and then added as an attachment to the mail message using the IMailAttachment interface.
            // The filename is also set on the attachment to ensure that the recipient can identify the attached file.
            // This is being done before the file transfer operation to ensure that the file content is captured before any potential changes or
            // deletions that may occur during the transfer process, especially if the archive settings specify that the source file should be deleted after transfer.

            IMailAttachment retVal = Core.IoC.Get<IMailAttachment>();

            if (FileCopyTaskParameters.AttachFilesToEmail)
            {
                using (Stream fileData = FileTransferService.TransferFile(fileTransferSettings))
                {
                    FileInfo fileInfo = new FileInfo(fileTransferSettings.Location);
                    Byte[] fileContent = new Byte[fileData.Length];

                    using (MemoryStream ms = new MemoryStream())
                    {
                        Int32 read;
                        while ((read = fileData.Read(fileContent, 0, fileContent.Length)) > 0)
                        {
                            ms.Write(fileContent, 0, read);
                        }
                    }

                    retVal.Content = fileContent;
                    retVal.Filename = fileInfo.Name;
                }
            }

            return retVal;
        }

        private IFileTransferSettings GetSourceFileSettings(String filename)
        {
            LoggingHelpers.TraceCallEnter(filename);

            String targetFolder = String.Empty; // The target folder is not used for the source file settings, as we are only interested in the source file path.

            IFileTransferSettings retVal = Core.IoC.Get<IFileTransferSettings>();
            retVal.FileTransferMethod = FileTransferMethod.FileSystem;
            retVal.Location = FileApi.MakeDataPath(FileCopyTaskParameters.SourceFilePath, targetFolder, filename);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        private IFileTransferSettings GetDestinationFileSettings(String filename)
        {
            LoggingHelpers.TraceCallEnter(filename);

            String targetFolder = String.Empty; // The target folder is not used for the destination file settings, as we are only interested in the destination file path.

            IFileTransferSettings retVal = Core.IoC.Get<IFileTransferSettings>();
            retVal.FileTransferMethod = FileTransferMethod.FileSystem;
            retVal.Location = FileApi.MakeDataPath(FileCopyTaskParameters.DestinationFilePath, targetFolder, filename);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        private IArchiveTransferSettings GetArchiveFileSettings(String filename)
        {
            LoggingHelpers.TraceCallEnter(filename);

            String targetFolder = String.Empty; // The target folder is not used for the archive file settings, as we are only interested in the archive file path.

            IArchiveTransferSettings retVal = Core.IoC.Get<IArchiveTransferSettings>();
            retVal.DeleteSourceFile = true;
            retVal.FileTransferAction = FileCopyTaskParameters.FileArchiveTransferAction;
            retVal.FileTransferMethod = FileTransferMethod.FileSystem;
            retVal.Location = FileApi.MakeDataPath(FileCopyTaskParameters.ArchiveFilePath, targetFolder, filename);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
