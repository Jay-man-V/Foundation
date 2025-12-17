//-----------------------------------------------------------------------
// <copyright file="IImportExportControl.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Import Export Control model interface
    /// </summary>
    public interface IImportExportControl : IFoundationModel
    {
        /// <summary>
        /// The Date/time the Import or Export process was last run.
        /// </summary>
        /// <value>The processed on.</value>
        DateTime ProcessedOn { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        String Name { get; set; }

        /// <summary>
        /// Whether an import or export process is currently in progress.
        /// </summary>
        Boolean InProgress { get; set; }
    }
}
