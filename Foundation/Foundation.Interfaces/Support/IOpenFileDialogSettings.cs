//-----------------------------------------------------------------------
// <copyright file="IOpenFileDialogSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// The interface Open File Dialog definition
    /// </summary>
    public interface IOpenFileDialogSettings
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
        /// Gets or sets the default extension.
        /// </summary>
        /// <value>
        /// The default extension.
        /// </value>
        String DefaultExtension { get; set; }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        String Filter { get; set; }

        /// <summary>
        /// Gets or sets the index of the filter.
        /// </summary>
        /// <value>
        /// The index of the filter.
        /// </value>
        UInt16 FilterIndex { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [overwrite prompt].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [overwrite prompt]; otherwise, <c>false</c>.
        /// </value>
        Boolean OverwritePrompt { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        String FileName { get; set; }

        /// <summary>
        /// Gets or sets the dialog result.
        /// </summary>
        /// <value>
        /// The dialog result.
        /// </value>
        DialogResult DialogResult { get; set; }
    }
}
