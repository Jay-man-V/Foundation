//-----------------------------------------------------------------------
// <copyright file="ApplicationConfigurationKeysTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Resources;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Resources.ConstantsTests
{
    /// <summary>
    /// Unit Tests for the Application Configuration Keys Tests class
    /// </summary>
    [TestFixture]
    public class ApplicationConfigurationKeysTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="ApplicationConfigurationKeys"/>
        /// </summary>
        [TestCase]
        public void Test_CountMembers()
        {
            IEnumerable<MethodInfo> testMethods = GetListOfTestMethods();
            Int32 testMethodCount = testMethods.Count() - 1;

            // This test exists to ensure all the Properties are tested/checked in the next test
            Type theType = typeof(ApplicationConfigurationKeys);
            PropertyInfo[] propertyInfos = theType.GetProperties();

            Assert.That(propertyInfos.Length, Is.EqualTo(testMethodCount));

            Int32 index = 0;
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ApplicationConfigurationKeys.UserDataPath)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ApplicationConfigurationKeys.SystemDataPath)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ApplicationConfigurationKeys.EmailFromAddress)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ApplicationConfigurationKeys.EmailFromDisplayName)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ApplicationConfigurationKeys.EmailSmtpHostAddress)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ApplicationConfigurationKeys.EmailSmtpHostPort)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ApplicationConfigurationKeys.EmailSmtpHostEnableSsl)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ApplicationConfigurationKeys.EmailSmtpHostUsername)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ApplicationConfigurationKeys.EmailSmtpHostPassword)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ApplicationConfigurationKeys.ServiceHolidaysNationalUkUrl)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ApplicationConfigurationKeys.ServiceGeneratorPasswordRandomUrl)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ApplicationConfigurationKeys.ServiceGeneratorPasswordMemorableUrl)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ApplicationConfigurationKeys.ServiceGeneratorPasswordRuleLength)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(ApplicationConfigurationKeys.ServiceGeneratorPasswordRuleCount)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Keys()
        {
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(ApplicationConfigurationKeys));
            Int32 index = 0;

            index++; Assert.That(ApplicationConfigurationKeys.UserDataPath, Is.EqualTo("UserDataPath"));
            index++; Assert.That(ApplicationConfigurationKeys.SystemDataPath, Is.EqualTo("SystemDataPath"));
            index++; Assert.That(ApplicationConfigurationKeys.EmailFromAddress, Is.EqualTo("email.from.address"));
            index++; Assert.That(ApplicationConfigurationKeys.EmailFromDisplayName, Is.EqualTo("email.from.display.name"));
            index++; Assert.That(ApplicationConfigurationKeys.EmailSmtpHostAddress, Is.EqualTo("email.smtp.host.address"));
            index++; Assert.That(ApplicationConfigurationKeys.EmailSmtpHostPort, Is.EqualTo("email.smtp.host.port"));
            index++; Assert.That(ApplicationConfigurationKeys.EmailSmtpHostEnableSsl, Is.EqualTo("email.smtp.host.enable.ssl"));
            index++; Assert.That(ApplicationConfigurationKeys.EmailSmtpHostUsername, Is.EqualTo("email.smtp.host.username"));
            index++; Assert.That(ApplicationConfigurationKeys.EmailSmtpHostPassword, Is.EqualTo("email.smtp.host.password"));
            index++; Assert.That(ApplicationConfigurationKeys.ServiceHolidaysNationalUkUrl, Is.EqualTo("service.holidays.national.uk.url"));
            index++; Assert.That(ApplicationConfigurationKeys.ServiceGeneratorPasswordRandomUrl, Is.EqualTo("service.generator.password.random.url"));
            index++; Assert.That(ApplicationConfigurationKeys.ServiceGeneratorPasswordMemorableUrl, Is.EqualTo("service.generator.password.memorable.url"));
            index++; Assert.That(ApplicationConfigurationKeys.ServiceGeneratorPasswordRuleLength, Is.EqualTo("service.generator.password.rule.length"));
            index++; Assert.That(ApplicationConfigurationKeys.ServiceGeneratorPasswordRuleCount, Is.EqualTo("service.generator.password.rule.count"));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }
    }
}
