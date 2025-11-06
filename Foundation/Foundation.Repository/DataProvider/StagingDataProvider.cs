//-----------------------------------------------------------------------
// <copyright file="StagingDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.DataAccess.Database;
using Foundation.Interfaces;

namespace Foundation.Repository.DataProvider
{
    /// <summary>
    /// Defines the Staging Data Provider class
    /// </summary>
    /// <see cref="IStagingDataProvider" />
    /// <seealso cref="FoundationDataAccess" />
    [DependencyInjectionTransient]
    public class StagingDataProvider : FoundationDataAccess, IStagingDataProvider
    {
        public StagingDataProvider
        (
            ICore core,
            ISystemConfigurationService systemConfigurationService
        ) :
            base
            (
                core,
                systemConfigurationService,
                "Staging"
            )
        {
        }

        /// <inheritdoc cref="IDataProvider.ConnectionName"/>
        public String ConnectionName => "Staging";
    }
}
