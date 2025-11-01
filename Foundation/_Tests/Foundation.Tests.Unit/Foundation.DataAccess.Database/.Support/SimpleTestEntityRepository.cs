//-----------------------------------------------------------------------
// <copyright file="SimpleTestEntityRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;

using Foundation.Repository;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Mocks;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.DataAccess.Database.Support
{
    public class SimpleTestEntityRepository : FoundationModelRepository<IMockFoundationModel>
    {
        public SimpleTestEntityRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            IUnitTestingDatabaseProvider databaseProvider,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                systemConfigurationService,
                databaseProvider,
                dateTimeService
            )
        {

        }

        /// <inheritdoc cref="EntityName"/>
        protected override String EntityName => "TestEntity";

        /// <inheritdoc cref="TableName"/>
        protected override String TableName => "[TestEntity]";

        public ApplicationRole GetRequiredMinimumCreateRole() { return base.RequiredMinimumCreateRole; }
        public ApplicationRole GetRequiredMinimumEditRole() { return base.RequiredMinimumEditRole; }
        public ApplicationRole GetRequiredMinimumDeleteRole() { return base.RequiredMinimumDeleteRole; }

        public IDataLogicProvider GetDataLogicProvider() { return DataLogicProvider;}

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
    }
}
