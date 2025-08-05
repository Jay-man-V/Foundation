//-----------------------------------------------------------------------
// <copyright file="IOpenFolderDialogSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The interface Open Folder Dialog definition
    /// </summary>
    public interface IOpenFolderDialogSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether [check path exists].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [check path exists]; otherwise, <c>false</c>.
        /// </value>
        Boolean CheckPathExists { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [create prompt].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [create prompt]; otherwise, <c>false</c>.
        /// </value>
        Boolean CreatePrompt { get; set; }

        /// <summary>
        /// Gets or sets the name of the folder.
        /// </summary>
        /// <value>
        /// The name of the folder.
        /// </value>
        String FolderName { get; set; }

        /// <summary>
        /// Gets or sets the dialog result.
        /// </summary>
        /// <value>
        /// The dialog result.
        /// </value>
        DialogResult DialogResult { get; set; }
    }
}
