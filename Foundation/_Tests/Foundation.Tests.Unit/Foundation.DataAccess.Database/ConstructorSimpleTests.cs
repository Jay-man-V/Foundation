//-----------------------------------------------------------------------
// <copyright file="ConstructorSimpleTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.DataAccess.Database.DataLogicProviders;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Foundation.DataAccess.Database.Support;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.DataAccess.Database
{
    /// <summary>
    /// Get Tests
    /// </summary>
    /// <see cref="UnitTestBase" />
    [TestFixture]
    public class ConstructorSimpleTests : UnitTestBase
    {
        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_Constructor_Exception()
        {
            ICore core = Substitute.For<ICore>();

            String connectionStringKey = "Made up connection string key";
            String parameterName = nameof(connectionStringKey);
            String errorMessage = $"Cannot load Connection named '{connectionStringKey}'. Check to make sure the connection is defined in the Configuration File. (Parameter '{parameterName}')";

            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                ISystemConfigurationService systemConfigurationService = Substitute.For<ISystemConfigurationService>();

                IUnitTestingDataProvider dataProvider = new UnitTestingDataProvider(core, systemConfigurationService, connectionStringKey);

                _ = new SimpleTestEntityRepository(core, RunTimeEnvironmentSettings, systemConfigurationService, dataProvider, DateTimeService);
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
            ICore core = Substitute.For<ICore>();

            String connectionStringKey = "MsSQLDataLogicProviderTest";
            String dataProviderName = "System.Data.SqlClient";

            ISystemConfigurationService systemConfigurationService = Substitute.For<ISystemConfigurationService>();
            systemConfigurationService.GetConnectionString(Arg.Any<String>()).Returns("Microsoft Sql Server Connection String");
            systemConfigurationService.GetDataProviderName(Arg.Any<String>()).Returns("System.Data.SqlClient");

            IUnitTestingDataProvider dataProvider = new UnitTestingDataProvider(core, systemConfigurationService, connectionStringKey);

            SimpleTestEntityRepository obj = new SimpleTestEntityRepository(core, RunTimeEnvironmentSettings, systemConfigurationService, dataProvider, DateTimeService);
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
            ICore core = Substitute.For<ICore>();

            String connectionStringKey = "MySQLDataLogicProviderTest";
            String dataProviderName = "MySql.Data.MySqlClient";

            ISystemConfigurationService systemConfigurationService = Substitute.For<ISystemConfigurationService>();
            systemConfigurationService.GetConnectionString(Arg.Any<String>()).Returns("MySql Connection String");
            systemConfigurationService.GetDataProviderName(Arg.Any<String>()).Returns("MySql.Data.MySqlClient");

            IUnitTestingDataProvider dataProvider = new UnitTestingDataProvider(core, systemConfigurationService, connectionStringKey);

            SimpleTestEntityRepository obj = new SimpleTestEntityRepository(core, RunTimeEnvironmentSettings, systemConfigurationService, dataProvider, DateTimeService);
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
            ICore core = Substitute.For<ICore>();

            String connectionStringKey = "OracleDataLogicProviderTest";
            String dataProviderName = "System.Data.OracleClient";

            ISystemConfigurationService systemConfigurationService = Substitute.For<ISystemConfigurationService>();
            systemConfigurationService.GetConnectionString(Arg.Any<String>()).Returns("Oracle Connection String");
            systemConfigurationService.GetDataProviderName(Arg.Any<String>()).Returns("System.Data.OracleClient");

            IUnitTestingDataProvider dataProvider = new UnitTestingDataProvider(core, systemConfigurationService, connectionStringKey);

            SimpleTestEntityRepository obj = new SimpleTestEntityRepository(core, RunTimeEnvironmentSettings, systemConfigurationService, dataProvider, DateTimeService);
            String actualDataProviderName = obj.GetDataProviderName();
            IDataLogicProvider actualDataLogicProvider = obj.GetDataLogicProvider();

            Assert.That(actualDataProviderName, Is.EqualTo(dataProviderName));
            Assert.That(actualDataLogicProvider, Is.InstanceOf<OracleDataLogicProvider>());
            Assert.That(actualDataProviderName, Is.EqualTo(dataProviderName));
        }
    }
}
