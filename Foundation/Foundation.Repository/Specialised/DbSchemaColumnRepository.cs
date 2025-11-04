//-----------------------------------------------------------------------
// <copyright file="DatabaseSchemaColumnRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Text;

using Foundation.Common;
using Foundation.DataAccess.Database;
using Foundation.Interfaces;
using Foundation.Repository.DataProvider;
using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Specialised
{
    /// <summary>
    /// Defines the Db Schema Column Data Access class
    /// </summary>
    /// <see cref="IDatabaseSchemaColumn" />
    [DependencyInjectionTransient]
    public class DatabaseSchemaColumnRepository : FoundationDataAccess, IDatabaseSchemaColumnRepository
    {
        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        protected String EntityName => FDC.Specialised.DatabaseSchemaColumn.EntityName;

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        protected String TableName => FDC.TableNames.Specialised.DbSchemaColumn;

        /// <summary>
        /// Initialises a new instance of the <see cref="DatabaseSchemaColumnRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        public DatabaseSchemaColumnRepository
        (
            ICore core,
            ISystemConfigurationService systemConfigurationService
        ) :
            base
            (
                core,
                systemConfigurationService,
                new SchemaDataProvider()
            )
        {
            LoggingHelpers.TraceCallEnter(core, systemConfigurationService);

            // Does nothing

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IDatabaseSchemaColumnRepository.GetAllColumns(IDatabaseSchemaTable)"/>
        public List<IDatabaseSchemaColumn> GetAllColumns(IDatabaseSchemaTable databaseSchemaTable)
        {
            LoggingHelpers.TraceCallEnter(databaseSchemaTable);

            List<IDatabaseSchemaColumn> retVal = GetAllColumns(databaseSchemaTable.TableCatalog, databaseSchemaTable.TableSchema, databaseSchemaTable.TableName);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IDatabaseSchemaColumnRepository.GetAllColumns(String, String, String)"/>
        public List<IDatabaseSchemaColumn> GetAllColumns(String tableCatalog, String tableSchema, String tableName)
        {
            LoggingHelpers.TraceCallEnter(tableCatalog, tableSchema, tableName);

            List<IDatabaseSchemaColumn> retVal = [];

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("    *");
            sql.AppendLine("FROM");
            sql.AppendLine(TableName);
            sql.AppendLine("WHERE");
            sql.AppendLine($"    {FDC.Specialised.DatabaseSchemaColumn.TableCatalog} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.Specialised.DatabaseSchemaColumn.EntityName}{FDC.Specialised.DatabaseSchemaColumn.TableCatalog} AND");
            sql.AppendLine($"    {FDC.Specialised.DatabaseSchemaColumn.TableSchema} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.Specialised.DatabaseSchemaColumn.EntityName}{FDC.Specialised.DatabaseSchemaColumn.TableSchema} AND");
            sql.AppendLine($"    {FDC.Specialised.DatabaseSchemaColumn.TableName} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.Specialised.DatabaseSchemaColumn.EntityName}{FDC.Specialised.DatabaseSchemaColumn.TableName}");

            DatabaseParameters databaseParameters =
            [
                CreateParameter($"{FDC.Specialised.DatabaseSchemaColumn.EntityName}{FDC.Specialised.DatabaseSchemaColumn.TableCatalog}",
                    tableCatalog),
                CreateParameter($"{FDC.Specialised.DatabaseSchemaColumn.EntityName}{FDC.Specialised.DatabaseSchemaColumn.TableSchema}", tableSchema),
                CreateParameter($"{FDC.Specialised.DatabaseSchemaColumn.EntityName}{FDC.Specialised.DatabaseSchemaColumn.TableName}", tableName)
            ];

            using (IDataReader dataReader = ExecuteReader(sql.ToString(), CommandType.Text, databaseParameters))
            {
                while (dataReader.Read())
                {
                    IDatabaseSchemaColumn entity = PopulateEntity(dataReader);
                    retVal.Add(entity);
                }

                dataReader.Close();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Populates the entity.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <returns></returns>
        private IDatabaseSchemaColumn PopulateEntity(IDataRecord dataRecord)
        {
            LoggingHelpers.TraceCallEnter(dataRecord);

            IDatabaseSchemaColumn retVal = Core.IoC.Get<IDatabaseSchemaColumn>();

            retVal.TableName = Convert.ToString(dataRecord[FDC.Specialised.DatabaseSchemaColumn.TableName]) ?? String.Empty;
            retVal.ColumnName = Convert.ToString(dataRecord[FDC.Specialised.DatabaseSchemaColumn.ColumnName]) ?? String.Empty;

            String dbType = Convert.ToString(dataRecord[FDC.Specialised.DatabaseSchemaColumn.DataType]) ?? String.Empty;
            retVal.DataType = DataLogicProvider.MapDbTypeToDotNetType(dbType);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
