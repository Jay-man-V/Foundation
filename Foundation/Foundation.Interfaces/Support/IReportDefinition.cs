//-----------------------------------------------------------------------
// <copyright file="IReportDefinition.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Report Definition model interface
    /// </summary>
    public interface IReportDefinition
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        String Title { get; set; }

        /// <summary>
        /// Gets or sets the subtitle.
        /// </summary>
        /// <value>
        /// The subtitle.
        /// </value>
        String SubTitle { get; set; }

        /// <summary>
        /// Gets or sets the page header.
        /// </summary>
        /// <value>
        /// The page header.
        /// </value>
        String PageHeader { get; set; }

        /// <summary>
        /// Gets or sets the page footer.
        /// </summary>
        /// <value>
        /// The page footer.
        /// </value>
        String PageFooter { get; set; }

        /// <summary>
        /// Gets or sets the generated on.
        /// </summary>
        /// <value>
        /// The generated on.
        /// </value>
        DateTime GeneratedOn { get; set; }

        /// <summary>
        /// Gets or sets the requested by.
        /// </summary>
        /// <value>
        /// The requested by.
        /// </value>
        String RequestedBy { get; set; }

        /// <summary>
        /// Gets or sets the columns.
        /// </summary>
        /// <value>
        /// The columns.
        /// </value>
        List<IGridColumnDefinition> Columns { get; set; }

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>
        /// The data source.
        /// </value>
        Object? DataSource { get; set; }
    }
}
