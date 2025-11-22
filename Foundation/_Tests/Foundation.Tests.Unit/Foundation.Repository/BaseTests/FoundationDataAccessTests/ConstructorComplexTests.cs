//-----------------------------------------------------------------------
// <copyright file="ConstructorComplexTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.DataAccess.Database.DataLogicProviders;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Foundation.Repository.Support;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Repository.BaseTests.FoundationDataAccessTests
{
    /// <summary>
    /// Get Tests
    /// </summary>
    /// <see cref="UnitTestBase" />
    [TestFixture]
    public class ConstructorComplexTests : UnitTestBase
    {
        private ICore? CoreInstance { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            CoreInstance = Substitute.For<ICore>();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_Constructor_Exception()
        {
            String connectionStringKey = "Made up connection string key";
            String parameterName = nameof(connectionStringKey);
            String errorMessage = $"Cannot load Connection named '{connectionStringKey}'. Check to make sure the connection is defined in the Configuration File. (Parameter '{parameterName}')";

            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                IUnitTestingDataProvider dataProvider = Substitute.For<IUnitTestingDataProvider>();
                dataProvider.ConnectionName.Returns(connectionStringKey);

                ISystemConfigurationService systemConfigurationService = Substitute.For<ISystemConfigurationService>();

                _ = new ComplexTestEntityRepository(CoreInstance!, RunTimeEnvironmentSettings, systemConfigurationService, dataProvider, DateTimeService);
            });

            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_Constructor_MsSqlDataLogicProvider()
        {
            String connectionStringKey = "MsSQLDataLogicProviderTest";
            String dataProviderName = "Microsoft.Data.SqlClient";

            IUnitTestingDataProvider dataProvider = Substitute.For<IUnitTestingDataProvider>();
            dataProvider.ConnectionName.Returns(connectionStringKey);

            ISystemConfigurationService systemConfigurationService = Substitute.For<ISystemConfigurationService>();
            systemConfigurationService.GetConnectionString(Arg.Any<String>()).Returns("Microsoft Sql Server Connection String");
            systemConfigurationService.GetDataProviderName(Arg.Any<String>()).Returns("Microsoft.Data.SqlClient");

            ComplexTestEntityRepository obj = new ComplexTestEntityRepository(CoreInstance!, RunTimeEnvironmentSettings, systemConfigurationService, dataProvider, DateTimeService);
            String actualDataProviderName = obj.GetDataProviderName();
            IDataLogicProvider actualDataLogicProvider = obj.GetDataLogicProvider();

            Assert.That(actualDataProviderName, Is.EqualTo(dataProviderName));
            Assert.That(actualDataLogicProvider, Is.InstanceOf<MsSqlDataLogicProvider>());
            Assert.That(actualDataProviderName, Is.EqualTo(dataProviderName));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_Constructor_MySqlDataLogicProvider()
        {
            String connectionStringKey = "MySQLDataLogicProviderTest";
            String dataProviderName = "MySql.Data.MySqlClient";

            IUnitTestingDataProvider dataProvider = Substitute.For<IUnitTestingDataProvider>();
            dataProvider.ConnectionName.Returns(connectionStringKey);

            ISystemConfigurationService systemConfigurationService = Substitute.For<ISystemConfigurationService>();
            systemConfigurationService.GetConnectionString(Arg.Any<String>()).Returns("MySql Connection String");
            systemConfigurationService.GetDataProviderName(Arg.Any<String>()).Returns("MySql.Data.MySqlClient");

            ComplexTestEntityRepository obj = new ComplexTestEntityRepository(CoreInstance!, RunTimeEnvironmentSettings, systemConfigurationService, dataProvider, DateTimeService);
            String actualDataProviderName = obj.GetDataProviderName();
            IDataLogicProvider actualDataLogicProvider = obj.GetDataLogicProvider();

            Assert.That(actualDataProviderName, Is.EqualTo(dataProviderName));
            Assert.That(actualDataLogicProvider, Is.InstanceOf<MySqlDataLogicProvider>());
            Assert.That(actualDataProviderName, Is.EqualTo(dataProviderName));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_Constructor_OracleSqlDataLogicProvider()
        {
            String connectionStringKey = "OracleDataLogicProviderTest";
            String dataProviderName = "Oracle.DataAccess.Client";

            IUnitTestingDataProvider dataProvider = Substitute.For<IUnitTestingDataProvider>();
            dataProvider.ConnectionName.Returns(connectionStringKey);

            ISystemConfigurationService systemConfigurationService = Substitute.For<ISystemConfigurationService>();
            systemConfigurationService.GetConnectionString(Arg.Any<String>()).Returns("Oracle Connection String");
            systemConfigurationService.GetDataProviderName(Arg.Any<String>()).Returns("Oracle.DataAccess.Client");

            ComplexTestEntityRepository obj = new ComplexTestEntityRepository(CoreInstance!, RunTimeEnvironmentSettings, systemConfigurationService, dataProvider, DateTimeService);
            String actualDataProviderName = obj.GetDataProviderName();
            IDataLogicProvider actualDataLogicProvider = obj.GetDataLogicProvider();

            Assert.That(actualDataProviderName, Is.EqualTo(dataProviderName));
            Assert.That(actualDataLogicProvider, Is.InstanceOf<OracleDataLogicProvider>());
            Assert.That(actualDataProviderName, Is.EqualTo(dataProviderName));
        }
    }
}
