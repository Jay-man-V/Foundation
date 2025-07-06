//-----------------------------------------------------------------------
// <copyright file="OpenFolderDialogSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// Definition of the Open Folder Dialog Settings
    /// </summary>
    /// <seealso cref="IOpenFolderDialogSettings" />
    [DependencyInjectionTransient]
    public class OpenFolderDialogSettings : IOpenFolderDialogSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether [check path exists].
        /// </summary>
        /// <value>
        /// <c>true</c> if [check path exists]; otherwise, <c>false</c>.
        /// </value>
        public Boolean CheckPathExists { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [create prompt].
        /// </summary>
        /// <value>
        /// <c>true</c> if [create prompt]; otherwise, <c>false</c>.
        /// </value>
        public Boolean CreatePrompt { get; set; }

        /// <summary>
        /// Gets or sets the folder name.
        /// </summary>
        /// <value>
        /// The Folder Name.
        /// </value>
        public String FolderName { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the dialog result.
        /// </summary>
        /// <value>
        /// The dialog result.
        /// </value>
        public DialogResult DialogResult { get; set; }
    }
}
