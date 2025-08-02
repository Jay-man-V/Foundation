//-----------------------------------------------------------------------
// <copyright file="SystemConfigurationService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Configuration;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <inheritdoc cref="ISystemConfigurationService"/>
    [DependencyInjectionTransient]
    public class SystemConfigurationService : ISystemConfigurationService
    {
        private ConnectionStringSettings GetConfigurationStringSettings(String dataConnectionName)
        {
            LoggingHelpers.TraceCallEnter(dataConnectionName);

            ConnectionStringSettings retVal = ConfigurationManager.ConnectionStrings[dataConnectionName];

            //if (retVal == null)
            //{
            //    String errorMessage = $"Cannot load Connection named '{dataConnectionName}'. Check to make sure the connection is defined in the Configuration File '{AppDomain.CurrentDomain.SetupInformation.ConfigurationFile}'.";

            //    throw new ArgumentNullException(nameof(dataConnectionName), errorMessage);
            //}

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ISystemConfigurationService.GetDataProviderName(String)"/>
        public String GetDataProviderName(String dataConnectionName)
        {
            LoggingHelpers.TraceCallEnter(dataConnectionName);

            ConnectionStringSettings connectionStringSettings = GetConfigurationStringSettings(dataConnectionName);

            String retVal = connectionStringSettings.ProviderName;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ISystemConfigurationService.GetConnectionString(String)"/>
        public String GetConnectionString(String dataConnectionName)
        {
            LoggingHelpers.TraceCallEnter(dataConnectionName);

            ConnectionStringSettings connectionStringSettings = GetConfigurationStringSettings(dataConnectionName);

            String retVal = connectionStringSettings.ConnectionString;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
