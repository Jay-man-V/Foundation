//-----------------------------------------------------------------------
// <copyright file="IApplicationConfigurationRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Application Configuration Data Access interface
    /// </summary>
    public interface IApplicationConfigurationRepository : IFoundationModelRepository<IApplicationConfiguration>
    {
        /// <summary>
        /// Saves the <paramref name="newValue"/> to the repository and converting to a <see cref="String"/> where required
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="userProfile">The user profile.</param>
        /// <param name="configurationScope">The configuration scope.</param>
        /// <param name="key">The key.</param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        void SetValue(AppId applicationId, IUserProfile userProfile, ConfigurationScope configurationScope, String key, String newValue);

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="userProfile">The user profile.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        IApplicationConfiguration? Get(AppId applicationId, IUserProfile userProfile, String key);

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
