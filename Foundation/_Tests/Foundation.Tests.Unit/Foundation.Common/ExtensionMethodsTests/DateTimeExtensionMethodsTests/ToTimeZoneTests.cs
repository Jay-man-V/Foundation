//-----------------------------------------------------------------------
// <copyright file="ToTimeZoneTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;

using Foundation.Common;

namespace Foundation.Tests.Unit.Foundation.Common.ExtensionMethodsTests.DateTimeExtensionMethodsTests
{
    /// <summary>
    /// The DateTime Extension tests
    ///
    /// Primary reasons for these tests is to determine when it is Midnight in Eastern Standard Time (New York)
    /// Time changes for 2023 are:
    /// US: Sun, Mar 12, 2023 2:00 AM - Sun, Nov 5, 2023 2:00 AM
    /// UK: Sun, Mar 26, 2023 1:00 AM - Sun, Oct 29, 2023 2:00 AM
    /// </summary>
    [TestFixture]
    public class ToTimeZoneTests
    {
        [TestCase("Eastern Standard Time", "2023-03-01 00:00:00", "2023-02-28 19:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 01:00:00", "2023-02-28 20:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 02:00:00", "2023-02-28 21:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 03:00:00", "2023-02-28 22:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 04:00:00", "2023-02-28 23:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 05:00:00", "2023-03-01 00:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 06:00:00", "2023-03-01 01:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 07:00:00", "2023-03-01 02:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 08:00:00", "2023-03-01 03:00:00")] // Input - US is in EST // Output UK is in GMT

        [TestCase("Eastern Standard Time", "2023-03-22 00:00:00", "2023-03-21 20:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 01:00:00", "2023-03-21 21:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 02:00:00", "2023-03-21 22:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 03:00:00", "2023-03-21 23:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 04:00:00", "2023-03-22 00:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 05:00:00", "2023-03-22 01:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 06:00:00", "2023-03-22 02:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 07:00:00", "2023-03-22 03:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 08:00:00", "2023-03-22 04:00:00")] // Input - US is in DST // Output UK is in GMT

        [TestCase("Eastern Standard Time", "2023-03-27 00:00:00", "2023-03-26 19:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 01:00:00", "2023-03-26 20:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 02:00:00", "2023-03-26 21:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 03:00:00", "2023-03-26 22:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 04:00:00", "2023-03-26 23:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 05:00:00", "2023-03-27 00:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 06:00:00", "2023-03-27 01:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 07:00:00", "2023-03-27 02:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 08:00:00", "2023-03-27 03:00:00")] // Input - US is in DST // Output UK is in BST

        [TestCase("Eastern Standard Time", "2023-10-30 00:00:00", "2023-10-29 20:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 01:00:00", "2023-10-29 21:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 02:00:00", "2023-10-29 22:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 03:00:00", "2023-10-29 23:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 04:00:00", "2023-10-30 00:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 05:00:00", "2023-10-30 01:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 06:00:00", "2023-10-30 02:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 07:00:00", "2023-10-30 03:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 08:00:00", "2023-10-30 04:00:00")] // Input - US is in EST // Output UK is in BST

        [TestCase("Central Europe Standard Time", "2023-10-30 04:00:00", "2023-10-30 05:00:00")] // Input - EU is in CET // Output UK is in BST
        public void Test_FromUkTime(String targetTimeZone, String inputDateTime, String outputDateTime)
        {
            DateTime localTime = DateTime.ParseExact(inputDateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime expected = DateTime.ParseExact(outputDateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            DateTime actualResult = localTime.ToTimeZone(targetTimeZone);

            Assert.That(actualResult, Is.EqualTo(expected));
        }

        [TestCase("Eastern Standard Time", "2023-03-01 00:00:00", "2023-02-28 19:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 01:00:00", "2023-02-28 20:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 02:00:00", "2023-02-28 21:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 03:00:00", "2023-02-28 22:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 04:00:00", "2023-02-28 23:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 05:00:00", "2023-03-01 00:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 06:00:00", "2023-03-01 01:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 07:00:00", "2023-03-01 02:00:00")] // Input - US is in EST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-01 08:00:00", "2023-03-01 03:00:00")] // Input - US is in EST // Output UK is in GMT

        [TestCase("Eastern Standard Time", "2023-03-22 00:00:00", "2023-03-21 20:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 01:00:00", "2023-03-21 21:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 02:00:00", "2023-03-21 22:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 03:00:00", "2023-03-21 23:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 04:00:00", "2023-03-22 00:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 05:00:00", "2023-03-22 01:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 06:00:00", "2023-03-22 02:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 07:00:00", "2023-03-22 03:00:00")] // Input - US is in DST // Output UK is in GMT
        [TestCase("Eastern Standard Time", "2023-03-22 08:00:00", "2023-03-22 04:00:00")] // Input - US is in DST // Output UK is in GMT

        [TestCase("Eastern Standard Time", "2023-03-27 00:00:00", "2023-03-26 20:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 01:00:00", "2023-03-26 21:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 02:00:00", "2023-03-26 22:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 03:00:00", "2023-03-26 23:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 04:00:00", "2023-03-27 00:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 05:00:00", "2023-03-27 01:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 06:00:00", "2023-03-27 02:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 07:00:00", "2023-03-27 03:00:00")] // Input - US is in DST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-03-27 08:00:00", "2023-03-27 04:00:00")] // Input - US is in DST // Output UK is in BST

        [TestCase("Eastern Standard Time", "2023-10-30 00:00:00", "2023-10-29 20:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 01:00:00", "2023-10-29 21:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 02:00:00", "2023-10-29 22:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 03:00:00", "2023-10-29 23:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 04:00:00", "2023-10-30 00:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 05:00:00", "2023-10-30 01:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 06:00:00", "2023-10-30 02:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 07:00:00", "2023-10-30 03:00:00")] // Input - US is in EST // Output UK is in BST
        [TestCase("Eastern Standard Time", "2023-10-30 08:00:00", "2023-10-30 04:00:00")] // Input - US is in EST // Output UK is in BST

        [TestCase("Central Europe Standard Time", "2023-10-30 04:00:00", "2023-10-30 05:00:00")] // Input - EU is in CET // Output UK is in BST
        public void Test_FromUkTime_Utc(String targetTimeZone, String inputDateTime, String outputDateTime)
        {
            DateTime localTime = DateTime.ParseExact(inputDateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            localTime = DateTime.SpecifyKind(localTime, DateTimeKind.Utc);
            DateTime expected = DateTime.ParseExact(outputDateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            DateTime actualResult = localTime.ToTimeZone(targetTimeZone);

            Assert.That(actualResult, Is.EqualTo(expected));
        }
    }
}
