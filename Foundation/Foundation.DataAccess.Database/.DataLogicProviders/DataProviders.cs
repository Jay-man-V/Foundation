//-----------------------------------------------------------------------
// <copyright file="DataProviders.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.DataAccess.Database.DataLogicProviders
{
    /// <summary>
    /// Contains a list of supported Data providers
    /// </summary>
    [DependencyInjectionTransient]
    internal static class DataProviders
    {
        /// <summary>
        /// Microsoft.Data.SqlClient, System.Data.SqlClient
        /// </summary>
        public static String[] MsSqlClient => ["Microsoft.Data.SqlClient", "System.Data.SqlClient"];

        /// <summary>
        /// MySql.Data.MySqlClient
        /// </summary>
        public static String[] MySqlClient => ["MySql.Data.MySqlClient"];

        /// <summary>
        /// Oracle.DataAccess.Client
        /// </summary>
        public static String[] OracleClient => ["Oracle.DataAccess.Client"];

        /// <summary>
        /// Foundation.FileData.Client
        /// </summary>
        public static String[] FoundationFileClient => ["Foundation.FileData.Client"];

        public static IDataLogicProvider GetDataProvider(ICore core, String databaseProviderName)
        {
            IDataLogicProvider retVal;

            if (DataProviders.MsSqlClient.Contains(databaseProviderName))
            {
                retVal = new MsSqlDataLogicProvider(core);
            }
            else if (DataProviders.MySqlClient.Contains(databaseProviderName))
            {
                retVal = new MySqlDataLogicProvider(core);
            }
            else if (DataProviders.OracleClient.Contains(databaseProviderName))
            {
                retVal = new OracleDataLogicProvider(core);
            }
            else if (DataProviders.FoundationFileClient.Contains(databaseProviderName))
            {
                retVal = new FoundationFileDataProvider(core);
            }
            else
            {
                String message = $"The Data Provider '{databaseProviderName}' is unknown and not supported";
                throw new NotSupportedException(message);
            }

            return retVal;
        }
    }
}