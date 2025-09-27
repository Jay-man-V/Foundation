//-----------------------------------------------------------------------
// <copyright file="IEnumerableExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Mocks;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests
{
    /// <summary>
    /// The IEnumerable Extension Methods tests class
    /// </summary>
    [TestFixture]
    public class IEnumerableExtensionMethodsTests : UnitTestBase
    {
        [TestCase]
        public void Test_HasItems_IEnumerable_Null()
        {
            IEnumerable<Int32>? aList1 = null;
            Assert.That(aList1.HasItems(), Is.EqualTo(false));
        }
        [TestCase]
        public void Test_HasItems_IEnumerable_Null_Predicate()
        {
            IEnumerable<Int32>? aList1 = null;
            Assert.That(aList1.HasItems(a => a == 3), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_HasItems_IEnumerable_Empty()
        {
            IEnumerable<String> aList1 = [];
            Assert.That(aList1.HasItems(), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_HasItems_IEnumerable_Empty_Predicate()
        {
            IEnumerable<String> aList1 = [];
            Assert.That(aList1.HasItems(a => a == "3"), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_HasItems_IEnumerable_WithItems()
        {
            IEnumerable<String> aList1 = ["String1"];
            Assert.That(aList1.HasItems());
        }

        [TestCase]
        public void Test_HasItems_IEnumerable_WithItems_Predicate()
        {
            IEnumerable<String> aList1 = ["String1"];
            Assert.That(aList1.HasItems(a => a == "String1"));
        }

        [TestCase]
        public void Test_None_IEnumerable_Null()
        {
            IEnumerable<Int32>? aList1 = null;
            Assert.That(aList1.None());
        }
        [TestCase]
        public void Test_None_IEnumerable_Null_Predicate()
        {
            IEnumerable<Int32>? aList1 = null;
            Assert.That(aList1.None(a => a == 3));
        }

        [TestCase]
        public void Test_None_IEnumerable_Empty()
        {
            IEnumerable<String> aList1 = [];
            Assert.That(aList1.None());
        }

        [TestCase]
        public void Test_None_IEnumerable_Empty_Predicate()
        {
            IEnumerable<String> aList1 = [];
            Assert.That(aList1.None(a => a == "3"));
        }

        [TestCase]
        public void Test_None_IEnumerable_WithItems()
        {
            IEnumerable<String> aList1 = ["String1"];
            Assert.That(aList1.None(), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_None_IEnumerable_WithItems_Predicate()
        {
            IEnumerable<String> aList1 = ["String1"];
            Assert.That(aList1.None(a => a == "String1"), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_Clone_IEnumerable_Empty_1()
        {
            IEnumerable<String> aList1 = [];
            IEnumerable<String> aList2 = aList1.Clone();

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList1.SequenceEqual(aList2), Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Clone_IEnumerable_Empty_2()
        {
            IEnumerable<RandomObject> aList1 = [];
            IEnumerable<RandomObject> aList2 = aList1.Clone();

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList1.SequenceEqual(aList2), Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Clone_IEnumerable_WithItems_1()
        {
            IEnumerable<String> aList1 = ["String1", "String2"];
            IEnumerable<String> aList2 = aList1.Clone();

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList1.SequenceEqual(aList2), Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Clone_IEnumerable_WithItems_2()
        {
            IEnumerable<RandomObject> aList1 = [new RandomObject("String1"), new RandomObject("String2")];
            IEnumerable<RandomObject> aList2 = aList1.Clone();

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList1.SequenceEqual(aList2), Is.EqualTo(true));
            Assert.That(aList2.ElementAt(0).Name, Is.EqualTo(aList1.ElementAt(0).Name));
        }

        [TestCase]
        public void Test_Clone_IEnumerable_WithItems_4()
        {
            IEnumerable<RandomObject> aList1 = [new RandomObject(), new RandomObject()];
            IEnumerable<RandomObject> aList2 = aList1.Clone();

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList1.SequenceEqual(aList2), Is.EqualTo(true));
            Assert.That(aList2.ElementAt(0).Name, Is.EqualTo(aList1.ElementAt(0).Name));
        }

        [TestCase]
        public void Test_Clone_IEnumerable_WithItems_5()
        {
            IEnumerable<RandomCloneableObject> aList1 = [new RandomCloneableObject("String1"), new RandomCloneableObject("String2")];
            IEnumerable<RandomCloneableObject> aList2 = aList1.Clone();

            Assert.That(aList2, Is.Not.EqualTo(aList1));
            Assert.That(aList1.SequenceEqual(aList2), Is.EqualTo(false));
        }
    }
}
