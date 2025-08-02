//-----------------------------------------------------------------------
// <copyright file="SchemaDatabaseProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using Foundation.Interfaces;

namespace Foundation.Repository
{
    /// <summary>
    /// Defines the Schema Database Provider class
    /// </summary>
    /// <see cref="ISchemaDatabaseProvider" />
    [DependencyInjectionTransient]
    public class SchemaDatabaseProvider : ISchemaDatabaseProvider
    {
        /// <inheritdoc cref="IDatabaseProvider.ConnectionName"/>
        public String ConnectionName => "Schema";
    }
}
