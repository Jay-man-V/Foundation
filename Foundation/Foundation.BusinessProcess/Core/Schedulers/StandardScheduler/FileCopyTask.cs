//-----------------------------------------------------------------------
// <copyright file="FileCopyTask.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.BusinessProcess.Core.Schedulers.StandardScheduler.TaskParameters;
using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.BusinessProcess.Core.Schedulers.StandardScheduler
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
    public class FileCopyTask : ScheduledTaskBase
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
        /// <param name="fileApi">The file API service used for file system operations.</param>
        /// <param name="fileTransferService">The file transfer service responsible for handling file copy operations.</param>
        public FileCopyTask
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            IApplicationConfigurationService applicationConfigurationService,
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

            FileCopyTaskParameters = new FileCopyTaskParameters();

            LoggingHelpers.TraceCallReturn();
        }

        IFileApi FileApi { get; }
        private IFileTransferService FileTransferService { get; }

        private FileCopyTaskParameters FileCopyTaskParameters { get; set; }

        /// <inheritdoc cref="ScheduledTaskBase.ProcessTask(LogId, String)"/>
        protected override void ProcessTask(LogId parentLogId, String taskParameters)
        {
            LoggingHelpers.TraceCallEnter(parentLogId, taskParameters);

            // The taskParameters are already deserialised in InitialiseRunTimeParameters, so we can use the FileCopyTaskParameters property directly.
            // Get the source, destination, and archive file transfer settings based on the task parameters.
            // These settings will be used to perform the file transfer operation.
            // Need to ensure that the source file exists and the destination path is valid before attempting the transfer.
            // The archive settings will determine whether the source file is deleted after the transfer and where it is archived.
            // The FileTransferService will handle the actual file transfer operation based on the provided settings.
            // The FileCopyTaskParameters.SourceFileMask can be used to filter which files to copy from the source directory.

            Boolean includeSubDirectories = false; // Set to true if you want to include subdirectories in the file copy operation.
            List<String> files = FileApi.GetListOfFiles(FileCopyTaskParameters.SourceFilePath, FileCopyTaskParameters.SourceFileMask, includeSubDirectories);

            foreach (String file in files)
            {
                IFileTransferSettings sourceSettings = GetSourceFileSettings(file);
                IFileTransferSettings destinationSettings = GetDestinationFileSettings(file);
                IArchiveTransferSettings archiveSettings = GetArchiveFileSettings();

                FileTransferService.TransferFile(sourceSettings, destinationSettings, archiveSettings);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ScheduledTaskBase.ProcessTask(LogId, String)"/>
        protected override void InitialiseRunTimeParameters(String taskParameters)
        {
            LoggingHelpers.TraceCallEnter(taskParameters);

            FileCopyTaskParameters = SerialisationHelpers.Deserialise<FileCopyTaskParameters>(taskParameters);

            LoggingHelpers.TraceCallReturn();
        }

        protected override String GetRunTimeParametersForLogging()
        {
            LoggingHelpers.TraceCallEnter();

            String retVal = "<none>";

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        private IFileTransferSettings GetSourceFileSettings(String filename)
        {
            LoggingHelpers.TraceCallEnter();

            IFileTransferSettings retVal = Core.IoC.Get<IFileTransferSettings>();
            retVal.FileTransferMethod = FileTransferMethod.FileSystem;
            retVal.Location = FileCopyTaskParameters.SourceFilePath;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        private IFileTransferSettings GetDestinationFileSettings(String filename)
        {
            LoggingHelpers.TraceCallEnter();

            IFileTransferSettings retVal = Core.IoC.Get<IFileTransferSettings>();
            retVal.FileTransferMethod = FileTransferMethod.FileSystem;
            retVal.Location = FileCopyTaskParameters.DestinationFilePath;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        private IArchiveTransferSettings GetArchiveFileSettings()
        {
            LoggingHelpers.TraceCallEnter();

            IArchiveTransferSettings retVal = Core.IoC.Get<IArchiveTransferSettings>();
            retVal.DeleteSourceFile = true;
            retVal.FileTransferAction = FileCopyTaskParameters.FileArchiveTransferAction;
            retVal.FileTransferMethod = FileTransferMethod.FileSystem;
            retVal.Location = FileCopyTaskParameters.ArchiveFilePath;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
