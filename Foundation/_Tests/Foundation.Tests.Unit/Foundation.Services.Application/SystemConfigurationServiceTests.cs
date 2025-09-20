//-----------------------------------------------------------------------
// <copyright file="SystemConfigurationServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;
using Foundation.Services.Application;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    /// <summary>
    /// The System Configuration Tests
    /// </summary>
    [TestFixture]
    public class SystemConfigurationServiceTests : UnitTestBase
    {
        private ISystemConfigurationService? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheService = new SystemConfigurationService(CoreInstance);
        }

        public override void TestCleanup()
        {
            TheService = null;

            base.TestCleanup();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_GetDataProviderName()
        {
            String dataConnectionName = "UnitTesting";
            String expected = "System.Data.SqlClient";

            String actual = TheService!.GetDataProviderName(dataConnectionName);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_GetDataProviderName_Exception_NoConnectionString()
        {
            String dataConnectionName = "MadeUpNonExisting";
            String parameterName = nameof(dataConnectionName);
            String errorMessage = $"Cannot load Connection named '{dataConnectionName}'. Check to make sure the connection is defined in the Configuration File. (Parameter '{parameterName}')";

            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = TheService!.GetDataProviderName(dataConnectionName);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_GetDataProviderName_Exception_NoDataProvider()
        {
            String dataConnectionName = "UnitTestingNoProviderName";
            String errorMessage = $"Unable to retrieve Data Provider for '{dataConnectionName}'. Check to make sure the connection is defined in the Configuration File.";

            InvalidOperationException actualException = Assert.Throws<InvalidOperationException>(() =>
            {
                _ = TheService!.GetDataProviderName(dataConnectionName);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }


        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_GetConnectionString()
        {
            String dataConnectionName = "UnitTesting";
            String expected = "Server=Callisto;Database=UnitTesting;User Id=Jay;Password=pass;TrustServerCertificate=True;";

            String actual = TheService!.GetConnectionString(dataConnectionName);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_GetConnectionString_Exception()
        {
            String dataConnectionName = "MadeUpNonExisting";
            String parameterName = nameof(dataConnectionName);
            String errorMessage = $"Cannot load Connection named '{dataConnectionName}'. Check to make sure the connection is defined in the Configuration File. (Parameter '{parameterName}')";

            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = TheService!.GetDataProviderName(dataConnectionName);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
        }
    }
}
