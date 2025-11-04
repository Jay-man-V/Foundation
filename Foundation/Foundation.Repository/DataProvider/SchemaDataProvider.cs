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
    public class SchemaDataProvider : ISchemaDataProvider
    {
        /// <inheritdoc cref="IDataProvider.ConnectionName"/>
        public String ConnectionName => "Schema";
    }
}
