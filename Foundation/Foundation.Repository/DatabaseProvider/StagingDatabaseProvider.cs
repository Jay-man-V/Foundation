//-----------------------------------------------------------------------
// <copyright file="StagingDatabaseProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using Foundation.Interfaces;

namespace Foundation.Repository
{
    /// <summary>
    /// Defines the Staging Database Provider class
    /// </summary>
    /// <see cref="IStagingDatabaseProvider" />
    [DependencyInjectionTransient]
    public class StagingDatabaseProvider : IStagingDatabaseProvider
    {
        /// <inheritdoc cref="IDatabaseProvider.ConnectionName"/>
        public String ConnectionName => "Staging";
    }
}
