//-----------------------------------------------------------------------
// <copyright file="SaveFileDialogSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// Definition of the Save Dialog Settings
    /// </summary>
    /// <seealso cref="ISaveFileDialogSettings" />
    [DependencyInjectionTransient]
    public class SaveFileDialogSettings : ISaveFileDialogSettings
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
        /// Gets or sets the default extension.
        /// </summary>
        /// <value>
        /// The default extension.
        /// </value>
        public String DefaultExtension { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public String Filter { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the index of the filter.
        /// </summary>
        /// <value>
        /// The index of the filter.
        /// </value>
        public UInt16 FilterIndex { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [overwrite prompt].
        /// </summary>
        /// <value>
        /// <c>true</c> if [overwrite prompt]; otherwise, <c>false</c>.
        /// </value>
        public Boolean OverwritePrompt { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public String FileName { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the dialog result.
        /// </summary>
        /// <value>
        /// The dialog result.
        /// </value>
        public DialogResult DialogResult { get; set; }
    }
}
