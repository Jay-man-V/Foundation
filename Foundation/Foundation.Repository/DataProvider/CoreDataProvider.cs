//-----------------------------------------------------------------------
// <copyright file="CoreDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Repository.DataProvider
{
    /// <summary>
    /// Defines the Core Data Provider class
    /// </summary>
    /// <see cref="ICoreDataProvider" />
    /// <seealso cref="DataProvider" />
    [DependencyInjectionTransient]
    public class CoreDataProvider : DataProvider, ICoreDataProvider
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
    }
}
