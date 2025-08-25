//-----------------------------------------------------------------------
// <copyright file="SystemConfigurationService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

using Microsoft.Extensions.Configuration;

using System;

namespace Foundation.Services.Application
{
    /// <inheritdoc cref="ISystemConfigurationService"/>
    [DependencyInjectionTransient]
    public class SystemConfigurationService : ServiceBase, ISystemConfigurationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        public SystemConfigurationService
        (
            ICore core
        ) :
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter(core);

            Core = core;

            LoggingHelpers.TraceCallReturn();
        }

        private ICore Core { get; }

        private String GetConnectionStringSettings(String dataConnectionName)
        {
            LoggingHelpers.TraceCallEnter(dataConnectionName);

            String? retVal = Core.ConfigurationManager.GetConnectionString(dataConnectionName);

            if (retVal == null)
            {
                String errorMessage = $"Cannot load Connection named '{dataConnectionName}'. Check to make sure the connection is defined in the Configuration File.";
                throw new ArgumentNullException(nameof(dataConnectionName), errorMessage);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ISystemConfigurationService.GetDataProviderName(String)"/>
        public String GetDataProviderName(String dataConnectionName)
        {
            LoggingHelpers.TraceCallEnter(dataConnectionName);

            String connectionStringSettings = GetConnectionStringSettings(dataConnectionName);

            String[] parts = connectionStringSettings.Split([';']);

            if (!parts[0].StartsWith("providerName", StringComparison.InvariantCultureIgnoreCase))
            {
                String errorMessage = $"Unable to retrieve Data Provider for '{dataConnectionName}'. Check to make sure the connection is defined in the Configuration File.";
                throw new InvalidOperationException(errorMessage);
            }

            // Provider name should be the first part of the string
            String retVal = parts[0];

            // We don't expect the Provider Name portion to have any white space
            retVal = retVal.Replace(" ", String.Empty);

            // String the tag 'ProviderName=' from the string and return
            retVal = retVal.Replace("ProviderName=", String.Empty, StringComparison.InvariantCultureIgnoreCase);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ISystemConfigurationService.GetConnectionString(String)"/>
        public String GetConnectionString(String dataConnectionName)
        {
            LoggingHelpers.TraceCallEnter(dataConnectionName);

            String connectionStringSettings = GetConnectionStringSettings(dataConnectionName);

            String dataProviderName = GetDataProviderName(dataConnectionName);

            // Need to remove the 'providerName=abc' from the connection string specified in the config
            String valueToMatch = $"providerName={dataProviderName};";
            Int32 index = connectionStringSettings.IndexOf(valueToMatch, StringComparison.InvariantCultureIgnoreCase);
            String retVal = (index < 0)
                ? connectionStringSettings
                : connectionStringSettings.Remove(index, valueToMatch.Length);

            // Remove leading/trailing spaces
            retVal = retVal.Trim();

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
