//-----------------------------------------------------------------------
// <copyright file="RandomServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Services.Application;
using Foundation.Tests.Unit.Support;

using NUnit.Framework;

using System;
using Foundation.Resources;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    /// <summary>
    /// The Random Tests
    /// </summary>
    [TestFixture]
    public class RandomServicesTests : UnitTestBase
    {
        private IRandomService? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheService = new RandomService();
        }

        public override void TestCleanup()
        {
            TheService = null;

            base.TestCleanup();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_NextInt32()
        {
            Int32 aNumber1 = TheService!.RandomInt32();
            Int32 aNumber2 = TheService!.RandomInt32();
            Assert.That(aNumber2, Is.Not.EqualTo(aNumber1));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_NextInt32_MaxValue()
        {
            Int32 maxValue = 100;
            Int32 aNumber1 = TheService!.RandomInt32(maxValue);
            Assert.That(aNumber1 <= maxValue);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_NextInt32_Min_MaxValue()
        {
            Int32 minValue = 50;
            Int32 maxValue = 100;
            Int32 aNumber1 = TheService!.RandomInt32(minValue, maxValue);

            Assert.That(aNumber1 >= minValue);
            Assert.That(aNumber1 <= maxValue);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_NextInt32_Negative_Min_MaxValue()
        {
            Int32 minValue = -100;
            Int32 maxValue = -50;
            Int32 aNumber1 = TheService!.RandomInt32(minValue, maxValue);

            Assert.That(aNumber1 >= minValue);
            Assert.That(aNumber1 <= maxValue);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_SimpleRandomString()
        {
            String aString1 = TheService!.SimpleRandomString(10, CharacterCodes.AlphaNumeric);
            String aString2 = TheService!.SimpleRandomString(10, CharacterCodes.AlphaNumeric);
            Assert.That(aString2, Is.Not.EqualTo(aString1));

            String aString3 = TheService!.SimpleRandomString(1000, CharacterCodes.AlphaNumeric);
            String aString4 = TheService!.SimpleRandomString(1000, CharacterCodes.AlphaNumeric);
            Assert.That(aString4, Is.Not.EqualTo(aString3));

            String aString5 = TheService!.SimpleRandomString(15, CharacterCodes.AllChars);
            String aString6 = TheService!.SimpleRandomString(15, CharacterCodes.AllChars);
            Assert.That(aString6, Is.Not.EqualTo(aString5));

            String aString7 = TheService!.SimpleRandomString(200, CharacterCodes.AlphaUpperCaseOnly);
            String aString8 = TheService!.SimpleRandomString(200, CharacterCodes.AlphaUpperCaseOnly);
            Assert.That(aString8, Is.Not.EqualTo(aString7));

            String aString9 = TheService!.SimpleRandomString(200, CharacterCodes.AlphaLowerCaseOnly);
            String aString10 = TheService!.SimpleRandomString(200, CharacterCodes.AlphaLowerCaseOnly);
            Assert.That(aString10, Is.Not.EqualTo(aString9));

            String aString11 = TheService!.SimpleRandomString(200, CharacterCodes.NonAlphaChars);
            String aString12 = TheService!.SimpleRandomString(200, CharacterCodes.NonAlphaChars);
            Assert.That(aString12, Is.Not.EqualTo(aString11));
        }
    }
}
