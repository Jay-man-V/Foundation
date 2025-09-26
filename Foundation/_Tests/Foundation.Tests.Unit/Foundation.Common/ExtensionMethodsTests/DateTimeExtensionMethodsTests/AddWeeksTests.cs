//-----------------------------------------------------------------------
// <copyright file="AddWeeksTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.DateTimeExtensionMethodsTests
{
    /// <summary>
    /// The DateTime Extension tests
    /// </summary>
    [TestFixture]
    public class AddWeeksTests
    {
        [TestCase]
        public void TestAddWeeks_1()
        {
            Int32 interval = 1;
            DateTime startValue = new DateTime(2018, 9, 1, 20, 10, 0);
            DateTime expectedValue = new DateTime(2018, 9, 8, 20, 10, 0);

            DateTime actualValue = startValue.AddWeeks(interval);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestAddWeeks_2()
        {
            Int32 interval = 2;
            DateTime startValue = new DateTime(2018, 9, 1, 20, 10, 0);
            DateTime expectedValue = new DateTime(2018, 9, 15, 20, 10, 0);

            DateTime actualValue = startValue.AddWeeks(interval);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestAddWeeks_4()
        {
            Int32 interval = 4;
            DateTime startValue = new DateTime(2018, 9, 1, 20, 10, 0);
            DateTime expectedValue = new DateTime(2018, 9, 29, 20, 10, 0);

            DateTime actualValue = startValue.AddWeeks(interval);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestAddWeeks_6()
        {
            Int32 interval = 6;
            DateTime startValue = new DateTime(2018, 9, 1, 20, 10, 0);
            DateTime expectedValue = new DateTime(2018, 10, 13, 20, 10, 0);

            DateTime actualValue = startValue.AddWeeks(interval);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
