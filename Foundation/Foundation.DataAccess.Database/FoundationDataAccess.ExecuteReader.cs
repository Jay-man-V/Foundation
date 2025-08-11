//-----------------------------------------------------------------------
// <copyright file="FoundationDataAccess.ExecuteReader.cs" company="JDV Software Ltd">
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
        /// <inheritdoc cref="IFoundationDataAccess.ExecuteReader(String, CommandType, IDatabaseParameters?)"/>
        public IDataReader ExecuteReader(String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null)
        {
            LoggingHelpers.TraceCallEnter(sql, commandType, databaseParameters);

            IDbConnection conn = GetConnection();

            IDataReader retVal = ExecuteReader(conn, sql, commandType, databaseParameters);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.ExecuteReader(IDbConnection, String, CommandType, IDatabaseParameters?)"/>
        public IDataReader ExecuteReader(IDbConnection conn, String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null)
        {
            LoggingHelpers.TraceCallEnter(conn, sql, commandType, databaseParameters);

            IDataReader retVal;

            using (IDbCommand command = conn.CreateCommand())
            {
                if (DatabaseTransaction != null)
                {
                    command.Transaction = DatabaseTransaction;
                }

                if (databaseParameters.HasItems())
                {
                    databaseParameters!.ToList().ForEach(p => command.Parameters.Add(p));
                }

                command.CommandText = sql;
                command.CommandType = commandType;

                retVal = command.ExecuteReader();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
