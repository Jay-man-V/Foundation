//-----------------------------------------------------------------------
// <copyright file="LogDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Repository.DataProvider
{
    /// <summary>
    /// Defines the Log Data Provider class
    /// </summary>
    /// <see cref="LogDataProvider" />
    public class LogDataProvider : ILogDataProvider
    {
        /// <inheritdoc cref="IDataProvider.ConnectionName"/>
        public String ConnectionName => "Log";
    }
}
