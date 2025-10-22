//-----------------------------------------------------------------------
// <copyright file="ApplicationConfigurationService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <ineritdoc cref="IApplicationConfigurationService" />
    [DependencyInjectionTransient]
    public class ApplicationConfigurationService : ServiceBase, IApplicationConfigurationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository">The data access.</param>
        /// <param name="encryptionService">The encryption service</param>
        public ApplicationConfigurationService
        (
            IApplicationConfigurationRepository repository,
            IEncryptionService encryptionService
        ) : 
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter(repository);

            Repository = repository;
            EncryptionService = encryptionService;

            LoggingHelpers.TraceCallReturn();
        }
        private IApplicationConfigurationRepository Repository { get; }
        private IEncryptionService EncryptionService { get; }

        /// <inheritdoc cref="IApplicationConfigurationService.SetValue{TValue}(AppId, IUserProfile, ConfigurationScope, String, TValue)"/>
        public void SetValue<TValue>(AppId applicationId, IUserProfile userProfile, ConfigurationScope configurationScope, String key, TValue newValue)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile, configurationScope, key, newValue);

            String valueToSave = SerialisationHelpers.Serialise(newValue);

            Repository.SetValue(applicationId, userProfile, configurationScope, key, valueToSave);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IApplicationConfigurationService.Get{TValue}(AppId, IUserProfile, String)"/>
        public TValue Get<TValue>(AppId applicationId, IUserProfile userProfile, String key)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile, key);

            IApplicationConfiguration? applicationConfiguration = Repository.Get(applicationId, userProfile, key);

            if (applicationConfiguration == null)
            {
                String errorMessage = $"Configuration value with Key '{key}' for application id '{applicationId.TheAppId}' not found. Null value retrieved from database.";
                throw new NullValueException(errorMessage);
            }

            if (applicationConfiguration.Value == null)
            {
                String errorMessage = $"Configuration value with Key '{key}' for application id '{applicationId.TheAppId}' is null. Null value retrieved from database.";
                throw new NullValueException(errorMessage);
            }

            String? loadedValue = applicationConfiguration.Value.ToString();

            if (applicationConfiguration.IsEncrypted)
            {
                loadedValue = EncryptionService.DecryptData(key, loadedValue);
            }

            TValue retVal = SerialisationHelpers.Deserialise<TValue>(loadedValue);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IApplicationConfigurationService.Get{TValue}(AppId, IUserProfile, String, TValue)"/>
        public TValue Get<TValue>(AppId applicationId, IUserProfile userProfile, String key, TValue defaultValue)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile, key, defaultValue);

            IApplicationConfiguration? applicationConfiguration = Repository.Get(applicationId, userProfile, key);

            TValue retVal = defaultValue;

            if (applicationConfiguration is not { Value: not null })
            {
                String message = $"Configuration value with Key '{key}' for application id '{applicationId.TheAppId}' not found, using default value '{defaultValue}'";
                LoggingHelpers.LogWarningMessage(message);
            }
            else
            {
                String? loadedValue = applicationConfiguration.Value.ToString();

                if (applicationConfiguration.IsEncrypted)
                {
                    loadedValue = EncryptionService.DecryptData(key, loadedValue);
                }

                retVal = SerialisationHelpers.Deserialise<TValue>(loadedValue);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IApplicationConfigurationService.GetGroupValues(AppId, IUserProfile, String)"/>
        public List<IApplicationConfiguration> GetGroupValues(AppId applicationId, IUserProfile userProfile, String key)
        {
            LoggingHelpers.TraceCallEnter(userProfile, applicationId, key);

            List<IApplicationConfiguration> retVal = Repository.GetGroupValues(applicationId, userProfile, key);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
