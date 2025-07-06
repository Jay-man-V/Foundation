//-----------------------------------------------------------------------
// <copyright file="ISystemConfigurationService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISystemConfigurationService
    {
        /// <summary>
        /// Gets the name of the data provider of the database connection.
        /// </summary>
        /// <param name="dataConnectionName">Name of the data connection.</param>
        /// <returns></returns>
        String GetDataProviderName(String dataConnectionName);

        /// <summary>
        /// Retrieves the Connection String from the configuration repository
        /// </summary>
        /// <param name="dataConnectionName">Name of the data connection.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">dataConnectionName</exception>
        String GetConnectionString(String dataConnectionName);
    }
}
