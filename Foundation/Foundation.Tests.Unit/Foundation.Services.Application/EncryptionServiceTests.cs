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

        private const string SourceValueString = "AbCdEfGhIjKlMnOpQrStUvWxYz1234567980!£$%^&*()_+";
        private Byte[] SourceValueBytes => Encoding.UTF8.GetBytes(SourceValueString);

        private IEncryptionService? TheService { get; set; }

        protected override void StartTest()
        {
            base.StartTest();

            TheService = new EncryptionService();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}