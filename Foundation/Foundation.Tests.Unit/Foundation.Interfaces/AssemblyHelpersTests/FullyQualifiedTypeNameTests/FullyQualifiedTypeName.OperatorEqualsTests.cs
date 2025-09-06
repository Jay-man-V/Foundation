//-----------------------------------------------------------------------
// <copyright file="FullyQualifiedTypeNameOperatorEqualsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Interfaces.AssemblyHelpersTests.FullyQualifiedTypeNameTests
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class FullyQualifiedTypeNameOperatorEqualsTests : UnitTestBase
    {
        private const String AssemblyName = "Foundation.BusinessProcess";
        private const String TypeName = "Foundation.BusinessProcess.ScheduledJobProcess";
        private readonly String _fullyQualifiedTypeNameString = $@"<TaskImplementation assembly=""{AssemblyName}"" type=""{TypeName}"" />";

        /// <summary>
        /// Tests the implicit cast from string.
        /// </summary>
        [TestCase]
        public void Test_ImplicitCastFromString()
        {
            FullyQualifiedTypeName fullyQualifiedTypeName = _fullyQualifiedTypeNameString;

            Assert.That(fullyQualifiedTypeName.ToString(), Is.EqualTo(_fullyQualifiedTypeNameString));
            Assert.That(fullyQualifiedTypeName.AssemblyName, Is.EqualTo(AssemblyName));
            Assert.That(fullyQualifiedTypeName.TypeName, Is.EqualTo(TypeName));
        }

        /// <summary>
        /// Tests the implicit cast to string.
        /// </summary>
        [TestCase]
        public void Test_ImplicitCastToString()
        {
            FullyQualifiedTypeName fullyQualifiedTypeName = new(_fullyQualifiedTypeNameString);

            String fullyQualifiedTypeNameString = fullyQualifiedTypeName;

            Assert.That(fullyQualifiedTypeNameString, Is.EqualTo(_fullyQualifiedTypeNameString));
        }

        /// <summary>
        /// Tests the implicit cast from null string.
        /// </summary>
        [TestCase]
        public void Test_ImplicitCastFromNullString()
        {
            const String? nullEmailAddressString = null;
            EmailAddress emailAddress = nullEmailAddressString;

            String emailAddressString = emailAddress;
            Assert.That(emailAddressString, Is.EqualTo(null));
        }
    }
}
