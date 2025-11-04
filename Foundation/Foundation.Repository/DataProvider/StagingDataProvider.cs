//-----------------------------------------------------------------------
// <copyright file="StagingDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Repository.DataProvider
{
    /// <summary>
    /// Defines the Staging Data Provider class
    /// </summary>
    /// <see cref="IStagingDataProvider" />
    public class StagingDataProvider : IStagingDataProvider
    {
        /// <inheritdoc cref="IDataProvider.ConnectionName"/>
        public String ConnectionName => "Staging";
    }
}
