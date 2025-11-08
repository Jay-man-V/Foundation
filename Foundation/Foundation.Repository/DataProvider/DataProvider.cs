//-----------------------------------------------------------------------
// <copyright file="DataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Repository.DataProvider
{
    /// <summary>
    /// Defines the Data Provider class
    /// </summary>
    /// <see cref="IDataProvider" />
    //[DependencyInjectionIgnore]
    public abstract class DataProvider : IDataProvider
    {
        protected DataProvider
        (
            ICore core,
            ISystemConfigurationService systemConfigurationService,
            String connectionName
        ) :
            base
            (
                //core,
                //systemConfigurationService,
                //connectionName
            )
        {
            ConnectionName = connectionName;
        }

        /// <inheritdoc cref="IDataProvider.ConnectionName"/>
        public String ConnectionName { get; }
    }
}
