//-----------------------------------------------------------------------
// <copyright file="LogDatabaseProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Repository
{
    /// <summary>
    /// Defines the Log Database Provider class
    /// </summary>
    /// <see cref="LogDatabaseProvider" />
    [DependencyInjectionTransient]
    public class LogDatabaseProvider : ILogDatabaseProvider
    {
        /// <inheritdoc cref="IDatabaseProvider.ConnectionName"/>
        public String ConnectionName => "Log";
    }
}
