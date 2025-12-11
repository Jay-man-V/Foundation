//-----------------------------------------------------------------------
// <copyright file="MsSqlDataLogProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data.Common;

using Foundation.Interfaces;

namespace Foundation.DataAccess.Database.DataLogicProviders
{
    /// <summary>
    /// The Microsoft Sql Server Database Data Logic Provider
    /// </summary>
    [DependencyInjectionTransient]
    internal class MsSqlDataLogicProvider : DataLogicProvider, IDataLogicProvider
    {
        public MsSqlDataLogicProvider
        (
            ICore core
        ) :
            base
            (
                core,
                DataProviders.MsSqlClient
            )
        {
            foreach (String factoryName in DatabaseProviders)
            {
                Boolean alreadyExists = DbProviderFactories.TryGetFactory(factoryName, out _);
                if (!alreadyExists)
                {
                    String assemblyName = "Microsoft.Data.SqlClient, Version=6.0.0.0, Culture=neutral, PublicKeyToken=23ec7fc2d6eaa4a5";
                    String typeName = "Microsoft.Data.SqlClient.SqlClientFactory";

                    SetupFactory(factoryName, assemblyName, typeName);
                }
            }
        }

        /// <inheritdoc cref="IDataLogicProvider.DatabaseParameterPrefix" />
        public override String DatabaseParameterPrefix => "@";

        /// <inheritdoc cref="IDataLogicProvider.IdentityOfLastInsertFunction"/>
        public override String IdentityOfLastInsertFunction => "(SELECT SCOPE_IDENTITY())";

        /// <inheritdoc cref="IDataLogicProvider.IdentityOfNewRowSql" />
        public override String IdentityOfNewRowSql => "SELECT Timestamp, Id FROM {0} WHERE Id = " + IdentityOfLastInsertFunction;

        /// <inheritdoc cref="IDataLogicProvider.TimestampOfUpdatedRowSql" />
        public override String TimestampOfUpdatedRowSql => "SELECT Timestamp, @@ROWCOUNT [ROWCOUNT] FROM {0} WHERE Id = {1}";

        /// <inheritdoc cref="IDataLogicProvider.CurrentDateTimeFunction" />
        public override String CurrentDateTimeFunction => "GETDATE()";

        /// <inheritdoc cref="IDataLogicProvider.UniqueIdFunction"/>
        public override String UniqueIdFunction => "NEWID()";

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
                    String errorMessage = $"MsSql database type of '{dbType}' has not been mapped to a .Net type";
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
            String retVal = $"DATEDIFF(MI, {columnOrParameter1}, {columnOrParameter2}) {comparisonResult}";

            return retVal;
        }
    }
}
