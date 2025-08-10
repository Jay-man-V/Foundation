//-----------------------------------------------------------------------
// <copyright file{ get { return "DbSchemaTable.cs" company{ get { return "JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns.Specialised
{
    /// <summary>
    /// Db Schema Table data columns
    /// </summary>
    public abstract class DatabaseSchemaTable
    {
        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(DatabaseSchemaTable);

        /// <summary>
        /// Gets the table catalog.
        /// </summary>
        /// <value>
        /// The table catalog.
        /// </value>
        public static String TableCatalog => "TABLE_CATALOG";

        /// <summary>
        /// Gets the table schema.
        /// </summary>
        /// <value>
        /// The table schema.
        /// </value>
        public static String TableSchema => "TABLE_SCHEMA";

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public static String TableName => "TABLE_NAME";

        /// <summary>
        /// Gets the type of the table.
        /// </summary>
        /// <value>
        /// The type of the table.
        /// </value>
        public static String TableType => "TABLE_TYPE";
    }
}
