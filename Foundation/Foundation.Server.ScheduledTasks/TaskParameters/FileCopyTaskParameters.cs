//-----------------------------------------------------------------------
// <copyright file="FileCopyTaskParameters.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Server.ScheduledTasks.TaskParameters
{
    /// <summary>
    /// Represents the set of parameters required to configure a file copy task.
    /// </summary>
    public class FileCopyTaskParameters : TaskParameters
    {
        /// <summary>
        /// Gets or sets the file name pattern used to select source files.
        /// </summary>
        /// <remarks>
        /// The file mask can include wildcard characters such as '*' and '?'. This property
        /// determines which files are considered as source files for processing.
        /// </remarks>
        public String SourceFileMask { get; set; } = String.Empty;

        /// <summary>
        /// Gets a value indicating whether files have been copied since the last run.
        /// </summary>
        public Boolean CopyFilesSinceLastRun { get; set; } = false;

        /// <summary>
        /// Gets or sets the full file system path to the source file associated with this instance.
        /// </summary>
        public String SourceFilePath { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the full file path where the destination file will be saved.
        /// </summary>
        public String DestinationFilePath { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether an email should be sent after the file copy operation.
        /// </summary>
        public Boolean EmailAfterCopy { get; set; } = false;

        /// <summary>
        /// Gets or sets additional text to include in the email body when sending notifications after the file copy operation.
        /// </summary>
        public String EmailAdditionalText { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the configuration key for the email subject line.
        /// </summary>
        public String EmailSubjectConfigKey { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the configuration key for the email addresses to which notifications should be sent.
        /// </summary>
        public String EmailFromAddressesConfigKey { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the configuration key for the email addresses to which notifications should be sent.
        /// </summary>
        public String EmailToAddressesConfigKey { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the configuration key for the email addresses to which notifications should be sent as carbon copies.
        /// </summary>
        public String EmailCcAddressesConfigKey { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the configuration key for the email addresses to which notifications should be sent as carbon copies.
        /// </summary>
        public Boolean EmailAddFilePathsToEmail { get; set; }

        /// <summary>
        /// Gets or sets the configuration key for the email addresses to which notifications should be sent as carbon copies.
        /// </summary>
        public Boolean AttachFilesToEmail { get; set; } = false;

        /// <summary>
        /// Gets or sets the file path where the archive is stored.
        /// </summary>
        public String ArchiveFilePath { get; set; } = String.Empty;

        /// <summary>
        /// Gets the action to perform during a file archive transfer operation.
        /// </summary>
        public FileTransferAction FileArchiveTransferAction { get; set; } = FileTransferAction.Move;
    }
}
