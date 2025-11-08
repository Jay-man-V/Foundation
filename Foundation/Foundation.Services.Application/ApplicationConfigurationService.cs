//-----------------------------------------------------------------------
// <copyright file="ApplicationConfigurationService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.IO;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.Services.Application
{
    /// <ineritdoc cref="IApplicationConfigurationService" />
    [DependencyInjectionTransient]
    public class ApplicationConfigurationService : ServiceBase, IApplicationConfigurationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="core">The Foundation Core Service.</param>
        /// <param name="repository">The data access.</param>
        /// <param name="encryptionService">The encryption service</param>
        public ApplicationConfigurationService
        (
            ICore core,
            IApplicationConfigurationRepository repository,
            IEncryptionService encryptionService
        ) : 
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter(core, repository, encryptionService);

            Core = core;
            Repository = repository;
            EncryptionService = encryptionService;

            LoggingHelpers.TraceCallReturn();
        }

        private ICore Core { get; }
        private IApplicationConfigurationRepository Repository { get; }
        internal IEncryptionService EncryptionService { get; }

        /// <inheritdoc cref="IApplicationConfigurationService.UserDataPath"/>
        public String UserDataPath
        {
            get
            {
                String configuredUserDataPath = Get<String>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.UserDataPath);

                String retVal = configuredUserDataPath;
                if (!retVal.Trim().EndsWith(Path.DirectorySeparatorChar))
                {
                    retVal += Path.DirectorySeparatorChar;
                }

                return retVal;
            }
        }

        /// <inheritdoc cref="IApplicationConfigurationService.SystemDataPath"/>
        public String SystemDataPath
        {
            get
            {
                String configuredSystemDataPath = Get<String>(Core.ApplicationId, Core.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.SystemDataPath);

                String retVal = configuredSystemDataPath;
                if (!retVal.Trim().EndsWith(Path.DirectorySeparatorChar))
                {
                    retVal += Path.DirectorySeparatorChar;
                }

                return retVal;
            }
        }

        /// <inheritdoc cref="IApplicationConfigurationService.SetValue{TValue}(AppId, IUserProfile, ConfigurationScope, String, Boolean, TValue)"/>
        public void SetValue<TValue>(AppId applicationId, IUserProfile userProfile, ConfigurationScope configurationScope, String key, Boolean isEncrypted, TValue newValue)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile, configurationScope, key, newValue);

            String valueToSave = SerialisationHelpers.Serialise(newValue);

            if (isEncrypted)
            {
                valueToSave = EncryptionService.EncryptData(key, valueToSave);
            }

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

            if (String.IsNullOrEmpty(loadedValue))
            {
                String errorMessage = $"Configuration value with Key '{key}' for application id '{applicationId.TheAppId}' could not be read as a string.";
                throw new NullValueException(errorMessage);
            }

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
                    loadedValue = EncryptionService.DecryptData(key, loadedValue!); // Null check is above
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
