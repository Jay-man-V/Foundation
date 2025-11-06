//-----------------------------------------------------------------------
// <copyright file="IDbSchemaColumnRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Database Schema Column Data Access interface
    /// </summary>
    public interface IDatabaseSchemaColumnDataAccess
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbSchemaTable"></param>
        /// <returns></returns>
        List<IDatabaseSchemaColumn> GetAllColumns(IDatabaseSchemaTable dbSchemaTable);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableCatalog"></param>
        /// <param name="tableSchema"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        List<IDatabaseSchemaColumn> GetAllColumns(String tableCatalog, String tableSchema, String tableName);
    }
}
