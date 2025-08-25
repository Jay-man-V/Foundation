//-----------------------------------------------------------------------
// <copyright file="PasswordServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Resources;
using Foundation.Services.Application;

using Foundation.Tests.Unit.Support;
using NSubstitute.ClearExtensions;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    /// <summary>
    /// UnitTests for PasswordService
    /// </summary>
    [TestFixture]
    public class PasswordServiceTests : UnitTestBase
    {
        private IPasswordGeneratorService? TheService { get; set; }
        private IRestApi? RestApi { get; set; }
        private IRandomService? RandomService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            RestApi = Substitute.For<IRestApi>();
            RandomService = Substitute.For<IRandomService>();

            TheService = new PasswordGeneratorService(CoreInstance, ApplicationConfigurationService, RestApi, RandomService);
        }

        [TestCase]
        public void Test_GeneratePassword()
        {
            String expectedPassword = "Password1";
            String expectedPasswords = "[\"Password1\",\"Password2\",\"Password3\"]";

            RestApi!.DownloadString(Arg.Any<IFileTransferSettings>()).Returns(expectedPasswords);
            RandomService!.RandomInt32(Arg.Any<Int32>(), Arg.Any<Int32>()).Returns(1);

            String actual = TheService!.GeneratePassword();

            Assert.That(actual, Is.Not.EqualTo(expectedPassword));
        }

        [TestCase]
        public void Test_GenerateMultiplePasswords()
        {
            String expectedPasswords = "[\"Password1\",\"Password2\",\"Password3\"]";

            RestApi!.DownloadString(Arg.Any<IFileTransferSettings>()).Returns(expectedPasswords);

            String actual = TheService!.GeneratePassword();

            Assert.That(actual, Is.Not.EqualTo(expectedPasswords));
        }

        [TestCase]
        public void Test_GenerateMultiplePasswords_Exception()
        {
            String passwordGenerateUrl = "https://random-word-api.herokuapp.com/home";
            String randomPasswordGenerateUrlKey = "service.generator.password.random.url";
            String errorMessage = $"Unable to generate random passwords using '{randomPasswordGenerateUrlKey}' '({passwordGenerateUrl})' service";
            InvalidOperationException? actualException = null;

            RestApi!.ClearSubstitute();

            ApplicationConfigurationService.Get<String>(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), randomPasswordGenerateUrlKey).Returns(passwordGenerateUrl);

            try
            {
                _ = TheService!.GenerateMultiplePasswords();
            }
            catch (InvalidOperationException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));

            String actualErrorMessage = actualException.Message;

            Assert.That(actualErrorMessage, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_RandomPassword()
        {
            String password1 = TheService!.RandomCharacterPassword(10, CharacterCodes.AlphaNumeric);
            String password2 = TheService!.RandomCharacterPassword(10, CharacterCodes.AlphaNumeric);
            Assert.That(password2, Is.Not.EqualTo(password1));

            String password3 = TheService!.RandomCharacterPassword(1000, CharacterCodes.AlphaNumeric);
            String password4 = TheService!.RandomCharacterPassword(1000, CharacterCodes.AlphaNumeric);
            Assert.That(password4, Is.Not.EqualTo(password3));

            String password5 = TheService!.RandomCharacterPassword(15, CharacterCodes.AlphaNumeric);
            String password6 = TheService!.RandomCharacterPassword(15, CharacterCodes.AlphaNumeric);
            Assert.That(password6, Is.Not.EqualTo(password5));

            String password7 = TheService!.RandomCharacterPassword(20, CharacterCodes.AllChars);
            String password8 = TheService!.RandomCharacterPassword(20, CharacterCodes.AllChars);
            Assert.That(password7, Is.Not.EqualTo(password8));
        }
    }
}
