//-----------------------------------------------------------------------
// <copyright file="BulkLoader.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.IO;

using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;

using Foundation.Common;
using Foundation.DataAccess.Database;
using Foundation.Interfaces;

namespace Foundation.DataAccess.MSSql
{
    /// <summary>
    /// 
    /// </summary>
    [DependencyInjectionTransient]
    public class BulkLoader : IMsSqlBulkLoader
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="BulkLoader"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="coreDataProvider">The core data provider.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        /// <param name="fileApi">The file API.</param>
        public BulkLoader
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ICoreDataProvider coreDataProvider,
            IDateTimeService dateTimeService,
            IFileApi fileApi
        )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, coreDataProvider, dateTimeService);

            Core = core;
            RunTimeEnvironmentSettings = runTimeEnvironmentSettings;
            SystemConfigurationService = systemConfigurationService;
            CoreDataProvider = coreDataProvider;
            DateTimeService = dateTimeService;

            FileApi = fileApi;

            FoundationDataAccess = new FoundationDataAccess(Core, SystemConfigurationService, CoreDataProvider.ConnectionName);

            LoggingHelpers.TraceCallReturn();
        }

        private ICore Core { get; }
        private IRunTimeEnvironmentSettings RunTimeEnvironmentSettings { get; }
        private ISystemConfigurationService SystemConfigurationService { get; }
        private ICoreDataProvider CoreDataProvider { get; }
        private IDateTimeService DateTimeService { get; }
        private IFileApi FileApi { get; }

        private IFoundationDataAccess FoundationDataAccess { get; }

            /// <inheritdoc cref="IFoundationBulkLoader.BulkDataLoad"/>
        public void BulkDataLoad(IBulkDataLoadSettings bulkDataLoadSettings)
        {
            LoggingHelpers.TraceCallEnter(bulkDataLoadSettings);

            // Check the file exists
            FileApi.EnsureFileExists(bulkDataLoadSettings.SourceFilePath);

            using (IDbConnection connection = FoundationDataAccess.GetConnection())
            {
                IEnumerable<SqlDataRecord> dt = GetData(bulkDataLoadSettings);

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = bulkDataLoadSettings.ProcedureName;
                    command.CommandTimeout = 0;
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = new(bulkDataLoadSettings.ProcedureParameterName, SqlDbType.Structured)
                    {
                        TypeName = bulkDataLoadSettings.ProcedureCustomTypeName,
                        Value = dt,
                    };
                    command.Parameters.Add(p1);
                    command.ExecuteNonQuery();
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Loads the data from the source file and returns an IEnumerable of SqlDataRecord objects.
        /// </summary>
        /// <param name="bulkDataLoadSettings"></param>
        /// <returns></returns>
        private IEnumerable<SqlDataRecord> GetData(IBulkDataLoadSettings bulkDataLoadSettings)
        {
            LoggingHelpers.TraceCallEnter(bulkDataLoadSettings);

            List<SqlMetaData> schema = SetupDataTable(bulkDataLoadSettings);

            SqlDataRecord dataRecord = new SqlDataRecord(schema.ToArray());
            StreamReader reader = new StreamReader(bulkDataLoadSettings.SourceFilePath);

            try
            {
                while (!reader.EndOfStream)
                {
                    String? fileRow = reader.ReadLine();
                    if (!String.IsNullOrEmpty(fileRow))
                    {
                        String[] values = fileRow.Split(',');

                        dataRecord.SetValues(values);

                        yield return dataRecord;
                    }
                }
            }
            finally
            {
                reader.Close();
            }

            LoggingHelpers.TraceCallReturn();
        }

        private List<SqlMetaData> SetupDataTable(IBulkDataLoadSettings bulkDataLoadSettings)
        {
            LoggingHelpers.TraceCallEnter(bulkDataLoadSettings);

            List<SqlMetaData> retVal = [];

            foreach(IDbDataParameter dbDataParameter in bulkDataLoadSettings.DataLoadParameters)
            {
                SqlDbType dbType = Utils.MapFromDbType(dbDataParameter.DbType);
                SqlMetaData sqlMetaData = new SqlMetaData(dbDataParameter.ParameterName, dbType, dbDataParameter.Size);
                retVal.Add(sqlMetaData);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
