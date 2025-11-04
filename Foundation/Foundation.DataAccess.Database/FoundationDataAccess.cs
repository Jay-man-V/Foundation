//-----------------------------------------------------------------------
// <copyright file="FoundationRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;

using Foundation.Common;
using Foundation.DataAccess.Database.DataLogicProviders;
using Foundation.Interfaces;

namespace Foundation.DataAccess.Database
{
    /// <summary>
    /// Defines the FoundationDataAccess class
    /// </summary>
    public partial class FoundationDataAccess : IFoundationDataAccess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="FoundationDataAccess"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="dataProvider">The data provider.</param>
        public FoundationDataAccess
        (
            ICore core,
            ISystemConfigurationService systemConfigurationService,
            IDataProvider dataProvider
        )
        {
            LoggingHelpers.TraceCallEnter(core, dataProvider);

            Core = core;
            DataProvider = dataProvider;

            DatabaseConnection = null;
            DatabaseTransaction = null;

            String connectionStringKey = DataProvider.ConnectionName;
            ConnectionString = systemConfigurationService.GetConnectionString(connectionStringKey);
            DatabaseProviderName = systemConfigurationService.GetDataProviderName(connectionStringKey);

            if (String.IsNullOrEmpty(ConnectionString))
            {
                String message = $"Cannot load Connection named '{connectionStringKey}'. Check to make sure the connection is defined in the Configuration File.";
                throw new ArgumentNullException(nameof(connectionStringKey), message);
            }

            switch (DatabaseProviderName)
            {
                case DataProviders.MsSqlClient: { DataLogicProvider = new MsSqlDataLogicProvider(); break; }
                case DataProviders.MySqlClient: { DataLogicProvider = new MySqlDataLogicProvider(); break; }
                case DataProviders.OracleClient: { DataLogicProvider = new OracleDataLogicProvider(); break; }
                default:
                {
                    String message = $"The Data Provider '{DatabaseProviderName}' is unknown and not supported";
                    throw new NotSupportedException(message);
                }
            }

            DatabaseProviderFactory = DbProviderFactories.GetFactory(DatabaseProviderName);

            LoggingHelpers.TraceMessage($"Database Provider Factory has been loaded for: '{DatabaseProviderName}'");

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value>
        /// 
        /// </value>
        private Boolean IsDisposed { get; set; }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        private String ConnectionString { get; }

        /// <summary>
        /// Gets the database provider factory.
        /// </summary>
        /// <value>
        /// The database provider factory.
        /// </value>
        private DbProviderFactory DatabaseProviderFactory { get; }

        /// <summary>
        /// The Foundation Core service
        /// </summary>
        protected ICore Core { get; }

        /// <summary>
        /// Gets the database connection.
        /// </summary>
        /// <value>
        /// The database connection.
        /// </value>
        protected IDbConnection? DatabaseConnection { get; set; }

        /// <summary>
        /// Gets the database provider name.
        /// </summary>
        /// <value>
        /// The database provider name.
        /// </value>
        protected String DatabaseProviderName { get; }

        /// <inheritdoc cref="IFoundationDataAccess.DataProvider"/>
        public IDataProvider DataProvider { get; }

        /// <inheritdoc cref="IFoundationDataAccess.DatabaseTransaction"/>
        public IDbTransaction? DatabaseTransaction { get; private set; }

        /// <inheritdoc cref="IFoundationDataAccess.DataLogicProvider"/>
        public IDataLogicProvider DataLogicProvider { get; }

        /// <inheritdoc cref="IFoundationDataAccess.GetConnection()"/>
        public IDbConnection GetConnection()
        {
            LoggingHelpers.TraceCallEnter();

            if (DatabaseConnection is { State: ConnectionState.Open })
            {
                DatabaseConnection.Close();
                DatabaseConnection.Dispose();
                DatabaseConnection = null;
            }

            DatabaseConnection = DatabaseProviderFactory.CreateConnection();

            if (DatabaseConnection == null)
            {
                String message = $"Unable to create Database connection to '{DatabaseProviderName}'";
                throw new InvalidOperationException(message);
            }

            DatabaseConnection.ConnectionString = ConnectionString;
            DatabaseConnection.Open();

            LoggingHelpers.TraceCallReturn(DatabaseConnection);

            return DatabaseConnection;
        }

        /// <inheritdoc cref="IFoundationDataAccess.BeginTransaction()"/>
        public IDbTransaction BeginTransaction()
        {
            LoggingHelpers.TraceCallEnter();

            if (DatabaseTransaction != null)
            {
                DatabaseTransaction.Dispose();
                DatabaseTransaction = null;
            }

            DatabaseConnection ??= GetConnection();

            DatabaseTransaction = DatabaseConnection.BeginTransaction();

            LoggingHelpers.TraceCallReturn(DatabaseTransaction);

            return DatabaseTransaction;
        }

        /// <inheritdoc cref="IFoundationDataAccess.ExecuteGetRowCount(String, CommandType, IDatabaseParameters)"/>
        public Int32 ExecuteGetRowCount(String sql, CommandType commandType = CommandType.Text, IDatabaseParameters? databaseParameters = null)
        {
            LoggingHelpers.TraceCallEnter();

            Object result = ExecuteNonQuery(sql, commandType, databaseParameters);

            Int32 retVal = DataHelpers.GetValue(result, -1);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <returns>Instance of type <see cref="IDbDataParameter"/></returns>
        private IDbDataParameter InternalCreateParameter(String parameterName)
        {
            LoggingHelpers.TraceCallEnter(parameterName);

            IDbDataParameter? retVal = DatabaseProviderFactory.CreateParameter();

            if (retVal == null)
            {
                String message = $"Unable to create basic parameter from DatabaseProviderFactory '{DatabaseProviderName}'";
                throw new ArgumentNullException(message);
            }

            retVal.ParameterName = parameterName;
            retVal.Direction = ParameterDirection.Input;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Returns the appropriate <see cref="DbType"/> for the .Net <see cref="Type"/>
        /// </summary>
        /// <param name="parameterName">Name of the parameter</param>
        /// <param name="parameterType">.Net type of the parameter</param>
        /// <returns>The <see cref="DbType"/></returns>
        /// <exception cref="NotSupportedException"></exception>
        private DbType GetParameterType(String parameterName, Type parameterType)
        {
            DbType retVal;

            if (parameterType == typeof(String)) retVal = DbType.String;
            else if (parameterType == typeof(EmailAddress)) retVal = DbType.String;
            else if (parameterType == typeof(EntityId)) retVal = EntityId.DbType;
            else if (parameterType == typeof(AppId)) retVal = AppId.DbType;
            else if (parameterType == typeof(LogId)) retVal = LogId.DbType;
            else if (parameterType == typeof(ScheduleInterval)) retVal = LogId.DbType;
            else if (parameterType == typeof(Boolean)) retVal = DbType.Boolean;
            else if (parameterType == typeof(Int16)) retVal = DbType.Int16;
            else if (parameterType == typeof(UInt16)) retVal = DbType.UInt16;
            else if (parameterType == typeof(Int32)) retVal = DbType.Int32;
            else if (parameterType == typeof(UInt32)) retVal = DbType.UInt32;
            else if (parameterType == typeof(Int64)) retVal = DbType.Int64;
            else if (parameterType == typeof(UInt64)) retVal = DbType.UInt64;
            else if (parameterType == typeof(Decimal)) retVal = DbType.Decimal;
            else if (parameterType == typeof(Single)) retVal = DbType.Single;
            else if (parameterType == typeof(Byte)) retVal = DbType.Byte;
            else if (parameterType == typeof(Byte[])) retVal = DbType.Binary;
            else if (parameterType == typeof(DateTime)) retVal = DbType.DateTime;
            else if (parameterType == typeof(TimeSpan)) retVal = DbType.Time;
            else if (parameterType == typeof(Bitmap)) retVal = DbType.Binary;
            else if (parameterType == typeof(Object)) retVal = DbType.Object;
            else
            {
                String errorMessage = $"The type of the parameter is unhandled. Type: '{parameterType}'. Name: '{parameterName}'";
                throw new NotSupportedException(errorMessage);
            }

            return retVal;
        }

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <typeparam name="TValue">The <see cref="Type"/> of <paramref name="parameterValue"/></typeparam>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns>Instance of DbParameter</returns>
        private IDbDataParameter InternalCreateParameter<TValue>(String parameterName, TValue? parameterValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, parameterValue);

            IDbDataParameter retVal = InternalCreateParameter(parameterName);

            Type parameterType = typeof(Object);

            if (parameterValue == null ||
                (parameterValue is String value && String.IsNullOrEmpty(value)))
            {
                retVal.Value = DBNull.Value;
            }
            else if (parameterValue is Bitmap imageParameterValue)
            {
                Image emptyImage1 = DataHelpers.DefaultImage;

                if (imageParameterValue.CompareAsByteArray(emptyImage1))
                {
                    retVal.Value = DBNull.Value;
                }
                else
                {
                    using MemoryStream ms = new MemoryStream();
                    imageParameterValue.Save(ms, imageParameterValue.RawFormat);

                    Byte[] byteArray = ms.ToArray();

                    retVal.Value = byteArray;
                }

                parameterType = parameterValue.GetType();
            }
            else
            {
                retVal.Value = parameterValue;
                parameterType = parameterValue.GetType();
            }

            retVal.DbType = GetParameterType(parameterName, parameterType);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.CreateParameter{TValue}(String, TValue?, TValue)"/>
        public IDbDataParameter CreateParameter<TValue>(String parameterName, TValue? parameterValue, TValue useNullForThisValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, parameterValue, useNullForThisValue);

            IDbDataParameter retVal;

            if (useNullForThisValue != null &&
                useNullForThisValue.Equals(parameterValue) ||
                parameterValue == null)
            {
                retVal = CreateParameter(parameterName, DbType.Object, DBNull.Value);

                Type parameterType = useNullForThisValue!.GetType();

                if (parameterValue != null)
                {
                    parameterType = parameterValue.GetType();
                }

                retVal.DbType = GetParameterType(parameterName, parameterType);
            }
            else
            {
                retVal = InternalCreateParameter(parameterName, parameterValue);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Creates the parameter.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="databaseType">Type of the database.</param>
        /// <param name="parameterValue">The parameter value.</param>
        /// <returns>Instance of DbParameter</returns>
        private IDbDataParameter CreateParameter(String parameterName, DbType databaseType, Object parameterValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, databaseType, parameterValue);

            IDbDataParameter retVal = InternalCreateParameter(parameterName);

            retVal.DbType = databaseType;
            retVal.Value = parameterValue;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.CreateParameter{TValue}(String, TValue?)"/>
        public IDbDataParameter CreateParameter<TValue>(String parameterName, TValue? parameterValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, parameterValue);

            IDbDataParameter retVal = InternalCreateParameter(parameterName, parameterValue);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.CreateParameter(String, EntityStatus)"/>
        public IDbDataParameter CreateParameter(String parameterName, EntityStatus parameterValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, parameterValue);

            IDbDataParameter retVal = InternalCreateParameter(parameterName, parameterValue.Id());

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.CreateParameter(String, LogSeverity)"/>
        public IDbDataParameter CreateParameter(String parameterName, LogSeverity parameterValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, parameterValue);

            IDbDataParameter retVal = InternalCreateParameter(parameterName, parameterValue.Id());

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.CreateParameter(String, IFoundationModel?)"/>
        public IDbDataParameter CreateParameter(String parameterName, IFoundationModel? parameterValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, parameterValue);

            IDbDataParameter retVal;

            if (parameterValue == null)
            {
                retVal = CreateParameter(parameterName, DbType.Int32, DBNull.Value);
            }
            else
            {
                retVal = CreateParameter(parameterName, parameterValue.Id);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.CreateParameter(String, Object?, EntityId)"/>
        public IDbDataParameter CreateParameter(String parameterName, Object? parameterValue, EntityId useNullForThisValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, parameterValue, useNullForThisValue);

            IDbDataParameter retVal;

            if (useNullForThisValue.Equals(parameterValue) ||
                parameterValue == null)
            {
                retVal = CreateParameter(parameterName, EntityId.DbType, DBNull.Value);

                Type parameterType = useNullForThisValue.GetType();

                if (parameterValue != null)
                {
                    parameterType = parameterValue.GetType();
                }

                retVal.DbType = GetParameterType(parameterName, parameterType);
            }
            else
            {
                retVal = CreateParameter(parameterName, (EntityId)parameterValue);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.CreateParameter(String, Object?, AppId)"/>
        public IDbDataParameter CreateParameter(String parameterName, Object? parameterValue, AppId useNullForThisValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, parameterValue, useNullForThisValue);

            IDbDataParameter retVal;

            if (useNullForThisValue.Equals(parameterValue) ||
                parameterValue == null)
            {
                retVal = CreateParameter(parameterName, AppId.DbType, DBNull.Value);

                Type parameterType = useNullForThisValue.GetType();

                if (parameterValue != null)
                {
                    parameterType = parameterValue.GetType();
                }

                retVal.DbType = GetParameterType(parameterName, parameterType);
            }
            else
            {
                retVal = CreateParameter(parameterName, (AppId)parameterValue);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.CreateParameter(String, Object?, LogId)"/>
        public IDbDataParameter CreateParameter(String parameterName, Object? parameterValue, LogId useNullForThisValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, parameterValue, useNullForThisValue);

            IDbDataParameter retVal;

            if (useNullForThisValue.Equals(parameterValue) ||
                parameterValue == null)
            {
                retVal = CreateParameter(parameterName, LogId.DbType, DBNull.Value);

                Type parameterType = useNullForThisValue.GetType();

                if (parameterValue != null)
                {
                    parameterType = parameterValue.GetType();
                }

                retVal.DbType = GetParameterType(parameterName, parameterType);
            }
            else
            {
                retVal = CreateParameter(parameterName, (LogId)parameterValue);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.CreateParameter(String, DateTime?)"/>
        public IDbDataParameter CreateParameter(String parameterName, DateTime? parameterValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, parameterValue);

            IDbDataParameter retVal;

            if (parameterValue == null)
            {
                retVal = CreateParameter(parameterName, DbType.DateTime, DBNull.Value);
            }
            else
            {
                retVal = InternalCreateParameter(parameterName, parameterValue);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.CreateParameter(String, EntityId)"/>
        public IDbDataParameter CreateParameter(String parameterName, EntityId parameterValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, parameterValue);

            IDbDataParameter retVal;

            if (parameterValue.TheEntityId is 0L or -1L)
            {
                retVal = CreateParameter(parameterName, EntityId.DbType, DBNull.Value);
            }
            else
            {
                retVal = InternalCreateParameter(parameterName, parameterValue.ToInteger());
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.CreateParameter(String, AppId)"/>
        public IDbDataParameter CreateParameter(String parameterName, AppId parameterValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, parameterValue);

            IDbDataParameter retVal;

            if (parameterValue.TheAppId is 0L or -1L)
            {
                retVal = CreateParameter(parameterName, AppId.DbType, DBNull.Value);
            }
            else
            {
                retVal = InternalCreateParameter(parameterName, parameterValue.ToInteger());
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.CreateParameter(String, LogId)"/>
        public IDbDataParameter CreateParameter(String parameterName, LogId parameterValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, parameterValue);

            IDbDataParameter retVal;

            if (parameterValue.TheLogId is 0L or -1L)
            {
                retVal = CreateParameter(parameterName, LogId.DbType, DBNull.Value);
            }
            else
            {
                retVal = InternalCreateParameter(parameterName, parameterValue.ToInteger());
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.CreateParameter(String, EmailAddress)"/>
        public IDbDataParameter CreateParameter(String parameterName, EmailAddress parameterValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, parameterValue);

            IDbDataParameter retVal;

            if (String.IsNullOrEmpty(parameterValue.ToString()))
            {
                retVal = CreateParameter(parameterName, DbType.String, DBNull.Value);
            }
            else
            {
                retVal = InternalCreateParameter(parameterName, parameterValue.ToString());
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IFoundationDataAccess.CreateParameter(String, EmailAddress?)"/>
        public IDbDataParameter CreateParameter(String parameterName, EmailAddress? parameterValue)
        {
            LoggingHelpers.TraceCallEnter(parameterName, parameterValue);

            IDbDataParameter retVal;

            if (!parameterValue.HasValue || String.IsNullOrEmpty(parameterValue.Value.ToString()))
            {
                retVal = CreateParameter(parameterName, DbType.String, DBNull.Value);
            }
            else
            {
                retVal = InternalCreateParameter(parameterName, parameterValue.ToString());
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Disposes the specified disposing.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        private void Dispose(Boolean disposing)
        {
            if (IsDisposed) return;

            if (disposing)
            {
                if (DatabaseConnection != null)
                {
                    if (DatabaseConnection.State == ConnectionState.Open) DatabaseConnection.Close();

                    DatabaseConnection.Dispose();
                    DatabaseConnection = null;
                }

                if (DatabaseTransaction != null)
                {
                    DatabaseTransaction.Dispose();
                    DatabaseTransaction = null;
                }
            }

            IsDisposed = true;
        }

        // Override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~FoundationDataAccess()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        /// <inheritdoc cref="IDisposable.Dispose()"/>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
