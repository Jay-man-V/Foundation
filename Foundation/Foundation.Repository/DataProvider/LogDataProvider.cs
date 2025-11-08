//-----------------------------------------------------------------------
// <copyright file="LogDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Repository.DataProvider
{
    /// <summary>
    /// Defines the Log Data Provider class
    /// </summary>
    /// <see cref="ILogDataProvider" />
    /// <seealso cref="DataProvider" />
    [DependencyInjectionTransient]
    public class LogDataProvider : DataProvider, ILogDataProvider
    {
        public LogDataProvider
        (
            ICore core,
            ISystemConfigurationService systemConfigurationService
        ) :
            base
            (
                core,
                systemConfigurationService,
                "Log"
            )
        {
        }
    }
}
