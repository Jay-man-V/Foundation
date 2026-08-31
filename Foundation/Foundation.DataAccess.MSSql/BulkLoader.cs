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
using Foundation.Interfaces;

namespace Foundation.DataAccess.MSSql
{
    /// <summary>
    /// 
    /// </summary>
    public class BulkLoader : IFoundationBulkLoader
    {
        public BulkLoader
        (
            IFoundationDataAccess dataAccess
        )
        {
            LoggingHelpers.TraceCallEnter(dataAccess);

            DataAccess = dataAccess;

            LoggingHelpers.TraceCallReturn();
        }

        private IFoundationDataAccess DataAccess { get; }

        /// <inheritdoc cref="IFoundationBulkLoader.BulkDataLoad"/>
        public void BulkDataLoad(IBulkDataLoadSettings bulkDataLoadSettings)
        {
            LoggingHelpers.TraceCallEnter(bulkDataLoadSettings);

            using (IDbConnection connection = DataAccess.GetConnection())
            {
                IEnumerable<SqlDataRecord> dt = GetData(bulkDataLoadSettings);

                connection.Open();

                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = bulkDataLoadSettings.ProcedureName;
                    command.CommandTimeout = 0;
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = new(bulkDataLoadSettings.DestinationTable, SqlDbType.Structured)
                    {
                        TypeName = $"{bulkDataLoadSettings.DestinationTable}",
                        Value = dt,
                    };
                    command.Parameters.Add(p1);
                    command.ExecuteNonQuery();
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        private IEnumerable<SqlDataRecord> GetData(IBulkDataLoadSettings bulkDataLoadSettings)
        {
            LoggingHelpers.TraceCallEnter(bulkDataLoadSettings);

            // TODO: Query the database to get the column names and types from the destination table.
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
