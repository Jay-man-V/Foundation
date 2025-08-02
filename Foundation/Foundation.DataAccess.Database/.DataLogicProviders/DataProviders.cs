//-----------------------------------------------------------------------
// <copyright file="DataProviders.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.DataAccess.Database
{
    /// <summary>
    /// Contains a list of supported Data providers
    /// </summary>
    [DependencyInjectionTransient]
    internal static class DataProviders
    {
        /// <summary>
        /// System.Data.SqlClient
        /// </summary>
        public const String MsSqlClient = "System.Data.SqlClient";

        /// <summary>
        /// MySql.Data.MySqlClient
        /// </summary>
        public const String MySqlClient = "MySql.Data.MySqlClient";

        /// <summary>
        /// System.Data.OracleClient
        /// </summary>
        public const String OracleClient = "System.Data.OracleClient";
    }
}