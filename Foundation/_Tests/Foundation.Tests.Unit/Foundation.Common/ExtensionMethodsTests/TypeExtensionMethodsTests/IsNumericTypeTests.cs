//-----------------------------------------------------------------------
// <copyright file="TypeExtensionMethodsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.TypeExtensionMethodsTests
{
    /// <summary>
    /// The Type Extension tests
    /// </summary>
    [TestFixture]
    public class IsNumericTypeTests
    {
        [TestCase]
        public void TestIsNumericType_Int16_True()
        {
            Int16 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Int16);

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_UInt16_True()
        {
            UInt16 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(UInt16);

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_Int32_True()
        {
            Int32 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Int32);

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_UInt32_True()
        {
            UInt32 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(UInt32);

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_Int64_True()
        {
            Int64 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Int64);

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_UInt64_True()
        {
            UInt64 anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(UInt64);

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_Decimal_True()
        {
            Decimal anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Decimal);

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_Double_True()
        {
            Double anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Double);

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_Single_True()
        {
            Single anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Single);

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_SByte_True()
        {
            SByte anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(SByte);

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsNumericType_Byte_True()
        {
            Byte anObject = 0;

            Boolean actualResult = anObject.GetType().IsNumericType();

            Assert.That(actualResult, Is.EqualTo(true));

            Object anObject2 = default(Byte);

            Boolean actualResult2 = anObject2.GetType().IsNumericType();

            Assert.That(actualResult2, Is.EqualTo(true));
        }
    }
}
