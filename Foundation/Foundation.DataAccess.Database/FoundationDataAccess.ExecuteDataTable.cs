//-----------------------------------------------------------------------
// <copyright file="FoundationDataAccess.ExecuteDataTable.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.DataAccess.Database
{
    /// <summary>
    /// Defines the FoundationDataAccess class
    /// </summary>
    public partial class FoundationDataAccess
    {
        /// <inheritdoc cref="IFoundationDataAccess.ExecuteDataTable(String, CommandType, IDatabaseParameters?)"/>
        public DataTable ExecuteDataTable(String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null)
        {
            LoggingHelpers.TraceCallEnter(sql, commandType, databaseParameters);

            DataTable retVal;

            using (IDbConnection conn = GetConnection())
            {
                DataSet ds = ExecuteDataSet(conn, sql, commandType, databaseParameters);
                retVal = ds.Tables[0];
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.ExecuteDataTable(String, CommandType, IDatabaseParameters?)"/>
        public DataTable ExecuteDataTable(IDbConnection conn, String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null)
        {
            LoggingHelpers.TraceCallEnter(conn, sql, commandType, databaseParameters);

            DataTable retVal;

            DataSet ds = ExecuteDataSet(conn, sql, commandType, databaseParameters);
            retVal = ds.Tables[0];

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
