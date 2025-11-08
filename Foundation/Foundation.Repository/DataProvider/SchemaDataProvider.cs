//-----------------------------------------------------------------------
// <copyright file="SchemaDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Repository.DataProvider
{
    /// <summary>
    /// Defines the Schema Data Provider class
    /// </summary>
    /// <see cref="ISchemaDataProvider" />
    /// <seealso cref="DataProvider" />
    [DependencyInjectionTransient]
    public class SchemaDataProvider : DataProvider, ISchemaDataProvider
    {
        public SchemaDataProvider
        (
            ICore core,
            ISystemConfigurationService systemConfigurationService
        ) :
            base
            (
                core,
                systemConfigurationService,
                "Schema"
            )
        {
        }
    }
}
