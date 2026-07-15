//-----------------------------------------------------------------------
// <copyright file="BulkLoader.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Diagnostics;
using System.IO;
using Foundation.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;

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
                IEnumerable<SqlDataRecord> dt = GetData(bulkDataLoadSettings.SourceFilePath);

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

        private IEnumerable<SqlDataRecord> GetData(String fileName)
        {
            LoggingHelpers.TraceCallEnter(fileName);

            // TODO: Query the database to get the column names and types from the destination table.
            List<SqlMetaData> schema = CommonCode.SetupDataTable();

            SqlDataRecord dataRecord = new SqlDataRecord(schema.ToArray());
            StreamReader reader = new StreamReader(fileName);
            Int32 rowCounter = 0;
            try
            {
                while (!reader.EndOfStream)
                {
                    rowCounter++;

                    if (rowCounter % CommonCode.DebugCount == 0)
                    {
                        Debug.WriteLine($"Progress: {rowCounter}");
                    }

                    String? fileRow = reader.ReadLine();
                    var values = fileRow.Split(',');

                    dataRecord.SetValues(values);

                    //for (Int32 counter = 0; counter < CommonCode.ColumnCount; counter++)
                    //{
                    //    dataRecord.SetString(counter, values[counter]);
                    //}

                    yield return dataRecord;
                }
            }
            finally
            {
                reader.Close();
            }

            LoggingHelpers.TraceCallReturn();
        }
    }
}
}
