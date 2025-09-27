//-----------------------------------------------------------------------
// <copyright file="IsBetweenNullableTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.DateTimeExtensionMethodsTests
{
    /// <summary>
    /// The DateTime Extension tests
    /// </summary>
    [TestFixture]
    public class IsBetweenNullableTests : UnitTestBase
    {
        [TestCase]
        public void TestIsBetween_NullTarget()
        {
            DateTime? targetValue = null;
            DateTime startValue = new DateTime(2018, 9, 1, 20, 10, 0);
            DateTime endValue = new DateTime(2018, 11, 1, 20, 10, 0);

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(false));
        }

        [TestCase]
        public void TestIsBetween_True()
        {
            DateTime? targetValue = new DateTime(2018, 10, 1, 20, 10, 0);
            DateTime startValue = new DateTime(2018, 9, 1, 20, 10, 0);
            DateTime endValue = new DateTime(2018, 11, 1, 20, 10, 0);

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_False()
        {
            DateTime? targetValue = new DateTime(2018, 10, 1, 20, 10, 0);
            DateTime startValue = new DateTime(2019, 9, 1, 20, 10, 0);
            DateTime endValue = new DateTime(2019, 11, 1, 20, 10, 0);

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(false));
        }

        [TestCase]
        public void TestIsBetween_SameValue()
        {
            DateTime? targetValue = new DateTime(2018, 10, 1, 20, 10, 0);
            DateTime startValue = new DateTime(2018, 10, 1, 20, 10, 0);
            DateTime endValue = new DateTime(2018, 10, 1, 20, 10, 0);

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_StartSameValue()
        {
            DateTime? targetValue = new DateTime(2018, 10, 1, 20, 10, 0);
            DateTime startValue = new DateTime(2018, 10, 1, 20, 10, 0);
            DateTime endValue = new DateTime(2018, 11, 1, 20, 10, 0);

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_EndSameValue()
        {
            DateTime? targetValue = new DateTime(2018, 10, 1, 20, 10, 0);
            DateTime startValue = new DateTime(2018, 9, 1, 20, 10, 0);
            DateTime endValue = new DateTime(2018, 10, 1, 20, 10, 0);

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }
    }
}
