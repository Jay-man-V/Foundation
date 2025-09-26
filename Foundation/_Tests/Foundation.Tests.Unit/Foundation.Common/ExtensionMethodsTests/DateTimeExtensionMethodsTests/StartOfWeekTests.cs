//-----------------------------------------------------------------------
// <copyright file="StartOfWeekTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.DateTimeExtensionMethodsTests
{
    /// <summary>
    /// Summary description for StartOfWeekTests
    /// </summary>
    [TestFixture]
    public class StartOfWeekTests
    {
        [TestCase]
        public void TestStartOfWeek_Sunday()
        {
            DateTime expectedDateTime = new DateTime(2020, 12, 20);
            Int32 startDate = 20;
            DayOfWeek startOfWeek = DayOfWeek.Sunday;

            TestStartOfWeek(expectedDateTime, startDate, startOfWeek);
        }

        [TestCase]
        public void TestStartOfWeek_Monday()
        {
            DateTime expectedDateTime = new DateTime(2020, 12, 21);
            Int32 startDate = 21;
            DayOfWeek startOfWeek = DayOfWeek.Monday;

            TestStartOfWeek(expectedDateTime, startDate, startOfWeek);
        }

        [TestCase]
        public void TestStartOfWeek_Tuesday()
        {
            DateTime expectedDateTime = new DateTime(2020, 12, 22);
            Int32 startDate = 22;
            DayOfWeek startOfWeek = DayOfWeek.Tuesday;

            TestStartOfWeek(expectedDateTime, startDate, startOfWeek);
        }

        [TestCase]
        public void TestStartOfWeek_Wednesday()
        {
            DateTime expectedDateTime = new DateTime(2020, 12, 23);
            Int32 startDate = 23;
            DayOfWeek startOfWeek = DayOfWeek.Wednesday;

            TestStartOfWeek(expectedDateTime, startDate, startOfWeek);
        }

        [TestCase]
        public void TestStartOfWeek_Thursday()
        {
            DateTime expectedDateTime = new DateTime(2020, 12, 24);
            Int32 startDate = 24;
            DayOfWeek startOfWeek = DayOfWeek.Thursday;

            TestStartOfWeek(expectedDateTime, startDate, startOfWeek);
        }

        [TestCase]
        public void TestStartOfWeek_Friday()
        {
            DateTime expectedDateTime = new DateTime(2020, 12, 25);
            Int32 startDate = 25;
            DayOfWeek startOfWeek = DayOfWeek.Friday;

            TestStartOfWeek(expectedDateTime, startDate, startOfWeek);
        }

        [TestCase]
        public void TestStartOfWeek_Saturday()
        {
            DateTime expectedDateTime = new DateTime(2020, 12, 26);
            Int32 startDate = 26;
            DayOfWeek startOfWeek = DayOfWeek.Saturday;

            TestStartOfWeek(expectedDateTime, startDate, startOfWeek);
        }

        private void TestStartOfWeek(DateTime expectedDateTime, Int32 startDate, DayOfWeek startOfWeek)
        {
            for (Int32 counter = 0; counter < 7; counter++)
            {
                DateTime startDateTime = new DateTime(2020, 12, startDate).AddDays(counter);

                DateTime actualDateTime = startDateTime.StartOfWeek(startOfWeek);

                Assert.That(actualDateTime, Is.EqualTo(expectedDateTime));
            }
        }
    }
}
