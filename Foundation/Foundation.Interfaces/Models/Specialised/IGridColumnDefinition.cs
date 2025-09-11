//-----------------------------------------------------------------------
// <copyright file="IGridColumnDefinition.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Grid Column Definition definition
    /// </summary>
    public interface IGridColumnDefinition : ICloneable
    {
        /// <summary>
        /// Width
        /// </summary>
        Int32 Width { get; set; }
        /// <summary>
        /// Data member name
        /// </summary>
        String DataMemberName { get; }
        /// <summary>
        /// Column header name
        /// </summary>
        String ColumnHeaderName { get; }
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
        Int32 MaxInputLength { get; set; }

        /// <summary>
        /// DotNetFormat
        /// </summary>
        String DotNetFormat { get; set; }
        /// <summary>
        /// Excel format
        /// </summary>
        String ExcelFormat { get; set; }
        /// <summary>
        /// Minimum value
        /// </summary>
        Object? MinimumValue { get; set; }
        /// <summary>
        /// Maximum value
        /// </summary>
        Object? MaximumValue { get; set; }
        /// <summary>
        /// True value
        /// </summary>
        String TrueValue { get; set; }
        /// <summary>
        /// False value
        /// </summary>
        String FalseValue { get; set; }
        /// <summary>
        /// Data Source
        /// </summary>
        Object? DataSource { get; set; }
        /// <summary>
        /// Value Member
        /// </summary>
        String ValueMember { get; set; }
        /// <summary>
        /// Display Member
        /// </summary>
        String DisplayMember { get; set; }
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
        String TemplateName { get; }
    }
}
