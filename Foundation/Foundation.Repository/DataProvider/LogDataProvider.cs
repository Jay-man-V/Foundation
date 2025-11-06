//-----------------------------------------------------------------------
// <copyright file="LogDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.DataAccess.Database;
using Foundation.Interfaces;

namespace Foundation.Repository.DataProvider
{
    /// <summary>
    /// Defines the Log Data Provider class
    /// </summary>
    /// <see cref="LogDataProvider" />
    /// <seealso cref="FoundationDataAccess" />
    [DependencyInjectionTransient]
    public class LogDataProvider : FoundationDataAccess, ILogDataProvider
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

        /// <inheritdoc cref="IDataProvider.ConnectionName"/>
        public String ConnectionName => "Log";
    }
}
