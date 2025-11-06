//-----------------------------------------------------------------------
// <copyright file="ObjectCreation2Tests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Foundation.DataAccess.Database.Support;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.DataAccess.Database
{
    /// <summary>
    /// Object Creation Tests
    /// </summary>
    /// <see cref="UnitTestBase" />
    [TestFixture]
    public class ObjectCreation2Tests : UnitTestBase
    {
        /// <summary>
        /// Tests the object creation1.
        /// </summary>
        [TestCase]
        public void Test_InvalidProvideName()
        {
            String connectionStringConfiguration = "UnitTestingUnknownProvider";
            String errorMessage = $"The Data Provider '{connectionStringConfiguration}' is unknown and not supported";

            ICore core = Substitute.For<ICore>();

            NotSupportedException actualException = Assert.Throws<NotSupportedException>(() =>
            {
                IUnitTestingDataProvider dataProvider = Substitute.For<IUnitTestingDataProvider>();
                dataProvider.ConnectionName.Returns(connectionStringConfiguration);

                ISystemConfigurationService systemConfigurationService = Substitute.For<ISystemConfigurationService>();
                systemConfigurationService.GetConnectionString(Arg.Any<String>()).Returns("InvalidConnectionString");
                systemConfigurationService.GetDataProviderName(Arg.Any<String>()).Returns("UnitTestingUnknownProvider");

                _ = new ComplexTestEntityRepository(core, RunTimeEnvironmentSettings, systemConfigurationService, dataProvider, DateTimeService);
            });

            Assert.That(actualException, Is.InstanceOf<NotSupportedException>());
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }
    }
}
