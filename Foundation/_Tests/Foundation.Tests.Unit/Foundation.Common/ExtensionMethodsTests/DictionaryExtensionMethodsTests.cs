//-----------------------------------------------------------------------
// <copyright file="DictionaryExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests
{
    /// <summary>
    /// The Dictionary Extension Methods tests class
    /// </summary>
    [TestFixture]
    public class DictionaryExtensionMethodsTests : UnitTestBase
    {
        [TestCase]
        public void TestHasItems_Dictionary_Null()
        {
            const Dictionary<String, String>? aDictionary1 = null;
            Assert.That(aDictionary1.HasItems(), Is.EqualTo(false));
        }

        [TestCase]
        public void TestHasItems_Dictionary_Empty()
        {
            Dictionary<String, String> aDictionary1 = new Dictionary<String, String>();
            Assert.That(aDictionary1.HasItems(), Is.EqualTo(false));
        }

        [TestCase]
        public void TestHasItems_IDictionary_Items()
        {
            Dictionary<String, String> aDictionary1 = new Dictionary<String, String> { { "K", "V" } };
            Assert.That(aDictionary1.HasItems());
        }

        [TestCase]
        public void Test_IReadOnlyDictionary_GetValue()
        {
            String expectedValue1 = "Abc123";
            String expectedValue2 = "V";
            Dictionary<String, String> aDictionary1 = new Dictionary<String, String> { { "K", "V" } };
            IReadOnlyDictionary<String, String> readOnlyDictionary = aDictionary1;

            String actualValue1 = readOnlyDictionary.GetValue("A", expectedValue1);
            Assert.That(actualValue1, Is.EqualTo(expectedValue1));

            String actualValue2 = readOnlyDictionary.GetValue("K", expectedValue1);
            Assert.That(actualValue2, Is.EqualTo(expectedValue2));
        }

        [TestCase]
        public void Test_IReadOnlyDictionary_GetNullableValue()
        {
            DateTime expectedValue1 = new DateTime(2021, 1, 24, 15, 16, 5);
            Dictionary<String, DateTime> aDictionary1 = new Dictionary<String, DateTime> { { "K", expectedValue1} };
            IReadOnlyDictionary<String, DateTime> readOnlyDictionary = aDictionary1;

            DateTime? actualValue1 = readOnlyDictionary.GetNullableValue("K");
            Assert.That(actualValue1, Is.EqualTo(expectedValue1));

            DateTime? actualValue2 = readOnlyDictionary.GetNullableValue("A");
            Assert.That(actualValue2.HasValue, Is.EqualTo(false));
        }
    }
}
