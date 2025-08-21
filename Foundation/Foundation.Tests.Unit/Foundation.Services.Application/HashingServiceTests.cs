//-----------------------------------------------------------------------
// <copyright file="HashingUtilsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Text;

using Foundation.Interfaces;
using Foundation.Services.Application;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    /// <summary>
    /// The Hashing Tests
    /// </summary>
    [TestFixture]
    public class HashingServiceTests : UnitTestBase
    {
        private const String SourceValueString = "AbCdEfGhIjKlMnOpQrStUvWxYz1234567980!£$%^&*()_+";

        private readonly Byte[] _sourceValueBytes = Encoding.UTF8.GetBytes(SourceValueString);

        private IHashingService? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheService = new HashingService();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_GenerateSalt_RepeatedCalls_Default()
        {
            Byte[] salt1 = TheService!.GenerateSalt();
            Byte[] salt2 = TheService!.GenerateSalt();

            Debug.WriteLine("salt1 -> " + ByteArrayToStringRepresentationForCode(salt1));
            Debug.WriteLine("salt2 -> " + ByteArrayToStringRepresentationForCode(salt2));

            Assert.That(salt2, Is.Not.EquivalentTo(salt1));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_GenerateSalt_RepeatedCalls_SmallSize()
        {
            Byte[] salt1 = TheService!.GenerateSalt(8);
            Byte[] salt2 = TheService!.GenerateSalt(8);

            Assert.That(salt2, Is.Not.EquivalentTo(salt1));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_GenerateHash_String()
        {
            String expectedValue = "c8e7fb972ae30e2b8c0a6fc72be782829fbd35f878fc364d18716460543214d03e6dac9182f607441a7ce082facdfb89";
            String actualValue = TheService!.GenerateHash(SourceValueString, _sourceValueBytes);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        public void Test_GenerateHash_Bytes()
        {
            Byte[] expectedValue = { 200, 231, 251, 151, 42, 227, 14, 43, 140, 10, 111, 199, 43, 231, 130, 130, 159, 189, 53, 248, 120, 252, 54, 77, 24, 113, 100, 96, 84, 50, 20, 208, 62, 109, 172, 145, 130, 246, 7, 68, 26, 124, 224, 130, 250, 205, 251, 137 };
            Byte[] actualValue = TheService!.GenerateHash(_sourceValueBytes, _sourceValueBytes);

            Assert.That(actualValue, Is.EquivalentTo(expectedValue));
        }
    }
}
