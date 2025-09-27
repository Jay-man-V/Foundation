//-----------------------------------------------------------------------
// <copyright file="IsBetweenNullableTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.ByteExtensionMethodsTests
{
    /// <summary>
    /// The Byte Extension Methods tests class
    /// </summary>
    [TestFixture]
    public class IsBetweenNullableTests : UnitTestBase
    {
        [TestCase]
        public void TestIsBetween_Null()
        {
            Byte? targetValue = null;
            Byte startValue = 50;
            Byte endValue = 100;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(false));
        }

        [TestCase]
        public void TestIsBetween_True()
        {
            Byte? targetValue = 75;
            Byte startValue = 50;
            Byte endValue = 100;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_False()
        {
            Byte? targetValue = 10;
            Byte startValue = 50;
            Byte endValue = 100;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(false));
        }

        [TestCase]
        public void TestIsBetween_SameValue()
        {
            Byte? targetValue = 100;
            Byte startValue = 100;
            Byte endValue = 100;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_StartSameValue()
        {
            Byte? targetValue = 50;
            Byte startValue = 50;
            Byte endValue = 100;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_EndSameValue()
        {
            Byte? targetValue = 100;
            Byte startValue = 50;
            Byte endValue = 100;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }
    }
}
