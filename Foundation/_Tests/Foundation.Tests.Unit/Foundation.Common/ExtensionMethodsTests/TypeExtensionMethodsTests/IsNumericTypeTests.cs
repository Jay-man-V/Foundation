//-----------------------------------------------------------------------
// <copyright file="TypeExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.TypeExtensionMethodsTests
{
    /// <summary>
    /// The Type Extension tests
    /// </summary>
    [TestFixture]
    public class IsNumericTypeTests : UnitTestBase
    {
        [TestCase]
        public void TestIsNumericType_Int16_True()
        {
            Int16 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = (Int16)0;

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_UInt16_True()
        {
            UInt16 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = (UInt16)0;

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_Int32_True()
        {
            Int32 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = 0;

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_UInt32_True()
        {
            UInt32 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = (UInt32)0;

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_Int64_True()
        {
            Int64 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = (Int64)0;

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_UInt64_True()
        {
            UInt64 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = (UInt64)0;

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_Decimal_True()
        {
            Decimal anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = (Decimal)0;

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_Double_True()
        {
            Double anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = (Double)0;

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_Single_True()
        {
            Single anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = (Single)0;

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_SByte_True()
        {
            SByte anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = (SByte)0;

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_Byte_True()
        {
            Byte anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = (Byte)0;

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }
    }
}
