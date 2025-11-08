//-----------------------------------------------------------------------
// <copyright file="DbSchemaTableRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Text;

using Foundation.Common;
using Foundation.DataAccess.Database;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Specialised
{
    /// <summary>
    /// Defines the Db Schema Table Data Access class
    /// </summary>
    /// <see cref="IDatabaseSchemaTable" />
    [DependencyInjectionTransient]
    public class DbSchemaTableRepository : FoundationDataAccess, IDatabaseSchemaTableDataAccess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DbSchemaTableRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="schemaDataProvider">The schema data provider.</param>
        public DbSchemaTableRepository
        (
            ICore core,
            ISystemConfigurationService systemConfigurationService,
            ISchemaDataProvider schemaDataProvider
        ) :
            base
            (
                core,
                systemConfigurationService,
                schemaDataProvider.ConnectionName
            )
        {
            LoggingHelpers.TraceCallEnter(core, systemConfigurationService, schemaDataProvider);

            DbSchemaColumnRepository = new DatabaseSchemaColumnRepository(core, systemConfigurationService, schemaDataProvider);

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        protected String EntityName => FDC.Specialised.DatabaseSchemaTable.EntityName;

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        protected String TableName => FDC.TableNames.Specialised.DbSchemaTable;

        /// <summary>
        /// Gets the database schema column repository.
        /// </summary>
        /// <value>
        /// The database schema column repository.
        /// </value>
        private IDatabaseSchemaColumnDataAccess DbSchemaColumnRepository { get; }

        /// <inheritdoc cref="IDatabaseSchemaTableDataAccess.GetAllTables()"/>
        public List<IDatabaseSchemaTable> GetAllTables()
        {
            LoggingHelpers.TraceCallEnter();

            List<IDatabaseSchemaTable> retVal = [];

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("    *");
            sql.AppendLine("FROM");
            sql.AppendLine(TableName);
            sql.AppendLine("ORDER BY");
            sql.AppendLine($"    {FDC.Specialised.DatabaseSchemaTable.TableName}");

            using (IDataReader dataReader = ExecuteReader(sql.ToString()))
            {
                while (dataReader.Read())
                {
                    IDatabaseSchemaTable entity = PopulateEntity(dataReader);
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
        private IDatabaseSchemaTable PopulateEntity(IDataRecord dataRecord)
        {
            LoggingHelpers.TraceCallEnter(dataRecord);

            IDatabaseSchemaTable retVal = Core.IoC.Get<IDatabaseSchemaTable>();

            retVal.TableCatalog = Convert.ToString(dataRecord[FDC.Specialised.DatabaseSchemaTable.TableCatalog]) ?? String.Empty;
            retVal.TableSchema = Convert.ToString(dataRecord[FDC.Specialised.DatabaseSchemaTable.TableSchema]) ?? String.Empty;
            retVal.TableName = Convert.ToString(dataRecord[FDC.Specialised.DatabaseSchemaTable.TableName]) ?? String.Empty;
            retVal.TableType = Convert.ToString(dataRecord[FDC.Specialised.DatabaseSchemaTable.TableType]) ?? String.Empty;

            IEnumerable<IDatabaseSchemaColumn> dbSchemaColumns = DbSchemaColumnRepository.GetAllColumns(retVal);
            retVal.SchemaColumns.ToList().AddRange(dbSchemaColumns);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
