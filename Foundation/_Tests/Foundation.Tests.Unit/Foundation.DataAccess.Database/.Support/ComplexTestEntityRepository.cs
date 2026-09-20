//-----------------------------------------------------------------------
// <copyright file="ComplexTestEntityRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Text;

using Foundation.Interfaces;
using Foundation.Repository;

using Foundation.Tests.Unit.Mocks;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.DataAccess.Database.Support
{
    public interface IComplexTestEntityRepository : IFoundationModelDataAccess<IMockFoundationModel>
    {
        List<IDbDataParameter> SetupDataTable(Int32 requiredColumnCount);

        void SetupDatabase(Int32 requiredColumnCount, String bulkLoadProcedureName);
    }

    [DependencyInjectionTransient]
    public class ComplexTestEntityRepository : FoundationModelRepository<IMockFoundationModel>, IComplexTestEntityRepository
    {
        public ComplexTestEntityRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            IUnitTestingDataProvider dataProvider,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                systemConfigurationService,
                dataProvider,
                dateTimeService
            )
        {

        }

        /// <inheritdoc cref="EntityName"/>
        protected override String EntityName => "TestEntity";

        /// <inheritdoc cref="TableName"/>
        protected override String TableName => "[TestEntity]";

        /// <inheritdoc cref="EntityKey"/>
        protected override String EntityKey => "Code";

        protected override string GetAllOrderByClause()
        {
            return "Name ASC";
        }

        public ApplicationRole GetRequiredMinimumCreateRole() { return base.RequiredMinimumCreateRole; }
        public ApplicationRole GetRequiredMinimumEditRole() { return base.RequiredMinimumEditRole; }
        public ApplicationRole GetRequiredMinimumDeleteRole() { return base.RequiredMinimumDeleteRole; }

        public IDataLogicProvider GetDataLogicProvider() { return DataLogicProvider; }

        public String GetDataProviderName() { return FoundationDataAccess.DataLogicProvider.DatabaseProviderName; }

        public void GetConnectionTwice()
        {
            IDbConnection conn1 = FoundationDataAccess.GetConnection();
            IDbConnection conn2 = FoundationDataAccess.GetConnection();

            FoundationDataAccess.BeginTransaction();
            FoundationDataAccess.BeginTransaction();
        }

        public String GetEntityKey()
        {
            return EntityKey;
        }

        public void RefreshCache()
        {
            base.RefreshCacheData();
        }

        public List<IDbDataParameter> SetupDataTable(Int32 requiredColumnCount)
        {
            List<IDbDataParameter> retVal = [];

            for (Int32 i = 0; i < requiredColumnCount; i++)
            {
                IDbDataParameter metaDataParameter = FoundationDataAccess.CreateParameter($"Value{i:D3}", String.Empty, String.Empty);
                metaDataParameter.Size = 50;
                retVal.Add(metaDataParameter);
            }

            return retVal;
        }

        public void SetupDatabase(Int32 requiredColumnCount, String bulkLoadProcedureName)
        {
            ResetTestTable();

            DropStoredProcedure(bulkLoadProcedureName);
            DropUserDefinedType();

            CreateUserDefinedType(requiredColumnCount);
            CreateStoredProcedure(requiredColumnCount, bulkLoadProcedureName);
        }

        public void ResetTestTable()
        {
            FoundationDataAccess.ExecuteNonQuery("TRUNCATE TABLE LoadTest;");
            FoundationDataAccess.ExecuteNonQuery("DBCC CHECKIDENT('[LoadTest]', RESEED, 1);");
        }

        public void DropUserDefinedType()
        {
            String sql = String.Empty;
            sql += "IF TYPE_ID('dbo.LoadTestValues') IS NOT NULL DROP TYPE dbo.LoadTestValues; ";

            FoundationDataAccess.ExecuteNonQuery(sql);
        }

        public void CreateUserDefinedType(Int32 requiredColumnCount)
        {
            StringBuilder procedureCreate = new StringBuilder();
            procedureCreate.AppendLine("CREATE TYPE [dbo].[LoadTestValues] AS TABLE(");

            Boolean moreColumnLines = false;
            for (Int32 i = 1; i <= requiredColumnCount; i++)
            {
                if (moreColumnLines) procedureCreate.AppendLine(",");
                procedureCreate.Append($"        [Value{i:D3}] [nvarchar](50) NULL");

                moreColumnLines = true;
            }
            procedureCreate.AppendLine();

            procedureCreate.AppendLine(")");

            FoundationDataAccess.ExecuteNonQuery(procedureCreate.ToString());
        }

        public void DropStoredProcedure(String bulkLoadProcedureName)
        {
            String sql = String.Empty;
            sql += $"IF OBJECT_ID('{bulkLoadProcedureName}', 'P') IS NOT NULL DROP PROCEDURE dbo.{bulkLoadProcedureName}; ";

            FoundationDataAccess.ExecuteNonQuery(sql);
        }

        public void CreateStoredProcedure(Int32 requiredColumnCount, String bulkLoadProcedureName)
        {
            StringBuilder procedureCreate = new StringBuilder();
            procedureCreate.AppendLine($"CREATE PROCEDURE [dbo].[{bulkLoadProcedureName}]");
            procedureCreate.AppendLine("@loadValues LoadTestValues READONLY");
            procedureCreate.AppendLine("    AS");
            procedureCreate.AppendLine("BEGIN");
            procedureCreate.AppendLine("    SET NOCOUNT ON; ");
            procedureCreate.AppendLine();
            procedureCreate.AppendLine("    INSERT INTO LoadTest");
            procedureCreate.AppendLine("    (");

            Boolean moreColumnLines = false;
            for (Int32 i = 1; i <= requiredColumnCount; i++)
            {
                if (moreColumnLines) procedureCreate.AppendLine(",");
                procedureCreate.Append($"        Value{i:D3} ");

                moreColumnLines = true;
            }
            procedureCreate.AppendLine();

            procedureCreate.AppendLine("    )");
            procedureCreate.AppendLine();
            procedureCreate.AppendLine("    SELECT");

            Boolean moreValueLines = false;
            for (Int32 i = 1; i <= requiredColumnCount; i++)
            {
                if (moreValueLines) procedureCreate.AppendLine(",");
                procedureCreate.Append($"        Value{i:D3} ");

                moreValueLines = true;
            }
            procedureCreate.AppendLine();

            procedureCreate.AppendLine();
            procedureCreate.AppendLine("    FROM @loadValues");
            procedureCreate.AppendLine();
            procedureCreate.AppendLine("END");

            FoundationDataAccess.ExecuteNonQuery(procedureCreate.ToString());
        }
    }
}
