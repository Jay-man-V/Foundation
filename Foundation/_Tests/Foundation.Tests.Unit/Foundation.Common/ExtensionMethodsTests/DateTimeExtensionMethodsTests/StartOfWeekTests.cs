//-----------------------------------------------------------------------
// <copyright file="StartOfWeekTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.DateTimeExtensionMethodsTests
{
    /// <summary>
    /// Summary description for StartOfWeekTests
    /// </summary>
    [TestFixture]
    public class StartOfWeekTests : UnitTestBase
    {
        [TestCase(DayOfWeek.Sunday, "2020-12-20", 20)]
        [TestCase(DayOfWeek.Monday, "2020-12-21", 21)]
        [TestCase(DayOfWeek.Tuesday, "2020-12-22", 22)]
        [TestCase(DayOfWeek.Wednesday, "2020-12-23", 23)]
        [TestCase(DayOfWeek.Thursday, "2020-12-24", 24)]
        [TestCase(DayOfWeek.Friday, "2020-12-25", 25)]
        [TestCase(DayOfWeek.Saturday, "2020-12-26", 26)]
        public void Test_StartOfWeek(DayOfWeek startOfWeek, String expectedDateTimeString, Int32 startDate)
        {
            DateTime expectedDateTime = DateTime.ParseExact(expectedDateTimeString, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            for (Int32 counter = 0; counter < 7; counter++)
            {
                DateTime startDateTime = new DateTime(2020, 12, startDate).AddDays(counter);

                DateTime actualDateTime = startDateTime.StartOfWeek(startOfWeek);

                Assert.That(actualDateTime, Is.EqualTo(expectedDateTime));
            }
        }
    }
}
