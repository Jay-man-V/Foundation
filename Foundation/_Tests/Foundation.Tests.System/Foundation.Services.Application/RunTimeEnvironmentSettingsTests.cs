//-----------------------------------------------------------------------
// <copyright file="RunTimeEnvironmentSettingsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.System.BaseClasses;

namespace Foundation.Tests.System.Foundation.Services.Application
{
    /// <summary>
    /// UnitTests for RunTimeEnvironmentSettings
    /// </summary>
    [TestFixture]
    public class RunTimeEnvironmentSettingsTests : SystemTestBase
    {
        private IRunTimeEnvironmentSettings? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheService = CoreInstance.IoC.Get<IRunTimeEnvironmentSettings>();
        }

        public override void TestCleanup()
        {
            TheService = null;

            base.TestCleanup();
        }

        [TestCase]
        public void Test_Properties()
        {
            Assert.That(TheService, Is.Not.EqualTo(null));

            String[] arguments = TheService.Arguments;
            Assert.That(arguments, Is.Not.EqualTo(null));

            String standardCountryCode = TheService.StandardCountryCode;
            Assert.That(standardCountryCode, Is.Not.EqualTo(null));
            Assert.That(standardCountryCode, Is.EqualTo("GB"));

            String userName = TheService.UserName;
            Assert.That(userName, Is.Not.EqualTo(null));
            Assert.That(userName, Is.EqualTo(Environment.UserName));

            String userDomainName = TheService.UserDomainName;
            Assert.That(userDomainName, Is.Not.EqualTo(null));
            Assert.That(userDomainName, Is.EqualTo(Environment.UserDomainName));

            String userLogonName = TheService.UserFullLogonName;
            Assert.That(userLogonName, Is.Not.EqualTo(null));
            Assert.That(userLogonName, Is.EqualTo($@"{Environment.UserDomainName}\{Environment.UserName}"));

            String machineName = TheService.MachineName;
            Assert.That(machineName, Is.Not.EqualTo(null));
            Assert.That(machineName, Is.EqualTo(Environment.MachineName));
        }
    }
}
