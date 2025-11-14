//-----------------------------------------------------------------------
// <copyright file="MySqlDataLogProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data.Common;

using MySql.Data.MySqlClient;

using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.DataAccess.Database.DataLogicProviders
{
    /// <summary>
    /// The My Sql Server Database Data Logic Provider
    /// </summary>
    [DependencyInjectionTransient]
    internal class MySqlDataLogicProvider : IDataLogicProvider
    {
        public MySqlDataLogicProvider()
        {
            foreach (String factoryName in DataProviders.MySqlClient)
            {
                Boolean alreadyExists = DbProviderFactories.TryGetFactory(factoryName, out _);
                if (!alreadyExists)
                {
                    DbProviderFactories.RegisterFactory(factoryName, MySqlClientFactory.Instance);
                }
            }
        }

        /// <inheritdoc cref="IDataLogicProvider.ValidToDateString" />
        public String ValidToDateString => ApplicationDefaultValues.DefaultValidToDateTime.ToString(Formats.DotNet.DateTimeMilliseconds);

        /// <inheritdoc cref="IDataLogicProvider.DatabaseProviderName" />
        public String DatabaseProviderName => DataProviders.MySqlClient[0];

        /// <inheritdoc cref="IDataLogicProvider.DatabaseParameterPrefix" />
        public String DatabaseParameterPrefix => "@";

        /// <inheritdoc cref="IDataLogicProvider.IdentityOfLastInsertFunction"/>
        public String IdentityOfLastInsertFunction => "LAST_INSERT_ID()";

        /// <inheritdoc cref="IDataLogicProvider.IdentityOfNewRowSql" />
        public String IdentityOfNewRowSql => "SELECT Id, RowVersion FROM {0} WHERE Id = " + IdentityOfLastInsertFunction;

        /// <inheritdoc cref="IDataLogicProvider.TimestampOfUpdatedRowSql" />
        public String TimestampOfUpdatedRowSql => "SELECT RowVersion FROM {0} WHERE Id = @id";

        /// <inheritdoc cref="IDataLogicProvider.CurrentDateTimeFunction" />
        public String CurrentDateTimeFunction => "NOW(3)";

        /// <inheritdoc cref="IDataLogicProvider.UniqueIdFunction"/>
        public String UniqueIdFunction => "(SELECT uuid())";

        /// <inheritdoc cref="IDataLogicProvider.MapDbTypeToDotNetType" />
        public Type MapDbTypeToDotNetType(String dbType)
        {
            Type retVal;

            switch (dbType.ToLower())
            {
                case "bit": retVal = typeof(Boolean); break;
                case "datetime": retVal = typeof(DateTime); break;
                case "int": retVal = typeof(Int32); break;
                case "decimal": retVal = typeof(Decimal); break;
                case "nchar": retVal = typeof(String); break;
                case "nvarchar": retVal = typeof(String); break;
                case "time": retVal = typeof(TimeSpan); break;
                case "timestamp": retVal = typeof(Byte[]); break;
                case "tinyint": retVal = typeof(Int32); break;
                case "varbinary": retVal = typeof(Byte[]); break;
                default:
                    String errorMessage = $"MySql database type of '{dbType}' has not been mapped to a .Net type";
                    throw new ArgumentException(errorMessage);
            }

            return retVal;
        }

        /// <inheritdoc cref="IDataLogicProvider.GetRowVersionValue" />
        public Object GetRowVersionValue()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IDataLogicProvider.GetDateComparisonSql(String, String, String)" />
        public String GetDateComparisonSql(String columnOrParameter1, String columnOrParameter2, String comparisonResult)
        {
            String retVal = $"DATEDIFF(D, {columnOrParameter1}, {columnOrParameter2}) {comparisonResult}";

            return retVal;
        }

        /// <inheritdoc cref="IDataLogicProvider.GetMinuteComparisonSql(String, String, String)" />
        public String GetMinuteComparisonSql(String columnOrParameter1, String columnOrParameter2, String comparisonResult)
        {
            String retVal = $"TIMESTAMPDIFF(MINUTE, {columnOrParameter1}, {columnOrParameter2}) {comparisonResult}";

            return retVal;
        }
    }
}