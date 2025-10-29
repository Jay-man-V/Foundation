//-----------------------------------------------------------------------
// <copyright file="SystemConfigurationServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;
using NSubstitute.ClearExtensions;

using Foundation.Interfaces;
using Foundation.Services.Application;
using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    /// <summary>
    /// The System Configuration Tests
    /// </summary>
    [TestFixture]
    public class SystemConfigurationServiceTests : UnitTestBase
    {
        private String ValidDataConnectionName => "UnitTesting";
        private String InvalidDataConnectionName => "MadeUpNonExisting";

        private IConfigurationWrapper? ConfigurationWrapper { get; set; }
        private ISystemConfigurationService? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            ICore core = Substitute.For<ICore>();
            ConfigurationWrapper = Substitute.For<IConfigurationWrapper>();

            core.ConfigurationManager.Returns(ConfigurationWrapper);

            ConfigurationWrapper.GetConnectionString(ValidDataConnectionName).Returns("providerName=System.Data.SqlClient;Server=DbServer;Database=DbName;User Id=UserId;Password=ThePassword;TrustServerCertificate=True;");

            String? nullString = null;
            ConfigurationWrapper.GetConnectionString(InvalidDataConnectionName).Returns(nullString);

            TheService = new SystemConfigurationService(core);
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
            String expected = "System.Data.SqlClient";

            String actual = TheService!.GetDataProviderName(ValidDataConnectionName);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_GetConnectionString()
        {
            String expected = "Server=DbServer;Database=DbName;User Id=UserId;Password=ThePassword;TrustServerCertificate=True;";

            String actual = TheService!.GetConnectionString(ValidDataConnectionName);

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
            String parameterName = "dataConnectionName";
            String errorMessage = $"Cannot load Connection named '{InvalidDataConnectionName}'. Check to make sure the connection is defined in the Configuration File. (Parameter '{parameterName}')";

            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = TheService!.GetDataProviderName(InvalidDataConnectionName);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_GetDataProviderName_Exception_BadlyFormatter()
        {
            String parameterName = "dataConnectionName";
            String errorMessage = $"Unable to retrieve Data Provider for '{InvalidDataConnectionName}'. Check to make sure the connection is defined in the Configuration File.";

            ConfigurationWrapper!.ClearSubstitute();
            ConfigurationWrapper!.GetConnectionString(ValidDataConnectionName).Returns("InvalidText=System.Data.SqlClient;Server=DbServer;Database=DbName;User Id=UserId;Password=ThePassword;TrustServerCertificate=True;");

            InvalidOperationException actualException = Assert.Throws<InvalidOperationException>(() =>
            {
                _ = TheService!.GetDataProviderName(InvalidDataConnectionName);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_GetConnectionString_Exception()
        {
            String parameterName = "dataConnectionName";
            String errorMessage = $"Cannot load Connection named '{InvalidDataConnectionName}'. Check to make sure the connection is defined in the Configuration File. (Parameter '{parameterName}')";

            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                _ = TheService!.GetConnectionString(InvalidDataConnectionName);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
        }
    }
}
