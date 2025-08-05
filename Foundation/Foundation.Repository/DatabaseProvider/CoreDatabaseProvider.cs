//-----------------------------------------------------------------------
// <copyright file="CoreDatabaseProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Repository
{
    /// <summary>
    /// Defines the Core Database Provider class
    /// </summary>
    /// <see cref="ICoreDatabaseProvider" />
    [DependencyInjectionTransient]
    public class CoreDatabaseProvider : ICoreDatabaseProvider
    {
        /// <inheritdoc cref="IDatabaseProvider.ConnectionName"/>
        public String ConnectionName => "Core";
    }
}
