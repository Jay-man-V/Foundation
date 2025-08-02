//-----------------------------------------------------------------------
// <copyright file="IFoundationDataAccess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Data;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the IFoundationDataAccess behaviours
    /// </summary>
    public interface IFoundationDataAccess : IDisposable
    {
        /// <summary>
        /// Gets the database parameter prefix.
        /// </summary>
        /// <value>
        /// The database parameter prefix.
        /// </value>
        IDataLogicProvider DataLogicProvider { get; }

        /// <summary>
        /// Gets the database transaction.
        /// </summary>
        /// <value>
        /// The database transaction.
        /// </value>
        IDbTransaction DatabaseTransaction { get; }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <returns><see cref="IDbConnection"/></returns>
        IDbConnection GetConnection();

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        /// <returns>The database transaction.</returns>
        IDbTransaction BeginTransaction();

        /// <summary>
        /// Executes the get row count.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        /// <param name="commandType">The command type.</param>
        /// <param name="databaseParameters">The database parameters.</param>
        /// <returns>
        /// <br />
        /// </returns>
        Int32 ExecuteGetRowCount(String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null);

        /// <summary>
        /// Executes the command and returns the resulting <see cref="DataSet"/>
        /// </summary>
        /// <param name="sql">The SQL Command Text or Stored Procedure name</param>
        /// <param name="commandType">The <see cref="CommandType"/> of the command to be executed</param>
        /// <param name="databaseParameters">The parameters to pass to the command</param>
        /// <returns>The <see cref="DataSet"/> from the command</returns>
        DataSet ExecuteDataSet(String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null);

        /// <summary>
        /// Executes the command and returns the resulting <see cref="DataSet"/>
        /// </summary>
        /// <param name="conn">The database connection to use for this command</param>
        /// <param name="sql">The SQL Command Text or Stored Procedure name</param>
        /// <param name="commandType">The <see cref="CommandType"/> of the command to be executed</param>
        /// <param name="databaseParameters">The parameters to pass to the command</param>
        /// <returns>The <see cref="DataSet"/> from the command</returns>
        DataSet ExecuteDataSet(IDbConnection conn, String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null);

        /// <summary>
        /// Executes the command and returns the resulting <see cref="DataSet"/>
        /// </summary>
        /// <param name="sql">The SQL Command Text or Stored Procedure name</param>
        /// <param name="commandType">The <see cref="CommandType"/> of the command to be executed</param>
        /// <param name="databaseParameters">The parameters to pass to the command</param>
        /// <returns>The <see cref="DataTable"/> from the command</returns>
        DataTable ExecuteDataTable(String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null);

        /// <summary>
        /// Executes the command and returns the resulting <see cref="DataSet"/>
        /// </summary>
        /// <param name="conn">The database connection to use for this command</param>
        /// <param name="sql">The SQL Command Text or Stored Procedure name</param>
        /// <param name="commandType">The <see cref="CommandType"/> of the command to be executed</param>
        /// <param name="databaseParameters">The parameters to pass to the command</param>
        /// <returns>The <see cref="DataTable"/> from the command</returns>
        DataTable ExecuteDataTable(IDbConnection conn, String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null);

        /// <summary>
        /// Executes the command and returns the resulting <see cref="DataSet"/>
        /// </summary>
        /// <param name="sql">The SQL Command Text or Stored Procedure name</param>
        /// <param name="commandType">The <see cref="CommandType"/> of the command to be executed</param>
        /// <param name="databaseParameters">The parameters to pass to the command</param>
        /// <returns>The <see cref="int"/> result of the number of records affected</returns>
        Int32 ExecuteNonQuery(String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null);

        /// <summary>
        /// Executes the command and returns the resulting <see cref="DataSet"/>
        /// </summary>
        /// <param name="conn">The database connection to use for this command</param>
        /// <param name="sql">The SQL Command Text or Stored Procedure name</param>
        /// <param name="commandType">The <see cref="CommandType"/> of the command to be executed</param>
        /// <param name="databaseParameters">The parameters to pass to the command</param>
        /// <returns>The <see cref="Int32"/> result of the number of records affected</returns>
        Int32 ExecuteNonQuery(IDbConnection conn, String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null);

        /// <summary>
        /// Executes the command and returns the resulting <see cref="DataSet"/>
        /// </summary>
        /// <param name="sql">The SQL Command Text or Stored Procedure name</param>
        /// <param name="commandType">The <see cref="CommandType"/> of the command to be executed</param>
        /// <param name="databaseParameters">The parameters to pass to the command</param>
        /// <returns>The <see cref="IDataReader"/> for the command</returns>
        IDataReader ExecuteReader(String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null);

        /// <summary>
        /// Executes the command and returns the resulting <see cref="DataSet"/>
        /// </summary>
        /// <param name="conn">The database connection to use for this command</param>
        /// <param name="sql">The SQL Command Text or Stored Procedure name</param>
        /// <param name="commandType">The <see cref="CommandType"/> of the command to be executed</param>
        /// <param name="databaseParameters">The parameters to pass to the command</param>
        /// <returns>The <see cref="IDataReader"/> for the command</returns>
        IDataReader ExecuteReader(IDbConnection conn, String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null);

        /// <summary>
        /// Executes the command and returns the resulting <see cref="DataSet"/>
        /// </summary>
        /// <param name="sql">The SQL Command Text or Stored Procedure name</param>
        /// <param name="commandType">The <see cref="CommandType"/> of the command to be executed</param>
        /// <param name="databaseParameters">The parameters to pass to the command</param>
        /// <returns>The <see cref="object"/> result of the command</returns>
        Object ExecuteScalar(String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null);

        /// <summary>
        /// Executes the command and returns the resulting <see cref="DataSet"/>
        /// </summary>
        /// <param name="conn">The database connection to use for this command</param>
        /// <param name="sql">The SQL Command Text or Stored Procedure name</param>
        /// <param name="commandType">The <see cref="CommandType"/> of the command to be executed</param>
        /// <param name="databaseParameters">The parameters to pass to the command</param>
        /// <returns>The <see cref="Object"/> result of the command</returns>
        Object ExecuteScalar(IDbConnection conn, String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null);

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <typeparam name="TValue">The <see cref="Type"/> of <paramref name="parameterValue"/></typeparam>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <param name="useNullForThisValue">if <paramref name="parameterValue"/> equals this value, then DbNull.Value is used instead</param>
        /// <returns>Instance of DbParameter</returns>
        IDbDataParameter CreateParameter<TValue>(String parameterName, TValue? parameterValue, TValue useNullForThisValue);

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <typeparam name="TValue">The <see cref="Type"/> of <paramref name="parameterValue"/></typeparam>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns>Instance of DbParameter</returns>
        IDbDataParameter CreateParameter<TValue>(String parameterName, TValue? parameterValue);

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns>Instance of DbParameter</returns>
        IDbDataParameter CreateParameter(String parameterName, EntityStatus parameterValue);

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns>Instance of DbParameter</returns>
        IDbDataParameter CreateParameter(String parameterName, LogSeverity parameterValue);

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns>Instance of DbParameter</returns>
        IDbDataParameter CreateParameter(String parameterName, IFoundationModel? parameterValue);

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <param name="useNullForThisValue">if <paramref name="parameterValue"/> equals this value, then DbNull.Value is used instead</param>
        /// <returns>Instance of DbParameter</returns>
        IDbDataParameter CreateParameter(String parameterName, Object? parameterValue, EntityId useNullForThisValue);

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <param name="useNullForThisValue">if <paramref name="parameterValue"/> equals this value, then DbNull.Value is used instead</param>
        /// <returns>Instance of DbParameter</returns>
        IDbDataParameter CreateParameter(String parameterName, Object? parameterValue, AppId useNullForThisValue);

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <param name="useNullForThisValue">if <paramref name="parameterValue"/> equals this value, then DbNull.Value is used instead</param>
        /// <returns>Instance of DbParameter</returns>
        IDbDataParameter CreateParameter(String parameterName, Object? parameterValue, LogId useNullForThisValue);

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns>Instance of DbParameter</returns>
        IDbDataParameter CreateParameter(String parameterName, DateTime? parameterValue);

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns>Instance of DbParameter</returns>
        IDbDataParameter CreateParameter(String parameterName, EntityId? parameterValue);

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns>Instance of DbParameter</returns>
        IDbDataParameter CreateParameter(String parameterName, AppId parameterValue);

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns>Instance of DbParameter</returns>
        IDbDataParameter CreateParameter(String parameterName, LogId? parameterValue);

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns>Instance of DbParameter</returns>
        IDbDataParameter CreateParameter(String parameterName, EmailAddress? parameterValue);
    }
}
