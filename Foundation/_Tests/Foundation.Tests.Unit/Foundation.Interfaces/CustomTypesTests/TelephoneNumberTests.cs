//-----------------------------------------------------------------------
// <copyright file="TelephoneNumberTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Interfaces.CustomTypesTests
{
    /// <summary>
    /// Unit Tests for the Telephone Number type
    /// </summary>
    [TestFixture]
    public class TelephoneNumberTests : UnitTestBase
    {
        [TestCase]
        public void Test_Constructor_and_Properties()
        {
            Type thisType = typeof(TelephoneNumber);
            ConstructorInfo[] constructorInfos = thisType.GetConstructors();
            Assert.That(constructorInfos.Length, Is.EqualTo(1));

            TelephoneNumber telephoneNumber = new TelephoneNumber();

            Assert.That(telephoneNumber.Parsed, Is.EqualTo(false));
            Assert.That(telephoneNumber.Value, Is.EqualTo(null));
            Assert.That(telephoneNumber.LocalNumber, Is.EqualTo(null));
            Assert.That(telephoneNumber.AreaCode, Is.EqualTo(null));
            Assert.That(telephoneNumber.InternationalCode, Is.EqualTo(null));
        }

        [TestCase]
        public void Test_LandLine_UK()
        {
            String number = "020 8952 7219";

            TelephoneNumber telephoneNumber = new TelephoneNumber(number);

            Assert.That(telephoneNumber.Parsed, Is.EqualTo(false));
            Assert.That(telephoneNumber.Value, Is.EqualTo(number));
            Assert.That(telephoneNumber.LocalNumber, Is.EqualTo(String.Empty));
            Assert.That(telephoneNumber.AreaCode, Is.EqualTo(String.Empty));
            Assert.That(telephoneNumber.InternationalCode, Is.EqualTo(String.Empty));
        }

        [TestCase]
        public void Test_ToString()
        {
            String number = "020 8952 7219";

            TelephoneNumber telephoneNumber = new TelephoneNumber(number);

            Assert.That(telephoneNumber.ToString(), Is.EqualTo(number));
        }
    }
}
