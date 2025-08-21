//-----------------------------------------------------------------------
// <copyright file="PasswordGeneratorService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

using Newtonsoft.Json;

using System.Security.Cryptography;
using System.Text;

namespace Foundation.Services.Application
{
    /// <ineritdoc cref="IPasswordGeneratorService" />
    [DependencyInjectionTransient]
    public class PasswordGeneratorService : ServiceBase, IPasswordGeneratorService
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="PasswordGeneratorService"/> class.
        /// </summary>
        /// <param name="core"></param>
        /// <param name="applicationConfigurationService"></param>
        /// <param name="restApi"></param>
        /// <param name="randomService"></param>
        public PasswordGeneratorService
        (
            ICore core,
            IApplicationConfigurationService applicationConfigurationService,
            IRestApi restApi,
            IRandomService randomService
        ) :
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter(core, applicationConfigurationService, restApi);

            Core = core;
            ApplicationConfigurationService = applicationConfigurationService;
            RestApi = restApi;
            RandomService = randomService;

            LoggingHelpers.TraceCallReturn();
        }

        private ICore Core { get; }
        private IApplicationConfigurationService ApplicationConfigurationService { get; }
        private IRestApi RestApi { get; }
        private IRandomService RandomService { get; }

        private String RandomPasswordRuleLengthKey => "service.generator.password.rule.length";
        private String RandomPasswordRuleLengthDefaultValue => "10";
        private String RandomPasswordRuleCountKey => "service.generator.password.rule.count";
        private String RandomPasswordRuleCountDefaultValue => "3";
        private String RandomPasswordGenerateUrlKey => "service.generator.password.random.url";
        private String MemorablePasswordGenerateUrlKey => "service.generator.password.memorable.url";

        /// <inheritdoc cref="IPasswordGeneratorService.GeneratePassword()"/>
        public String GeneratePassword()
        {
            LoggingHelpers.TraceCallEnter();

            String retVal;

            String[] randomWords = GenerateMultiplePasswords();

            Int32 maxValues = randomWords.Length;

            Int32 index = RandomService.RandomInt32(0, maxValues);

            retVal = randomWords[index];

            LoggingHelpers.TraceCallEnter(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IPasswordGeneratorService.GenerateMultiplePasswords()"/>
        public String[] GenerateMultiplePasswords()
        {
            LoggingHelpers.TraceCallEnter();

            String[]? retVal;

            // https://random-word-api.herokuapp.com/home

            String passwordLengthValue = ApplicationConfigurationService.Get(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, RandomPasswordRuleLengthKey, RandomPasswordRuleLengthDefaultValue);
            String passwordCountValue = ApplicationConfigurationService.Get(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, RandomPasswordRuleCountKey, RandomPasswordRuleCountDefaultValue);
            String passwordGeneratorUrl = ApplicationConfigurationService.Get<String>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, RandomPasswordGenerateUrlKey);
            passwordGeneratorUrl = String.Format(passwordGeneratorUrl, passwordLengthValue, passwordCountValue);

            IFileTransferSettings fileTransferSettings = new FileTransferSettings();
            fileTransferSettings.Location = passwordGeneratorUrl;
            fileTransferSettings.Credentials = null;
            fileTransferSettings.FileTransferMethod = FileTransferMethod.Rest;

            String jsonString = RestApi.DownloadString(fileTransferSettings);

            retVal = JsonConvert.DeserializeObject<String[]>(jsonString);

            if (retVal == null)
            {
                String message = $"Unable to generate random passwords using {RandomPasswordGenerateUrlKey} service";
                throw new InvalidOperationException(message);
            }

            LoggingHelpers.TraceCallEnter($"{nameof(retVal)} not logged");

            return retVal;
        }

        /// <inheritdoc cref="IPasswordGeneratorService.RandomCharacterPassword(Int32, String)"/>
        public String RandomCharacterPassword(Int32 length, String validCharacters)
        {
            LoggingHelpers.TraceCallEnter(length, validCharacters);

            StringBuilder retVal = new StringBuilder(length);
            using (RandomNumberGenerator cryptoServiceProvider = RandomNumberGenerator.Create())
            {
                Int32 count = (Int32)Math.Ceiling(Math.Log(validCharacters.Length, 2) / 8.0);
                Int32 offset = BitConverter.IsLittleEndian ? 0 : sizeof(UInt32) - count;
                Int32 max = (Int32)(Math.Pow(2, count * 8) / validCharacters.Length) * validCharacters.Length;
                Byte[] uintBuffer = new Byte[sizeof(UInt32)];

                cryptoServiceProvider.GetBytes(uintBuffer, offset, count);
                UInt32 lastNum = BitConverter.ToUInt32(uintBuffer, 0);
                while (retVal.Length < length)
                {
                    cryptoServiceProvider.GetBytes(uintBuffer, offset, count);
                    UInt32 num = BitConverter.ToUInt32(uintBuffer, 0);

                    // num must be outside the range of the last num +/- 3 to avoid potential consecutive or closeness of characters
                    Boolean isAcceptable = !lastNum.IsBetween(num - 3, num + 3);

                    if (isAcceptable &&
                        num < max)
                    {
                        retVal.Append(validCharacters[(Int32)(num % validCharacters.Length)]);
                        lastNum = num;
                    }
                }
            }

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal.ToString();
        }
    }
}
