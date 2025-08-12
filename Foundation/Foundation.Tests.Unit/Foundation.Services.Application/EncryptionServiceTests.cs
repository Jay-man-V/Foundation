//-----------------------------------------------------------------------
// <copyright file="EncryptionServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text;

using Foundation.Interfaces;
using Foundation.Services.Application;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    public class EncryptionServiceTests : UnitTestBase
    {
        private const string Password = "tHiSiSmYpAsSwOrD!£$%^";
        private static Byte[] Salt => Encoding.UTF8.GetBytes(Password);

        private const String SourceValueString = "AbCdEfGhIjKlMnOpQrStUvWxYz1234567980!£$%^&*()_+";
        private Byte[] SourceValueBytes => Encoding.UTF8.GetBytes(SourceValueString);

        private IEncryptionService? TheService { get; set; }

        protected override void StartTest()
        {
            base.StartTest();

            TheService = new EncryptionService();
        }

        [Test]
        public void Test_GenerateSalt_RepeatedCalls()
        {
            Byte[] salt1 = TheService!.GenerateSalt();
            Byte[] salt2 = TheService!.GenerateSalt();

            Byte[] saltCopy = salt1.ToArray();

            Assert.That(salt1, Is.EqualTo(saltCopy));
            Assert.That(salt1, Is.Not.EqualTo(salt2));
        }
    }
}