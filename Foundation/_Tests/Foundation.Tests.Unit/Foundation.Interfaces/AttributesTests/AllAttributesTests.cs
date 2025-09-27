//-----------------------------------------------------------------------
// <copyright file="AllAttributesTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Interfaces.AttributesTests
{
    /// <summary>
    /// This test class exists to ensure all Attributes in Foundation.Common
    /// are accounted for and tested appropriately
    /// </summary>
    [TestFixture]
    public class AllAttributesTests : UnitTestBase
    {
        /// <summary>
        /// Find all the attributes in Foundation.Common assembly.
        /// </summary>
        [TestCase]
        public void Test_Attributes()
        {
            IEnumerable<MethodInfo> testMethods = GetListOfTestMethods();
            int testMethodCount = testMethods.Count();

            // This test exists to ensure all the Application Settings are tested/checked in the next test
            List<Type> allTypes = GetListOfValidTypes(t => t.BaseType != null && t.BaseType.Name.EndsWith("Attribute") &&
                                                           t.Namespace != null && t.Namespace.StartsWith("Foundation")
                                                           );

            Assert.That(allTypes.Count, Is.EqualTo(testMethodCount - 1));

            int index = 0;

            Assert.That(allTypes[index++].Name, Is.EqualTo(nameof(RequiredAppIdAttribute)));
            Assert.That(allTypes[index++].Name, Is.EqualTo(nameof(RequiredEntityIdAttribute)));
            Assert.That(allTypes[index++].Name, Is.EqualTo(nameof(RequiredLogIdAttribute)));
            Assert.That(allTypes[index++].Name, Is.EqualTo(nameof(DependencyInjectionIgnoreAttribute)));
            Assert.That(allTypes[index++].Name, Is.EqualTo(nameof(DependencyInjectionScopedAttribute)));
            Assert.That(allTypes[index++].Name, Is.EqualTo(nameof(DependencyInjectionSingletonAttribute)));
            Assert.That(allTypes[index++].Name, Is.EqualTo(nameof(DependencyInjectionStrategyAttribute)));
            Assert.That(allTypes[index++].Name, Is.EqualTo(nameof(DependencyInjectionTransientAttribute)));
            Assert.That(allTypes[index++].Name, Is.EqualTo(nameof(EmailAddressMaxLengthAttribute)));
            Assert.That(allTypes[index++].Name, Is.EqualTo(nameof(IdAttribute)));
            Assert.That(allTypes[index++].Name, Is.EqualTo(nameof(IndexAttribute)));

            Assert.That(allTypes.Count, Is.EqualTo(index));
        }

        /// <summary>
        /// Tests the RequiredAppIdAttribute.
        /// </summary>
        [TestCase]
        public void Test_RequiredAppIdAttribute()
        {
            RequiredAppIdAttribute attribute = new RequiredAppIdAttribute();
            Assert.That(attribute.ErrorMessage, Is.EqualTo("Application Id must be provided"));

            bool result1 = attribute.IsValid(new AppId(1));
            Assert.That(result1, Is.EqualTo(true));

            bool result2 = attribute.IsValid(new AppId(0));
            Assert.That(result2, Is.EqualTo(false));

            bool result3 = attribute.IsValid(new LogId(1));
            Assert.That(result3, Is.EqualTo(false));
        }

        /// <summary>
        /// Tests the RequiredEntityIdAttribute.
        /// </summary>
        [TestCase]
        public void Test_RequiredEntityIdAttribute()
        {
            RequiredEntityIdAttribute attribute = new RequiredEntityIdAttribute();
            Assert.That(attribute.ErrorMessage, Is.EqualTo("Entity Id must be provided"));

            string guidValue = Guid.NewGuid().ToString();
            attribute.EntityName = guidValue;
            Assert.That(attribute.ErrorMessage, Is.EqualTo($"{guidValue} Id must be provided"));

            bool result1 = attribute.IsValid(new EntityId(1));
            Assert.That(result1, Is.EqualTo(true));

            bool result2 = attribute.IsValid(new EntityId(0));
            Assert.That(result2, Is.EqualTo(false));

            bool result3 = attribute.IsValid(new LogId(1));
            Assert.That(result3, Is.EqualTo(false));
        }

        /// <summary>
        /// Tests the RequiredLogIdAttribute.
        /// </summary>
        [TestCase]
        public void Test_RequiredLogIdAttribute()
        {
            RequiredLogIdAttribute attribute = new RequiredLogIdAttribute();

            bool result1 = attribute.IsValid(new LogId(1));
            Assert.That(result1, Is.EqualTo(true));

            bool result2 = attribute.IsValid(new LogId(0));
            Assert.That(result2, Is.EqualTo(false));

            bool result3 = attribute.IsValid(new EntityId(1));
            Assert.That(result3, Is.EqualTo(false));
        }

        /// <summary>
        /// Tests the DependencyInjectionIgnoreAttribute.
        /// </summary>
        [TestCase]
        public void Test_DependencyInjectionIgnoreAttribute()
        {
            _ = new DependencyInjectionIgnoreAttribute();

            // No additional tests
        }

        /// <summary>
        /// Tests the DependencyInjectionScopedAttribute.
        /// </summary>
        [TestCase]
        public void Test_DependencyInjectionScopedAttribute()
        {
            _ = new DependencyInjectionScopedAttribute();

            // No additional tests
        }

        /// <summary>
        /// Tests the DependencyInjectionSingletonAttribute.
        /// </summary>
        [TestCase]
        public void Test_DependencyInjectionSingletonAttribute()
        {
            _ = new DependencyInjectionSingletonAttribute();

            // No additional tests
        }

        /// <summary>
        /// Tests the DependencyInjectionStrategyAttribute.
        /// </summary>
        [TestCase]
        public void Test_DependencyInjectionStrategyAttribute()
        {
            _ = new DependencyInjectionStrategyAttribute();

            // No additional tests
        }

        /// <summary>
        /// Tests the DependencyInjectionTransientAttribute.
        /// </summary>
        [TestCase]
        public void Test_DependencyInjectionTransientAttribute()
        {
            _ = new DependencyInjectionTransientAttribute();

            // No additional tests
        }

        /// <summary>
        /// Tests the EmailAddressMaxLengthAttribute.
        /// </summary>
        [TestCase]
        public void Test_EmailAddressMaxLengthAttribute()
        {
            int expectedValue = 123;
            EmailAddressMaxLengthAttribute attribute = new EmailAddressMaxLengthAttribute(expectedValue);

            EmailAddress emailAddress = new EmailAddress("somewheremadeup@gmail.com");

            Assert.That(attribute.Length, Is.EqualTo(expectedValue));
            Assert.That(attribute.IsValid(emailAddress), Is.EqualTo(true));
            Assert.That(attribute.IsValid(attribute), Is.EqualTo(false));
        }

        /// <summary>
        /// Tests the IndexAttribute.
        /// </summary>
        [TestCase]
        public void Test_IndexAttribute()
        {
            int expectedValue = 123456;
            IndexAttribute attribute = new IndexAttribute(expectedValue);

            Assert.That(attribute.Index, Is.EqualTo(expectedValue));
        }

        /// <summary>
        /// Tests the IdAttribute.
        /// </summary>
        [TestCase]
        public void Test_IdAttribute()
        {
            int expectedValue = 123456;
            IdAttribute attribute = new IdAttribute(expectedValue);

            Assert.That(attribute.Id, Is.EqualTo(expectedValue));
        }
    }
}
