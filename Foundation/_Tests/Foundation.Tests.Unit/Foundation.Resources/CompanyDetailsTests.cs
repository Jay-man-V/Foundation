//-----------------------------------------------------------------------
// <copyright file="CompanyDetailsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Drawing;
using System.Reflection;

using Foundation.Common;
using Foundation.Resources;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Resources
{
    /// <summary>
    /// Unit Tests for the Company Details class
    /// </summary>
    [TestFixture]
    public class CompanyDetailsTests : UnitTestBase
    {
        [TestCase]
        public void Test_CountMembers()
        {
            IEnumerable<MethodInfo> testMethods = GetListOfTestMethods();
            Int32 testMethodCount = testMethods.Count();

            // This test exists to ensure all the Properties are tested/checked in the next test
            Type theType = typeof(CompanyDetails);
            PropertyInfo[] propertyInfos = theType.GetProperties();

            Assert.That(propertyInfos.Length, Is.EqualTo(testMethodCount - 1));

            Int32 index = 0;
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CompanyDetails.Name)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CompanyDetails.RegisteredNumber)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CompanyDetails.VatNumber)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CompanyDetails.WebSite)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(CompanyDetails.CompanyLogo)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        [TestCase]
        public void Test_Name()
        {
            String expected = "JDV Software Ltd";
            String actual = CompanyDetails.Name;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_RegisteredNumber()
        {
            String expected = String.Empty;
            String actual = CompanyDetails.RegisteredNumber;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_VatNumber()
        {
            String expected = String.Empty;
            String actual = CompanyDetails.VatNumber;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_WebSite()
        {
            String expected = "http://www.jdvsoftware.co.uk";
            String actual = CompanyDetails.WebSite;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        [DeploymentItem(@".ExpectedResults\Foundation.Resources\Images\Logos\JDV Software Logo.png", @".ExpectedResults\Foundation.Resources\Images\Logos\")]
        public void Test_CompanyLogo()
        {
            Image expectedLogo = Image.FromFile(@".ExpectedResults\Foundation.Resources\Images\Logos\JDV Software Logo.png");
            Byte[] expectedByteArray = expectedLogo.ToByteArray();
            Image actual = CompanyDetails.CompanyLogo;
            Byte[] actualByteArray = actual.ToByteArray();

            Assert.That(actualByteArray, Is.EquivalentTo(expectedByteArray));
        }
    }
}
