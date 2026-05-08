//-----------------------------------------------------------------------
// <copyright file="IApplicationConfigurationService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Provides methods and properties for accessing and managing application configuration data, including retrieving
    /// and storing configuration values for specific applications and user profiles.
    /// </summary>
    /// <remarks>
    /// This interface defines the contract for services that handle application configuration
    /// storage and retrieval. Implementations may support features such as value encryption, configuration scoping, and
    /// grouping of related configuration entries. Thread safety and persistence guarantees depend on the specific
    /// implementation.
    /// </remarks>
    public interface IApplicationConfigurationService
    {
        /// <summary>
        /// Gets the file system path to the directory where user-specific data is stored.
        /// </summary>
        String UserDataPath { get; }

        /// <summary>
        /// Gets the file system path to the application's system data directory.
        /// </summary>
        String SystemDataPath { get; }

        /// <summary>
        /// Sets the value for the specified configuration key within the given application, user profile, and
        /// configuration scope.
        /// </summary>
        /// <typeparam name="TValue">The type of the value to set for the configuration key.</typeparam>
        /// <param name="applicationId">The identifier of the application for which the configuration value is being set.</param>
        /// <param name="userProfile">The user profile associated with the configuration value.</param>
        /// <param name="configurationScope">The scope in which the configuration value applies, such as user or application level.</param>
        /// <param name="isEncrypted">true if the value should be stored in encrypted form; otherwise, false.</param>
        /// <param name="key">The key that identifies the configuration setting to update.</param>
        /// <param name="newValue">The new value to assign to the configuration key.</param>
        void SetValue<TValue>(AppId applicationId, IUserProfile userProfile, ConfigurationScope configurationScope, Boolean isEncrypted, String key, TValue newValue);
        
        /// <summary>
        /// Retrieves the value associated with the specified key for the given application and user profile.
        /// </summary>
        /// <typeparam name="TValue">The type of the value to retrieve.</typeparam>
        /// <param name="applicationId">The identifier of the application for which the value is requested.</param>
        /// <param name="userProfile">The user profile context used to locate the value.</param>
        /// <param name="key">The key that identifies the value to retrieve. Cannot be null or empty.</param>
        /// <returns>
        /// The value associated with the specified key, cast to the specified type. The behavior if the key does not
        /// exist depends on the implementation.
        /// </returns>
        TValue Get<TValue>(AppId applicationId, IUserProfile userProfile, String key);

        /// <summary>
        /// Retrieves the value associated with the specified key for the given application and user profile, or returns
        /// a default value if the key does not exist.
        /// </summary>
        /// <typeparam name="TValue">The type of the value to retrieve.</typeparam>
        /// <param name="applicationId">The identifier of the application for which the value is retrieved.</param>
        /// <param name="userProfile">The user profile context used to scope the retrieval of the value.</param>
        /// <param name="key">The key that identifies the value to retrieve. Cannot be null or empty.</param>
        /// <param name="defaultValue">The value to return if the specified key does not exist.</param>
        /// <returns>
        /// The value associated with the specified key if found; otherwise, the specified default value.
        /// </returns>
        TValue Get<TValue>(AppId applicationId, IUserProfile userProfile, String key, TValue defaultValue);

        /// <summary>
        /// Retrieves a list of application configuration values associated with the specified group key for a given
        /// application and user profile.
        /// </summary>
        /// <param name="applicationId">The identifier of the application for which to retrieve configuration values.</param>
        /// <param name="userProfile">The user profile context used to determine which configuration values to return. Cannot be null.</param>
        /// <param name="key">The group key that identifies the set of configuration values to retrieve. Cannot be null or empty.</param>
        /// <returns>
        /// A list of application configuration values matching the specified group key. The list is empty if no values are found.
        /// </returns>
        List<IApplicationConfiguration> GetGroupValues(AppId applicationId, IUserProfile userProfile, String key);
    }
}
