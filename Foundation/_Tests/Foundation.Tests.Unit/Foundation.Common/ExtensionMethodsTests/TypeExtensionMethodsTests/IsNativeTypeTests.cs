//-----------------------------------------------------------------------
// <copyright file="IsNativeTypeTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.TypeExtensionMethodsTests
{
    /// <summary>
    /// The Object Extension tests
    /// </summary>
    [TestFixture]
    public class IsNativeTypeTests : UnitTestBase
    {
        [TestCase]
        public void TestIsNativeType_SpecificType_False()
        {
            IsNativeTypeTests anObject = new IsNativeTypeTests();

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(false));
        }

        [TestCase]
        public void TestIsNativeType_BaseIsObject_False()
        {
            Object anObject = new IsNativeTypeTests();

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(false));
        }

        [TestCase]
        public void TestIsNativeType_Boolean_True()
        {
            Boolean anObject = true;

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Boolean);

            Boolean actualResult2 = anObject2.GetType().IsNativeType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNativeType_DateTime_True()
        {
            DateTime anObject = new DateTime();

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(DateTime);

            Boolean actualResult2 = anObject2.GetType().IsNativeType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNativeType_Char_True()
        {
            Char anObject = ' ';

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Char);

            Boolean actualResult2 = anObject2.GetType().IsNativeType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNativeType_String_True()
        {
            String anObject = " ";

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = " ";

            Boolean actualResult2 = anObject2.GetType().IsNativeType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNativeType_Int16_True()
        {
            Int16 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Int16);

            Boolean actualResult2 = anObject2.GetType().IsNativeType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNativeType_UInt16_True()
        {
            UInt16 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(UInt16);

            Boolean actualResult2 = anObject2.GetType().IsNativeType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNativeType_Int32_True()
        {
            Int32 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Int32);

            Boolean actualResult2 = anObject2.GetType().IsNativeType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNativeType_UInt32_True()
        {
            UInt32 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(UInt32);

            Boolean actualResult2 = anObject2.GetType().IsNativeType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNativeType_Int64_True()
        {
            Int64 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Int64);

            Boolean actualResult2 = anObject2.GetType().IsNativeType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNativeType_UInt64_True()
        {
            UInt64 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(UInt64);

            Boolean actualResult2 = anObject2.GetType().IsNativeType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNativeType_Decimal_True()
        {
            Decimal anObject = 0;

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Decimal);

            Boolean actualResult2 = anObject2.GetType().IsNativeType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNativeType_Double_True()
        {
            Double anObject = 0;

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Double);

            Boolean actualResult2 = anObject2.GetType().IsNativeType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNativeType_Single_True()
        {
            Single anObject = 0;

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Single);

            Boolean actualResult2 = anObject2.GetType().IsNativeType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNativeType_SByte_True()
        {
            SByte anObject = 0;

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(SByte);

            Boolean actualResult2 = anObject2.GetType().IsNativeType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNativeType_Byte_True()
        {
            Byte anObject = 0;

            Boolean actualResult = anObject.GetType().IsNativeType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Byte);

            Boolean actualResult2 = anObject2.GetType().IsNativeType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }
    }
}
