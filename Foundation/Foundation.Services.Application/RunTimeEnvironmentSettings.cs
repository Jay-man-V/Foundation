//-----------------------------------------------------------------------
// <copyright file="RunTimeEnvironmentSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Security.Principal;

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

        /// <inheritdoc cref="IRunTimeEnvironmentSettings.UserFullLogonName"/>
        public String UserFullLogonName => $@"{UserDomainName}\{UserName}";

        /// <inheritdoc cref="IRunTimeEnvironmentSettings.MachineName"/>
        public String MachineName => Environment.MachineName;

        /// <inheritdoc cref="IRunTimeEnvironmentSettings.TraceSwitch"/>
        public TraceSwitch TraceSwitch => new TraceSwitch("TraceLevelSwitch", String.Empty);

        public String SecurityIdentifier
        {
            get
            {
                //// Set up domain context
                //PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
                //// Find user
                //UserPrincipal user = UserPrincipal.FindByIdentity(ctx, "<Username>");

                WindowsIdentity identity = WindowsIdentity.GetCurrent();

                return identity.User.Value;
            }
        }
    }
}
