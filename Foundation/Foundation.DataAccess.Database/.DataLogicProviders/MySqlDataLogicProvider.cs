//-----------------------------------------------------------------------
// <copyright file="MySqlDataLogProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data.Common;
using System.Reflection;

using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.DataAccess.Database.DataLogicProviders
{
    /// <summary>
    /// The My Sql Server Database Data Logic Provider
    /// </summary>
    [DependencyInjectionTransient]
    internal class MySqlDataLogicProvider : DataLogicProvider, IDataLogicProvider
    {
        public MySqlDataLogicProvider
        (
            ICore core
        ) :
            base
            (
                core,
                DataProviders.MySqlClient
            )
        {
            foreach (String factoryName in DatabaseProviders)
            {
                Boolean alreadyExists = DbProviderFactories.TryGetFactory(factoryName, out _);
                if (!alreadyExists)
                {
                    String assemblyName = "MySql.Data, Version=9.5.0.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d";
                    String typeName = "MySql.Data.MySqlClient.MySqlClientFactory";

                    SetupFactory(factoryName, assemblyName, typeName);
                }
            }
        }

        /// <inheritdoc cref="IDataLogicProvider.DatabaseParameterPrefix" />
        public override String DatabaseParameterPrefix => "@";

        /// <inheritdoc cref="IDataLogicProvider.IdentityOfLastInsertFunction"/>
        public override String IdentityOfLastInsertFunction => "LAST_INSERT_ID()";

        /// <inheritdoc cref="IDataLogicProvider.IdentityOfNewRowSql" />
        public override String IdentityOfNewRowSql => "SELECT Id, RowVersion FROM {0} WHERE Id = " + IdentityOfLastInsertFunction;

        /// <inheritdoc cref="IDataLogicProvider.TimestampOfUpdatedRowSql" />
        public override String TimestampOfUpdatedRowSql => "SELECT RowVersion FROM {0} WHERE Id = @id";

        /// <inheritdoc cref="IDataLogicProvider.CurrentDateTimeFunction" />
        public override String CurrentDateTimeFunction => "NOW(3)";

        /// <inheritdoc cref="IDataLogicProvider.UniqueIdFunction"/>
        public override String UniqueIdFunction => "(SELECT uuid())";

        /// <inheritdoc cref="IDataLogicProvider.MapDbTypeToDotNetType" />
        public override Type MapDbTypeToDotNetType(String dbType)
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
        public override Object GetRowVersionValue()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IDataLogicProvider.GetDateComparisonSql(String, String, String)" />
        public override String GetDateComparisonSql(String columnOrParameter1, String columnOrParameter2, String comparisonResult)
        {
            String retVal = $"DATEDIFF(D, {columnOrParameter1}, {columnOrParameter2}) {comparisonResult}";

            return retVal;
        }

        /// <inheritdoc cref="IDataLogicProvider.GetMinuteComparisonSql(String, String, String)" />
        public override String GetMinuteComparisonSql(String columnOrParameter1, String columnOrParameter2, String comparisonResult)
        {
            String retVal = $"TIMESTAMPDIFF(MINUTE, {columnOrParameter1}, {columnOrParameter2}) {comparisonResult}";

            return retVal;
        }
    }
}