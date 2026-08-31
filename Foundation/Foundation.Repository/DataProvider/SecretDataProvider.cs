//-----------------------------------------------------------------------
// <copyright file="SecretDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Repository.DataProvider
{
    /// <summary>
    /// Defines the Secret Data Provider class
    /// </summary>
    /// <see cref="ISecretDataProvider" />
    /// <seealso cref="DataProvider" />
    [DependencyInjectionTransient]
    public class SecretDataProvider : DataProvider, ISecretDataProvider
    {
        public SecretDataProvider
        (
            ICore core,
            ISystemConfigurationService systemConfigurationService
        ) :
            base
            (
                core,
                systemConfigurationService,
                "Secret"
            )
        {
            LoggingHelpers.TraceCallEnter();

            // Does nothing

            LoggingHelpers.TraceCallReturn();
        }
    }
}
