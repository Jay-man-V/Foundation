//-----------------------------------------------------------------------
// <copyright file="IsBetweenNullableTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.UInt32ExtensionMethodsTests
{
    /// <summary>
    /// The UInt32 Extension Methods tests class
    /// </summary>
    [TestFixture]
    public class IsBetweenNullableTests : UnitTestBase
    {
        [TestCase]
        public void TestIsBetween_UInt32_Null()
        {
            UInt32? targetValue = null;
            UInt32 startValue = 2000;
            UInt32 endValue = 2100;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(false));
        }

        [TestCase]
        public void TestIsBetween_UInt32_True()
        {
            UInt32? targetValue = 2010;
            UInt32 startValue = 2000;
            UInt32 endValue = 2100;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_UInt32_False()
        {
            UInt32? targetValue = 2010;
            UInt32 startValue = 2100;
            UInt32 endValue = 2200;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(false));
        }

        [TestCase]
        public void TestIsBetween_UInt32_SameValue()
        {
            UInt32? targetValue = 2010;
            UInt32 startValue = 2010;
            UInt32 endValue = 2010;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_UInt32_StartSameValue()
        {
            UInt32? targetValue = 2010;
            UInt32 startValue = 2010;
            UInt32 endValue = 2100;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_UInt32_EndSameValue()
        {
            UInt32? targetValue = 2010;
            UInt32 startValue = 2000;
            UInt32 endValue = 2010;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_Int32_Null()
        {
            UInt32? targetValue = null;
            Int32 startValue = 2000;
            Int32 endValue = 2100;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(false));
        }

        [TestCase]
        public void TestIsBetween_Int32_True()
        {
            UInt32? targetValue = 2010;
            Int32 startValue = 2000;
            Int32 endValue = 2100;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_Int32_False()
        {
            UInt32? targetValue = 2010;
            Int32 startValue = 2100;
            Int32 endValue = 2200;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(false));
        }

        [TestCase]
        public void TestIsBetween_Int32_SameValue()
        {
            UInt32? targetValue = 2010;
            Int32 startValue = 2010;
            Int32 endValue = 2010;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_Int32_StartSameValue()
        {
            UInt32? targetValue = 2010;
            Int32 startValue = 2010;
            Int32 endValue = 2100;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_Int32_EndSameValue()
        {
            UInt32? targetValue = 2010;
            Int32 startValue = 2000;
            Int32 endValue = 2010;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }
    }
}
