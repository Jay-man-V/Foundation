//-----------------------------------------------------------------------
// <copyright file="CoreDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Repository.DataProvider
{
    /// <summary>
    /// Defines the Core Data Provider class
    /// </summary>
    /// <see cref="ICoreDataProvider" />
    public class CoreDataProvider : ICoreDataProvider
    {
        /// <inheritdoc cref="IDataProvider.ConnectionName"/>
        public String ConnectionName => "Core";
    }
}
