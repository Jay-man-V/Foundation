//-----------------------------------------------------------------------
// <copyright file="IGridColumnDefinition.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces.Helpers
{
    /// <summary>
    /// The Grid Column Definition definition
    /// </summary>
    public interface IGridColumnDefinition : ICloneable
    {
        /// <summary>
        /// Width
        /// </summary>
        int Width { get; set; }
        /// <summary>
        /// Data member name
        /// </summary>
        string DataMemberName { get; }
        /// <summary>
        /// Column header name
        /// </summary>
        string ColumnHeaderName { get; }
        /// <summary>
        /// Data type
        /// </summary>
        Type DataType { get; }

        /// <summary>
        /// Text alignment
        /// </summary>
        TextAlignment TextAlignment { get; set; }

        /// <summary>
        /// Gets or sets the maximum length of the input.
        /// </summary>
        /// <value>
        /// The maximum length of the input.
        /// </value>
        int MaxInputLength { get; set; }

        /// <summary>
        /// DotNetFormat
        /// </summary>
        string DotNetFormat { get; set; }
        /// <summary>
        /// Excel format
        /// </summary>
        string ExcelFormat { get; set; }
        /// <summary>
        /// Minimum value
        /// </summary>
        object? MinimumValue { get; set; }
        /// <summary>
        /// Maximum value
        /// </summary>
        object? MaximumValue { get; set; }
        /// <summary>
        /// True value
        /// </summary>
        string TrueValue { get; set; }
        /// <summary>
        /// False value
        /// </summary>
        string FalseValue { get; set; }
        /// <summary>
        /// Data Source
        /// </summary>
        object? DataSource { get; set; }
        /// <summary>
        /// Value Member
        /// </summary>
        string ValueMember { get; set; }
        /// <summary>
        /// Display Member
        /// </summary>
        string DisplayMember { get; set; }
        /// <summary>
        /// Visible
        /// </summary>
        Boolean Visible { get; set; }
        /// <summary>
        /// Read Only
        /// </summary>
        Boolean ReadOnly { get; set; }

        /// <summary>
        /// Template Name
        /// </summary>
        string TemplateName { get; }
    }
}
