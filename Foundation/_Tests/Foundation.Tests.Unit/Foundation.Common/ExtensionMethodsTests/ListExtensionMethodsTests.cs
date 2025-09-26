//-----------------------------------------------------------------------
// <copyright file="ListExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.Mocks;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests
{
    /// <summary>
    /// The List Extension Methods tests class
    /// </summary>
    [TestFixture]
    public class ListExtensionMethodsTests
    {
        [TestCase]
        public void Test_HasItems_List_Null()
        {
            List<Int32>? aList1 = null;
            Assert.That(aList1.HasItems(), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_HasItems_List_Empty()
        {
            List<String> aList1 = [];
            Assert.That(aList1.HasItems(), Is.EqualTo(false));
        }

        [TestCase]
        public void Test_HasItems_List_WithItems()
        {
            List<String> aList1 = ["String1"];
            Assert.That(aList1.HasItems(), Is.EqualTo(true));
        }

        [TestCase]
        public void Test_Clone_List_Empty_1()
        {
            List<String> aList1 = [];
            List<String> aList2 = aList1.Clone();

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList2, Is.EquivalentTo(aList1));
        }

        [TestCase]
        public void Test_Clone_List_Empty_2()
        {
            List<RandomObject> aList1 = [];
            List<RandomObject> aList2 = aList1.Clone() as List<RandomObject>;

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList2, Is.EquivalentTo(aList1));
        }

        [TestCase]
        public void Test_Clone_List_WithItems_1()
        {
            List<String> aList1 = ["String1", "String2"];
            List<String> aList2 = aList1.Clone();

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList2, Is.EquivalentTo(aList1));
        }

        [TestCase]
        public void Test_Clone_List_WithItems_2()
        {
            List<RandomObject> aList1 = [new RandomObject("String1"), new RandomObject("String2")];
            List<RandomObject> aList2 = aList1.Clone() as List<RandomObject>;

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList2, Is.EquivalentTo(aList1));
            Assert.That(aList2[0].Name, Is.EqualTo(aList1[0].Name));
        }

        [TestCase]
        public void Test_Clone_List_WithItems_4()
        {
            List<RandomObject> aList1 = [new RandomObject(), new RandomObject()];
            List<RandomObject> aList2 = aList1.Clone() as List<RandomObject>;

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList2, Is.EquivalentTo(aList1));
            Assert.That(aList2[0].Name, Is.EqualTo(aList1[0].Name));
        }

        [TestCase]
        public void Test_Clone_List_WithItems_5()
        {
            List<RandomCloneableObject> aList1 = [new RandomCloneableObject("String1"), new RandomCloneableObject("String2")];
            List<RandomCloneableObject> aList2 = aList1.Clone();

            Assert.That(aList2, Is.Not.SameAs(aList1));
            Assert.That(aList2, Is.Not.EquivalentTo(aList1));
        }
    }
}
