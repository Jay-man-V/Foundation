//-----------------------------------------------------------------------
// <copyright file="IApplicationConfigurationService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Application Configuration service
    /// </summary>
    public interface IApplicationConfigurationService
    {
        /// <summary>
        /// Saves the <paramref name="newValue"/> to the repository and converting to a <see cref="String"/> where required
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="userProfile">The user profile.</param>
        /// <param name="configurationScope">The configuration scope.</param>
        /// <param name="key">Name of the key.</param>
        /// <param name="isEncrypted">Whether the <paramref name="newValue"/> is to be encrypted</param>
        /// <param name="newValue">The new value to be saved to the repository</param>
        /// <returns></returns>
        void SetValue<TValue>(AppId applicationId, IUserProfile userProfile, ConfigurationScope configurationScope, String key, Boolean isEncrypted, TValue newValue);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="userProfile">The user profile.</param>
        /// <param name="key">Name of the key.</param>
        /// <returns>
        /// </returns>
        TValue Get<TValue>(AppId applicationId, IUserProfile userProfile, String key);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="userProfile">The user profile.</param>
        /// <param name="key">Name of the key.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        TValue Get<TValue>(AppId applicationId, IUserProfile userProfile, String key, TValue defaultValue);

        /// <summary>
        /// Gets the group of values.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="userProfile">The user profile.</param>
        /// <param name="key">Name of the key.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        List<IApplicationConfiguration> GetGroupValues(AppId applicationId, IUserProfile userProfile, String key);
    }
}
