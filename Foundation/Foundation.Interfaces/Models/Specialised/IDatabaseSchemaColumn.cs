//-----------------------------------------------------------------------
// <copyright file="IDatabaseSchemaColumn.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Database Schema Column model interface
    /// </summary>
    public interface IDatabaseSchemaColumn : IFoundationModel
    {
        /// <summary>Gets or sets the name of the table.</summary>
        /// <value>The name of the table.</value>
        String TableName { get; set; }

        /// <summary>Gets or sets the name of the column.</summary>
        /// <value>The name of the column.</value>
        String ColumnName { get; set; }

        /// <summary>Gets or sets the type of the data.</summary>
        /// <value>The type of the data.</value>
        Type DataType { get; set; }
    }
}
