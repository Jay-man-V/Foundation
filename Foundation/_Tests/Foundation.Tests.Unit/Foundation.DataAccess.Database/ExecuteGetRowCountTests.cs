//-----------------------------------------------------------------------
// <copyright file="ExecuteGetRowCountTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Mocks;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.DataAccess.Database
{
    /// <summary>
    /// Execute Get Row Count Tests
    /// </summary>
    /// <see cref="UnitTestBase" />
    [TestFixture]
    public class ExecuteGetRowCountTests : UnitTestBase
    {
        private IMockFoundationModelRepository? TheRepository { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            ICore core = Substitute.For<ICore>();

            IUnitTestingDataProvider dataProvider = new UnitTestingDataProvider();

            ISystemConfigurationService systemConfigurationService = Substitute.For<ISystemConfigurationService>();
            systemConfigurationService.GetConnectionString(Arg.Any<String>()).Returns("Server=Callisto;Database=Master;User Id=Jay;Password=pass;TrustServerCertificate=True;");
            systemConfigurationService.GetDataProviderName(Arg.Any<String>()).Returns("System.Data.SqlClient");

            IFoundationDataAccess dataAccess = Substitute.For<IFoundationDataAccess>();

            TheRepository = new MockFoundationModelRepository(core, RunTimeEnvironmentSettings, systemConfigurationService, dataAccess, dataProvider, DateTimeService);
        }

        public override void TestCleanup()
        {
            TheRepository!.Dispose();
            TheRepository = null;

            base.TestCleanup();
        }

        [TestCase]
        public void Test_ExecuteGetCount()
        {
            String sql = "select count(*) from [TestEntity]";
            Int32 actual = TheRepository!.FoundationDataAccess.ExecuteGetRowCount(sql);

            Assert.That(actual, Is.EqualTo(0));
        }
    }
}
