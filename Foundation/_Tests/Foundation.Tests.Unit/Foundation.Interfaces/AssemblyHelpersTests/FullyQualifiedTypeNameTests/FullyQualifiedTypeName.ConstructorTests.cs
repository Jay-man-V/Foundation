//-----------------------------------------------------------------------
// <copyright file="FullyQualifiedTypeNameConstructorTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;
using Foundation.Tests.Unit.Support;

using NSubstitute;

using System;

namespace Foundation.Tests.Unit.Foundation.Interfaces.AssemblyHelpersTests.FullyQualifiedTypeNameTests
{
    /// <summary>
    /// Email Address tests
    /// </summary>
    [TestFixture]
    public class FullyQualifiedTypeNameConstructorTests : UnitTestBase
    {
        private const String AssemblyName = "Foundation.BusinessProcess";
        private const String TypeName = "Foundation.BusinessProcess.ScheduledJobProcess";
        private readonly String _fullyQualifiedTypeNameString = $@"<TaskImplementation assembly=""{AssemblyName}"" type=""{TypeName}"" />";

        /// <summary>
        /// Tests the default constructor.
        /// </summary>
        [TestCase]
        public void Test_ConstructorDefault()
        {
            FullyQualifiedTypeName fullyQualifiedTypeName = new FullyQualifiedTypeName();

            Assert.That(fullyQualifiedTypeName.ToString(), Is.EqualTo(String.Empty));
            Assert.That(fullyQualifiedTypeName.AssemblyName, Is.EqualTo(String.Empty));
            Assert.That(fullyQualifiedTypeName.TypeName, Is.EqualTo(String.Empty));
        }

        /// <summary>
        /// Tests the string constructor.
        /// </summary>
        [TestCase]
        public void Test_ConstructorString()
        {
            FullyQualifiedTypeName fullyQualifiedTypeNameObject = new FullyQualifiedTypeName(_fullyQualifiedTypeNameString);

            Assert.That(fullyQualifiedTypeNameObject.ToString(), Is.EqualTo(_fullyQualifiedTypeNameString));
            Assert.That(fullyQualifiedTypeNameObject.AssemblyName, Is.EqualTo(AssemblyName));
            Assert.That(fullyQualifiedTypeNameObject.TypeName, Is.EqualTo(TypeName));
        }

        /// <summary>
        /// Tests the constructor with an empty string.
        /// </summary>
        [TestCase]
        public void Test_ConstructorEmptyString()
        {
            String paramName = "xmlTypeName";
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                String xmlTypeName = String.Empty;
                _ = new FullyQualifiedTypeName(xmlTypeName);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        /// <summary>
        /// Tests the constructor with a null string.
        /// </summary>
        [TestCase]
        public void Test_ConstructorNullString()
        {
            String paramName = "xmlTypeName";
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                const String? xmlTypeName = null;
                _ = new FullyQualifiedTypeName(xmlTypeName);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.ParamName, Is.EqualTo(paramName));
        }

        /// <summary>
        ///.
        /// </summary>
        [TestCase]
        public void Test_Properties()
        {
            FullyQualifiedTypeName fullyQualifiedTypeNameObject = new FullyQualifiedTypeName(_fullyQualifiedTypeNameString);

            Assert.That(fullyQualifiedTypeNameObject.AssemblyName, Is.EqualTo(AssemblyName));
            Assert.That(fullyQualifiedTypeNameObject.TypeName, Is.EqualTo(TypeName));
        }
    }
}
