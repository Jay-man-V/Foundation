//-----------------------------------------------------------------------
// <copyright file="EncryptionServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text;

using NSubstitute;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Services.Application;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    public class EncryptionServiceTests : UnitTestBase
    {
        private const String Password = "tHiSiSmYpAsSwOrD!£$%^";

        private const String SourceValueString = "AbCdEfGhIjKlMnOpQrStUvWxYz1234567980!£$%^&*()_+";
        private Byte[] SourceValueBytes => Encoding.UTF8.GetBytes(SourceValueString);
        private String OutputFolder => Path.Combine(BaseTemporaryOutputsPath, LocationUtils.GetClassName());

        private IEncryptionService? TheService { get; set; }
        private IFileApi FileApi { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            FileApi = Substitute.For<IFileApi>();

            TheService = new EncryptionService(FileApi);
        }

        public override void TestCleanup()
        {
            TheService = null;

            base.TestCleanup();
        }

        [TestCase]
        public void Test_GenerateSalt_RepeatedCalls()
        {
            Byte[] salt1 = TheService!.GenerateSalt();
            Byte[] salt2 = TheService!.GenerateSalt();

            Byte[] saltCopy = salt1.ToArray();

            Assert.That(salt1, Is.EqualTo(saltCopy));
            Assert.That(salt1, Is.Not.EqualTo(salt2));
        }

        [TestCase]
        public void Test_GenerateKeys()
        {
            Byte[] salt1 = TheService!.GenerateSalt();
            TheService!.GenerateKeys(Password, salt1, out Byte[] key1, out Byte[] iv1);

            Assert.That(key1, Is.Not.Null);
            Assert.That(iv1, Is.Not.Null);

            Byte[] salt2 = TheService!.GenerateSalt();

            TheService!.GenerateKeys(Password, salt2, out Byte[] key2, out Byte[] iv2);

            Assert.That(key2, Is.Not.Null);
            Assert.That(iv2, Is.Not.Null);

            Assert.That(key1, Is.Not.EqualTo(key2));
            Assert.That(iv1, Is.Not.EqualTo(iv2));
        }

        [TestCase]
        public void Test_GenerateKeys_Exception()
        {
            String parameterName = "salt";
            String errorMessage = $"Value cannot be null. (Parameter '{parameterName}')";
            ArgumentNullException actualException = Assert.Throws<ArgumentNullException>(() =>
            {
                const Byte[]? salt1 = null;
                TheService!.GenerateKeys(Password, salt1, out Byte[] _, out Byte[] _);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
            Assert.That(actualException.ParamName, Is.EqualTo(parameterName));
        }

        [TestCase]
        public void Test_GenerateKeys_SaveToFolder_WithSalt()
        {
            String keyName = $"{LocationUtils.GetFunctionName()} - {Guid.NewGuid()}";

            Directory.CreateDirectory(OutputFolder);

            Byte[] salt1 = TheService!.GenerateSalt();

            TheService!.GenerateKeys(OutputFolder, keyName, Password, salt1);

            Boolean keyExists = File.Exists(Path.Combine(OutputFolder, $"{keyName}.key"));
            Boolean ivExists = File.Exists(Path.Combine(OutputFolder, $"{keyName}.iv"));

            Assert.That(keyExists, Is.EqualTo(true));
            Assert.That(ivExists, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_GenerateKeys_SaveToFolder_NoSalt()
        {
            String keyName = $"{LocationUtils.GetFunctionName()} - {Guid.NewGuid()}";

            Directory.CreateDirectory(OutputFolder);

            TheService!.GenerateKeys(OutputFolder, keyName, Password);

            Boolean keyExists = File.Exists(Path.Combine(OutputFolder, $"{keyName}.key"));
            Boolean ivExists = File.Exists(Path.Combine(OutputFolder, $"{keyName}.iv"));

            Assert.That(keyExists, Is.EqualTo(true));
            Assert.That(ivExists, Is.EqualTo(true));
        }

        [TestCase]
        public void Test_EncryptData_String()
        {
            Byte[] salt1 = TheService!.GenerateSalt();
            TheService!.GenerateKeys(Password, salt1, out Byte[] key1, out Byte[] iv1);

             String encryptedData = TheService!.EncryptData(key1, iv1, SourceValueString);

             Assert.That(encryptedData, Is.Not.Empty);
             Assert.That(encryptedData, Is.Not.EqualTo(SourceValueString));

             String decryptedData = TheService!.DecryptData(key1, iv1, encryptedData);

             Assert.That(decryptedData, Is.EqualTo(SourceValueString));
        }

        [TestCase]
        public void Test_EncryptData_ByteArray()
        {
            Byte[] salt1 = TheService!.GenerateSalt();
            TheService!.GenerateKeys(Password, salt1, out Byte[] key1, out Byte[] iv1);

            Byte[] encryptedData = TheService!.EncryptData(key1, iv1, SourceValueBytes);

            Assert.That(encryptedData, Is.Not.Empty);
            Assert.That(encryptedData, Is.Not.EqualTo(SourceValueBytes));

            Byte[] decryptedData = TheService!.DecryptData(key1, iv1, encryptedData);

            Assert.That(decryptedData, Is.EqualTo(SourceValueBytes));
        }

        [TestCase]
        public void Test_EncryptData_FileBasedKeys_String()
        {
            String keyName = $"{LocationUtils.GetFunctionName()} - {Guid.NewGuid()}";

            Directory.CreateDirectory(OutputFolder);

            TheService!.GenerateKeys(OutputFolder, keyName, Password);

            String encryptedData = TheService!.EncryptData(OutputFolder, keyName, SourceValueString);

            Assert.That(encryptedData, Is.Not.Empty);
            Assert.That(encryptedData, Is.Not.EqualTo(SourceValueString));

            String decryptedData = TheService!.DecryptData(OutputFolder, keyName, encryptedData);

            Assert.That(decryptedData, Is.EqualTo(SourceValueString));
        }

        [TestCase]
        public void Test_EncryptData_FileBasedKeys_ByteArray()
        {
            String keyName = $"{LocationUtils.GetFunctionName()} - {Guid.NewGuid()}";

            Directory.CreateDirectory(OutputFolder);

            TheService!.GenerateKeys(OutputFolder, keyName, Password);

            Byte[] encryptedData = TheService!.EncryptData(OutputFolder, keyName, SourceValueBytes);

            Assert.That(encryptedData, Is.Not.Empty);
            Assert.That(encryptedData, Is.Not.EqualTo(SourceValueBytes));

            Byte[] decryptedData = TheService!.DecryptData(OutputFolder, keyName, encryptedData);

            Assert.That(decryptedData, Is.EqualTo(SourceValueBytes));
        }
    }
}