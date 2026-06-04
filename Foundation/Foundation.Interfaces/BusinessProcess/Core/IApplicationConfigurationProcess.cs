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
        List<IApplicationConfiguration> ApplyFilter(List<IApplicationConfiguration> applicationConfigurations, IConfigurationScope? configurationScope, IApplication? application, IUserProfile? userProfile);

        /// <summary>
        /// Gets the <see cref="IApplicationConfiguration"/> for the given <paramref name="key"/>
        /// </summary>
        /// <param name="key">The key of the configuration to retrieve</param>
        /// <returns>The matching <see cref="IApplicationConfiguration"/>, or null if not found</returns>
        IApplicationConfiguration? Get(String key);
    }
}
