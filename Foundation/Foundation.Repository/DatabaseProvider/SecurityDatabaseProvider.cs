//-----------------------------------------------------------------------
// <copyright file="SecurityDatabaseProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using Foundation.Interfaces;

namespace Foundation.Repository
{
    /// <summary>
    /// Defines the Security Database Provider class
    /// </summary>
    /// <see cref="ISecurityDatabaseProvider" />
    [DependencyInjectionTransient]
    public class SecurityDatabaseProvider : ISecurityDatabaseProvider
    {
        /// <inheritdoc cref="IDatabaseProvider.ConnectionName"/>
        public String ConnectionName => "Security";
    }
}
