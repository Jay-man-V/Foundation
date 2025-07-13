//-----------------------------------------------------------------------
// <copyright file="RunTimeEnvironmentSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <inheritdoc cref="IRunTimeEnvironmentSettings"/>
    [DependencyInjectionTransient]
    public class RunTimeEnvironmentSettings : IRunTimeEnvironmentSettings
    {
        /// <inheritdoc cref="IRunTimeEnvironmentSettings.StandardCountryCode"/>
        public String[] Arguments => Environment.GetCommandLineArgs();

        /// <inheritdoc cref="IRunTimeEnvironmentSettings.StandardCountryCode"/>
        public String StandardCountryCode => "GB";

        /// <inheritdoc cref="IRunTimeEnvironmentSettings.UserName"/>
        public String UserName => Environment.UserName;

        /// <inheritdoc cref="IRunTimeEnvironmentSettings.UserDomainName"/>
        public String UserDomainName => Environment.UserDomainName;

        /// <inheritdoc cref="IRunTimeEnvironmentSettings.UserLogonName"/>
        public String UserLogonName => $@"{UserDomainName}\{UserName}";

        /// <inheritdoc cref="IRunTimeEnvironmentSettings.MachineName"/>
        public String MachineName => Environment.MachineName;
    }
}