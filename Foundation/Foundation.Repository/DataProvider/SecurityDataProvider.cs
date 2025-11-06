//-----------------------------------------------------------------------
// <copyright file="SecurityDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.DataAccess.Database;
using Foundation.Interfaces;

namespace Foundation.Repository.DataProvider
{
    /// <summary>
    /// Defines the Security Data Provider class
    /// </summary>
    /// <see cref="ISecurityDataProvider" />
    /// <seealso cref="FoundationDataAccess" />
    [DependencyInjectionTransient]
    public class SecurityDataProvider : FoundationDataAccess, ISecurityDataProvider
    {
        public SecurityDataProvider
        (
            ICore core,
            ISystemConfigurationService systemConfigurationService
        ) :
            base
            (
                core,
                systemConfigurationService,
                "Security"
            )
        {
        }

        /// <inheritdoc cref="IDataProvider.ConnectionName"/>
        public String ConnectionName => "Security";
    }
}
