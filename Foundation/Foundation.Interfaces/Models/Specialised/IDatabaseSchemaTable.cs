//-----------------------------------------------------------------------
// <copyright file="DatabaseSchemaTable.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Database Schema Table model interface
    /// </summary>
    public interface IDatabaseSchemaTable : IFoundationModel
    {
        /// <summary>Gets or sets the table catalog.</summary>
        /// <value>The table catalog.</value>
        String TableCatalog { get; set; }

        /// <summary>Gets or sets the table schema.</summary>
        /// <value>The table schema.</value>
        String TableSchema { get; set; }

        /// <summary>Gets or sets the name of the table.</summary>
        /// <value>The name of the table.</value>
        String TableName { get; set; }

        /// <summary>Gets or sets the type of the table.</summary>
        /// <value>The type of the table.</value>
        String TableType { get; set; }

        /// <summary>Gets the schema columns.</summary>
        /// <value>The schema columns.</value>
        IList<IDatabaseSchemaColumn> SchemaColumns { get; }
    }
}
