//-----------------------------------------------------------------------
// <copyright file="SystemConfigurationServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;
using Foundation.Tests.System.BaseClasses;

namespace Foundation.Tests.System.Foundation.Services.Application
{
    /// <summary>
    /// The System Configuration Tests
    /// </summary>
    [TestFixture]
    public class SystemConfigurationServiceTests : SystemTestBase
    {
        private String ValidDataConnectionName => "SystemTesting";
        private String InvalidDataConnectionName => "MadeUpNonExisting";
        private String BadlyFormattedDataConnectionName => "BadlyFormatted";

        private ISystemConfigurationService? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheService = CoreInstance.IoC.Get<ISystemConfigurationService>();
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
            String expected = "Microsoft.Data.SqlClient";

            String actual = TheService!.GetDataProviderName(ValidDataConnectionName);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_GetConnectionString()
        {
            String expected = "Server=Callisto;Database=SystemTesting;User Id=Jay;Password=pass;TrustServerCertificate=True;";

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
        public void Test_GetDataProviderName_Exception_BadlyFormatted()
        {
            String errorMessage = $"Unable to retrieve Data Provider for '{BadlyFormattedDataConnectionName}'. Check to make sure the connection is defined in the Configuration File.";

            InvalidOperationException actualException = Assert.Throws<InvalidOperationException>(() =>
            {
                _ = TheService!.GetDataProviderName(BadlyFormattedDataConnectionName);
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
