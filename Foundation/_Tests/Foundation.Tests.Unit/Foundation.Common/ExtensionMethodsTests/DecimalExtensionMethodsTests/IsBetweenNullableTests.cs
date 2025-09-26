//-----------------------------------------------------------------------
// <copyright file="IsBetweenNullableTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.DecimalExtensionMethodsTests
{
    /// <summary>
    /// The Decimal Extension Methods tests class
    /// </summary>
    [TestFixture]
    public class IsBetweenNullableTests
    {
        [TestCase]
        public void TestIsBetween_Null()
        {
            Decimal? targetValue = null;
            Decimal startValue = 20.00m;
            Decimal endValue = 21.00m;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(false));
        }

        [TestCase]
        public void TestIsBetween_True()
        {
            Decimal? targetValue = 20.10m;
            Decimal startValue = 20.00m;
            Decimal endValue = 21.00m;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_False()
        {
            Decimal? targetValue = 20.10m;
            Decimal startValue = 30.00m;
            Decimal endValue = 31.00m;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(false));
        }

        [TestCase]
        public void TestIsBetween_SameValue()
        {
            Decimal? targetValue = 20.10m;
            Decimal startValue = 20.00m;
            Decimal endValue = 21.00m;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_StartSameValue()
        {
            Decimal? targetValue = 20.10m;
            Decimal startValue = 20.00m;
            Decimal endValue = 21.00m;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_EndSameValue()
        {
            Decimal? targetValue = 20.10m;
            Decimal startValue = 20.00m;
            Decimal endValue = 21.00m;

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }
    }
}
