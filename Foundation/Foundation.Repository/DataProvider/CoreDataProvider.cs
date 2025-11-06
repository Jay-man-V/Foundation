//-----------------------------------------------------------------------
// <copyright file="CoreDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.DataAccess.Database;
using Foundation.Interfaces;

namespace Foundation.Repository.DataProvider
{
    /// <summary>
    /// Defines the Core Data Provider class
    /// </summary>
    /// <see cref="ICoreDataProvider" />
    /// <seealso cref="FoundationDataAccess" />
    [DependencyInjectionTransient]
    public class CoreDataProvider : FoundationDataAccess, ICoreDataProvider
    {
        public CoreDataProvider
        (
            ICore core,
            ISystemConfigurationService systemConfigurationService
        ) :
            base
            (
                core,
                systemConfigurationService,
                "Core"
            )
        {
        }

        /// <inheritdoc cref="IDataProvider.ConnectionName"/>
        public String ConnectionName => "Core";
    }
}
