//-----------------------------------------------------------------------
// <copyright file="IsBetweenNotNullableTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.TimeSpanExtensionMethodsTests
{
    /// <summary>
    /// The TimeSpan Extension Methods tests class
    /// </summary>
    [TestFixture]
    public class IsBetweenNotNullableTests : UnitTestBase
    {
        [TestCase]
        public void TestIsBetween_True()
        {
            TimeSpan targetValue = new TimeSpan(20, 10, 0);
            TimeSpan startValue = new TimeSpan(20, 0, 0);
            TimeSpan endValue = new TimeSpan(21, 0, 0);

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_False()
        {
            TimeSpan targetValue = new TimeSpan(20, 10, 0);
            TimeSpan startValue = new TimeSpan(21, 0, 0);
            TimeSpan endValue = new TimeSpan(22, 0, 0);

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(false));
        }

        [TestCase]
        public void TestIsBetween_SameValue()
        {
            TimeSpan targetValue = new TimeSpan(20, 10, 0);
            TimeSpan startValue = new TimeSpan(20, 10, 0);
            TimeSpan endValue = new TimeSpan(20, 10, 0);

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_StartSameValue()
        {
            TimeSpan targetValue = new TimeSpan(20, 10, 0);
            TimeSpan startValue = new TimeSpan(20, 10, 0);
            TimeSpan endValue = new TimeSpan(21, 0, 0);

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }

        [TestCase]
        public void TestIsBetween_EndSameValue()
        {
            TimeSpan targetValue = new TimeSpan(20, 10, 0);
            TimeSpan startValue = new TimeSpan(20, 0, 0);
            TimeSpan endValue = new TimeSpan(20, 10, 0);

            Boolean actualResult = targetValue.IsBetween(startValue, endValue);

            Assert.That(actualResult, Is.EqualTo(true));
        }
    }
}
