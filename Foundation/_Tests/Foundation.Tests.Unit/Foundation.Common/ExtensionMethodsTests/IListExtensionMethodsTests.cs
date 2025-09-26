//-----------------------------------------------------------------------
// <copyright file="IListExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.Mocks;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests
{
    /// <summary>
    /// The IList Extension Methods tests class
    /// </summary>
    [TestFixture]
    public class IListExtensionMethodsTests : UnitTestBase
    {
        [TestCase]
        public void Test_HasItems_List_Null()
        {
            IList<Int32>? aList1 = null;
            Assert.That(aList1.HasItems(), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_HasItems_List_Null_Predicate()
        {
            IList<Int32>? aList1 = null;
            Assert.That(aList1.HasItems(a => a == 3), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_HasItems_List_Empty()
        {
            IList<String> aList1 = [];
            Assert.That(aList1.HasItems(), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_HasItems_List_Empty_Predicate()
        {
            IList<String> aList1 = [];
            Assert.That(aList1.HasItems(a => a == "3"), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_HasItems_List_WithItems()
        {
            IList<String> aList1 = ["String1"];
            Assert.That(aList1.HasItems());
        }

        [TestCase]
        public void Test_HasItems_List_WithItems_Predicate()
        {
            IList<String> aList1 = ["String1"];
            Assert.That(aList1.HasItems(a => a == "String1"));
        }

        [TestCase]
        public void Test_None_List_Null()
        {
            IList<Int32>? aList1 = null;
            Assert.That(aList1.None());
        }

        [TestCase]
        public void Test_None_List_Null_Predicate()
        {
            IList<Int32>? aList1 = null;
            Assert.That(aList1.None(a => a == 3));
        }

        [TestCase]
        public void Test_None_List_Empty()
        {
            IList<String> aList1 = [];
            Assert.That(aList1.None());
        }

        [TestCase]
        public void Test_None_List_Empty_Predicate()
        {
            IList<String> aList1 = [];
            Assert.That(aList1.None(a => a == "3"));
        }

        [TestCase]
        public void Test_None_List_WithItems()
        {
            IList<String> aList1 = ["String1"];
            Assert.That(aList1.None(), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_None_List_WithItems_Predicate()
        {
            IList<String> aList1 = ["String1"];
            Assert.That(aList1.None(a => a == "String1"), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_Clone_List_Empty_1()
        {
            IList<String> aList1 = [];
            IList<String> aList2 = aList1.Clone();

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList1.SequenceEqual(aList2), Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Clone_List_Empty_2()
        {
            IList<RandomObject> aList1 = [];
            IList<RandomObject> aList2 = aList1.Clone() as IList<RandomObject>;

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList1.SequenceEqual(aList2), Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Clone_List_WithItems_1()
        {
            IList<String> aList1 = ["String1", "String2"];
            IList<String> aList2 = aList1.Clone();

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList1.SequenceEqual(aList2), Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Clone_List_WithItems_2()
        {
            IList<RandomObject> aList1 = [new RandomObject("String1"), new RandomObject("String2")];
            IList<RandomObject> aList2 = aList1.Clone() as IList<RandomObject>;

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList1.SequenceEqual(aList2), Is.EqualTo(true));
            Assert.That(aList2[0].Name, Is.EqualTo(aList1[0].Name));
        }

        [TestCase]
        public void Test_Clone_List_WithItems_4()
        {
            IList<RandomObject> aList1 = [new RandomObject(), new RandomObject()];
            IList<RandomObject> aList2 = aList1.Clone() as IList<RandomObject>;

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList1.SequenceEqual(aList2), Is.EqualTo(true));
            Assert.That(aList2[0].Name, Is.EqualTo(aList1[0].Name));
        }

        [TestCase]
        public void Test_Clone_List_WithItems_5()
        {
            IList<RandomCloneableObject> aList1 = [new RandomCloneableObject("String1"), new RandomCloneableObject("String2")];
            IList<RandomCloneableObject> aList2 = aList1.Clone();

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList1.SequenceEqual(aList2), Is.EqualTo(false));
        }
    }
}
