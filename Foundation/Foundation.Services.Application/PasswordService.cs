//-----------------------------------------------------------------------
// <copyright file="PasswordService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Newtonsoft.Json;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <ineritdoc cref="IPasswordService" />
    [DependencyInjectionTransient]
    public class PasswordService : IPasswordService
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="PasswordService"/> class.
        /// </summary>
        /// <param name="core"></param>
        /// <param name="applicationConfigurationProcess"></param>
        /// <param name="restApi"></param>
        /// <param name="randomService"></param>
        public PasswordService
        (
            ICore core,
            IApplicationConfigurationProcess applicationConfigurationProcess,
            IRestApi restApi,
            IRandomService randomService
        )
        {
            LoggingHelpers.TraceCallEnter(core, applicationConfigurationProcess, restApi);

            Core = core;
            ApplicationConfigurationProcess = applicationConfigurationProcess;
            RestApi = restApi;
            RandomService = randomService;

            LoggingHelpers.TraceCallReturn();
        }

        private ICore Core { get; }
        private IApplicationConfigurationProcess ApplicationConfigurationProcess { get; }
        private IRestApi RestApi { get; }
        private IRandomService RandomService { get; }

        private String RandomPasswordRuleLengthKey => "service.generator.password.rule.length";
        private String RandomPasswordRuleLengthDefaultValue => "10";
        private String RandomPasswordRuleCountKey => "service.generator.password.rule.count";
        private String RandomPasswordRuleCountDefaultValue => "3";
        private String RandomPasswordGenerateUrlKey => "service.generator.password.random.url";
        private String MemorablePasswordGenerateUrlKey => "service.generator.password.memorable.url";

        /// <inheritdoc cref="IPasswordService.GeneratePassword()"/>
        public String GeneratePassword()
        {
            LoggingHelpers.TraceCallEnter();

            String retVal;

            String[] randomWords = GenerateMultiplePasswords();

            Int32 maxValues = randomWords.Length;

            Int32 index = RandomService.NextInt32(0, maxValues);

            retVal = randomWords[index];

            LoggingHelpers.TraceCallEnter(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IPasswordService.GenerateMultiplePasswords()"/>
        public String[] GenerateMultiplePasswords()
        {
            LoggingHelpers.TraceCallEnter();

            String[]? retVal;

            // https://random-word-api.herokuapp.com/home

            String passwordLengthValue = ApplicationConfigurationProcess.Get(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, RandomPasswordRuleLengthKey, RandomPasswordRuleLengthDefaultValue);
            String passwordCountValue = ApplicationConfigurationProcess.Get(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, RandomPasswordRuleCountKey, RandomPasswordRuleCountDefaultValue);
            String passwordGeneratorUrl = ApplicationConfigurationProcess.Get<String>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, RandomPasswordGenerateUrlKey);
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
    }
}
