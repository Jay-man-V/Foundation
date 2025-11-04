//-----------------------------------------------------------------------
// <copyright file="ObjectCreationTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Repository;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Foundation.DataAccess.Database.Support;
using Foundation.Tests.Unit.Mocks;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.DataAccess.Database
{
    /// <summary>
    /// Object Creation Tests
    /// </summary>
    /// <see cref="UnitTestBase" />
    [TestFixture]
    public class ObjectCreationTests : UnitTestBase
    {
        private SimpleTestEntityRepository CreateProcess()
        {
            ICore core = Substitute.For<ICore>();

            IUnitTestingDataProvider dataProvider = Substitute.For<IUnitTestingDataProvider>();
            dataProvider.ConnectionName.Returns("UnitTesting");

            ISystemConfigurationService systemConfigurationService = Substitute.For<ISystemConfigurationService>();
            systemConfigurationService.GetConnectionString(Arg.Any<String>()).Returns("Unit Testing Connection String");
            systemConfigurationService.GetDataProviderName(Arg.Any<String>()).Returns("System.Data.SqlClient");

            IFoundationDataAccess dataAccess = Substitute.For<IFoundationDataAccess>();

            SimpleTestEntityRepository retVal = new SimpleTestEntityRepository(core, RunTimeEnvironmentSettings, systemConfigurationService, dataAccess, dataProvider, DateTimeService);

            return retVal;
        }

        /// <summary>
        /// Tests the object creation1.
        /// </summary>
        [TestCase]
        public void Test_ObjectCreation1()
        {
            ICore core = Substitute.For<ICore>();

            IUnitTestingDataProvider dataProvider = Substitute.For<IUnitTestingDataProvider>();
            dataProvider.ConnectionName.Returns("UnitTesting");

            ISystemConfigurationService systemConfigurationService = Substitute.For<ISystemConfigurationService>();
            systemConfigurationService.GetConnectionString(Arg.Any<String>()).Returns("Unit Testing Connection String");
            systemConfigurationService.GetDataProviderName(Arg.Any<String>()).Returns("System.Data.SqlClient");

            IFoundationDataAccess dataAccess = Substitute.For<IFoundationDataAccess>();

            ComplexTestEntityRepository obj = new ComplexTestEntityRepository(core, RunTimeEnvironmentSettings, systemConfigurationService, dataAccess, dataProvider, DateTimeService);

            Assert.That(obj, Is.Not.EqualTo(null));
            Assert.That(obj, Is.InstanceOf<FoundationModelRepository<IMockFoundationModel>>());
            Assert.That(obj, Is.InstanceOf<IFoundationModelRepository<IMockFoundationModel>>());
            Assert.That(obj, Is.InstanceOf<IDisposable>());
        }

        [TestCase]
        public void Test_RefreshCacheData()
        {
            SimpleTestEntityRepository obj = CreateProcess();

            obj.RefreshCache();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_EntityKey_Exception()
        {
            String errorMessage = "The method or operation is not implemented.";
            NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
            {
                SimpleTestEntityRepository obj = CreateProcess();
                _ = obj.GetEntityKey();
            });

            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }
    }
}
