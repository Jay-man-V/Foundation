//-----------------------------------------------------------------------
// <copyright file="CompanyDetails.HeadOfficeTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Resources;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Resources
{
    /// <summary>
    /// Unit Tests for the Company Details Head Office class
    /// </summary>
    [TestFixture]
    public class CompanyDetailsHeadOfficeTests : UnitTestBase
    {
        [TestCase]
        public void Test_CountMembers()
        {
            IEnumerable<MethodInfo> testMethods = GetListOfTestMethods();
            Int32 testMethodCount = testMethods.Count();

            // This test exists to ensure all the Properties are tested/checked in the next test
            Type theType = typeof(CompanyDetails.HeadOffice);
            PropertyInfo[] propertyInfos = theType.GetProperties();

            Assert.That(propertyInfos.Length, Is.EqualTo(testMethodCount - 1));

            Int32 index = 0;
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CompanyDetails.HeadOffice.ContactTelephone)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CompanyDetails.HeadOffice.Address)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CompanyDetails.HeadOffice.AddressWithCountry)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CompanyDetails.HeadOffice.WhatThreeWords)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CompanyDetails.HeadOffice.LatitudeLongitudeCoordinates)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        [TestCase]
        public void Test_ContactTelephone()
        {
            String expected = "+44 (0) 7466 489 027";
            String actual = CompanyDetails.HeadOffice.ContactTelephone;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Address()
        {
            String expected = String.Empty;
            expected += "56 Buckingham Road" + Environment.NewLine;
            expected += "Edgware" + Environment.NewLine;
            expected += "Middlesex" + Environment.NewLine;
            expected += "HA8 6LZ" + Environment.NewLine;

            String actual = CompanyDetails.HeadOffice.Address;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_AddressWithCountry()
        {
            String expected = String.Empty;
            expected += "56 Buckingham Road" + Environment.NewLine;
            expected += "Edgware" + Environment.NewLine;
            expected += "Middlesex" + Environment.NewLine;
            expected += "HA8 6LZ" + Environment.NewLine;
            expected += "England" + Environment.NewLine;

            String actual = CompanyDetails.HeadOffice.AddressWithCountry;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_WhatThreeWords()
        {
            String expected = "tones.civic.vine";

            String actual = CompanyDetails.HeadOffice.WhatThreeWords;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_GPSCoordinates()
        {
            String expected = "51.60774,-0.28391";

            String actual = CompanyDetails.HeadOffice.LatitudeLongitudeCoordinates;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
