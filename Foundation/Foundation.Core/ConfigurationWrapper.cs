//-----------------------------------------------------------------------
// <copyright file="ConfigurationWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.Extensions.Configuration;

using Foundation.Interfaces;

namespace Foundation.Core
{
    /// <summary>
    /// Details of the current user
    /// </summary>
    public class ConfigurationWrapper : IConfigurationWrapper
    {
        internal ConfigurationWrapper(ConfigurationManager configurationManager)
        {
            ConfigurationManager = configurationManager;
        }

        private ConfigurationManager ConfigurationManager { get; }

        /// <inheritdoc cref="IConfigurationWrapper.GetValue{T}(String)"/>
        public T? GetValue<T>(String key)
        {
            T? retVal = ConfigurationManager.GetValue<T>(key);

            return retVal;
        }

        /// <inheritdoc cref="IConfigurationWrapper.GetConnectionString(String)"/>
        public String? GetConnectionString(String name)
        {
            String? retVal = ConfigurationManager.GetConnectionString(name);

            return retVal;
        }
    }
}