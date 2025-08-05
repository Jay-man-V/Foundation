//-----------------------------------------------------------------------
// <copyright file="IApplicationConfigurationProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Application Configuration process
    /// </summary>
    public interface IApplicationConfigurationProcess : ICommonBusinessProcess<IApplicationConfiguration>
    {
        /// <summary>
        /// Applies the given filter criteria (<paramref name="configurationScope"/> and <paramref name="application"/>) to the supplied
        /// <paramref name="applicationConfigurations"/> and returns the result
        /// </summary>
        /// <param name="applicationConfigurations">The full list of <see cref="IApplication"/></param>
        /// <param name="configurationScope">The <see cref="IConfigurationScope"/> to filter by</param>
        /// <param name="application">The <see cref="IApplication"/> to filter by</param>
        /// <param name="userProfile">The <see cref="IUserProfile"/> to filter by</param>
        /// <returns>Filtered <see cref="List{TValue}"/></returns>
        List<IApplicationConfiguration> ApplyFilter(List<IApplicationConfiguration> applicationConfigurations, IConfigurationScope configurationScope, IApplication application, IUserProfile userProfile);

        /// <summary>
        /// Saves the <paramref name="newValue"/> to the repository and converting to a <see cref="String"/> where required
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="userProfile">The user profile.</param>
        /// <param name="configurationScope">The configuration scope.</param>
        /// <param name="key">Name of the key.</param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        void SetValue<TValue>(AppId applicationId, IUserProfile userProfile, ConfigurationScope configurationScope, String key, TValue newValue);

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
