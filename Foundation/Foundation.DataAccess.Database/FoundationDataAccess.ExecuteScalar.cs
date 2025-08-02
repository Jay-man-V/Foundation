//-----------------------------------------------------------------------
// <copyright file="FoundationDataAccess.ExecuteScalar.cs" company="JDV Software Ltd">
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
        /// <inheritdoc cref="IFoundationDataAccess.ExecuteScalar(String, CommandType, IDatabaseParameters?)"/>
        public Object ExecuteScalar(String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null)
        {
            LoggingHelpers.TraceCallEnter(sql, commandType, databaseParameters);

            Object retVal;

            using (IDbConnection conn = GetConnection())
            {
                retVal = ExecuteScalar(conn, sql, commandType, databaseParameters);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.ExecuteScalar(IDbConnection, String, CommandType, IDatabaseParameters?)"/>
        public Object ExecuteScalar(IDbConnection conn, String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null)
        {
            LoggingHelpers.TraceCallEnter(conn, sql, commandType, databaseParameters);

            Object retVal;

            using (IDbCommand command = conn.CreateCommand())
            {
                if (DatabaseTransaction != null)
                {
                    command.Transaction = DatabaseTransaction;
                }

                if (databaseParameters.HasItems())
                {
                    databaseParameters.ToList().ForEach(p => command.Parameters.Add(p));
                }

                command.CommandText = sql;
                command.CommandType = commandType;

                retVal = command.ExecuteScalar();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
