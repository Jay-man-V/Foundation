//-----------------------------------------------------------------------
// <copyright file="SecurityDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Repository.DataProvider
{
    /// <summary>
    /// Defines the Security Data Provider class
    /// </summary>
    /// <see cref="ISecurityDataProvider" />
    /// <seealso cref="DataProvider" />
    [DependencyInjectionTransient]
    public class SecurityDataProvider : DataProvider, ISecurityDataProvider
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
    }
}
